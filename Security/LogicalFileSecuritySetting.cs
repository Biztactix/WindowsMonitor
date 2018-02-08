using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LogicalFileSecuritySetting
    {
        public string Caption { get; private set; }
        public uint ControlFlags { get; private set; }
        public string Description { get; private set; }
        public bool OwnerPermissions { get; private set; }
        public string Path { get; private set; }
        public string SettingID { get; private set; }

        public static LogicalFileSecuritySetting[] Retrieve(string remote, string username, string password)
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

        public static LogicalFileSecuritySetting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LogicalFileSecuritySetting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalFileSecuritySetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LogicalFileSecuritySetting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LogicalFileSecuritySetting
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ControlFlags = (uint) managementObject.Properties["ControlFlags"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    OwnerPermissions = (bool) managementObject.Properties["OwnerPermissions"].Value,
                    Path = (string) managementObject.Properties["Path"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value
                });

            return list.ToArray();
        }
    }
}