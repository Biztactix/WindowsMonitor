using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_StorageSpacesVirtualDisk
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

        public static PerfRawData_Counters_StorageSpacesVirtualDisk[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_StorageSpacesVirtualDisk[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_StorageSpacesVirtualDisk[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_StorageSpacesVirtualDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_StorageSpacesVirtualDisk>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_StorageSpacesVirtualDisk
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    VirtualDiskActive = (ulong) managementObject.Properties["VirtualDiskActive"].Value,
                    VirtualDiskActiveBytes = (ulong) managementObject.Properties["VirtualDiskActiveBytes"].Value,
                    VirtualDiskMissing = (ulong) managementObject.Properties["VirtualDiskMissing"].Value,
                    VirtualDiskMissingBytes = (ulong) managementObject.Properties["VirtualDiskMissingBytes"].Value,
                    VirtualDiskNeedReallocation = (ulong) managementObject.Properties["VirtualDiskNeedReallocation"]
                        .Value,
                    VirtualDiskNeedReallocationBytes =
                        (ulong) managementObject.Properties["VirtualDiskNeedReallocationBytes"].Value,
                    VirtualDiskNeedRegeneration = (ulong) managementObject.Properties["VirtualDiskNeedRegeneration"]
                        .Value,
                    VirtualDiskNeedRegenerationBytes =
                        (ulong) managementObject.Properties["VirtualDiskNeedRegenerationBytes"].Value,
                    VirtualDiskPendingDeletion =
                        (ulong) managementObject.Properties["VirtualDiskPendingDeletion"].Value,
                    VirtualDiskPendingDeletionBytes =
                        (ulong) managementObject.Properties["VirtualDiskPendingDeletionBytes"].Value,
                    VirtualDiskRegenerating = (ulong) managementObject.Properties["VirtualDiskRegenerating"].Value,
                    VirtualDiskRegeneratingBytes = (ulong) managementObject.Properties["VirtualDiskRegeneratingBytes"]
                        .Value,
                    VirtualDiskStale = (ulong) managementObject.Properties["VirtualDiskStale"].Value,
                    VirtualDiskStaleBytes = (ulong) managementObject.Properties["VirtualDiskStaleBytes"].Value,
                    VirtualDiskTotal = (ulong) managementObject.Properties["VirtualDiskTotal"].Value,
                    VirtualDiskTotalBytes = (ulong) managementObject.Properties["VirtualDiskTotalBytes"].Value
                });

            return list.ToArray();
        }
    }
}