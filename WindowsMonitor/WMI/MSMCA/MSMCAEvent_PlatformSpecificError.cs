using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_PlatformSpecificError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint LogToEventlog { get; private set; }
		public byte[] OEM_COMPONENT_ID { get; private set; }
		public ulong PLATFORM_BUS_SPECIFIC_DATA { get; private set; }
		public ulong PLATFORM_ERROR_STATUS { get; private set; }
		public ulong PLATFORM_REQUESTOR_ID { get; private set; }
		public ulong PLATFORM_RESPONDER_ID { get; private set; }
		public ulong PLATFORM_TARGET_ID { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint Size { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint Type { get; private set; }
		public ulong VALIDATION_BITS { get; private set; }

        public static IEnumerable<MSMCAEvent_PlatformSpecificError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_PlatformSpecificError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_PlatformSpecificError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_PlatformSpecificError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_PlatformSpecificError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 OEM_COMPONENT_ID = (byte[]) (managementObject.Properties["OEM_COMPONENT_ID"]?.Value ?? new byte[0]),
		 PLATFORM_BUS_SPECIFIC_DATA = (ulong) (managementObject.Properties["PLATFORM_BUS_SPECIFIC_DATA"]?.Value ?? default(ulong)),
		 PLATFORM_ERROR_STATUS = (ulong) (managementObject.Properties["PLATFORM_ERROR_STATUS"]?.Value ?? default(ulong)),
		 PLATFORM_REQUESTOR_ID = (ulong) (managementObject.Properties["PLATFORM_REQUESTOR_ID"]?.Value ?? default(ulong)),
		 PLATFORM_RESPONDER_ID = (ulong) (managementObject.Properties["PLATFORM_RESPONDER_ID"]?.Value ?? default(ulong)),
		 PLATFORM_TARGET_ID = (ulong) (managementObject.Properties["PLATFORM_TARGET_ID"]?.Value ?? default(ulong)),
		 RawRecord = (byte[]) (managementObject.Properties["RawRecord"]?.Value ?? new byte[0]),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint)),
		 VALIDATION_BITS = (ulong) (managementObject.Properties["VALIDATION_BITS"]?.Value ?? default(ulong))
                };
        }
    }
}