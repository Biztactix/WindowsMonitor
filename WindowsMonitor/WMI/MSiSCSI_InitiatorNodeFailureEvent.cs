using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSI_InitiatorNodeFailureEvent
    {
		public bool Active { get; private set; }
		public ulong FailureTime { get; private set; }
		public byte FailureType { get; private set; }
		public string InstanceName { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public dynamic TargetFailureAddr { get; private set; }
		public string TargetFailureName { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<MSiSCSI_InitiatorNodeFailureEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSI_InitiatorNodeFailureEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSI_InitiatorNodeFailureEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSI_InitiatorNodeFailureEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSI_InitiatorNodeFailureEvent
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 FailureTime = (ulong) (managementObject.Properties["FailureTime"]?.Value ?? default(ulong)),
		 FailureType = (byte) (managementObject.Properties["FailureType"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TargetFailureAddr = (dynamic) (managementObject.Properties["TargetFailureAddr"]?.Value ?? default(dynamic)),
		 TargetFailureName = (string) (managementObject.Properties["TargetFailureName"]?.Value ?? default(string)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}