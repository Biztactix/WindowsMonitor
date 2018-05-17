using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_ReceiveQueueInfoArray
    {
		public uint ElementSize { get; private set; }
		public uint FirstElementOffset { get; private set; }
		public dynamic Header { get; private set; }
		public uint NumElements { get; private set; }
		public dynamic[] Queue { get; private set; }

        public static IEnumerable<MSNdis_ReceiveQueueInfoArray> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_ReceiveQueueInfoArray> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_ReceiveQueueInfoArray> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_ReceiveQueueInfoArray");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_ReceiveQueueInfoArray
                {
                     ElementSize = (uint) (managementObject.Properties["ElementSize"]?.Value ?? default(uint)),
		 FirstElementOffset = (uint) (managementObject.Properties["FirstElementOffset"]?.Value ?? default(uint)),
		 Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic)),
		 NumElements = (uint) (managementObject.Properties["NumElements"]?.Value ?? default(uint)),
		 Queue = (dynamic[]) (managementObject.Properties["Queue"]?.Value ?? new dynamic[0])
                };
        }
    }
}