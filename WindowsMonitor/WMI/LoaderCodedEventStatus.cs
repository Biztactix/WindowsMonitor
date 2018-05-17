using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class LoaderCodedEventStatus
    {
		public ulong BaseAddress { get; private set; }
		public sbyte Code { get; private set; }
		public byte ErrorOpcode { get; private set; }
		public uint Flags { get; private set; }
		public string String { get; private set; }

        public static IEnumerable<LoaderCodedEventStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LoaderCodedEventStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LoaderCodedEventStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM LoaderCodedEventStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LoaderCodedEventStatus
                {
                     BaseAddress = (ulong) (managementObject.Properties["BaseAddress"]?.Value ?? default(ulong)),
		 Code = (sbyte) (managementObject.Properties["Code"]?.Value ?? default(sbyte)),
		 ErrorOpcode = (byte) (managementObject.Properties["ErrorOpcode"]?.Value ?? default(byte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 String = (string) (managementObject.Properties["String"]?.Value ?? default(string))
                };
        }
    }
}