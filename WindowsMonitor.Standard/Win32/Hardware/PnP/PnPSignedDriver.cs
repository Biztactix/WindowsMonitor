using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class PnPSignedDriver
    {
		public string Caption { get; private set; }
		public string ClassGuid { get; private set; }
		public string CompatID { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public string DeviceClass { get; private set; }
		public string DeviceID { get; private set; }
		public string DeviceName { get; private set; }
		public string DevLoader { get; private set; }
		public DateTime DriverDate { get; private set; }
		public string DriverName { get; private set; }
		public string DriverProviderName { get; private set; }
		public string DriverVersion { get; private set; }
		public string FriendlyName { get; private set; }
		public string HardWareID { get; private set; }
		public string InfName { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool IsSigned { get; private set; }
		public string Location { get; private set; }
		public string Manufacturer { get; private set; }
		public string Name { get; private set; }
		public string PDO { get; private set; }
		public string Signer { get; private set; }
		public bool Started { get; private set; }
		public string StartMode { get; private set; }
		public string Status { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }

        public static IEnumerable<PnPSignedDriver> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<PnPSignedDriver> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PnPSignedDriver> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPSignedDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PnPSignedDriver
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ClassGuid = (string) (managementObject.Properties["ClassGuid"]?.Value ?? default(string)),
		 CompatID = (string) (managementObject.Properties["CompatID"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceClass = (string) (managementObject.Properties["DeviceClass"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 DeviceName = (string) (managementObject.Properties["DeviceName"]?.Value ?? default(string)),
		 DevLoader = (string) (managementObject.Properties["DevLoader"]?.Value ?? default(string)),
		 DriverDate = (DateTime) (managementObject.Properties["DriverDate"]?.Value ?? default(DateTime)),
		 DriverName = (string) (managementObject.Properties["DriverName"]?.Value ?? default(string)),
		 DriverProviderName = (string) (managementObject.Properties["DriverProviderName"]?.Value ?? default(string)),
		 DriverVersion = (string) (managementObject.Properties["DriverVersion"]?.Value ?? default(string)),
		 FriendlyName = (string) (managementObject.Properties["FriendlyName"]?.Value ?? default(string)),
		 HardWareID = (string) (managementObject.Properties["HardWareID"]?.Value ?? default(string)),
		 InfName = (string) (managementObject.Properties["InfName"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 IsSigned = (bool) (managementObject.Properties["IsSigned"]?.Value ?? default(bool)),
		 Location = (string) (managementObject.Properties["Location"]?.Value ?? default(string)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PDO = (string) (managementObject.Properties["PDO"]?.Value ?? default(string)),
		 Signer = (string) (managementObject.Properties["Signer"]?.Value ?? default(string)),
		 Started = (bool) (managementObject.Properties["Started"]?.Value ?? default(bool)),
		 StartMode = (string) (managementObject.Properties["StartMode"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string))
                };
        }
    }
}