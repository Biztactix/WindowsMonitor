using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSRedbook_DriverInformation
    {
		public bool Active { get; private set; }
		public bool CDDAAccurate { get; private set; }
		public bool CDDASupported { get; private set; }
		public string InstanceName { get; private set; }
		public uint MaximumSectorsPerRead { get; private set; }
		public uint NumberOfBuffers { get; private set; }
		public bool PlayEnabled { get; private set; }
		public bool Reserved1 { get; private set; }
		public uint SectorsPerRead { get; private set; }
		public uint SectorsPerReadMask { get; private set; }

        public static IEnumerable<MSRedbook_DriverInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSRedbook_DriverInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSRedbook_DriverInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSRedbook_DriverInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSRedbook_DriverInformation
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 CDDAAccurate = (bool) (managementObject.Properties["CDDAAccurate"]?.Value ?? default(bool)),
		 CDDASupported = (bool) (managementObject.Properties["CDDASupported"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 MaximumSectorsPerRead = (uint) (managementObject.Properties["MaximumSectorsPerRead"]?.Value ?? default(uint)),
		 NumberOfBuffers = (uint) (managementObject.Properties["NumberOfBuffers"]?.Value ?? default(uint)),
		 PlayEnabled = (bool) (managementObject.Properties["PlayEnabled"]?.Value ?? default(bool)),
		 Reserved1 = (bool) (managementObject.Properties["Reserved1"]?.Value ?? default(bool)),
		 SectorsPerRead = (uint) (managementObject.Properties["SectorsPerRead"]?.Value ?? default(uint)),
		 SectorsPerReadMask = (uint) (managementObject.Properties["SectorsPerReadMask"]?.Value ?? default(uint))
                };
        }
    }
}