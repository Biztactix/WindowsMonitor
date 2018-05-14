using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Hardware
{
    /// <summary>
    /// </summary>
    public sealed class PhysicalElementLocation
    {
		public short Element { get; private set; }
		public short PhysicalLocation { get; private set; }

        public static IEnumerable<PhysicalElementLocation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PhysicalElementLocation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PhysicalElementLocation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_PhysicalElementLocation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PhysicalElementLocation
                {
                     Element = (short) (managementObject.Properties["Element"]?.Value ?? default(short)),
		 PhysicalLocation = (short) (managementObject.Properties["PhysicalLocation"]?.Value ?? default(short))
                };
        }
    }
}