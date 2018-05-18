using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_NPIVLUNMappingInformationEx
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public byte OSBus { get; private set; }
		public byte OSLUN { get; private set; }
		public byte OSTarget { get; private set; }
		public byte PortNumber { get; private set; }
		public byte[] WWPNPhysicalPort { get; private set; }
		public byte[] WWPNVirtualPort { get; private set; }

        public static IEnumerable<MSFC_NPIVLUNMappingInformationEx> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_NPIVLUNMappingInformationEx> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_NPIVLUNMappingInformationEx> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_NPIVLUNMappingInformationEx");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_NPIVLUNMappingInformationEx
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 OSBus = (byte) (managementObject.Properties["OSBus"]?.Value ?? default(byte)),
		 OSLUN = (byte) (managementObject.Properties["OSLUN"]?.Value ?? default(byte)),
		 OSTarget = (byte) (managementObject.Properties["OSTarget"]?.Value ?? default(byte)),
		 PortNumber = (byte) (managementObject.Properties["PortNumber"]?.Value ?? default(byte)),
		 WWPNPhysicalPort = (byte[]) (managementObject.Properties["WWPNPhysicalPort"]?.Value ?? new byte[0]),
		 WWPNVirtualPort = (byte[]) (managementObject.Properties["WWPNVirtualPort"]?.Value ?? new byte[0])
                };
        }
    }
}