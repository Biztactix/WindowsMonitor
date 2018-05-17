using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class RegisteredGuids
    {
		public bool Active { get; private set; }
		public uint EnableFlags { get; private set; }
		public uint EnableLevel { get; private set; }
		public uint GuidType { get; private set; }
		public string InstanceName { get; private set; }
		public bool IsEnabled { get; private set; }
		public uint LoggerId { get; private set; }

        public static IEnumerable<RegisteredGuids> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<RegisteredGuids> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<RegisteredGuids> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM RegisteredGuids");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new RegisteredGuids
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 EnableFlags = (uint) (managementObject.Properties["EnableFlags"]?.Value ?? default(uint)),
		 EnableLevel = (uint) (managementObject.Properties["EnableLevel"]?.Value ?? default(uint)),
		 GuidType = (uint) (managementObject.Properties["GuidType"]?.Value ?? default(uint)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 IsEnabled = (bool) (managementObject.Properties["IsEnabled"]?.Value ?? default(bool)),
		 LoggerId = (uint) (managementObject.Properties["LoggerId"]?.Value ?? default(uint))
                };
        }
    }
}