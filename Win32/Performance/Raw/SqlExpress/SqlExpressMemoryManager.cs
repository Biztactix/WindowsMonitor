using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlExpressMemoryManager
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

        public static IEnumerable<SqlExpressMemoryManager> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlExpressMemoryManager> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressMemoryManager> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSMemoryManager");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlExpressMemoryManager
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConnectionMemoryKB = (ulong) (managementObject.Properties["ConnectionMemoryKB"]?.Value ?? default(ulong)),
		 DatabaseCacheMemoryKB = (ulong) (managementObject.Properties["DatabaseCacheMemoryKB"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Externalbenefitofmemory = (ulong) (managementObject.Properties["Externalbenefitofmemory"]?.Value ?? default(ulong)),
		 FreeMemoryKB = (ulong) (managementObject.Properties["FreeMemoryKB"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GrantedWorkspaceMemoryKB = (ulong) (managementObject.Properties["GrantedWorkspaceMemoryKB"]?.Value ?? default(ulong)),
		 LockBlocks = (ulong) (managementObject.Properties["LockBlocks"]?.Value ?? default(ulong)),
		 LockBlocksAllocated = (ulong) (managementObject.Properties["LockBlocksAllocated"]?.Value ?? default(ulong)),
		 LockMemoryKB = (ulong) (managementObject.Properties["LockMemoryKB"]?.Value ?? default(ulong)),
		 LockOwnerBlocks = (ulong) (managementObject.Properties["LockOwnerBlocks"]?.Value ?? default(ulong)),
		 LockOwnerBlocksAllocated = (ulong) (managementObject.Properties["LockOwnerBlocksAllocated"]?.Value ?? default(ulong)),
		 LogPoolMemoryKB = (ulong) (managementObject.Properties["LogPoolMemoryKB"]?.Value ?? default(ulong)),
		 MaximumWorkspaceMemoryKB = (ulong) (managementObject.Properties["MaximumWorkspaceMemoryKB"]?.Value ?? default(ulong)),
		 MemoryGrantsOutstanding = (ulong) (managementObject.Properties["MemoryGrantsOutstanding"]?.Value ?? default(ulong)),
		 MemoryGrantsPending = (ulong) (managementObject.Properties["MemoryGrantsPending"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OptimizerMemoryKB = (ulong) (managementObject.Properties["OptimizerMemoryKB"]?.Value ?? default(ulong)),
		 ReservedServerMemoryKB = (ulong) (managementObject.Properties["ReservedServerMemoryKB"]?.Value ?? default(ulong)),
		 SQLCacheMemoryKB = (ulong) (managementObject.Properties["SQLCacheMemoryKB"]?.Value ?? default(ulong)),
		 StolenServerMemoryKB = (ulong) (managementObject.Properties["StolenServerMemoryKB"]?.Value ?? default(ulong)),
		 TargetServerMemoryKB = (ulong) (managementObject.Properties["TargetServerMemoryKB"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalServerMemoryKB = (ulong) (managementObject.Properties["TotalServerMemoryKB"]?.Value ?? default(ulong))
                };
        }
    }
}