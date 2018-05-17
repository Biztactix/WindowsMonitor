using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SessionPoolAllocFree
    {
		public uint Entry { get; private set; }
		public uint Flags { get; private set; }
		public dynamic NumberOfBytes { get; private set; }
		public uint SessionId { get; private set; }
		public uint Tag { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<SessionPoolAllocFree> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SessionPoolAllocFree> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SessionPoolAllocFree> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SessionPoolAllocFree");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SessionPoolAllocFree
                {
                     Entry = (uint) (managementObject.Properties["Entry"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 NumberOfBytes = (dynamic) (managementObject.Properties["NumberOfBytes"]?.Value ?? default(dynamic)),
		 SessionId = (uint) (managementObject.Properties["SessionId"]?.Value ?? default(uint)),
		 Tag = (uint) (managementObject.Properties["Tag"]?.Value ?? default(uint)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}