using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode
    {
        public string Caption { get; private set; }
        public ulong DatabaseNodeMemoryKB { get; private set; }
        public string Description { get; private set; }
        public ulong ForeignNodeMemoryKB { get; private set; }
        public ulong FreeNodeMemoryKB { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong StolenNodeMemoryKB { get; private set; }
        public ulong TargetNodeMemoryKB { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalNodeMemoryKB { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode[] Retrieve(string remote, string username,
            string password)
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryNode
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DatabaseNodeMemoryKB = (ulong) managementObject.Properties["DatabaseNodeMemoryKB"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ForeignNodeMemoryKB = (ulong) managementObject.Properties["ForeignNodeMemoryKB"].Value,
                    FreeNodeMemoryKB = (ulong) managementObject.Properties["FreeNodeMemoryKB"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    StolenNodeMemoryKB = (ulong) managementObject.Properties["StolenNodeMemoryKB"].Value,
                    TargetNodeMemoryKB = (ulong) managementObject.Properties["TargetNodeMemoryKB"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalNodeMemoryKB = (ulong) managementObject.Properties["TotalNodeMemoryKB"].Value
                });

            return list.ToArray();
        }
    }
}