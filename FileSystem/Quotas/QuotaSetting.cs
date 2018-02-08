using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class QuotaSetting
    {
        public string Caption { get; private set; }
        public long DefaultLimit { get; private set; }
        public long DefaultWarningLimit { get; private set; }
        public string Description { get; private set; }
        public bool ExceededNotification { get; private set; }
        public string SettingID { get; private set; }
        public uint State { get; private set; }
        public string VolumePath { get; private set; }
        public bool WarningExceededNotification { get; private set; }

        public static QuotaSetting[] Retrieve(string remote, string username, string password)
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

        public static QuotaSetting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static QuotaSetting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_QuotaSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<QuotaSetting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new QuotaSetting
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DefaultLimit = (long) managementObject.Properties["DefaultLimit"].Value,
                    DefaultWarningLimit = (long) managementObject.Properties["DefaultWarningLimit"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExceededNotification = (bool) managementObject.Properties["ExceededNotification"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    State = (uint) managementObject.Properties["State"].Value,
                    VolumePath = (string) managementObject.Properties["VolumePath"].Value,
                    WarningExceededNotification = (bool) managementObject.Properties["WarningExceededNotification"]
                        .Value
                });

            return list.ToArray();
        }
    }
}