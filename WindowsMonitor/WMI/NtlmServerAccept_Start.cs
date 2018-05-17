using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class NtlmServerAccept_Start
    {
		public uint InContext { get; private set; }
		public uint StageHint { get; private set; }

        public static IEnumerable<NtlmServerAccept_Start> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NtlmServerAccept_Start> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NtlmServerAccept_Start> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM NtlmServerAccept_Start");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NtlmServerAccept_Start
                {
                     InContext = (uint) (managementObject.Properties["InContext"]?.Value ?? default(uint)),
		 StageHint = (uint) (managementObject.Properties["StageHint"]?.Value ?? default(uint))
                };
        }
    }
}