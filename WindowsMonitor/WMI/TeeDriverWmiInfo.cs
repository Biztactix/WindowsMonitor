using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TeeDriverWmiInfo
    {
		public bool Active { get; private set; }
		public uint AsyncEvents { get; private set; }
		public uint D0ix { get; private set; }
		public uint FwNotfication { get; private set; }
		public string InstanceName { get; private set; }
		public bool Pg { get; private set; }
		public uint Pgi_Alivness { get; private set; }
		public uint RTD3 { get; private set; }

        public static IEnumerable<TeeDriverWmiInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TeeDriverWmiInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TeeDriverWmiInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TeeDriverWmiInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TeeDriverWmiInfo
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AsyncEvents = (uint) (managementObject.Properties["AsyncEvents"]?.Value ?? default(uint)),
		 D0ix = (uint) (managementObject.Properties["D0ix"]?.Value ?? default(uint)),
		 FwNotfication = (uint) (managementObject.Properties["FwNotfication"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Pg = (bool) (managementObject.Properties["Pg"]?.Value ?? default(bool)),
		 Pgi_Alivness = (uint) (managementObject.Properties["Pgi_Alivness"]?.Value ?? default(uint)),
		 RTD3 = (uint) (managementObject.Properties["RTD3"]?.Value ?? default(uint))
                };
        }
    }
}