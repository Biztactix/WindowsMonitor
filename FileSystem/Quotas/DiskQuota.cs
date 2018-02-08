using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DiskQuota
    {
        public ulong DiskSpaceUsed { get; private set; }
        public ulong Limit { get; private set; }
        public string QuotaVolume { get; private set; }
        public uint Status { get; private set; }
        public string User { get; private set; }
        public ulong WarningLimit { get; private set; }

        public static DiskQuota[] Retrieve(string remote, string username, string password)
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

        public static DiskQuota[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DiskQuota[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DiskQuota");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DiskQuota>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DiskQuota
                {
                    DiskSpaceUsed = (ulong) managementObject.Properties["DiskSpaceUsed"].Value,
                    Limit = (ulong) managementObject.Properties["Limit"].Value,
                    QuotaVolume = (string) managementObject.Properties["QuotaVolume"].Value,
                    Status = (uint) managementObject.Properties["Status"].Value,
                    User = (string) managementObject.Properties["User"].Value,
                    WarningLimit = (ulong) managementObject.Properties["WarningLimit"].Value
                });

            return list.ToArray();
        }
    }
}