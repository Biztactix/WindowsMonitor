using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SecuritySettingOwner
    {
        public string Owner { get; private set; }
        public string SecuritySetting { get; private set; }

        public static SecuritySettingOwner[] Retrieve(string remote, string username, string password)
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

        public static SecuritySettingOwner[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SecuritySettingOwner[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecuritySettingOwner");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SecuritySettingOwner>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SecuritySettingOwner
                {
                    Owner = (string) managementObject.Properties["Owner"].Value,
                    SecuritySetting = (string) managementObject.Properties["SecuritySetting"].Value
                });

            return list.ToArray();
        }
    }
}