using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class DCOMApplicationSetting
    {
		public string AppID { get; private set; }
		public uint AuthenticationLevel { get; private set; }
		public string Caption { get; private set; }
		public string CustomSurrogate { get; private set; }
		public string Description { get; private set; }
		public bool EnableAtStorageActivation { get; private set; }
		public string LocalService { get; private set; }
		public string RemoteServerName { get; private set; }
		public string RunAsUser { get; private set; }
		public string ServiceParameters { get; private set; }
		public string SettingID { get; private set; }
		public bool UseSurrogate { get; private set; }

        public static IEnumerable<DCOMApplicationSetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DCOMApplicationSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DCOMApplicationSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DCOMApplicationSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DCOMApplicationSetting
                {
                     AppID = (string) (managementObject.Properties["AppID"]?.Value ?? default(string)),
		 AuthenticationLevel = (uint) (managementObject.Properties["AuthenticationLevel"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CustomSurrogate = (string) (managementObject.Properties["CustomSurrogate"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EnableAtStorageActivation = (bool) (managementObject.Properties["EnableAtStorageActivation"]?.Value ?? default(bool)),
		 LocalService = (string) (managementObject.Properties["LocalService"]?.Value ?? default(string)),
		 RemoteServerName = (string) (managementObject.Properties["RemoteServerName"]?.Value ?? default(string)),
		 RunAsUser = (string) (managementObject.Properties["RunAsUser"]?.Value ?? default(string)),
		 ServiceParameters = (string) (managementObject.Properties["ServiceParameters"]?.Value ?? default(string)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 UseSurrogate = (bool) (managementObject.Properties["UseSurrogate"]?.Value ?? default(bool))
                };
        }
    }
}