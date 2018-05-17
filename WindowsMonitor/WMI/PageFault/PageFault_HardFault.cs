using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class PageFault_HardFault
    {
		public uint ByteCount { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public dynamic InitialTime { get; private set; }
		public ulong ReadOffset { get; private set; }
		public uint TThreadId { get; private set; }
		public uint VirtualAddress { get; private set; }

        public static IEnumerable<PageFault_HardFault> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PageFault_HardFault> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PageFault_HardFault> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PageFault_HardFault");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PageFault_HardFault
                {
                     ByteCount = (uint) (managementObject.Properties["ByteCount"]?.Value ?? default(uint)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InitialTime = (dynamic) (managementObject.Properties["InitialTime"]?.Value ?? default(dynamic)),
		 ReadOffset = (ulong) (managementObject.Properties["ReadOffset"]?.Value ?? default(ulong)),
		 TThreadId = (uint) (managementObject.Properties["TThreadId"]?.Value ?? default(uint)),
		 VirtualAddress = (uint) (managementObject.Properties["VirtualAddress"]?.Value ?? default(uint))
                };
        }
    }
}