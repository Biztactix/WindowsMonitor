using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SystemOperatingSystem
    {
        public string GroupComponent { get; private set; }
        public string PartComponent { get; private set; }
        public bool PrimaryOS { get; private set; }

        public static SystemOperatingSystem[] Retrieve(string remote, string username, string password)
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

        public static SystemOperatingSystem[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SystemOperatingSystem[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SystemOperatingSystem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SystemOperatingSystem>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SystemOperatingSystem
                {
                    GroupComponent = (string) managementObject.Properties["GroupComponent"].Value,
                    PartComponent = (string) managementObject.Properties["PartComponent"].Value,
                    PrimaryOS = (bool) managementObject.Properties["PrimaryOS"].Value
                });

            return list.ToArray();
        }
    }
}