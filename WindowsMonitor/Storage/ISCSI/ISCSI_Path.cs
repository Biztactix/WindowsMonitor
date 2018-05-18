using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_Path
    {
		public uint ConnectionStatus { get; private set; }
		public ulong EstimatedLinkSpeed { get; private set; }
		public uint PathWeight { get; private set; }
		public uint PrimaryPath { get; private set; }
		public uint TCPOffLoadAvailable { get; private set; }
		public ulong UniqueConnectionId { get; private set; }

        public static IEnumerable<ISCSI_Path> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_Path> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_Path> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_Path");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_Path
                {
                     ConnectionStatus = (uint) (managementObject.Properties["ConnectionStatus"]?.Value ?? default(uint)),
		 EstimatedLinkSpeed = (ulong) (managementObject.Properties["EstimatedLinkSpeed"]?.Value ?? default(ulong)),
		 PathWeight = (uint) (managementObject.Properties["PathWeight"]?.Value ?? default(uint)),
		 PrimaryPath = (uint) (managementObject.Properties["PrimaryPath"]?.Value ?? default(uint)),
		 TCPOffLoadAvailable = (uint) (managementObject.Properties["TCPOffLoadAvailable"]?.Value ?? default(uint)),
		 UniqueConnectionId = (ulong) (managementObject.Properties["UniqueConnectionId"]?.Value ?? default(ulong))
                };
        }
    }
}