using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Hardware
{
    /// <summary>
    /// </summary>
    public sealed class LogicalDiskBasedOnVolumeSet
    {
		public short Antecedent { get; private set; }
		public short Dependent { get; private set; }
		public ulong EndingAddress { get; private set; }
		public ulong StartingAddress { get; private set; }

        public static IEnumerable<LogicalDiskBasedOnVolumeSet> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LogicalDiskBasedOnVolumeSet> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LogicalDiskBasedOnVolumeSet> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_LogicalDiskBasedOnVolumeSet");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LogicalDiskBasedOnVolumeSet
                {
                     Antecedent = (short) (managementObject.Properties["Antecedent"]?.Value ?? default(short)),
		 Dependent = (short) (managementObject.Properties["Dependent"]?.Value ?? default(short)),
		 EndingAddress = (ulong) (managementObject.Properties["EndingAddress"]?.Value ?? default(ulong)),
		 StartingAddress = (ulong) (managementObject.Properties["StartingAddress"]?.Value ?? default(ulong))
                };
        }
    }
}