using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class LoaderNewDllEvent
    {
		public string FilePath { get; private set; }
		public uint Flags { get; private set; }
		public uint LoadReason { get; private set; }
		public uint NewDllBaseAddress { get; private set; }
		public uint ParentDllBaseAddress { get; private set; }

        public static IEnumerable<LoaderNewDllEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LoaderNewDllEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LoaderNewDllEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM LoaderNewDllEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LoaderNewDllEvent
                {
                     FilePath = (string) (managementObject.Properties["FilePath"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 LoadReason = (uint) (managementObject.Properties["LoadReason"]?.Value ?? default(uint)),
		 NewDllBaseAddress = (uint) (managementObject.Properties["NewDllBaseAddress"]?.Value ?? default(uint)),
		 ParentDllBaseAddress = (uint) (managementObject.Properties["ParentDllBaseAddress"]?.Value ?? default(uint))
                };
        }
    }
}