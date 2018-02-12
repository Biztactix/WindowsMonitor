using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __MethodInvocationEvent
    {
		public string Method { get; private set; }
		public dynamic Parameters { get; private set; }
		public bool PreCall { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public dynamic TargetInstance { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<__MethodInvocationEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__MethodInvocationEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__MethodInvocationEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __MethodInvocationEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __MethodInvocationEvent
                {
                     Method = (string) (managementObject.Properties["Method"]?.Value ?? default(string)),
		 Parameters = (dynamic) (managementObject.Properties["Parameters"]?.Value ?? default(dynamic)),
		 PreCall = (bool) (managementObject.Properties["PreCall"]?.Value ?? default(bool)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TargetInstance = (dynamic) (managementObject.Properties["TargetInstance"]?.Value ?? default(dynamic)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}