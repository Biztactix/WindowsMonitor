using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.HBA
{
    /// <summary>
    /// </summary>
    public sealed class HBAScsiID
    {
		public ushort[] OSDeviceName { get; private set; }
		public uint ScsiBusNumber { get; private set; }
		public uint ScsiOSLun { get; private set; }
		public uint ScsiTargetNumber { get; private set; }

        public static IEnumerable<HBAScsiID> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HBAScsiID> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HBAScsiID> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HBAScsiID");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HBAScsiID
                {
                     OSDeviceName = (ushort[]) (managementObject.Properties["OSDeviceName"]?.Value ?? new ushort[0]),
		 ScsiBusNumber = (uint) (managementObject.Properties["ScsiBusNumber"]?.Value ?? default(uint)),
		 ScsiOSLun = (uint) (managementObject.Properties["ScsiOSLun"]?.Value ?? default(uint)),
		 ScsiTargetNumber = (uint) (managementObject.Properties["ScsiTargetNumber"]?.Value ?? default(uint))
                };
        }
    }
}