using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class XTPDatabaseEngine_XTPPhantomProcessor
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint DustycornerscanretriesPersecPhantomissued { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint PhantomexpiredrowsremovedPersec { get; private set; }
		public uint PhantomexpiredrowstouchedPersec { get; private set; }
		public uint PhantomexpiringrowstouchedPersec { get; private set; }
		public uint PhantomrowstouchedPersec { get; private set; }
		public uint PhantomscansstartedPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<XTPDatabaseEngine_XTPPhantomProcessor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<XTPDatabaseEngine_XTPPhantomProcessor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<XTPDatabaseEngine_XTPPhantomProcessor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_XTPDatabaseEngine_XTPPhantomProcessor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new XTPDatabaseEngine_XTPPhantomProcessor
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DustycornerscanretriesPersecPhantomissued = (uint) (managementObject.Properties["DustycornerscanretriesPersecPhantomissued"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PhantomexpiredrowsremovedPersec = (uint) (managementObject.Properties["PhantomexpiredrowsremovedPersec"]?.Value ?? default(uint)),
		 PhantomexpiredrowstouchedPersec = (uint) (managementObject.Properties["PhantomexpiredrowstouchedPersec"]?.Value ?? default(uint)),
		 PhantomexpiringrowstouchedPersec = (uint) (managementObject.Properties["PhantomexpiringrowstouchedPersec"]?.Value ?? default(uint)),
		 PhantomrowstouchedPersec = (uint) (managementObject.Properties["PhantomrowstouchedPersec"]?.Value ?? default(uint)),
		 PhantomscansstartedPersec = (uint) (managementObject.Properties["PhantomscansstartedPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}