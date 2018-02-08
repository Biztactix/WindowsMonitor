using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata
    {
        public uint AFTSExecutionTimems { get; private set; }
        public uint ArtExtractionTimems { get; private set; }
        public string Caption { get; private set; }
        public uint CommitTimems { get; private set; }
        public string Description { get; private set; }
        public uint DirectoryChangeQueueLength { get; private set; }
        public uint DirtyDirectoryHitCount { get; private set; }
        public uint FileScanningThreadPrioirty { get; private set; }
        public ulong FilesScannedPerMinute { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GrovelerServiceRoutineExecutionsPerSecond { get; private set; }
        public ulong LibraryDescriptionChangeNotificationsPerSecond { get; private set; }
        public ulong LibraryDescriptionUpdatesPerSecond { get; private set; }
        public ulong MonitoredFolderUpdatesPerSecond { get; private set; }
        public string Name { get; private set; }
        public uint NormalizationTimems { get; private set; }
        public uint PropertyExtractionTimems { get; private set; }
        public uint ReorganizeTimems { get; private set; }
        public uint ScanningState { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TimestampDirectoryHitCount { get; private set; }
        public uint URLClassificationTimems { get; private set; }

        public static PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve(string remote,
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

        public static PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_WindowsMediaPlayer_WindowsMediaPlayerMetadata
                {
                    AFTSExecutionTimems = (uint) managementObject.Properties["AFTSExecutionTimems"].Value,
                    ArtExtractionTimems = (uint) managementObject.Properties["ArtExtractionTimems"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommitTimems = (uint) managementObject.Properties["CommitTimems"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DirectoryChangeQueueLength = (uint) managementObject.Properties["DirectoryChangeQueueLength"].Value,
                    DirtyDirectoryHitCount = (uint) managementObject.Properties["DirtyDirectoryHitCount"].Value,
                    FileScanningThreadPrioirty = (uint) managementObject.Properties["FileScanningThreadPrioirty"].Value,
                    FilesScannedPerMinute = (ulong) managementObject.Properties["FilesScannedPerMinute"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GrovelerServiceRoutineExecutionsPerSecond = (ulong) managementObject
                        .Properties["GrovelerServiceRoutineExecutionsPerSecond"].Value,
                    LibraryDescriptionChangeNotificationsPerSecond = (ulong) managementObject
                        .Properties["LibraryDescriptionChangeNotificationsPerSecond"].Value,
                    LibraryDescriptionUpdatesPerSecond =
                        (ulong) managementObject.Properties["LibraryDescriptionUpdatesPerSecond"].Value,
                    MonitoredFolderUpdatesPerSecond =
                        (ulong) managementObject.Properties["MonitoredFolderUpdatesPerSecond"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NormalizationTimems = (uint) managementObject.Properties["NormalizationTimems"].Value,
                    PropertyExtractionTimems = (uint) managementObject.Properties["PropertyExtractionTimems"].Value,
                    ReorganizeTimems = (uint) managementObject.Properties["ReorganizeTimems"].Value,
                    ScanningState = (uint) managementObject.Properties["ScanningState"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TimestampDirectoryHitCount = (uint) managementObject.Properties["TimestampDirectoryHitCount"].Value,
                    URLClassificationTimems = (uint) managementObject.Properties["URLClassificationTimems"].Value
                });

            return list.ToArray();
        }
    }
}