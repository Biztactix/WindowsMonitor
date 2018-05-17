using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_TypeGroup1
    {
		public uint Flags { get; private set; }
		public uint Index { get; private set; }
		public long InitialTime { get; private set; }
		public uint KeyHandle { get; private set; }
		public string KeyName { get; private set; }
		public uint Status { get; private set; }

        public static IEnumerable<Registry_TypeGroup1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_TypeGroup1
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 InitialTime = (long) (managementObject.Properties["InitialTime"]?.Value ?? default(long)),
		 KeyHandle = (uint) (managementObject.Properties["KeyHandle"]?.Value ?? default(uint)),
		 KeyName = (string) (managementObject.Properties["KeyName"]?.Value ?? default(string)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint))
                };
        }
    }
}