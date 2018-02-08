using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class AutochkSetting
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string SettingID { get; private set; }
        public uint UserInputDelay { get; private set; }

        public static AutochkSetting[] Retrieve(string remote, string username, string password)
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

        public static AutochkSetting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static AutochkSetting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_AutochkSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<AutochkSetting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new AutochkSetting
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    UserInputDelay = (uint) managementObject.Properties["UserInputDelay"].Value
                });

            return list.ToArray();
        }
    }
}