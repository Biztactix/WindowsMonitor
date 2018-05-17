using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_MemoryHierarchyError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public ulong Address { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint LogToEventlog { get; private set; }
		public uint MemoryHierarchyLevel { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public uint RequestType { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint Size { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint TransactionType { get; private set; }
		public uint Type { get; private set; }

        public static IEnumerable<MSMCAEvent_MemoryHierarchyError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_MemoryHierarchyError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_MemoryHierarchyError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_MemoryHierarchyError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_MemoryHierarchyError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 Address = (ulong) (managementObject.Properties["Address"]?.Value ?? default(ulong)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 MemoryHierarchyLevel = (uint) (managementObject.Properties["MemoryHierarchyLevel"]?.Value ?? default(uint)),
		 RawRecord = (byte[]) (managementObject.Properties["RawRecord"]?.Value ?? new byte[0]),
		 RecordId = (ulong) (managementObject.Properties["RecordId"]?.Value ?? default(ulong)),
		 RequestType = (uint) (managementObject.Properties["RequestType"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionType = (uint) (managementObject.Properties["TransactionType"]?.Value ?? default(uint)),
		 Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}