using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class moduleDTO
    {
        public string ModuleName { get; set; }
        public string ModuleID { get; set; }
        public string pathToBuild { get; set; }
        public string pathToBuildSecondary { get; set; }
        public string ModuleCode { get; set; }
        public string BuildName { get; set; }
        public string BuildVersion { get; set; }
    }
}
