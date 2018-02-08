using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager
    {
        public string Caption { get; private set; }
        public ulong ConnectionMemoryKB { get; private set; }
        public ulong DatabaseCacheMemoryKB { get; private set; }
        public string Description { get; private set; }
        public ulong Externalbenefitofmemory { get; private set; }
        public ulong FreeMemoryKB { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GrantedWorkspaceMemoryKB { get; private set; }
        public ulong LockBlocks { get; private set; }
        public ulong LockBlocksAllocated { get; private set; }
        public ulong LockMemoryKB { get; private set; }
        public ulong LockOwnerBlocks { get; private set; }
        public ulong LockOwnerBlocksAllocated { get; private set; }
        public ulong LogPoolMemoryKB { get; private set; }
        public ulong MaximumWorkspaceMemoryKB { get; private set; }
        public ulong MemoryGrantsOutstanding { get; private set; }
        public ulong MemoryGrantsPending { get; private set; }
        public string Name { get; private set; }
        public ulong OptimizerMemoryKB { get; private set; }
        public ulong ReservedServerMemoryKB { get; private set; }
        public ulong SQLCacheMemoryKB { get; private set; }
        public ulong StolenServerMemoryKB { get; private set; }
        public ulong TargetServerMemoryKB { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalServerMemoryKB { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager[] Retrieve(string remote,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionMemoryKB = (ulong) managementObject.Properties["ConnectionMemoryKB"].Value,
                    DatabaseCacheMemoryKB = (ulong) managementObject.Properties["DatabaseCacheMemoryKB"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Externalbenefitofmemory = (ulong) managementObject.Properties["Externalbenefitofmemory"].Value,
                    FreeMemoryKB = (ulong) managementObject.Properties["FreeMemoryKB"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GrantedWorkspaceMemoryKB = (ulong) managementObject.Properties["GrantedWorkspaceMemoryKB"].Value,
                    LockBlocks = (ulong) managementObject.Properties["LockBlocks"].Value,
                    LockBlocksAllocated = (ulong) managementObject.Properties["LockBlocksAllocated"].Value,
                    LockMemoryKB = (ulong) managementObject.Properties["LockMemoryKB"].Value,
                    LockOwnerBlocks = (ulong) managementObject.Properties["LockOwnerBlocks"].Value,
                    LockOwnerBlocksAllocated = (ulong) managementObject.Properties["LockOwnerBlocksAllocated"].Value,
                    LogPoolMemoryKB = (ulong) managementObject.Properties["LogPoolMemoryKB"].Value,
                    MaximumWorkspaceMemoryKB = (ulong) managementObject.Properties["MaximumWorkspaceMemoryKB"].Value,
                    MemoryGrantsOutstanding = (ulong) managementObject.Properties["MemoryGrantsOutstanding"].Value,
                    MemoryGrantsPending = (ulong) managementObject.Properties["MemoryGrantsPending"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OptimizerMemoryKB = (ulong) managementObject.Properties["OptimizerMemoryKB"].Value,
                    ReservedServerMemoryKB = (ulong) managementObject.Properties["ReservedServerMemoryKB"].Value,
                    SQLCacheMemoryKB = (ulong) managementObject.Properties["SQLCacheMemoryKB"].Value,
                    StolenServerMemoryKB = (ulong) managementObject.Properties["StolenServerMemoryKB"].Value,
                    TargetServerMemoryKB = (ulong) managementObject.Properties["TargetServerMemoryKB"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalServerMemoryKB = (ulong) managementObject.Properties["TotalServerMemoryKB"].Value
                });

            return list.ToArray();
        }
    }
}