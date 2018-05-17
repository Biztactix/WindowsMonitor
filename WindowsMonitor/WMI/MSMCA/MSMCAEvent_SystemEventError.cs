using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_SystemEventError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint LogToEventlog { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public byte SEL_DATA1 { get; private set; }
		public byte SEL_DATA2 { get; private set; }
		public byte SEL_DATA3 { get; private set; }
		public byte SEL_EVENT_DIR_TYPE { get; private set; }
		public byte SEL_EVM_REV { get; private set; }
		public ushort SEL_GENERATOR_ID { get; private set; }
		public ushort SEL_RECORD_ID { get; private set; }
		public byte SEL_RECORD_TYPE { get; private set; }
		public byte SEL_SENSOR_NUM { get; private set; }
		public byte SEL_SENSOR_TYPE { get; private set; }
		public ulong SEL_TIME_STAMP { get; private set; }
		public uint Size { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint Type { get; private set; }
		public ulong VALIDATION_BITS { get; private set; }

        public static IEnumerable<MSMCAEvent_SystemEventError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_SystemEventError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_SystemEventError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_SystemEventError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_SystemEventError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 RawRecord = (byte[]) (managementObject.Properties["RawRecord"]?.Value ?? new byte[0]),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 SEL_DATA1 = (byte) (managementObject.Properties["SEL_DATA1"]?.Value ?? default(byte)),
		 SEL_DATA2 = (byte) (managementObject.Properties["SEL_DATA2"]?.Value ?? default(byte)),
		 SEL_DATA3 = (byte) (managementObject.Properties["SEL_DATA3"]?.Value ?? default(byte)),
		 SEL_EVENT_DIR_TYPE = (byte) (managementObject.Properties["SEL_EVENT_DIR_TYPE"]?.Value ?? default(byte)),
		 SEL_EVM_REV = (byte) (managementObject.Properties["SEL_EVM_REV"]?.Value ?? default(byte)),
		 SEL_GENERATOR_ID = (ushort) (managementObject.Properties["SEL_GENERATOR_ID"]?.Value ?? default(ushort)),
		 SEL_RECORD_ID = (ushort) (managementObject.Properties["SEL_RECORD_ID"]?.Value ?? default(ushort)),
		 SEL_RECORD_TYPE = (byte) (managementObject.Properties["SEL_RECORD_TYPE"]?.Value ?? default(byte)),
		 SEL_SENSOR_NUM = (byte) (managementObject.Properties["SEL_SENSOR_NUM"]?.Value ?? default(byte)),
		 SEL_SENSOR_TYPE = (byte) (managementObject.Properties["SEL_SENSOR_TYPE"]?.Value ?? default(byte)),
		 SEL_TIME_STAMP = (ulong) (managementObject.Properties["SEL_TIME_STAMP"]?.Value ?? default(ulong)),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint)),
		 VALIDATION_BITS = (ulong) (managementObject.Properties["VALIDATION_BITS"]?.Value ?? default(ulong))
                };
        }
    }
}