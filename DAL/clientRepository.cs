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
                cmd = new DBCommand("insert into client (name,lan_mac,wlan_mac,pc_description) values (@name,@lanMAC,@wlanMAC,@PCdesc)");
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
    }
}
