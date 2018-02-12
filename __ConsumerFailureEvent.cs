using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __ConsumerFailureEvent
    {
		public uint ErrorCode { get; private set; }
		public string ErrorDescription { get; private set; }
		public dynamic ErrorObject { get; private set; }
		public dynamic Event { get; private set; }
		public short IntendedConsumer { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<__ConsumerFailureEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__ConsumerFailureEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__ConsumerFailureEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __ConsumerFailureEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __ConsumerFailureEvent
                {
                     ErrorCode = (uint) (managementObject.Properties["ErrorCode"]?.Value ?? default(uint)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 ErrorObject = (dynamic) (managementObject.Properties["ErrorObject"]?.Value ?? default(dynamic)),
		 Event = (dynamic) (managementObject.Properties["Event"]?.Value ?? default(dynamic)),
		 IntendedConsumer = (short) (managementObject.Properties["IntendedConsumer"]?.Value ?? default(short)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}