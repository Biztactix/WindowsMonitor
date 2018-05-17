using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TerminateWorkerThread
    {
		public uint RetiredWorkers { get; private set; }
		public uint WorkerThreadCount { get; private set; }

        public static IEnumerable<TerminateWorkerThread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TerminateWorkerThread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TerminateWorkerThread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TerminateWorkerThread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TerminateWorkerThread
                {
                     RetiredWorkers = (uint) (managementObject.Properties["RetiredWorkers"]?.Value ?? default(uint)),
		 WorkerThreadCount = (uint) (managementObject.Properties["WorkerThreadCount"]?.Value ?? default(uint))
                };
        }
    }
}