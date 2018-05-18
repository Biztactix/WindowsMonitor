using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MS_SMHBA_SAS_Port
    {
		public byte[] AttachedSASAddress { get; private set; }
		public byte[] LocalSASAddress { get; private set; }
		public uint NumberofDiscoveredPorts { get; private set; }
		public uint NumberofPhys { get; private set; }
		public uint PortProtocol { get; private set; }

        public static IEnumerable<MS_SMHBA_SAS_Port> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MS_SMHBA_SAS_Port> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MS_SMHBA_SAS_Port> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MS_SMHBA_SAS_Port");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MS_SMHBA_SAS_Port
                {
                     AttachedSASAddress = (byte[]) (managementObject.Properties["AttachedSASAddress"]?.Value ?? new byte[0]),
		 LocalSASAddress = (byte[]) (managementObject.Properties["LocalSASAddress"]?.Value ?? new byte[0]),
		 NumberofDiscoveredPorts = (uint) (managementObject.Properties["NumberofDiscoveredPorts"]?.Value ?? default(uint)),
		 NumberofPhys = (uint) (managementObject.Properties["NumberofPhys"]?.Value ?? default(uint)),
		 PortProtocol = (uint) (managementObject.Properties["PortProtocol"]?.Value ?? default(uint))
                };
        }
    }
}