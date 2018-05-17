using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TP_V2_CBEnqueue
    {
		public uint CallbackContext { get; private set; }
		public uint CallbackFunction { get; private set; }
		public uint PoolId { get; private set; }
		public uint SubProcessTag { get; private set; }
		public uint TaskId { get; private set; }

        public static IEnumerable<TP_V2_CBEnqueue> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TP_V2_CBEnqueue> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TP_V2_CBEnqueue> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TP_V2_CBEnqueue");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TP_V2_CBEnqueue
                {
                     CallbackContext = (uint) (managementObject.Properties["CallbackContext"]?.Value ?? default(uint)),
		 CallbackFunction = (uint) (managementObject.Properties["CallbackFunction"]?.Value ?? default(uint)),
		 PoolId = (uint) (managementObject.Properties["PoolId"]?.Value ?? default(uint)),
		 SubProcessTag = (uint) (managementObject.Properties["SubProcessTag"]?.Value ?? default(uint)),
		 TaskId = (uint) (managementObject.Properties["TaskId"]?.Value ?? default(uint))
                };
        }
    }
}