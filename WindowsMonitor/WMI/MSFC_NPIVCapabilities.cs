using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_NPIVCapabilities
    {
		public bool Active { get; private set; }
		public bool DhChapAvailableOnPhysicalPort { get; private set; }
		public bool DhChapAvailableOnVirtualPorts { get; private set; }
		public string InstanceName { get; private set; }
		public ushort MaxVirtualPortCount { get; private set; }

        public static IEnumerable<MSFC_NPIVCapabilities> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_NPIVCapabilities> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_NPIVCapabilities> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_NPIVCapabilities");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_NPIVCapabilities
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 DhChapAvailableOnPhysicalPort = (bool) (managementObject.Properties["DhChapAvailableOnPhysicalPort"]?.Value ?? default(bool)),
		 DhChapAvailableOnVirtualPorts = (bool) (managementObject.Properties["DhChapAvailableOnVirtualPorts"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 MaxVirtualPortCount = (ushort) (managementObject.Properties["MaxVirtualPortCount"]?.Value ?? default(ushort))
                };
        }
    }
}