using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PerfNet_ServerWorkQueues
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

        public static IEnumerable<PerfNet_ServerWorkQueues> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfNet_ServerWorkQueues> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfNet_ServerWorkQueues> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfNet_ServerWorkQueues");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfNet_ServerWorkQueues
                {
                     ActiveThreads = (uint) (managementObject.Properties["ActiveThreads"]?.Value ?? default(uint)),
		 AvailableThreads = (uint) (managementObject.Properties["AvailableThreads"]?.Value ?? default(uint)),
		 AvailableWorkItems = (uint) (managementObject.Properties["AvailableWorkItems"]?.Value ?? default(uint)),
		 BorrowedWorkItems = (uint) (managementObject.Properties["BorrowedWorkItems"]?.Value ?? default(uint)),
		 BytesReceivedPersec = (ulong) (managementObject.Properties["BytesReceivedPersec"]?.Value ?? default(ulong)),
		 BytesSentPersec = (ulong) (managementObject.Properties["BytesSentPersec"]?.Value ?? default(ulong)),
		 BytesTransferredPersec = (ulong) (managementObject.Properties["BytesTransferredPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ContextBlocksQueuedPersec = (uint) (managementObject.Properties["ContextBlocksQueuedPersec"]?.Value ?? default(uint)),
		 CurrentClients = (uint) (managementObject.Properties["CurrentClients"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 QueueLength = (uint) (managementObject.Properties["QueueLength"]?.Value ?? default(uint)),
		 ReadBytesPersec = (ulong) (managementObject.Properties["ReadBytesPersec"]?.Value ?? default(ulong)),
		 ReadOperationsPersec = (ulong) (managementObject.Properties["ReadOperationsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalBytesPersec = (ulong) (managementObject.Properties["TotalBytesPersec"]?.Value ?? default(ulong)),
		 TotalOperationsPersec = (ulong) (managementObject.Properties["TotalOperationsPersec"]?.Value ?? default(ulong)),
		 WorkItemShortages = (uint) (managementObject.Properties["WorkItemShortages"]?.Value ?? default(uint)),
		 WriteBytesPersec = (ulong) (managementObject.Properties["WriteBytesPersec"]?.Value ?? default(ulong)),
		 WriteOperationsPersec = (ulong) (managementObject.Properties["WriteOperationsPersec"]?.Value ?? default(ulong))
                };
        }
    }
}