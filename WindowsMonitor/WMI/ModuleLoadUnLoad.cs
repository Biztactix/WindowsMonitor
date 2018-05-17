using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ModuleLoadUnLoad
    {
		public ulong AssemblyId { get; private set; }
		public ulong ModuleFlags { get; private set; }
		public ulong ModuleId { get; private set; }
		public string ModuleILPath { get; private set; }
		public string ModuleNativePath { get; private set; }

        public static IEnumerable<ModuleLoadUnLoad> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ModuleLoadUnLoad> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ModuleLoadUnLoad> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ModuleLoadUnLoad");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ModuleLoadUnLoad
                {
                     AssemblyId = (ulong) (managementObject.Properties["AssemblyId"]?.Value ?? default(ulong)),
		 ModuleFlags = (ulong) (managementObject.Properties["ModuleFlags"]?.Value ?? default(ulong)),
		 ModuleId = (ulong) (managementObject.Properties["ModuleId"]?.Value ?? default(ulong)),
		 ModuleILPath = (string) (managementObject.Properties["ModuleILPath"]?.Value ?? default(string)),
		 ModuleNativePath = (string) (managementObject.Properties["ModuleNativePath"]?.Value ?? default(string))
                };
        }
    }
}