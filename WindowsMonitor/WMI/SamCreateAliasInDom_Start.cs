using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SamCreateAliasInDom_Start
    {
		public string Client { get; private set; }
		public string Sam { get; private set; }
		public string Sid { get; private set; }
		public uint Version { get; private set; }

        public static IEnumerable<SamCreateAliasInDom_Start> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<SamCreateAliasInDom_Start> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SamCreateAliasInDom_Start> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SamCreateAliasInDom_Start");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SamCreateAliasInDom_Start
                {
                     Client = (string) (managementObject.Properties["Client"]?.Value ?? default(string)),
		 Sam = (string) (managementObject.Properties["Sam"]?.Value ?? default(string)),
		 Sid = (string) (managementObject.Properties["Sid"]?.Value ?? default(string)),
		 Version = (uint) (managementObject.Properties["Version"]?.Value ?? default(uint))
                };
        }
    }
}