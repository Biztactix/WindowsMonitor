using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SecuritySettingGroup
    {
        public string Group { get; private set; }
        public string SecuritySetting { get; private set; }

        public static SecuritySettingGroup[] Retrieve(string remote, string username, string password)
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

        public static SecuritySettingGroup[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SecuritySettingGroup[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecuritySettingGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SecuritySettingGroup>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SecuritySettingGroup
                {
                    Group = (string) managementObject.Properties["Group"].Value,
                    SecuritySetting = (string) managementObject.Properties["SecuritySetting"].Value
                });

            return list.ToArray();
        }
    }
}