using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class LoaderCodedEventPath
    {
		public ulong BaseAddress { get; private set; }
		public sbyte Code { get; private set; }
		public byte ErrorOpcode { get; private set; }
		public uint Flags { get; private set; }
		public string String1 { get; private set; }
		public string String2 { get; private set; }

        public static IEnumerable<LoaderCodedEventPath> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LoaderCodedEventPath> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LoaderCodedEventPath> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM LoaderCodedEventPath");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LoaderCodedEventPath
                {
                     BaseAddress = (ulong) (managementObject.Properties["BaseAddress"]?.Value ?? default(ulong)),
		 Code = (sbyte) (managementObject.Properties["Code"]?.Value ?? default(sbyte)),
		 ErrorOpcode = (byte) (managementObject.Properties["ErrorOpcode"]?.Value ?? default(byte)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 String1 = (string) (managementObject.Properties["String1"]?.Value ?? default(string)),
		 String2 = (string) (managementObject.Properties["String2"]?.Value ?? default(string))
                };
        }
    }
}