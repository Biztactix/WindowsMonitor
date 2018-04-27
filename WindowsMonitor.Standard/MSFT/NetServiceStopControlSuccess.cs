using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class NetServiceStopControlSuccess
    {
		public string Comment { get; private set; }
		public string Control { get; private set; }
		public string Reason { get; private set; }
		public string ReasonText { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public string Service { get; private set; }
		public string sid { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetServiceStopControlSuccess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_NetServiceStopControlSuccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetServiceStopControlSuccess
                {
                     Comment = (string) (managementObject.Properties["Comment"]?.Value ?? default(string)),
		 Control = (string) (managementObject.Properties["Control"]?.Value ?? default(string)),
		 Reason = (string) (managementObject.Properties["Reason"]?.Value ?? default(string)),
		 ReasonText = (string) (managementObject.Properties["ReasonText"]?.Value ?? default(string)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Service = (string) (managementObject.Properties["Service"]?.Value ?? default(string)),
		 sid = (string) (managementObject.Properties["sid"]?.Value ?? default(string)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}