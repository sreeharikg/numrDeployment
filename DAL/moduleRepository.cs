﻿using DTO;
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
            List<moduleDTO> allowedModules = new List<moduleDTO>();
            DBCommand cmd = new DBCommand("select allowed_mdis from client where lan_mac=@lanMAC");
            cmd.Parameters.AddWithValue("@lanMAC", mac);
            string mdiIds = DB.ExecuteScalar(cmd).ToString();
            using (DBCommand get = new DBCommand("select * from desktop_mdis where mdi_code in ("+mdiIds+") and status=1"))
            {
                //get.Parameters.AddWithValue("@id", mdiIds);
                DataTable dt = DB.FillDataTable(get);
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        moduleDTO row = new moduleDTO();
                        row.ModuleCode = dr["mdi_code"].ToString();
                        row.ModuleName = dr["name"].ToString();
                        row.pathToBuild = dr["current_path"].ToString();
                        row.BuildName = dr["build_name"].ToString();
                        allowedModules.Add(row);
                    }
                }
            }
            return allowedModules;
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
                        row.ModuleCode = dr["mdi_code"].ToString();
                        row.ModuleName = dr["name"].ToString();
                        //row.pathToBuild = dr["current_path"].ToString();
                       // row.BuildName = dr["build_name"].ToString();
                        Modules.Add(row);
                    }
                }
            }
            return Modules;
        }
    }
}