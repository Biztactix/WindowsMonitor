using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSStorageDriver_FailurePredictStatus
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public bool PredictFailure { get; private set; }
		public uint Reason { get; private set; }

        public static IEnumerable<MSStorageDriver_FailurePredictStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSStorageDriver_FailurePredictStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSStorageDriver_FailurePredictStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSStorageDriver_FailurePredictStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSStorageDriver_FailurePredictStatus
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 PredictFailure = (bool) (managementObject.Properties["PredictFailure"]?.Value ?? default(bool)),
		 Reason = (uint) (managementObject.Properties["Reason"]?.Value ?? default(uint))
                };
        }
    }
}