using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LogicalShareSecuritySetting
    {
        public string Caption { get; private set; }
        public uint ControlFlags { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public string SettingID { get; private set; }

        public static LogicalShareSecuritySetting[] Retrieve(string remote, string username, string password)
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

        public static LogicalShareSecuritySetting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LogicalShareSecuritySetting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalShareSecuritySetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LogicalShareSecuritySetting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LogicalShareSecuritySetting
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ControlFlags = (uint) managementObject.Properties["ControlFlags"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value
                });

            return list.ToArray();
        }
    }
}