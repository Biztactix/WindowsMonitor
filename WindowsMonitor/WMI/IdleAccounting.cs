using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class IdleAccounting
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint ResetCount { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong StartTime { get; private set; }
		public dynamic[] State { get; private set; }
		public uint StateCount { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint TotalTransitions { get; private set; }

        public static IEnumerable<IdleAccounting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IdleAccounting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IdleAccounting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM IdleAccounting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IdleAccounting
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 ResetCount = (uint) (managementObject.Properties["ResetCount"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 StartTime = (ulong) (managementObject.Properties["StartTime"]?.Value ?? default(ulong)),
		 State = (dynamic[]) (managementObject.Properties["State"]?.Value ?? new dynamic[0]),
		 StateCount = (uint) (managementObject.Properties["StateCount"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TotalTransitions = (uint) (managementObject.Properties["TotalTransitions"]?.Value ?? default(uint))
                };
        }
    }
}