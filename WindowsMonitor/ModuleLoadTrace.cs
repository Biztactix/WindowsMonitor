using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ModuleLoadTrace
    {
		public ulong DefaultBase { get; private set; }
		public string FileName { get; private set; }
		public ulong ImageBase { get; private set; }
		public uint ImageChecksum { get; private set; }
		public ulong ImageSize { get; private set; }
		public uint ProcessID { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint TimeDateStamp { get; private set; }

        public static IEnumerable<ModuleLoadTrace> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<ModuleLoadTrace> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ModuleLoadTrace> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ModuleLoadTrace");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ModuleLoadTrace
                {
                     DefaultBase = (ulong) (managementObject.Properties["DefaultBase"]?.Value ?? default(ulong)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value),
		 ImageBase = (ulong) (managementObject.Properties["ImageBase"]?.Value ?? default(ulong)),
		 ImageChecksum = (uint) (managementObject.Properties["ImageChecksum"]?.Value ?? default(uint)),
		 ImageSize = (ulong) (managementObject.Properties["ImageSize"]?.Value ?? default(ulong)),
		 ProcessID = (uint) (managementObject.Properties["ProcessID"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TimeDateStamp = (uint) (managementObject.Properties["TimeDateStamp"]?.Value ?? default(uint))
                };
        }
    }
}