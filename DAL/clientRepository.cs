using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class clientRepository
    {
        DBHelper DB = new DBHelper();
        List<DBCommand> commands = new List<DBCommand>();

        public void RegisterOrUpdateClientDetails(clientDTO currentClient)
        {
            clientDTO client = new clientDTO();
            DBCommand cmd = new DBCommand("select lan_mac from client where lan_mac=@lanMAC");
            
                cmd.Parameters.AddWithValue("@lanMAC", currentClient.lanMAC);
                DataTable dt = DB.FillDataTable(cmd);
            if (dt.Rows.Count == 0)
            {
                string id = DB.ExecuteScalar(new DBCommand { SQLQuery = "select nextval('client_id_seq')" }).ToString();
                cmd = new DBCommand("insert into client (id,name,lan_mac,wlan_mac,pc_description,created_at) values (@Id,@name,@lanMAC,@wlanMAC,@PCdesc,now()::timestamp(0))");
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@lanMAC", currentClient.lanMAC);
                cmd.Parameters.AddWithValue("@wlanMAC", currentClient.wlanMAC);
                cmd.Parameters.AddWithValue("@name", currentClient.name);
                cmd.Parameters.AddWithValue("@PCdesc", currentClient.pcDescription);
                commands.Add(cmd);
                DBCommand insert = new DBCommand("insert into client_build (client,build) values (" + id + ", 0)");
                commands.Add(insert);
            }
            DBCommand updateCMD = new DBCommand("update client set name=@name,pc_description=@PCdesc,current_ip=@currIP,current_mac=@currMAC where lan_mac=@lanMAC");
            updateCMD.Parameters.AddWithValue("@lanMAC", currentClient.lanMAC);
            updateCMD.Parameters.AddWithValue("@currMAC", currentClient.currentMAC);
            updateCMD.Parameters.AddWithValue("@name", currentClient.name);
            updateCMD.Parameters.AddWithValue("@PCdesc", currentClient.pcDescription);
            updateCMD.Parameters.AddWithValue("@currIP", currentClient.ip);
            commands.Add(updateCMD);
            var result = DB.ExecuteNonQueriesInTransaction(commands);
        }

        public List<moduleDTO> GetAllModulesAllowedByClient(searchParam searchParam)
        {
            List<moduleDTO> Modules = new List<moduleDTO>();
            using (DBCommand dbCommand = new DBCommand("select dm.mdi_code,dm.name from client_build cb " +
                                                        "left join desktop_mdis dm on dm.id = cb.build " +
                                                        "where cb.client = @client"))
            {
                dbCommand.Parameters.AddWithValue("@client", searchParam.clientId);
                DataTable dt = DB.FillDataTable(dbCommand);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        moduleDTO row = new moduleDTO();
                        row.ModuleCode = dr["mdi_code"].ToString();
                        row.ModuleName = dr["name"].ToString();
                        Modules.Add(row);
                    }
                }
            }
            return Modules;
        }

        public List<clientDTO> GetAllClientDataByParam(searchParam param)
        {
            List<clientDTO> Modules = new List<clientDTO>();
            StringBuilder sb = new StringBuilder();
            DBCommand dbCommand = new DBCommand();
            sb.Append("select c.id,c.name,dm.name as moduleName,c.current_ip,cb.current_build_version,c.current_mac,c.lan_mac,c.wlan_mac,c.pc_description,u.name as current_user,cb.last_logged_in from client c " +
                        "left join client_build cb on cb.client = c.id " +
                        "left join desktop_mdis dm on dm.id = cb.build " +
                        "left join users u on u.id = cb.current_user " +
                        "where c.status = 1 and dm.mdi_code ilike '" + param.moduleCode + "'");
            if(param.moduleCode=="0")
            {
                sb.Clear();
                sb.Append("select null as moduleName,c.id,c.name,c.current_ip,cb.current_build_version,c.current_mac,c.lan_mac,c.wlan_mac,c.pc_description,cb.current_user,cb.last_logged_in from client c "
                            + " left join client_build cb on cb.client = c.id  where c.status = 1 and cb.build =0");
            }
            if (!string.IsNullOrEmpty(param.ip))
            {
                sb.Append(" and current_ip ilike CONCAT(@ip,'%' )");
                dbCommand.Parameters.AddWithValue("@ip", param.ip);
            }
            if (!string.IsNullOrEmpty(param.name))
            {
                sb.Append(" and c.name ilike CONCAT('%',@name,'%' )");
                dbCommand.Parameters.AddWithValue("@name", param.name);
            }
            sb.Append("order by  cb.last_logged_in");
            dbCommand.SQLQuery = sb.ToString();
            DataTable dt = DB.FillDataTable(dbCommand);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    clientDTO row = new clientDTO();
                    row.id = dr["id"].ToString();
                    row.name = dr["name"].ToString();
                    row.ip = dr["current_ip"].ToString();
                    row.allowedModules = dr["moduleName"].ToString();
                    row.currentBuild = dr["current_build_version"].ToString();
                    row.currentMAC = dr["current_mac"].ToString();
                    row.currentUser = dr["current_user"].ToString();
                    row.lanMAC = dr["lan_mac"].ToString();
                    row.wlanMAC = dr["wlan_mac"].ToString();
                    row.pcDescription = dr["pc_description"].ToString();
                    row.loggedDATE = dr["last_logged_in"].ToString();
                    Modules.Add(row);
                }
            }
            return Modules;
        }

        public void updateCurrentBuildVersionByMac(clientDTO clientToUpdate)
        {
            using (DBCommand updateCMD = new DBCommand("update client_build set current_build_version=@version where client=(select id from client where lan_mac=@lanMAC) and build=@build"))
            {
                updateCMD.Parameters.AddWithValue("@lanMAC", clientToUpdate.lanMAC);
                updateCMD.Parameters.AddWithValue("@version", clientToUpdate.currentBuild);
                updateCMD.Parameters.AddWithValue("@build", clientToUpdate.currentModuleId);
                DB.ExecuteNonQuery(updateCMD);
            }
        }

        public bool UpdateClientAllowedModules(clientDTO clientToUpdate)
        {
            DBCommand cmd = new DBCommand("delete from client_build where client=@client");
            cmd.Parameters.AddWithValue("@client", clientToUpdate.id);

            commands.Add(cmd);
            foreach (moduleDTO allowedModule in clientToUpdate.allowedModulesList)
            {
                DBCommand insert = new DBCommand("insert into client_build (client,build) values ("+clientToUpdate.id+","+ allowedModule.ModuleID + ")");
                commands.Add(insert);
            }

            var result = DB.ExecuteNonQueriesInTransaction(commands);
            if (result.IsSucceess)
                return true;
            else
                return false;
        }
        public CompanyDetails GetCompanydetails()
        {
            List<CompanyDetails> companydetails = new List<CompanyDetails>();
            using (DBCommand cmd = new DBCommand("select * from company"))
            {
                DataTable dt = DB.FillDataTable(cmd);

                if (dt.Rows.Count > 0)
                {
                    CompanyDetails company = new CompanyDetails();
                    DataRow dr = dt.Rows[0];
                    company.Id = Convert.ToString(dr["id"]);
                    company.Name = Convert.ToString(dr["name"]);
                    //company.Address = Convert.ToString(dr["address"]).Replace(System.Environment.NewLine, string.Empty);
                    //company.City = Convert.ToString(dr["city"]);
                    //company.Pincode = Convert.ToString(dr["pincode"]);
                    //company.Country = Convert.ToString(dr["country"]);
                    //company.State = Convert.ToString(dr["state"]);
                    //company.Created_at = Convert.ToString(dr["created_at"]);
                    //company.Created_by = Convert.ToString(dr["created_by"]);
                    //company.Updated_at = Convert.ToString(dr["updated_at"]);
                    //company.Updated_by = Convert.ToString(dr["updated_by"]);
                    //company.Status = Convert.ToString(dr["status"]);
                    //company.Phone = Convert.ToString(dr["phone"]);
                    //company.Booking_no = Convert.ToString(dr["booking_no"]);
                    //company.Gst_no = Convert.ToString(dr["gst_no"]);
                    //company.View_status = Convert.ToInt32(dr["view_status"]);
                    //byte[] picData = dr["bgimg"] as byte[] ?? null;

                    //if (picData != null)
                    //{
                    //    company.image = picData;
                    //}

                    byte[] piclogo = dr["logo1"] as byte[] ?? null;

                    if (piclogo != null)
                    {
                        company.Logoimg = piclogo;
                    }
                  //  company.OPdlno = Convert.ToString(dr["op_dlno"]);
                  //  company.IPDlno = Convert.ToString(dr["ip_dlno"]);
                  //  company.OPdlno = Convert.ToString(dr["op_dlno"]);
                  //  company.IPDlno = Convert.ToString(dr["ip_dlno"]);
                  ////  company.code = Convert.ToString(dr["company_code"]);
                    return company;
                }
            }
            return null;
        }
    }
}
