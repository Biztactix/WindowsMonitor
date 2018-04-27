using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class WindowsMediaPlayer_WindowsMediaPlayerMetadata
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

        public static IEnumerable<WindowsMediaPlayer_WindowsMediaPlayerMetadata> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WindowsMediaPlayer_WindowsMediaPlayerMetadata> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WindowsMediaPlayer_WindowsMediaPlayerMetadata> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_WindowsMediaPlayer_WindowsMediaPlayerMetadata");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WindowsMediaPlayer_WindowsMediaPlayerMetadata
                {
                     AFTSExecutionTimems = (uint) (managementObject.Properties["AFTSExecutionTimems"]?.Value ?? default(uint)),
		 ArtExtractionTimems = (uint) (managementObject.Properties["ArtExtractionTimems"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CommitTimems = (uint) (managementObject.Properties["CommitTimems"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DirectoryChangeQueueLength = (uint) (managementObject.Properties["DirectoryChangeQueueLength"]?.Value ?? default(uint)),
		 DirtyDirectoryHitCount = (uint) (managementObject.Properties["DirtyDirectoryHitCount"]?.Value ?? default(uint)),
		 FileScanningThreadPrioirty = (uint) (managementObject.Properties["FileScanningThreadPrioirty"]?.Value ?? default(uint)),
		 FilesScannedPerMinute = (ulong) (managementObject.Properties["FilesScannedPerMinute"]?.Value ?? default(ulong)),
		 FilesScannedPerMinute_Base = (uint) (managementObject.Properties["FilesScannedPerMinute_Base"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GrovelerServiceRoutineExecutionsPerSecond = (ulong) (managementObject.Properties["GrovelerServiceRoutineExecutionsPerSecond"]?.Value ?? default(ulong)),
		 GrovelerServiceRoutineExecutionsPerSecond_Base = (uint) (managementObject.Properties["GrovelerServiceRoutineExecutionsPerSecond_Base"]?.Value ?? default(uint)),
		 LibraryDescriptionChangeNotificationsPerSecond = (ulong) (managementObject.Properties["LibraryDescriptionChangeNotificationsPerSecond"]?.Value ?? default(ulong)),
		 LibraryDescriptionChangeNotificationsPerSecond_Base = (uint) (managementObject.Properties["LibraryDescriptionChangeNotificationsPerSecond_Base"]?.Value ?? default(uint)),
		 LibraryDescriptionUpdatesPerSecond = (ulong) (managementObject.Properties["LibraryDescriptionUpdatesPerSecond"]?.Value ?? default(ulong)),
		 LibraryDescriptionUpdatesPerSecond_Base = (uint) (managementObject.Properties["LibraryDescriptionUpdatesPerSecond_Base"]?.Value ?? default(uint)),
		 MonitoredFolderUpdatesPerSecond = (ulong) (managementObject.Properties["MonitoredFolderUpdatesPerSecond"]?.Value ?? default(ulong)),
		 MonitoredFolderUpdatesPerSecond_Base = (uint) (managementObject.Properties["MonitoredFolderUpdatesPerSecond_Base"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NormalizationTimems = (uint) (managementObject.Properties["NormalizationTimems"]?.Value ?? default(uint)),
		 PropertyExtractionTimems = (uint) (managementObject.Properties["PropertyExtractionTimems"]?.Value ?? default(uint)),
		 ReorganizeTimems = (uint) (managementObject.Properties["ReorganizeTimems"]?.Value ?? default(uint)),
		 ScanningState = (uint) (managementObject.Properties["ScanningState"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TimestampDirectoryHitCount = (uint) (managementObject.Properties["TimestampDirectoryHitCount"]?.Value ?? default(uint)),
		 URLClassificationTimems = (uint) (managementObject.Properties["URLClassificationTimems"]?.Value ?? default(uint))
                };
        }
    }
}