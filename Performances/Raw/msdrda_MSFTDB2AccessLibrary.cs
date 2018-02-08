using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_msdrda_MSFTDB2AccessLibrary
    {
        public uint AvgHostProcessingTime { get; private set; }
        public uint AvgHostProcessingTime_Base { get; private set; }
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
        public uint OLEDBAvgDataAccessTime_Base { get; private set; }
        public uint OLEDBAvgExecutionTime { get; private set; }
        public uint OLEDBAvgExecutionTime_Base { get; private set; }
        public uint OLEDBAvgFetchTime { get; private set; }
        public uint OLEDBAvgFetchTime_Base { get; private set; }
        public uint OLEDBAvgPrepareTime { get; private set; }
        public uint OLEDBAvgPrepareTime_Base { get; private set; }
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

        public static PerfRawData_msdrda_MSFTDB2AccessLibrary[] Retrieve(string remote, string username,
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

        public static PerfRawData_msdrda_MSFTDB2AccessLibrary[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_msdrda_MSFTDB2AccessLibrary[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_msdrda_MSFTDB2AccessLibrary");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_msdrda_MSFTDB2AccessLibrary>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_msdrda_MSFTDB2AccessLibrary
                {
                    AvgHostProcessingTime = (uint) managementObject.Properties["AvgHostProcessingTime"].Value,
                    AvgHostProcessingTime_Base = (uint) managementObject.Properties["AvgHostProcessingTime_Base"].Value,
                    BytesReceivedPerSecond = (ulong) managementObject.Properties["BytesReceivedPerSecond"].Value,
                    BytesSentPerSecond = (ulong) managementObject.Properties["BytesSentPerSecond"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommitsPerSecond = (uint) managementObject.Properties["CommitsPerSecond"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OLEDBAvgDataAccessTime = (uint) managementObject.Properties["OLEDBAvgDataAccessTime"].Value,
                    OLEDBAvgDataAccessTime_Base = (uint) managementObject.Properties["OLEDBAvgDataAccessTime_Base"]
                        .Value,
                    OLEDBAvgExecutionTime = (uint) managementObject.Properties["OLEDBAvgExecutionTime"].Value,
                    OLEDBAvgExecutionTime_Base = (uint) managementObject.Properties["OLEDBAvgExecutionTime_Base"].Value,
                    OLEDBAvgFetchTime = (uint) managementObject.Properties["OLEDBAvgFetchTime"].Value,
                    OLEDBAvgFetchTime_Base = (uint) managementObject.Properties["OLEDBAvgFetchTime_Base"].Value,
                    OLEDBAvgPrepareTime = (uint) managementObject.Properties["OLEDBAvgPrepareTime"].Value,
                    OLEDBAvgPrepareTime_Base = (uint) managementObject.Properties["OLEDBAvgPrepareTime_Base"].Value,
                    OLEDBExecutesPerSecond = (uint) managementObject.Properties["OLEDBExecutesPerSecond"].Value,
                    OLEDBGetDatacallsPerSecond = (uint) managementObject.Properties["OLEDBGetDatacallsPerSecond"].Value,
                    OLEDBPreparesPerSecond = (uint) managementObject.Properties["OLEDBPreparesPerSecond"].Value,
                    OLEDBRowsFetchedPerSecond = (uint) managementObject.Properties["OLEDBRowsFetchedPerSecond"].Value,
                    OpenConnections = (uint) managementObject.Properties["OpenConnections"].Value,
                    OpenStatements = (uint) managementObject.Properties["OpenStatements"].Value,
                    PacketsReceivedPerSecond = (ulong) managementObject.Properties["PacketsReceivedPerSecond"].Value,
                    PacketsSentPerSecond = (ulong) managementObject.Properties["PacketsSentPerSecond"].Value,
                    RollbacksPerSecond = (uint) managementObject.Properties["RollbacksPerSecond"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionsPerSecond = (uint) managementObject.Properties["TransactionsPerSecond"].Value
                });

            return list.ToArray();
        }
    }
}