using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSChangerProblemDeviceError
    {
		public bool Active { get; private set; }
		public uint ChangerProblemType { get; private set; }
		public string InstanceName { get; private set; }

        public static IEnumerable<MSChangerProblemDeviceError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSChangerProblemDeviceError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSChangerProblemDeviceError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSChangerProblemDeviceError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSChangerProblemDeviceError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 ChangerProblemType = (uint) (managementObject.Properties["ChangerProblemType"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string))
                };
        }
    }
}