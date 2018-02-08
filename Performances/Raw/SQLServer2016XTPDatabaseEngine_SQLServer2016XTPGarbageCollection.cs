using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint DustycornerscanretriesPersecGCissued { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MainGCworkitemsPersec { get; private set; }
        public string Name { get; private set; }
        public uint ParallelGCworkitemPersec { get; private set; }
        public uint RowsprocessedPersec { get; private set; }
        public uint RowsprocessedPersecfirstinbucket { get; private set; }
        public uint RowsprocessedPersecfirstinbucketandremoved { get; private set; }
        public uint RowsprocessedPersecmarkedforunlink { get; private set; }
        public uint RowsprocessedPersecnosweepneeded { get; private set; }
        public uint SweepexpiredrowsremovedPersec { get; private set; }
        public uint SweepexpiredrowstouchedPersec { get; private set; }
        public uint SweepexpiringrowstouchedPersec { get; private set; }
        public uint SweeprowstouchedPersec { get; private set; }
        public uint SweepscansstartedPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection[] Retrieve(
            string remote, string username, string password)
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPGarbageCollection
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DustycornerscanretriesPersecGCissued = (uint) managementObject
                        .Properties["DustycornerscanretriesPersecGCissued"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MainGCworkitemsPersec = (uint) managementObject.Properties["MainGCworkitemsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ParallelGCworkitemPersec = (uint) managementObject.Properties["ParallelGCworkitemPersec"].Value,
                    RowsprocessedPersec = (uint) managementObject.Properties["RowsprocessedPersec"].Value,
                    RowsprocessedPersecfirstinbucket =
                        (uint) managementObject.Properties["RowsprocessedPersecfirstinbucket"].Value,
                    RowsprocessedPersecfirstinbucketandremoved = (uint) managementObject
                        .Properties["RowsprocessedPersecfirstinbucketandremoved"].Value,
                    RowsprocessedPersecmarkedforunlink =
                        (uint) managementObject.Properties["RowsprocessedPersecmarkedforunlink"].Value,
                    RowsprocessedPersecnosweepneeded =
                        (uint) managementObject.Properties["RowsprocessedPersecnosweepneeded"].Value,
                    SweepexpiredrowsremovedPersec = (uint) managementObject.Properties["SweepexpiredrowsremovedPersec"]
                        .Value,
                    SweepexpiredrowstouchedPersec = (uint) managementObject.Properties["SweepexpiredrowstouchedPersec"]
                        .Value,
                    SweepexpiringrowstouchedPersec =
                        (uint) managementObject.Properties["SweepexpiringrowstouchedPersec"].Value,
                    SweeprowstouchedPersec = (uint) managementObject.Properties["SweeprowstouchedPersec"].Value,
                    SweepscansstartedPersec = (uint) managementObject.Properties["SweepscansstartedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}