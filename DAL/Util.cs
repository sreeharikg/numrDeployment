using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;
using DTO;

namespace Numr
{
    public class Util
    {
        public clientDTO GetMacAddress()
        {
            clientDTO mac = new clientDTO();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    mac.lanMAC = nic.GetPhysicalAddress().ToString();
                // Only consider WIFI network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    mac.wlanMAC = nic.GetPhysicalAddress().ToString();
                if (nic.OperationalStatus == OperationalStatus.Up && (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet|| nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                    mac.currentMAC = nic.GetPhysicalAddress().ToString();
            }
                return mac;
        }
        public string GetAllLocalIPv4()
        {
            string ipAddrList = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList += ip.Address.ToString() + ",";
                        }
                    }
                }
            }
            if (ipAddrList.Length > 0)
                return ipAddrList.Substring(0, ipAddrList.Length - 1);
            return ipAddrList;
        }
        public string GetMachineName()
        {
            return Environment.MachineName;
        }
        public List<moduleDTO> GetAllAllowedModulesByEthernetMAC(string mac)
        {
            return null;
        }
        public string GetComputerDescription()
        {
            string key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lanmanserver\parameters";
            return  (string)Registry.GetValue(key, "srvcomment", null);
        }

    }
}
