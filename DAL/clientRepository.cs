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
        public clientDTO RegisterOrUpdateClientDetails(clientDTO currentClient)
        {
            clientDTO client = new clientDTO();
            using (DBCommand cmd = new DBCommand("select * from client where lan_mac=@lanMAC"))
            {
                cmd.Parameters.AddWithValue("@lanMAC", currentClient.lanMAC);
                DataTable dt = DB.FillDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                        DataRow dr = dt.Rows[0];
                        client.name = Convert.ToString(dr["name"]);
                }
                else
                {
                  //  cmd = new DAL.DBCommand("");
                }
            }
            return client;
        }
    }
}
