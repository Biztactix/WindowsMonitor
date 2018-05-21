using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.HBA
{
    /// <summary>
    /// </summary>
    public sealed class HBAFC3MgmtInfo
    {
		public byte[] IPAddress { get; private set; }
		public ushort IPVersion { get; private set; }
		public uint NumberOfAttachedNodes { get; private set; }
		public uint PortId { get; private set; }
		public ushort reserved { get; private set; }
		public uint reserved1 { get; private set; }
		public ushort TopologyDiscoveryFlags { get; private set; }
		public ushort UDPPort { get; private set; }
		public ulong UniqueAdapterId { get; private set; }
		public uint unittype { get; private set; }
		public byte[] wwn { get; private set; }

        public static IEnumerable<HBAFC3MgmtInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HBAFC3MgmtInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HBAFC3MgmtInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HBAFC3MgmtInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HBAFC3MgmtInfo
                {
                     IPAddress = (byte[]) (managementObject.Properties["IPAddress"]?.Value ?? new byte[0]),
		 IPVersion = (ushort) (managementObject.Properties["IPVersion"]?.Value ?? default(ushort)),
		 NumberOfAttachedNodes = (uint) (managementObject.Properties["NumberOfAttachedNodes"]?.Value ?? default(uint)),
		 PortId = (uint) (managementObject.Properties["PortId"]?.Value ?? default(uint)),
		 reserved = (ushort) (managementObject.Properties["reserved"]?.Value ?? default(ushort)),
		 reserved1 = (uint) (managementObject.Properties["reserved1"]?.Value ?? default(uint)),
		 TopologyDiscoveryFlags = (ushort) (managementObject.Properties["TopologyDiscoveryFlags"]?.Value ?? default(ushort)),
		 UDPPort = (ushort) (managementObject.Properties["UDPPort"]?.Value ?? default(ushort)),
		 UniqueAdapterId = (ulong) (managementObject.Properties["UniqueAdapterId"]?.Value ?? default(ulong)),
		 unittype = (uint) (managementObject.Properties["unittype"]?.Value ?? default(uint)),
		 wwn = (byte[]) (managementObject.Properties["wwn"]?.Value ?? new byte[0])
                };
        }
    }
}