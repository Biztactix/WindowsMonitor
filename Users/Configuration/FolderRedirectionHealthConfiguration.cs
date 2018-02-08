using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirectionHealthConfiguration
    {
        public uint LastSyncDurationCautionInHours { get; private set; }
        public uint LastSyncDurationUnhealthyInHours { get; private set; }

        public static FolderRedirectionHealthConfiguration[] Retrieve(string remote, string username, string password)
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

        public static FolderRedirectionHealthConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static FolderRedirectionHealthConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirectionHealthConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<FolderRedirectionHealthConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new FolderRedirectionHealthConfiguration
                {
                    LastSyncDurationCautionInHours =
                        (uint) managementObject.Properties["LastSyncDurationCautionInHours"].Value,
                    LastSyncDurationUnhealthyInHours =
                        (uint) managementObject.Properties["LastSyncDurationUnhealthyInHours"].Value
                });

            return list.ToArray();
        }
    }
}