using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSChangerProblemEvent
    {
		public bool Active { get; private set; }
		public byte[] ChangerData { get; private set; }
		public uint ChangerProblemType { get; private set; }
		public string InstanceName { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<MSChangerProblemEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSChangerProblemEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSChangerProblemEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSChangerProblemEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSChangerProblemEvent
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 ChangerData = (byte[]) (managementObject.Properties["ChangerData"]?.Value ?? new byte[0]),
		 ChangerProblemType = (uint) (managementObject.Properties["ChangerProblemType"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}