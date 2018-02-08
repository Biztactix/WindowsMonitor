using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_SQLServer2016XTPDatabaseEngine_SQLServer2016XTPCursors
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CursordeletesPersec = (uint) managementObject.Properties["CursordeletesPersec"].Value,
                    CursorinsertsPersec = (uint) managementObject.Properties["CursorinsertsPersec"].Value,
                    CursorscansstartedPersec = (uint) managementObject.Properties["CursorscansstartedPersec"].Value,
                    CursoruniqueviolationsPersec = (uint) managementObject.Properties["CursoruniqueviolationsPersec"]
                        .Value,
                    CursorupdatesPersec = (uint) managementObject.Properties["CursorupdatesPersec"].Value,
                    CursorwriteconflictsPersec = (uint) managementObject.Properties["CursorwriteconflictsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DustycornerscanretriesPersecuserissued = (uint) managementObject
                        .Properties["DustycornerscanretriesPersecuserissued"].Value,
                    ExpiredrowsremovedPersec = (uint) managementObject.Properties["ExpiredrowsremovedPersec"].Value,
                    ExpiredrowstouchedPersec = (uint) managementObject.Properties["ExpiredrowstouchedPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RowsreturnedPersec = (uint) managementObject.Properties["RowsreturnedPersec"].Value,
                    RowstouchedPersec = (uint) managementObject.Properties["RowstouchedPersec"].Value,
                    TentativelydeletedrowstouchedPersec =
                        (uint) managementObject.Properties["TentativelydeletedrowstouchedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}