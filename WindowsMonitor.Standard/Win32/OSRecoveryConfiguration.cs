using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
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

        public static IEnumerable<OSRecoveryConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<OSRecoveryConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OSRecoveryConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_OSRecoveryConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OSRecoveryConfiguration
                {
                     AutoReboot = (bool) (managementObject.Properties["AutoReboot"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DebugFilePath = (string) (managementObject.Properties["DebugFilePath"]?.Value ?? default(string)),
		 DebugInfoType = (uint) (managementObject.Properties["DebugInfoType"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ExpandedDebugFilePath = (string) (managementObject.Properties["ExpandedDebugFilePath"]?.Value ?? default(string)),
		 ExpandedMiniDumpDirectory = (string) (managementObject.Properties["ExpandedMiniDumpDirectory"]?.Value ?? default(string)),
		 KernelDumpOnly = (bool) (managementObject.Properties["KernelDumpOnly"]?.Value ?? default(bool)),
		 MiniDumpDirectory = (string) (managementObject.Properties["MiniDumpDirectory"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OverwriteExistingDebugFile = (bool) (managementObject.Properties["OverwriteExistingDebugFile"]?.Value ?? default(bool)),
		 SendAdminAlert = (bool) (managementObject.Properties["SendAdminAlert"]?.Value ?? default(bool)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 WriteDebugInfo = (bool) (managementObject.Properties["WriteDebugInfo"]?.Value ?? default(bool)),
		 WriteToSystemLog = (bool) (managementObject.Properties["WriteToSystemLog"]?.Value ?? default(bool))
                };
        }
    }
}