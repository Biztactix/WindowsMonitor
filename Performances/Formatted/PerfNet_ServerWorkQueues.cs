using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfNet_ServerWorkQueues
    {
        public uint ActiveThreads { get; private set; }
        public uint AvailableThreads { get; private set; }
        public uint AvailableWorkItems { get; private set; }
        public uint BorrowedWorkItems { get; private set; }
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesSentPersec { get; private set; }
        public ulong BytesTransferredPersec { get; private set; }
        public string Caption { get; private set; }
        public uint ContextBlocksQueuedPersec { get; private set; }
        public uint CurrentClients { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint QueueLength { get; private set; }
        public ulong ReadBytesPersec { get; private set; }
        public ulong ReadOperationsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalBytesPersec { get; private set; }
        public ulong TotalOperationsPersec { get; private set; }
        public uint WorkItemShortages { get; private set; }
        public ulong WriteBytesPersec { get; private set; }
        public ulong WriteOperationsPersec { get; private set; }

        public static PerfFormattedData_PerfNet_ServerWorkQueues[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_PerfNet_ServerWorkQueues[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfNet_ServerWorkQueues[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfNet_ServerWorkQueues");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfNet_ServerWorkQueues>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfNet_ServerWorkQueues
                {
                    ActiveThreads = (uint) managementObject.Properties["ActiveThreads"].Value,
                    AvailableThreads = (uint) managementObject.Properties["AvailableThreads"].Value,
                    AvailableWorkItems = (uint) managementObject.Properties["AvailableWorkItems"].Value,
                    BorrowedWorkItems = (uint) managementObject.Properties["BorrowedWorkItems"].Value,
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesSentPersec = (ulong) managementObject.Properties["BytesSentPersec"].Value,
                    BytesTransferredPersec = (ulong) managementObject.Properties["BytesTransferredPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContextBlocksQueuedPersec = (uint) managementObject.Properties["ContextBlocksQueuedPersec"].Value,
                    CurrentClients = (uint) managementObject.Properties["CurrentClients"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    QueueLength = (uint) managementObject.Properties["QueueLength"].Value,
                    ReadBytesPersec = (ulong) managementObject.Properties["ReadBytesPersec"].Value,
                    ReadOperationsPersec = (ulong) managementObject.Properties["ReadOperationsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalBytesPersec = (ulong) managementObject.Properties["TotalBytesPersec"].Value,
                    TotalOperationsPersec = (ulong) managementObject.Properties["TotalOperationsPersec"].Value,
                    WorkItemShortages = (uint) managementObject.Properties["WorkItemShortages"].Value,
                    WriteBytesPersec = (ulong) managementObject.Properties["WriteBytesPersec"].Value,
                    WriteOperationsPersec = (ulong) managementObject.Properties["WriteOperationsPersec"].Value
                });

            return list.ToArray();
        }
    }
}