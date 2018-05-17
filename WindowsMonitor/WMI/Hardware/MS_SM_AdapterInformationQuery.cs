using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MS_SM_AdapterInformationQuery
    {
		public bool Active { get; private set; }
		public string DriverName { get; private set; }
		public string DriverVersion { get; private set; }
		public string FirmwareVersion { get; private set; }
		public string HardwareVersion { get; private set; }
		public uint HBAStatus { get; private set; }
		public string HBASymbolicName { get; private set; }
		public string InstanceName { get; private set; }
		public string Manufacturer { get; private set; }
		public string MfgDomain { get; private set; }
		public string Model { get; private set; }
		public string ModelDescription { get; private set; }
		public uint NumberOfPorts { get; private set; }
		public string OptionROMVersion { get; private set; }
		public string RedundantFirmwareVersion { get; private set; }
		public string RedundantOptionROMVersion { get; private set; }
		public string SerialNumber { get; private set; }
		public ulong UniqueAdapterId { get; private set; }
		public uint VendorSpecificID { get; private set; }

        public static IEnumerable<MS_SM_AdapterInformationQuery> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MS_SM_AdapterInformationQuery> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MS_SM_AdapterInformationQuery> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MS_SM_AdapterInformationQuery");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MS_SM_AdapterInformationQuery
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 DriverName = (string) (managementObject.Properties["DriverName"]?.Value ?? default(string)),
		 DriverVersion = (string) (managementObject.Properties["DriverVersion"]?.Value ?? default(string)),
		 FirmwareVersion = (string) (managementObject.Properties["FirmwareVersion"]?.Value ?? default(string)),
		 HardwareVersion = (string) (managementObject.Properties["HardwareVersion"]?.Value ?? default(string)),
		 HBAStatus = (uint) (managementObject.Properties["HBAStatus"]?.Value ?? default(uint)),
		 HBASymbolicName = (string) (managementObject.Properties["HBASymbolicName"]?.Value ?? default(string)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MfgDomain = (string) (managementObject.Properties["MfgDomain"]?.Value ?? default(string)),
		 Model = (string) (managementObject.Properties["Model"]?.Value ?? default(string)),
		 ModelDescription = (string) (managementObject.Properties["ModelDescription"]?.Value ?? default(string)),
		 NumberOfPorts = (uint) (managementObject.Properties["NumberOfPorts"]?.Value ?? default(uint)),
		 OptionROMVersion = (string) (managementObject.Properties["OptionROMVersion"]?.Value ?? default(string)),
		 RedundantFirmwareVersion = (string) (managementObject.Properties["RedundantFirmwareVersion"]?.Value ?? default(string)),
		 RedundantOptionROMVersion = (string) (managementObject.Properties["RedundantOptionROMVersion"]?.Value ?? default(string)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 UniqueAdapterId = (ulong) (managementObject.Properties["UniqueAdapterId"]?.Value ?? default(ulong)),
		 VendorSpecificID = (uint) (managementObject.Properties["VendorSpecificID"]?.Value ?? default(uint))
                };
        }
    }
}