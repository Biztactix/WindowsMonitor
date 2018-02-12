using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ShadowProvider
    {
		public string Caption { get; private set; }
		public string CLSID { get; private set; }
		public string Description { get; private set; }
		public string ID { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public string Status { get; private set; }
		public uint Type { get; private set; }
		public string Version { get; private set; }
		public string VersionID { get; private set; }

        public static IEnumerable<ShadowProvider> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ShadowProvider> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ShadowProvider> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShadowProvider");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ShadowProvider
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CLSID = (string) (managementObject.Properties["CLSID"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ID = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 VersionID = (string) (managementObject.Properties["VersionID"]?.Value ?? default(string))
                };
        }
    }
}