using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSWmi_GuidRegistrationInfo
    {
		public bool Active { get; private set; }
		public uint GuidCount { get; private set; }
		public dynamic[] GuidList { get; private set; }
		public string InstanceName { get; private set; }
		public uint Operation { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<MSWmi_GuidRegistrationInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSWmi_GuidRegistrationInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSWmi_GuidRegistrationInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSWmi_GuidRegistrationInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSWmi_GuidRegistrationInfo
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 GuidCount = (uint) (managementObject.Properties["GuidCount"]?.Value ?? default(uint)),
		 GuidList = (dynamic[]) (managementObject.Properties["GuidList"]?.Value ?? new dynamic[0]),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Operation = (uint) (managementObject.Properties["Operation"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}