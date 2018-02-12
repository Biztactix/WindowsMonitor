using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_StorageSpacesVirtualDisk
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong VirtualDiskActive { get; private set; }
		public ulong VirtualDiskActiveBytes { get; private set; }
		public ulong VirtualDiskMissing { get; private set; }
		public ulong VirtualDiskMissingBytes { get; private set; }
		public ulong VirtualDiskNeedReallocation { get; private set; }
		public ulong VirtualDiskNeedReallocationBytes { get; private set; }
		public ulong VirtualDiskNeedRegeneration { get; private set; }
		public ulong VirtualDiskNeedRegenerationBytes { get; private set; }
		public ulong VirtualDiskPendingDeletion { get; private set; }
		public ulong VirtualDiskPendingDeletionBytes { get; private set; }
		public ulong VirtualDiskRegenerating { get; private set; }
		public ulong VirtualDiskRegeneratingBytes { get; private set; }
		public ulong VirtualDiskStale { get; private set; }
		public ulong VirtualDiskStaleBytes { get; private set; }
		public ulong VirtualDiskTotal { get; private set; }
		public ulong VirtualDiskTotalBytes { get; private set; }

        public static IEnumerable<Counters_StorageSpacesVirtualDisk> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_StorageSpacesVirtualDisk> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_StorageSpacesVirtualDisk> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_StorageSpacesVirtualDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_StorageSpacesVirtualDisk
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 VirtualDiskActive = (ulong) (managementObject.Properties["VirtualDiskActive"]?.Value ?? default(ulong)),
		 VirtualDiskActiveBytes = (ulong) (managementObject.Properties["VirtualDiskActiveBytes"]?.Value ?? default(ulong)),
		 VirtualDiskMissing = (ulong) (managementObject.Properties["VirtualDiskMissing"]?.Value ?? default(ulong)),
		 VirtualDiskMissingBytes = (ulong) (managementObject.Properties["VirtualDiskMissingBytes"]?.Value ?? default(ulong)),
		 VirtualDiskNeedReallocation = (ulong) (managementObject.Properties["VirtualDiskNeedReallocation"]?.Value ?? default(ulong)),
		 VirtualDiskNeedReallocationBytes = (ulong) (managementObject.Properties["VirtualDiskNeedReallocationBytes"]?.Value ?? default(ulong)),
		 VirtualDiskNeedRegeneration = (ulong) (managementObject.Properties["VirtualDiskNeedRegeneration"]?.Value ?? default(ulong)),
		 VirtualDiskNeedRegenerationBytes = (ulong) (managementObject.Properties["VirtualDiskNeedRegenerationBytes"]?.Value ?? default(ulong)),
		 VirtualDiskPendingDeletion = (ulong) (managementObject.Properties["VirtualDiskPendingDeletion"]?.Value ?? default(ulong)),
		 VirtualDiskPendingDeletionBytes = (ulong) (managementObject.Properties["VirtualDiskPendingDeletionBytes"]?.Value ?? default(ulong)),
		 VirtualDiskRegenerating = (ulong) (managementObject.Properties["VirtualDiskRegenerating"]?.Value ?? default(ulong)),
		 VirtualDiskRegeneratingBytes = (ulong) (managementObject.Properties["VirtualDiskRegeneratingBytes"]?.Value ?? default(ulong)),
		 VirtualDiskStale = (ulong) (managementObject.Properties["VirtualDiskStale"]?.Value ?? default(ulong)),
		 VirtualDiskStaleBytes = (ulong) (managementObject.Properties["VirtualDiskStaleBytes"]?.Value ?? default(ulong)),
		 VirtualDiskTotal = (ulong) (managementObject.Properties["VirtualDiskTotal"]?.Value ?? default(ulong)),
		 VirtualDiskTotalBytes = (ulong) (managementObject.Properties["VirtualDiskTotalBytes"]?.Value ?? default(ulong))
                };
        }
    }
}