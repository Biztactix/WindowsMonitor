using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_Header
    {
		public uint AdditionalErrors { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public uint LogToEventlog { get; private set; }
		public ulong RecordId { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<MSMCAEvent_Header> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_Header> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_Header> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_Header");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_Header
                {
                     AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}