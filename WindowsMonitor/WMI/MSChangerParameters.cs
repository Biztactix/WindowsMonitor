using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSChangerParameters
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint MagazineSize { get; private set; }
		public uint NumberOfCleanerSlots { get; private set; }
		public uint NumberOfDoors { get; private set; }
		public uint NumberOfDrives { get; private set; }
		public uint NumberOfIEPorts { get; private set; }
		public uint NumberOfSlots { get; private set; }
		public uint NumberOfTransports { get; private set; }

        public static IEnumerable<MSChangerParameters> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSChangerParameters> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSChangerParameters> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSChangerParameters");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSChangerParameters
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 MagazineSize = (uint) (managementObject.Properties["MagazineSize"]?.Value ?? default(uint)),
		 NumberOfCleanerSlots = (uint) (managementObject.Properties["NumberOfCleanerSlots"]?.Value ?? default(uint)),
		 NumberOfDoors = (uint) (managementObject.Properties["NumberOfDoors"]?.Value ?? default(uint)),
		 NumberOfDrives = (uint) (managementObject.Properties["NumberOfDrives"]?.Value ?? default(uint)),
		 NumberOfIEPorts = (uint) (managementObject.Properties["NumberOfIEPorts"]?.Value ?? default(uint)),
		 NumberOfSlots = (uint) (managementObject.Properties["NumberOfSlots"]?.Value ?? default(uint)),
		 NumberOfTransports = (uint) (managementObject.Properties["NumberOfTransports"]?.Value ?? default(uint))
                };
        }
    }
}