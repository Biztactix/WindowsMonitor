using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class OSRecoveryConfiguration
    {
        public bool AutoReboot { get; private set; }
        public string Caption { get; private set; }
        public string DebugFilePath { get; private set; }
        public uint DebugInfoType { get; private set; }
        public string Description { get; private set; }
        public string ExpandedDebugFilePath { get; private set; }
        public string ExpandedMiniDumpDirectory { get; private set; }
        public bool KernelDumpOnly { get; private set; }
        public string MiniDumpDirectory { get; private set; }
        public string Name { get; private set; }
        public bool OverwriteExistingDebugFile { get; private set; }
        public bool SendAdminAlert { get; private set; }
        public string SettingID { get; private set; }
        public bool WriteDebugInfo { get; private set; }
        public bool WriteToSystemLog { get; private set; }

        public static OSRecoveryConfiguration[] Retrieve(string remote, string username, string password)
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

        public static OSRecoveryConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static OSRecoveryConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_OSRecoveryConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<OSRecoveryConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new OSRecoveryConfiguration
                {
                    AutoReboot = (bool) managementObject.Properties["AutoReboot"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DebugFilePath = (string) managementObject.Properties["DebugFilePath"].Value,
                    DebugInfoType = (uint) managementObject.Properties["DebugInfoType"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExpandedDebugFilePath = (string) managementObject.Properties["ExpandedDebugFilePath"].Value,
                    ExpandedMiniDumpDirectory = (string) managementObject.Properties["ExpandedMiniDumpDirectory"].Value,
                    KernelDumpOnly = (bool) managementObject.Properties["KernelDumpOnly"].Value,
                    MiniDumpDirectory = (string) managementObject.Properties["MiniDumpDirectory"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OverwriteExistingDebugFile = (bool) managementObject.Properties["OverwriteExistingDebugFile"].Value,
                    SendAdminAlert = (bool) managementObject.Properties["SendAdminAlert"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    WriteDebugInfo = (bool) managementObject.Properties["WriteDebugInfo"].Value,
                    WriteToSystemLog = (bool) managementObject.Properties["WriteToSystemLog"].Value
                });

            return list.ToArray();
        }
    }
}