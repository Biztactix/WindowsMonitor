using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DefragAnalysis
    {
        public ulong AverageFileSize { get; private set; }
        public double AverageFragmentsPerFile { get; private set; }
        public ulong AverageFreeSpacePerExtent { get; private set; }
        public ulong ClusterSize { get; private set; }
        public ulong ExcessFolderFragments { get; private set; }
        public uint FilePercentFragmentation { get; private set; }
        public ulong FragmentedFolders { get; private set; }
        public ulong FreeSpace { get; private set; }
        public uint FreeSpacePercent { get; private set; }
        public uint FreeSpacePercentFragmentation { get; private set; }
        public ulong LargestFreeSpaceExtent { get; private set; }
        public uint MFTPercentInUse { get; private set; }
        public ulong MFTRecordCount { get; private set; }
        public ulong PageFileSize { get; private set; }
        public ulong TotalExcessFragments { get; private set; }
        public ulong TotalFiles { get; private set; }
        public ulong TotalFolders { get; private set; }
        public ulong TotalFragmentedFiles { get; private set; }
        public ulong TotalFreeSpaceExtents { get; private set; }
        public ulong TotalMFTFragments { get; private set; }
        public ulong TotalMFTSize { get; private set; }
        public ulong TotalPageFileFragments { get; private set; }
        public uint TotalPercentFragmentation { get; private set; }
        public ulong TotalUnmovableFiles { get; private set; }
        public ulong UsedSpace { get; private set; }
        public string VolumeName { get; private set; }
        public ulong VolumeSize { get; private set; }

        public static DefragAnalysis[] Retrieve(string remote, string username, string password)
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

        public static DefragAnalysis[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DefragAnalysis[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DefragAnalysis");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DefragAnalysis>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DefragAnalysis
                {
                    AverageFileSize = (ulong) managementObject.Properties["AverageFileSize"].Value,
                    AverageFragmentsPerFile = (double) managementObject.Properties["AverageFragmentsPerFile"].Value,
                    AverageFreeSpacePerExtent = (ulong) managementObject.Properties["AverageFreeSpacePerExtent"].Value,
                    ClusterSize = (ulong) managementObject.Properties["ClusterSize"].Value,
                    ExcessFolderFragments = (ulong) managementObject.Properties["ExcessFolderFragments"].Value,
                    FilePercentFragmentation = (uint) managementObject.Properties["FilePercentFragmentation"].Value,
                    FragmentedFolders = (ulong) managementObject.Properties["FragmentedFolders"].Value,
                    FreeSpace = (ulong) managementObject.Properties["FreeSpace"].Value,
                    FreeSpacePercent = (uint) managementObject.Properties["FreeSpacePercent"].Value,
                    FreeSpacePercentFragmentation = (uint) managementObject.Properties["FreeSpacePercentFragmentation"]
                        .Value,
                    LargestFreeSpaceExtent = (ulong) managementObject.Properties["LargestFreeSpaceExtent"].Value,
                    MFTPercentInUse = (uint) managementObject.Properties["MFTPercentInUse"].Value,
                    MFTRecordCount = (ulong) managementObject.Properties["MFTRecordCount"].Value,
                    PageFileSize = (ulong) managementObject.Properties["PageFileSize"].Value,
                    TotalExcessFragments = (ulong) managementObject.Properties["TotalExcessFragments"].Value,
                    TotalFiles = (ulong) managementObject.Properties["TotalFiles"].Value,
                    TotalFolders = (ulong) managementObject.Properties["TotalFolders"].Value,
                    TotalFragmentedFiles = (ulong) managementObject.Properties["TotalFragmentedFiles"].Value,
                    TotalFreeSpaceExtents = (ulong) managementObject.Properties["TotalFreeSpaceExtents"].Value,
                    TotalMFTFragments = (ulong) managementObject.Properties["TotalMFTFragments"].Value,
                    TotalMFTSize = (ulong) managementObject.Properties["TotalMFTSize"].Value,
                    TotalPageFileFragments = (ulong) managementObject.Properties["TotalPageFileFragments"].Value,
                    TotalPercentFragmentation = (uint) managementObject.Properties["TotalPercentFragmentation"].Value,
                    TotalUnmovableFiles = (ulong) managementObject.Properties["TotalUnmovableFiles"].Value,
                    UsedSpace = (ulong) managementObject.Properties["UsedSpace"].Value,
                    VolumeName = (string) managementObject.Properties["VolumeName"].Value,
                    VolumeSize = (ulong) managementObject.Properties["VolumeSize"].Value
                });

            return list.ToArray();
        }
    }
}