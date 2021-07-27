using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;

namespace LoginService
{
    public class MacFinder
    {
        public static string GetMACAddress()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            return mac;
        }

        public static string GetMACAddressWhenOnlineOrOffline()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;

            var wifi = nics.Where(x => x.Name.Equals("Wi-Fi",StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var ethernet = nics.Where(x => x.Name.Equals("Ethernet", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (wifi != null)
                return wifi.GetPhysicalAddress().ToString();
            if (ethernet != null)
                return ethernet.GetPhysicalAddress().ToString();

            return string.Empty;
        }

        public static string GetCPUId()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        public static string GetAllInfo()
        {
            var macAddress = GetMACAddressWhenOnlineOrOffline();
            var cpuId = GetCPUId();
            
            return JsonConvert.SerializeObject(new { 
                mac = Encrypt(macAddress), 
                cpuId = Encrypt(cpuId),
                computerName = Encrypt(SystemInfo.GetComputerName()),
            });

        }

        private static string Encrypt(string value) => Security.EncDec.Enc(value);
    }
}
