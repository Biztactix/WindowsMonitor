using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MethodLoadUnLoad
    {
		public uint MethodFlags { get; private set; }
		public ulong MethodIdentifier { get; private set; }
		public uint MethodSize { get; private set; }
		public ulong MethodStartAddress { get; private set; }
		public uint MethodToken { get; private set; }
		public ulong ModuleID { get; private set; }

        public static IEnumerable<MethodLoadUnLoad> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MethodLoadUnLoad> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MethodLoadUnLoad> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MethodLoadUnLoad");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MethodLoadUnLoad
                {
                     MethodFlags = (uint) (managementObject.Properties["MethodFlags"]?.Value ?? default(uint)),
		 MethodIdentifier = (ulong) (managementObject.Properties["MethodIdentifier"]?.Value ?? default(ulong)),
		 MethodSize = (uint) (managementObject.Properties["MethodSize"]?.Value ?? default(uint)),
		 MethodStartAddress = (ulong) (managementObject.Properties["MethodStartAddress"]?.Value ?? default(ulong)),
		 MethodToken = (uint) (managementObject.Properties["MethodToken"]?.Value ?? default(uint)),
		 ModuleID = (ulong) (managementObject.Properties["ModuleID"]?.Value ?? default(ulong))
                };
        }
    }
}