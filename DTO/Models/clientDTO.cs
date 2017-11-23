using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clientDTO
    {
        public clientDTO()
        {
            allowedModulesList = new List<moduleDTO>();
        }
        public string id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public string lanMAC { get; set; }

        public string wlanMAC { get; set; }
        public string currentMAC { get; set; }
        public string loggedDATE { get; set; }
        public string pcDescription { get; set; }
        public string currentUser { get; set; }
        public string allowedModules { get; set; }
        public List<moduleDTO> allowedModulesList { get; set; }
        public string[] allowedModulesArray { get; set; }
        public string currentBuild { get; set; }

    }
}
