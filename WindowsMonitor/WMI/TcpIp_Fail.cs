using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TcpIp_Fail
    {
		public ushort FailureCode { get; private set; }
		public uint Flags { get; private set; }
		public ushort Proto { get; private set; }

        public static IEnumerable<TcpIp_Fail> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TcpIp_Fail> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TcpIp_Fail> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TcpIp_Fail");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TcpIp_Fail
                {
                     FailureCode = (ushort) (managementObject.Properties["FailureCode"]?.Value ?? default(ushort)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Proto = (ushort) (managementObject.Properties["Proto"]?.Value ?? default(ushort))
                };
        }
    }
}