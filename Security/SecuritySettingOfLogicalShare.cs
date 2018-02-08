using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SecuritySettingOfLogicalShare
    {
        public string Element { get; private set; }
        public string Setting { get; private set; }

        public static SecuritySettingOfLogicalShare[] Retrieve(string remote, string username, string password)
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

        public static SecuritySettingOfLogicalShare[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SecuritySettingOfLogicalShare[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecuritySettingOfLogicalShare");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SecuritySettingOfLogicalShare>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SecuritySettingOfLogicalShare
                {
                    Element = (string) managementObject.Properties["Element"].Value,
                    Setting = (string) managementObject.Properties["Setting"].Value
                });

            return list.ToArray();
        }
    }
}