using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SampledProfile_V1
    {
		public ushort Count { get; private set; }
		public uint Flags { get; private set; }
		public uint InstructionPointer { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<SampledProfile_V1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SampledProfile_V1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SampledProfile_V1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SampledProfile_V1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SampledProfile_V1
                {
                     Count = (ushort) (managementObject.Properties["Count"]?.Value ?? default(ushort)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InstructionPointer = (uint) (managementObject.Properties["InstructionPointer"]?.Value ?? default(uint)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}