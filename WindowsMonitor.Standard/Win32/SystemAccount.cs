using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class SystemAccount
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Domain { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool LocalAccount { get; private set; }
		public string Name { get; private set; }
		public string SID { get; private set; }
		public byte SIDType { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<SystemAccount> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemAccount> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemAccount> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SystemAccount");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemAccount
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Domain = (string) (managementObject.Properties["Domain"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LocalAccount = (bool) (managementObject.Properties["LocalAccount"]?.Value ?? default(bool)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SID = (string) (managementObject.Properties["SID"]?.Value ?? default(string)),
		 SIDType = (byte) (managementObject.Properties["SIDType"]?.Value ?? default(byte)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}