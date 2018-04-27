using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class Win32Reg_AddRemovePrograms64
    {
		public string DisplayName { get; private set; }
		public string InstallDate { get; private set; }
		public string ProdID { get; private set; }
		public string Publisher { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<Win32Reg_AddRemovePrograms64> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Win32Reg_AddRemovePrograms64> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Win32Reg_AddRemovePrograms64> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32Reg_AddRemovePrograms64");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32Reg_AddRemovePrograms64
                {
                     DisplayName = (string) (managementObject.Properties["DisplayName"]?.Value ?? default(string)),
		 InstallDate = (string) (managementObject.Properties["InstallDate"]?.Value ?? default(string)),
		 ProdID = (string) (managementObject.Properties["ProdID"]?.Value ?? default(string)),
		 Publisher = (string) (managementObject.Properties["Publisher"]?.Value ?? default(string)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}