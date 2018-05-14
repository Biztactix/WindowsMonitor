using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class XTPDatabaseEngine_XTPCursors
    {
		public string Caption { get; private set; }
		public uint CursordeletesPersec { get; private set; }
		public uint CursorinsertsPersec { get; private set; }
		public uint CursorscansstartedPersec { get; private set; }
		public uint CursoruniqueviolationsPersec { get; private set; }
		public uint CursorupdatesPersec { get; private set; }
		public uint CursorwriteconflictsPersec { get; private set; }
		public string Description { get; private set; }
		public uint DustycornerscanretriesPersecuserissued { get; private set; }
		public uint ExpiredrowsremovedPersec { get; private set; }
		public uint ExpiredrowstouchedPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint RowsreturnedPersec { get; private set; }
		public uint RowstouchedPersec { get; private set; }
		public uint TentativelydeletedrowstouchedPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<XTPDatabaseEngine_XTPCursors> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<XTPDatabaseEngine_XTPCursors> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<XTPDatabaseEngine_XTPCursors> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_XTPDatabaseEngine_XTPCursors");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new XTPDatabaseEngine_XTPCursors
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CursordeletesPersec = (uint) (managementObject.Properties["CursordeletesPersec"]?.Value ?? default(uint)),
		 CursorinsertsPersec = (uint) (managementObject.Properties["CursorinsertsPersec"]?.Value ?? default(uint)),
		 CursorscansstartedPersec = (uint) (managementObject.Properties["CursorscansstartedPersec"]?.Value ?? default(uint)),
		 CursoruniqueviolationsPersec = (uint) (managementObject.Properties["CursoruniqueviolationsPersec"]?.Value ?? default(uint)),
		 CursorupdatesPersec = (uint) (managementObject.Properties["CursorupdatesPersec"]?.Value ?? default(uint)),
		 CursorwriteconflictsPersec = (uint) (managementObject.Properties["CursorwriteconflictsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DustycornerscanretriesPersecuserissued = (uint) (managementObject.Properties["DustycornerscanretriesPersecuserissued"]?.Value ?? default(uint)),
		 ExpiredrowsremovedPersec = (uint) (managementObject.Properties["ExpiredrowsremovedPersec"]?.Value ?? default(uint)),
		 ExpiredrowstouchedPersec = (uint) (managementObject.Properties["ExpiredrowstouchedPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 RowsreturnedPersec = (uint) (managementObject.Properties["RowsreturnedPersec"]?.Value ?? default(uint)),
		 RowstouchedPersec = (uint) (managementObject.Properties["RowstouchedPersec"]?.Value ?? default(uint)),
		 TentativelydeletedrowstouchedPersec = (uint) (managementObject.Properties["TentativelydeletedrowstouchedPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}