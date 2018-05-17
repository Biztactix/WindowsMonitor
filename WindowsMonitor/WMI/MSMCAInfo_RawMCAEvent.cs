using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAInfo_RawMCAEvent
    {
		public bool Active { get; private set; }
		public uint Count { get; private set; }
		public string InstanceName { get; private set; }
		public dynamic[] Records { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<MSMCAInfo_RawMCAEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAInfo_RawMCAEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAInfo_RawMCAEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAInfo_RawMCAEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAInfo_RawMCAEvent
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Records = (dynamic[]) (managementObject.Properties["Records"]?.Value ?? new dynamic[0]),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}