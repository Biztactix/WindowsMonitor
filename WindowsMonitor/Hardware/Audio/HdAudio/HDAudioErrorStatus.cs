using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class HDAudioErrorStatus
    {
		public bool Active { get; private set; }
		public dynamic ControllerErrorStatus { get; private set; }
		public dynamic[] EngineErrorStatus { get; private set; }
		public string InstanceName { get; private set; }
		public uint NumEngines { get; private set; }

        public static IEnumerable<HDAudioErrorStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<HDAudioErrorStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HDAudioErrorStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HDAudioErrorStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HDAudioErrorStatus
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 ControllerErrorStatus = (dynamic) (managementObject.Properties["ControllerErrorStatus"]?.Value ?? default(dynamic)),
		 EngineErrorStatus = (dynamic[]) (managementObject.Properties["EngineErrorStatus"]?.Value ?? new dynamic[0]),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 NumEngines = (uint) (managementObject.Properties["NumEngines"]?.Value ?? default(uint))
                };
        }
    }
}