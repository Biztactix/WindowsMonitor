using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware
{
    /// <summary>
    /// </summary>
    public sealed class PhysicalMedia
    {
		public ulong Capacity { get; private set; }
		public string Caption { get; private set; }
		public bool CleanerMedia { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public bool HotSwappable { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Manufacturer { get; private set; }
		public string MediaDescription { get; private set; }
		public ushort MediaType { get; private set; }
		public string Model { get; private set; }
		public string Name { get; private set; }
		public string OtherIdentifyingInfo { get; private set; }
		public string PartNumber { get; private set; }
		public bool PoweredOn { get; private set; }
		public bool Removable { get; private set; }
		public bool Replaceable { get; private set; }
		public string SerialNumber { get; private set; }
		public string SKU { get; private set; }
		public string Status { get; private set; }
		public string Tag { get; private set; }
		public string Version { get; private set; }
		public bool WriteProtectOn { get; private set; }

        public static IEnumerable<PhysicalMedia> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PhysicalMedia> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PhysicalMedia> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PhysicalMedia");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PhysicalMedia
                {
                     Capacity = (ulong) (managementObject.Properties["Capacity"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CleanerMedia = (bool) (managementObject.Properties["CleanerMedia"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 HotSwappable = (bool) (managementObject.Properties["HotSwappable"]?.Value ?? default(bool)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MediaDescription = (string) (managementObject.Properties["MediaDescription"]?.Value ?? default(string)),
		 MediaType = (ushort) (managementObject.Properties["MediaType"]?.Value ?? default(ushort)),
		 Model = (string) (managementObject.Properties["Model"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OtherIdentifyingInfo = (string) (managementObject.Properties["OtherIdentifyingInfo"]?.Value ?? default(string)),
		 PartNumber = (string) (managementObject.Properties["PartNumber"]?.Value ?? default(string)),
		 PoweredOn = (bool) (managementObject.Properties["PoweredOn"]?.Value ?? default(bool)),
		 Removable = (bool) (managementObject.Properties["Removable"]?.Value ?? default(bool)),
		 Replaceable = (bool) (managementObject.Properties["Replaceable"]?.Value ?? default(bool)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 SKU = (string) (managementObject.Properties["SKU"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 Tag = (string) (managementObject.Properties["Tag"]?.Value ?? default(string)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 WriteProtectOn = (bool) (managementObject.Properties["WriteProtectOn"]?.Value ?? default(bool))
                };
        }
    }
}