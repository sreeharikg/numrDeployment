using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class moduleRepository
    {
        DBHelper DB = new DBHelper();
        public List<moduleDTO> GetAllAllowedModulesByEthernetMAC(string mac)
        {
            List<moduleDTO> Modules = new List<moduleDTO>();
            using (DBCommand dbCommand = new DBCommand("select dm.id,dm.mdi_code,dm.name from client_build cb " +
                                                        "left join desktop_mdis dm on dm.id = cb.build " +
                                                        "left join client c on c.id = cb.client " +
                                                        "where c.lan_mac = @mac and build!=0"))
            {
                dbCommand.Parameters.AddWithValue("@mac", mac);
                DataTable dt = DB.FillDataTable(dbCommand);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        moduleDTO row = new moduleDTO();
                        row.ModuleCode = dr["mdi_code"].ToString();
                        row.ModuleName = dr["name"].ToString();
                        row.ModuleID = dr["id"].ToString();
                        //row.BuildName = dr["build_name"].ToString();
                        Modules.Add(row);
                    }
                }
            }
            return Modules;
        }
        public List<moduleDTO> GetAllModulesByStatus()
        {
            List<moduleDTO> Modules = new List<moduleDTO>();
            using (DBCommand get = new DBCommand("select * from desktop_mdis where status=1"))
            {
                //get.Parameters.AddWithValue("@id", mdiIds);
                DataTable dt = DB.FillDataTable(get);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        moduleDTO row = new moduleDTO();
                        row.ModuleID= dr["id"].ToString();
                        row.ModuleCode = dr["mdi_code"].ToString();
                        row.ModuleName = dr["name"].ToString();
                        row.pathToBuild = dr["current_path"].ToString();
                        row.pathToBuildSecondary = dr["secondary_path"].ToString();
                        row.BuildName = dr["build_name"].ToString();
                        row.BuildVersion = dr["build_version"].ToString();
                        Modules.Add(row);
                    }
                }
            }
            return Modules;
        }
        public DateTime GetDate()
        {
            using (DBCommand cmd = new DBCommand("select now()::timestamp"))
            {
                return Convert.ToDateTime(DB.ExecuteScalar(cmd));
            }
        }

        public void deployNewBuildByModule(moduleDTO moduleDTO)
        {
            using (DBCommand set = new DBCommand("update desktop_mdis set current_path=@pathToBuild , build_version=@version, deployment_date=now()::timestamp where build_name=@moduleName"))
            {
                set.Parameters.AddWithValue("@pathToBuild", moduleDTO.pathToBuild);
                set.Parameters.AddWithValue("@version", moduleDTO.BuildVersion);
                set.Parameters.AddWithValue("@moduleName", moduleDTO.BuildName);
                var result = DB.ExecuteNonQuery(set);
            }
        }
    }
}
