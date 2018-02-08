using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SettingCheck
    {
        public string Check { get; private set; }
        public string Setting { get; private set; }

        public static SettingCheck[] Retrieve(string remote, string username, string password)
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

        public static SettingCheck[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SettingCheck[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SettingCheck");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SettingCheck>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SettingCheck
                {
                    Check = (string) managementObject.Properties["Check"].Value,
                    Setting = (string) managementObject.Properties["Setting"].Value
                });

            return list.ToArray();
        }
    }
}