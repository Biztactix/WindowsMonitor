using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __EventConsumer
    {
		public byte[] CreatorSID { get; private set; }
		public string MachineName { get; private set; }
		public uint MaximumQueueSize { get; private set; }

        public static IEnumerable<__EventConsumer> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<__EventConsumer> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__EventConsumer> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __EventConsumer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __EventConsumer
                {
                     CreatorSID = (byte[]) (managementObject.Properties["CreatorSID"]?.Value ?? new byte[0]),
		 MachineName = (string) (managementObject.Properties["MachineName"]?.Value ?? default(string)),
		 MaximumQueueSize = (uint) (managementObject.Properties["MaximumQueueSize"]?.Value ?? default(uint))
                };
        }
    }
}