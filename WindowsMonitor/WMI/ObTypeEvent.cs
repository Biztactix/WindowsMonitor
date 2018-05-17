using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ObTypeEvent
    {
		public uint Flags { get; private set; }
		public ushort ObjectType { get; private set; }
		public ushort Reserved { get; private set; }
		public string TypeName { get; private set; }

        public static IEnumerable<ObTypeEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ObTypeEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ObTypeEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ObTypeEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ObTypeEvent
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ObjectType = (ushort) (managementObject.Properties["ObjectType"]?.Value ?? default(ushort)),
		 Reserved = (ushort) (managementObject.Properties["Reserved"]?.Value ?? default(ushort)),
		 TypeName = (string) (managementObject.Properties["TypeName"]?.Value ?? default(string))
                };
        }
    }
}