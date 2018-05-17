using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class StackWalk_TypeGroup1
    {
		public uint Flags { get; private set; }
		public uint key { get; private set; }
		public uint[] StackFrame { get; private set; }

        public static IEnumerable<StackWalk_TypeGroup1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<StackWalk_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<StackWalk_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM StackWalk_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new StackWalk_TypeGroup1
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 key = (uint) (managementObject.Properties["key"]?.Value ?? default(uint)),
		 StackFrame = (uint[]) (managementObject.Properties["StackFrame"]?.Value ?? new uint[0])
                };
        }
    }
}