using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ObHandleRundownEvent
    {
		public uint Flags { get; private set; }
		public uint Handle { get; private set; }
		public uint Object { get; private set; }
		public string ObjectName { get; private set; }
		public ushort ObjectType { get; private set; }
		public uint ProcessId { get; private set; }

        public static IEnumerable<ObHandleRundownEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ObHandleRundownEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ObHandleRundownEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ObHandleRundownEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ObHandleRundownEvent
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Handle = (uint) (managementObject.Properties["Handle"]?.Value ?? default(uint)),
		 Object = (uint) (managementObject.Properties["Object"]?.Value ?? default(uint)),
		 ObjectName = (string) (managementObject.Properties["ObjectName"]?.Value ?? default(string)),
		 ObjectType = (ushort) (managementObject.Properties["ObjectType"]?.Value ?? default(ushort)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint))
                };
        }
    }
}