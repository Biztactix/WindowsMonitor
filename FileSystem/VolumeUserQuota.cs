using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class VolumeUserQuota
    {
        public string Account { get; private set; }
        public ulong DiskSpaceUsed { get; private set; }
        public ulong Limit { get; private set; }
        public uint Status { get; private set; }
        public string Volume { get; private set; }
        public ulong WarningLimit { get; private set; }

        public static VolumeUserQuota[] Retrieve(string remote, string username, string password)
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

        public static VolumeUserQuota[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static VolumeUserQuota[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_VolumeUserQuota");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<VolumeUserQuota>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new VolumeUserQuota
                {
                    Account = (string) managementObject.Properties["Account"].Value,
                    DiskSpaceUsed = (ulong) managementObject.Properties["DiskSpaceUsed"].Value,
                    Limit = (ulong) managementObject.Properties["Limit"].Value,
                    Status = (uint) managementObject.Properties["Status"].Value,
                    Volume = (string) managementObject.Properties["Volume"].Value,
                    WarningLimit = (ulong) managementObject.Properties["WarningLimit"].Value
                });

            return list.ToArray();
        }
    }
}