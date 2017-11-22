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
                cmd = new DBCommand("insert into client (name,lan_mac,wlan_mac,pc_description,created_at) values (@name,@lanMAC,@wlanMAC,@PCdesc,now()::timestamp(0))");
                cmd.Parameters.AddWithValue("@lanMAC", currentClient.lanMAC);
                cmd.Parameters.AddWithValue("@wlanMAC", currentClient.wlanMAC);
                cmd.Parameters.AddWithValue("@name", currentClient.name);
                cmd.Parameters.AddWithValue("@PCdesc", currentClient.pcDescription);
                commands.Add(cmd);
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

        public List<clientDTO> GetAllClientDataByParam(searchParam param)
        {
            List<clientDTO> Modules = new List<clientDTO>();
            StringBuilder sb = new StringBuilder();
            DBCommand dbCommand = new DBCommand();
            sb.Append("select * from client where status=1 and allowed_mdis ilike ('%"+param.moduleCode+"%')");
            if (!string.IsNullOrEmpty(param.ip))
            {
                sb.Append(" and current_ip ilike CONCAT(@ip,'%' )");
                dbCommand.Parameters.AddWithValue("@ip", param.ip);
            }
            if (!string.IsNullOrEmpty(param.name))
            {
                sb.Append(" and name ilike CONCAT('%',@name,'%' )");
                dbCommand.Parameters.AddWithValue("@name", param.name);
            }
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
                    row.allowedModules = dr["allowed_mdis"].ToString();
                    foreach (string code in row.allowedModules.Split(','))
                        row.allowedModulesList.Add(new moduleRepository().GetAllModulesByStatus().Where(x => x.ModuleCode == code.Replace("'", "")).FirstOrDefault());
                    row.currentBuild = dr["current_build_version"].ToString();
                    row.currentMAC = dr["current_mac"].ToString();
                    row.currentUser = dr["current_user"].ToString();
                    row.lanMAC = dr["lan_mac"].ToString();
                    row.wlanMAC = dr["wlan_mac"].ToString();
                    row.pcDescription = dr["pc_description"].ToString();
                    Modules.Add(row);
                }
            }
            return Modules;
        }

        public bool UpdateClientAllowedModules(clientDTO clientToUpdate)
        {
            using (DBCommand updateCMD = new DBCommand("update client set allowed_mdis=@allowedModules where lan_mac=@lanMAC"))
            {
                updateCMD.Parameters.AddWithValue("@lanMAC", clientToUpdate.lanMAC);
                updateCMD.Parameters.AddWithValue("@allowedModules", clientToUpdate.allowedModules);
                commands.Add(updateCMD);
                var result = DB.ExecuteNonQueriesInTransaction(commands);
                if (result.IsSucceess)
                {
                    return true;
                }
            }
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
