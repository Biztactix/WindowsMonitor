using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ReadyThread
    {
		public sbyte AdjustIncrement { get; private set; }
		public sbyte AdjustReason { get; private set; }
		public sbyte Flag { get; private set; }
		public uint Flags { get; private set; }
		public sbyte Reserved { get; private set; }
		public uint TThreadId { get; private set; }

        public static IEnumerable<ReadyThread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ReadyThread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ReadyThread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ReadyThread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ReadyThread
                {
                     AdjustIncrement = (sbyte) (managementObject.Properties["AdjustIncrement"]?.Value ?? default(sbyte)),
		 AdjustReason = (sbyte) (managementObject.Properties["AdjustReason"]?.Value ?? default(sbyte)),
		 Flag = (sbyte) (managementObject.Properties["Flag"]?.Value ?? default(sbyte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Reserved = (sbyte) (managementObject.Properties["Reserved"]?.Value ?? default(sbyte)),
		 TThreadId = (uint) (managementObject.Properties["TThreadId"]?.Value ?? default(uint))
                };
        }
    }
}