using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clientDTO
    {
        public string name { get; set; }
        public string ip { get; set; }
        public string lanMAC { get; set; }

        public string wlanMAC { get; set; }
        public string currentMAC { get; set; }
        public DateTime loggedDATE { get; set; }
        public string pcDescription { get; set; }
        //public string name { get; set; }
    }
}
