using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSAgp_Information
    {
		public bool Active { get; private set; }
		public uint AgpCommand { get; private set; }
		public uint AgpStatus { get; private set; }
		public ulong ApertureBase { get; private set; }
		public uint ApertureLength { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSAgp_Information> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSAgp_Information> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSAgp_Information> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSAgp_Information");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSAgp_Information
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AgpCommand = (uint) (managementObject.Properties["AgpCommand"]?.Value ?? default(uint)),
		 AgpStatus = (uint) (managementObject.Properties["AgpStatus"]?.Value ?? default(uint)),
		 ApertureBase = (ulong) (managementObject.Properties["ApertureBase"]?.Value ?? default(ulong)),
		 ApertureLength = (uint) (managementObject.Properties["ApertureLength"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}