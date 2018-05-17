using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_VirtualFibrePortAttributes
    {
		public byte[] FabricWWN { get; private set; }
		public uint FCId { get; private set; }
		public uint Status { get; private set; }
		public byte[] Tag { get; private set; }
		public ushort[] VirtualName { get; private set; }
		public byte[] WWNN { get; private set; }
		public byte[] WWPN { get; private set; }

        public static IEnumerable<MSFC_VirtualFibrePortAttributes> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_VirtualFibrePortAttributes> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_VirtualFibrePortAttributes> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_VirtualFibrePortAttributes");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_VirtualFibrePortAttributes
                {
                     FabricWWN = (byte[]) (managementObject.Properties["FabricWWN"]?.Value ?? new byte[0]),
		 FCId = (uint) (managementObject.Properties["FCId"]?.Value ?? default(uint)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint)),
		 Tag = (byte[]) (managementObject.Properties["Tag"]?.Value ?? new byte[0]),
		 VirtualName = (ushort[]) (managementObject.Properties["VirtualName"]?.Value ?? new ushort[0]),
		 WWNN = (byte[]) (managementObject.Properties["WWNN"]?.Value ?? new byte[0]),
		 WWPN = (byte[]) (managementObject.Properties["WWPN"]?.Value ?? new byte[0])
                };
        }
    }
}