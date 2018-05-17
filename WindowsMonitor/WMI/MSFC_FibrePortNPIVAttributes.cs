using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_FibrePortNPIVAttributes
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint NumberVirtualPorts { get; private set; }
		public dynamic[] VirtualPorts { get; private set; }
		public byte[] WWNN { get; private set; }
		public byte[] WWPN { get; private set; }

        public static IEnumerable<MSFC_FibrePortNPIVAttributes> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_FibrePortNPIVAttributes> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_FibrePortNPIVAttributes> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_FibrePortNPIVAttributes");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_FibrePortNPIVAttributes
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NumberVirtualPorts = (uint) (managementObject.Properties["NumberVirtualPorts"]?.Value ?? default(uint)),
		 VirtualPorts = (dynamic[]) (managementObject.Properties["VirtualPorts"]?.Value ?? new dynamic[0]),
		 WWNN = (byte[]) (managementObject.Properties["WWNN"]?.Value ?? new byte[0]),
		 WWPN = (byte[]) (managementObject.Properties["WWPN"]?.Value ?? new byte[0])
                };
        }
    }
}