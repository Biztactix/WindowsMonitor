using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Printers
{
    /// <summary>
    /// </summary>
    public sealed class TCPIPPrinterPort
    {
		public bool ByteCount { get; private set; }
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public string HostAddress { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public uint PortNumber { get; private set; }
		public uint Protocol { get; private set; }
		public string Queue { get; private set; }
		public string SNMPCommunity { get; private set; }
		public uint SNMPDevIndex { get; private set; }
		public bool SNMPEnabled { get; private set; }
		public string Status { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<TCPIPPrinterPort> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<TCPIPPrinterPort> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TCPIPPrinterPort> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_TCPIPPrinterPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TCPIPPrinterPort
                {
                     ByteCount = (bool) (managementObject.Properties["ByteCount"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 HostAddress = (string) (managementObject.Properties["HostAddress"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PortNumber = (uint) (managementObject.Properties["PortNumber"]?.Value ?? default(uint)),
		 Protocol = (uint) (managementObject.Properties["Protocol"]?.Value ?? default(uint)),
		 Queue = (string) (managementObject.Properties["Queue"]?.Value ?? default(string)),
		 SNMPCommunity = (string) (managementObject.Properties["SNMPCommunity"]?.Value ?? default(string)),
		 SNMPDevIndex = (uint) (managementObject.Properties["SNMPDevIndex"]?.Value ?? default(uint)),
		 SNMPEnabled = (bool) (managementObject.Properties["SNMPEnabled"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}