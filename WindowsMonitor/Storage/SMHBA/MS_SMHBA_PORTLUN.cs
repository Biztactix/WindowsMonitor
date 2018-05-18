using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MS_SMHBA_PORTLUN
    {
		public byte[] domainPortWWN { get; private set; }
		public byte[] PortWWN { get; private set; }
		public ulong TargetLun { get; private set; }

        public static IEnumerable<MS_SMHBA_PORTLUN> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MS_SMHBA_PORTLUN> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MS_SMHBA_PORTLUN> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MS_SMHBA_PORTLUN");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MS_SMHBA_PORTLUN
                {
                     domainPortWWN = (byte[]) (managementObject.Properties["domainPortWWN"]?.Value ?? new byte[0]),
		 PortWWN = (byte[]) (managementObject.Properties["PortWWN"]?.Value ?? new byte[0]),
		 TargetLun = (ulong) (managementObject.Properties["TargetLun"]?.Value ?? default(ulong))
                };
        }
    }
}