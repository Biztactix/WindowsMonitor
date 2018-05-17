using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ObHandleDuplicateEvent
    {
		public uint Flags { get; private set; }
		public uint Object { get; private set; }
		public ushort ObjectType { get; private set; }
		public uint SourceHandle { get; private set; }
		public uint TargetHandle { get; private set; }
		public uint TargetProcessId { get; private set; }

        public static IEnumerable<ObHandleDuplicateEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ObHandleDuplicateEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ObHandleDuplicateEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ObHandleDuplicateEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ObHandleDuplicateEvent
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Object = (uint) (managementObject.Properties["Object"]?.Value ?? default(uint)),
		 ObjectType = (ushort) (managementObject.Properties["ObjectType"]?.Value ?? default(ushort)),
		 SourceHandle = (uint) (managementObject.Properties["SourceHandle"]?.Value ?? default(uint)),
		 TargetHandle = (uint) (managementObject.Properties["TargetHandle"]?.Value ?? default(uint)),
		 TargetProcessId = (uint) (managementObject.Properties["TargetProcessId"]?.Value ?? default(uint))
                };
        }
    }
}