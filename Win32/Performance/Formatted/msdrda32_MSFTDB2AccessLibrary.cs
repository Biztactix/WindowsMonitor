using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class msdrda32_MSFTDB2AccessLibrary
    {
		public uint AvgHostProcessingTime { get; private set; }
		public ulong BytesReceivedPerSecond { get; private set; }
		public ulong BytesSentPerSecond { get; private set; }
		public string Caption { get; private set; }
		public uint CommitsPerSecond { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint OLEDBAvgDataAccessTime { get; private set; }
		public uint OLEDBAvgExecutionTime { get; private set; }
		public uint OLEDBAvgFetchTime { get; private set; }
		public uint OLEDBAvgPrepareTime { get; private set; }
		public uint OLEDBExecutesPerSecond { get; private set; }
		public uint OLEDBGetDatacallsPerSecond { get; private set; }
		public uint OLEDBPreparesPerSecond { get; private set; }
		public uint OLEDBRowsFetchedPerSecond { get; private set; }
		public uint OpenConnections { get; private set; }
		public uint OpenStatements { get; private set; }
		public ulong PacketsReceivedPerSecond { get; private set; }
		public ulong PacketsSentPerSecond { get; private set; }
		public uint RollbacksPerSecond { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TransactionsPerSecond { get; private set; }

        public static IEnumerable<msdrda32_MSFTDB2AccessLibrary> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<msdrda32_MSFTDB2AccessLibrary> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<msdrda32_MSFTDB2AccessLibrary> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_msdrda32_MSFTDB2AccessLibrary");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new msdrda32_MSFTDB2AccessLibrary
                {
                     AvgHostProcessingTime = (uint) (managementObject.Properties["AvgHostProcessingTime"]?.Value ?? default(uint)),
		 BytesReceivedPerSecond = (ulong) (managementObject.Properties["BytesReceivedPerSecond"]?.Value ?? default(ulong)),
		 BytesSentPerSecond = (ulong) (managementObject.Properties["BytesSentPerSecond"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CommitsPerSecond = (uint) (managementObject.Properties["CommitsPerSecond"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OLEDBAvgDataAccessTime = (uint) (managementObject.Properties["OLEDBAvgDataAccessTime"]?.Value ?? default(uint)),
		 OLEDBAvgExecutionTime = (uint) (managementObject.Properties["OLEDBAvgExecutionTime"]?.Value ?? default(uint)),
		 OLEDBAvgFetchTime = (uint) (managementObject.Properties["OLEDBAvgFetchTime"]?.Value ?? default(uint)),
		 OLEDBAvgPrepareTime = (uint) (managementObject.Properties["OLEDBAvgPrepareTime"]?.Value ?? default(uint)),
		 OLEDBExecutesPerSecond = (uint) (managementObject.Properties["OLEDBExecutesPerSecond"]?.Value ?? default(uint)),
		 OLEDBGetDatacallsPerSecond = (uint) (managementObject.Properties["OLEDBGetDatacallsPerSecond"]?.Value ?? default(uint)),
		 OLEDBPreparesPerSecond = (uint) (managementObject.Properties["OLEDBPreparesPerSecond"]?.Value ?? default(uint)),
		 OLEDBRowsFetchedPerSecond = (uint) (managementObject.Properties["OLEDBRowsFetchedPerSecond"]?.Value ?? default(uint)),
		 OpenConnections = (uint) (managementObject.Properties["OpenConnections"]?.Value ?? default(uint)),
		 OpenStatements = (uint) (managementObject.Properties["OpenStatements"]?.Value ?? default(uint)),
		 PacketsReceivedPerSecond = (ulong) (managementObject.Properties["PacketsReceivedPerSecond"]?.Value ?? default(ulong)),
		 PacketsSentPerSecond = (ulong) (managementObject.Properties["PacketsSentPerSecond"]?.Value ?? default(ulong)),
		 RollbacksPerSecond = (uint) (managementObject.Properties["RollbacksPerSecond"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionsPerSecond = (uint) (managementObject.Properties["TransactionsPerSecond"]?.Value ?? default(uint))
                };
        }
    }
}