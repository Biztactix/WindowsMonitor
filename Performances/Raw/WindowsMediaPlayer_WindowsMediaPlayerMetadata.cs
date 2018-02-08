using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata
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
        public uint FilesScannedPerMinute_Base { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GrovelerServiceRoutineExecutionsPerSecond { get; private set; }
        public uint GrovelerServiceRoutineExecutionsPerSecond_Base { get; private set; }
        public ulong LibraryDescriptionChangeNotificationsPerSecond { get; private set; }
        public uint LibraryDescriptionChangeNotificationsPerSecond_Base { get; private set; }
        public ulong LibraryDescriptionUpdatesPerSecond { get; private set; }
        public uint LibraryDescriptionUpdatesPerSecond_Base { get; private set; }
        public ulong MonitoredFolderUpdatesPerSecond { get; private set; }
        public uint MonitoredFolderUpdatesPerSecond_Base { get; private set; }
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

        public static PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve(string remote,
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

        public static PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata
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
                    FilesScannedPerMinute_Base = (uint) managementObject.Properties["FilesScannedPerMinute_Base"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GrovelerServiceRoutineExecutionsPerSecond = (ulong) managementObject
                        .Properties["GrovelerServiceRoutineExecutionsPerSecond"].Value,
                    GrovelerServiceRoutineExecutionsPerSecond_Base = (uint) managementObject
                        .Properties["GrovelerServiceRoutineExecutionsPerSecond_Base"].Value,
                    LibraryDescriptionChangeNotificationsPerSecond = (ulong) managementObject
                        .Properties["LibraryDescriptionChangeNotificationsPerSecond"].Value,
                    LibraryDescriptionChangeNotificationsPerSecond_Base = (uint) managementObject
                        .Properties["LibraryDescriptionChangeNotificationsPerSecond_Base"].Value,
                    LibraryDescriptionUpdatesPerSecond =
                        (ulong) managementObject.Properties["LibraryDescriptionUpdatesPerSecond"].Value,
                    LibraryDescriptionUpdatesPerSecond_Base = (uint) managementObject
                        .Properties["LibraryDescriptionUpdatesPerSecond_Base"].Value,
                    MonitoredFolderUpdatesPerSecond =
                        (ulong) managementObject.Properties["MonitoredFolderUpdatesPerSecond"].Value,
                    MonitoredFolderUpdatesPerSecond_Base = (uint) managementObject
                        .Properties["MonitoredFolderUpdatesPerSecond_Base"].Value,
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