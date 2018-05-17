using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class StackWalk_Key
    {
		public ulong EventTimeStamp { get; private set; }
		public uint Flags { get; private set; }
		public uint StackKey { get; private set; }
		public uint StackProcess { get; private set; }
		public uint StackThread { get; private set; }

        public static IEnumerable<StackWalk_Key> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<StackWalk_Key> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<StackWalk_Key> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM StackWalk_Key");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new StackWalk_Key
                {
                     EventTimeStamp = (ulong) (managementObject.Properties["EventTimeStamp"]?.Value ?? default(ulong)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 StackKey = (uint) (managementObject.Properties["StackKey"]?.Value ?? default(uint)),
		 StackProcess = (uint) (managementObject.Properties["StackProcess"]?.Value ?? default(uint)),
		 StackThread = (uint) (managementObject.Properties["StackThread"]?.Value ?? default(uint))
                };
        }
    }
}