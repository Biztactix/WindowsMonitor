using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_CPUError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public uint BusSev { get; private set; }
		public uint BusType { get; private set; }
		public uint CacheMesi { get; private set; }
		public uint CacheOp { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint Level { get; private set; }
		public uint LogToEventlog { get; private set; }
		public uint MajorErrorType { get; private set; }
		public uint MSArrayId { get; private set; }
		public uint MSIndex { get; private set; }
		public uint MSOp { get; private set; }
		public uint MSSid { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public uint RegFileId { get; private set; }
		public uint RegFileOp { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint Size { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint TLBOp { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<MSMCAEvent_CPUError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_CPUError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_CPUError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_CPUError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_CPUError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 BusSev = (uint) (managementObject.Properties["BusSev"]?.Value ?? default(uint)),
		 BusType = (uint) (managementObject.Properties["BusType"]?.Value ?? default(uint)),
		 CacheMesi = (uint) (managementObject.Properties["CacheMesi"]?.Value ?? default(uint)),
		 CacheOp = (uint) (managementObject.Properties["CacheOp"]?.Value ?? default(uint)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Level = (uint) (managementObject.Properties["Level"]?.Value ?? default(uint)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 MajorErrorType = (uint) (managementObject.Properties["MajorErrorType"]?.Value ?? default(uint)),
		 MSArrayId = (uint) (managementObject.Properties["MSArrayId"]?.Value ?? default(uint)),
		 MSIndex = (uint) (managementObject.Properties["MSIndex"]?.Value ?? default(uint)),
		 MSOp = (uint) (managementObject.Properties["MSOp"]?.Value ?? default(uint)),
		 MSSid = (uint) (managementObject.Properties["MSSid"]?.Value ?? default(uint)),
		 RawRecord = (byte[]) (managementObject.Properties["RawRecord"]?.Value ?? new byte[0]),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 RegFileId = (uint) (managementObject.Properties["RegFileId"]?.Value ?? default(uint)),
		 RegFileOp = (uint) (managementObject.Properties["RegFileOp"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TLBOp = (uint) (managementObject.Properties["TLBOp"]?.Value ?? default(uint)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}