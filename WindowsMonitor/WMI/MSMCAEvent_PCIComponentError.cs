using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSMCAEvent_PCIComponentError
    {
		public bool Active { get; private set; }
		public uint AdditionalErrors { get; private set; }
		public uint Cpu { get; private set; }
		public byte ErrorSeverity { get; private set; }
		public string InstanceName { get; private set; }
		public uint LogToEventlog { get; private set; }
		public ulong PCI_COMP_ERROR_STATUS { get; private set; }
		public byte PCI_COMP_INFO_BusNumber { get; private set; }
		public byte PCI_COMP_INFO_ClassCodeBaseClass { get; private set; }
		public byte PCI_COMP_INFO_ClassCodeInterface { get; private set; }
		public byte PCI_COMP_INFO_ClassCodeSubClass { get; private set; }
		public ushort PCI_COMP_INFO_DeviceId { get; private set; }
		public byte PCI_COMP_INFO_DeviceNumber { get; private set; }
		public byte PCI_COMP_INFO_FunctionNumber { get; private set; }
		public byte PCI_COMP_INFO_SegmentNumber { get; private set; }
		public ushort PCI_COMP_INFO_VendorId { get; private set; }
		public byte[] RawRecord { get; private set; }
		public ulong RecordId { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public uint Size { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public uint Type { get; private set; }
		public ulong VALIDATION_BITS { get; private set; }

        public static IEnumerable<MSMCAEvent_PCIComponentError> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSMCAEvent_PCIComponentError> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSMCAEvent_PCIComponentError> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSMCAEvent_PCIComponentError");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSMCAEvent_PCIComponentError
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 AdditionalErrors = (uint) (managementObject.Properties["AdditionalErrors"]?.Value ?? default(uint)),
		 Cpu = (uint) (managementObject.Properties["Cpu"]?.Value ?? default(uint)),
		 ErrorSeverity = (byte) (managementObject.Properties["ErrorSeverity"]?.Value ?? default(byte)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 LogToEventlog = (uint) (managementObject.Properties["LogToEventlog"]?.Value ?? default(uint)),
		 PCI_COMP_ERROR_STATUS = (ulong) (managementObject.Properties["PCI_COMP_ERROR_STATUS"]?.Value ?? default(ulong)),
		 PCI_COMP_INFO_BusNumber = (byte) (managementObject.Properties["PCI_COMP_INFO_BusNumber"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_ClassCodeBaseClass = (byte) (managementObject.Properties["PCI_COMP_INFO_ClassCodeBaseClass"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_ClassCodeInterface = (byte) (managementObject.Properties["PCI_COMP_INFO_ClassCodeInterface"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_ClassCodeSubClass = (byte) (managementObject.Properties["PCI_COMP_INFO_ClassCodeSubClass"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_DeviceId = (ushort) (managementObject.Properties["PCI_COMP_INFO_DeviceId"]?.Value ?? default(ushort)),
		 PCI_COMP_INFO_DeviceNumber = (byte) (managementObject.Properties["PCI_COMP_INFO_DeviceNumber"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_FunctionNumber = (byte) (managementObject.Properties["PCI_COMP_INFO_FunctionNumber"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_SegmentNumber = (byte) (managementObject.Properties["PCI_COMP_INFO_SegmentNumber"]?.Value ?? default(byte)),
		 PCI_COMP_INFO_VendorId = (ushort) (managementObject.Properties["PCI_COMP_INFO_VendorId"]?.Value ?? default(ushort)),
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