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
    }
}
