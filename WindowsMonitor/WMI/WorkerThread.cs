using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WorkerThread
    {
		public uint Flags { get; private set; }
		public ulong StartTime { get; private set; }
		public uint ThreadRoutine { get; private set; }
		public uint TThreadId { get; private set; }

        public static IEnumerable<WorkerThread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WorkerThread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WorkerThread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WorkerThread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WorkerThread
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 StartTime = (ulong) (managementObject.Properties["StartTime"]?.Value ?? default(ulong)),
		 ThreadRoutine = (uint) (managementObject.Properties["ThreadRoutine"]?.Value ?? default(uint)),
		 TThreadId = (uint) (managementObject.Properties["TThreadId"]?.Value ?? default(uint))
                };
        }
    }
}