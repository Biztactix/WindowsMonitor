using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_MemoryError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public ulong BUS_SPECIFIC_DATA { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint LogToEventlog { get; private set; }
		public ushort MEM_BANK { get; private set; }
		public ushort MEM_BIT_POSITION { get; private set; }
		public ushort MEM_CARD { get; private set; }
		public ushort MEM_COLUMN { get; private set; }
		public ulong MEM_ERROR_STATUS { get; private set; }
		public ushort MEM_MODULE { get; private set; }
		public ushort MEM_NODE { get; private set; }
		public ulong MEM_PHYSICAL_ADDR { get; private set; }
		public ulong MEM_PHYSICAL_MASK { get; private set; }
		public ushort MEM_ROW { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public ulong REQUESTOR_ID { get; private set; }
		public ulong RESPONDER_ID { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint Size { get; private set; }
		public ulong TARGET_ID { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint Type { get; private set; }
		public ulong VALIDATION_BITS { get; private set; }
		public ushort xMEM_DEVICE { get; private set; }

        public static IEnumerable<MSMCAEvent_MemoryError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_MemoryError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_MemoryError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_MemoryError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_MemoryError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 BUS_SPECIFIC_DATA = (ulong) (managementObject.Properties["BUS_SPECIFIC_DATA"]?.Value ?? default(ulong)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 MEM_BANK = (ushort) (managementObject.Properties["MEM_BANK"]?.Value ?? default(ushort)),
		 MEM_BIT_POSITION = (ushort) (managementObject.Properties["MEM_BIT_POSITION"]?.Value ?? default(ushort)),
		 MEM_CARD = (ushort) (managementObject.Properties["MEM_CARD"]?.Value ?? default(ushort)),
		 MEM_COLUMN = (ushort) (managementObject.Properties["MEM_COLUMN"]?.Value ?? default(ushort)),
		 MEM_ERROR_STATUS = (ulong) (managementObject.Properties["MEM_ERROR_STATUS"]?.Value ?? default(ulong)),
		 MEM_MODULE = (ushort) (managementObject.Properties["MEM_MODULE"]?.Value ?? default(ushort)),
		 MEM_NODE = (ushort) (managementObject.Properties["MEM_NODE"]?.Value ?? default(ushort)),
		 MEM_PHYSICAL_ADDR = (ulong) (managementObject.Properties["MEM_PHYSICAL_ADDR"]?.Value ?? default(ulong)),
		 MEM_PHYSICAL_MASK = (ulong) (managementObject.Properties["MEM_PHYSICAL_MASK"]?.Value ?? default(ulong)),
		 MEM_ROW = (ushort) (managementObject.Properties["MEM_ROW"]?.Value ?? default(ushort)),
		 RawRecord = (byte[]) (managementObject.Properties["RawRecord"]?.Value ?? new byte[0]),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 REQUESTOR_ID = (ulong) (managementObject.Properties["REQUESTOR_ID"]?.Value ?? default(ulong)),
		 RESPONDER_ID = (ulong) (managementObject.Properties["RESPONDER_ID"]?.Value ?? default(ulong)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 TARGET_ID = (ulong) (managementObject.Properties["TARGET_ID"]?.Value ?? default(ulong)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint)),
		 VALIDATION_BITS = (ulong) (managementObject.Properties["VALIDATION_BITS"]?.Value ?? default(ulong)),
		 xMEM_DEVICE = (ushort) (managementObject.Properties["xMEM_DEVICE"]?.Value ?? default(ushort))
                };
        }
    }
}