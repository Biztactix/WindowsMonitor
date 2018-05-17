using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSVerifierIrpLogInformation
    {
		public bool Active { get; private set; }
		public uint DeviceType { get; private set; }
		public dynamic[] Entries { get; private set; }
		public uint EntryCount { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSVerifierIrpLogInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSVerifierIrpLogInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSVerifierIrpLogInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSVerifierIrpLogInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSVerifierIrpLogInformation
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 DeviceType = (uint) (managementObject.Properties["DeviceType"]?.Value ?? default(uint)),
		 Entries = (dynamic[]) (managementObject.Properties["Entries"]?.Value ?? new dynamic[0]),
		 EntryCount = (uint) (managementObject.Properties["EntryCount"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}