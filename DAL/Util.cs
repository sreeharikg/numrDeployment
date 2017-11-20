using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;
using DTO;
using System.Security.Cryptography;

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

        public string GetComputerDescription()
        {
            string key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lanmanserver\parameters";
            return  (string)Registry.GetValue(key, "srvcomment", null);
        }
        public string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes("TIATECH@!@#$"));

            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;

            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;

            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();

            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            //Releasing the Memory Occupied by TripleDES Service Provider for Decryption.          
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
