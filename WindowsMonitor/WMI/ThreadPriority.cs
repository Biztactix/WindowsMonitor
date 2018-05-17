using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ThreadPriority
    {
		public uint Flags { get; private set; }
		public byte NewPriority { get; private set; }
		public byte OldPriority { get; private set; }
		public ushort Reserved { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<ThreadPriority> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ThreadPriority> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ThreadPriority> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ThreadPriority");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ThreadPriority
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NewPriority = (byte) (managementObject.Properties["NewPriority"]?.Value ?? default(byte)),
		 OldPriority = (byte) (managementObject.Properties["OldPriority"]?.Value ?? default(byte)),
		 Reserved = (ushort) (managementObject.Properties["Reserved"]?.Value ?? default(ushort)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}