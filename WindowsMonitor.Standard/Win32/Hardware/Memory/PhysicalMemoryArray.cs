using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Memory
{
    /// <summary>
    /// </summary>
    public sealed class PhysicalMemoryArray
    {
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public float Depth { get; private set; }
		public string Description { get; private set; }
		public float Height { get; private set; }
		public bool HotSwappable { get; private set; }
		public DateTime InstallDate { get; private set; }
		public ushort Location { get; private set; }
		public string Manufacturer { get; private set; }
		public uint MaxCapacity { get; private set; }
		public ulong MaxCapacityEx { get; private set; }
		public ushort MemoryDevices { get; private set; }
		public ushort MemoryErrorCorrection { get; private set; }
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
		public ushort Use { get; private set; }
		public string Version { get; private set; }
		public float Weight { get; private set; }
		public float Width { get; private set; }

        public static IEnumerable<PhysicalMemoryArray> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PhysicalMemoryArray> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PhysicalMemoryArray> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PhysicalMemoryArray");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PhysicalMemoryArray
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Depth = (float) (managementObject.Properties["Depth"]?.Value ?? default(float)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Height = (float) (managementObject.Properties["Height"]?.Value ?? default(float)),
		 HotSwappable = (bool) (managementObject.Properties["HotSwappable"]?.Value ?? default(bool)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Location = (ushort) (managementObject.Properties["Location"]?.Value ?? default(ushort)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MaxCapacity = (uint) (managementObject.Properties["MaxCapacity"]?.Value ?? default(uint)),
		 MaxCapacityEx = (ulong) (managementObject.Properties["MaxCapacityEx"]?.Value ?? default(ulong)),
		 MemoryDevices = (ushort) (managementObject.Properties["MemoryDevices"]?.Value ?? default(ushort)),
		 MemoryErrorCorrection = (ushort) (managementObject.Properties["MemoryErrorCorrection"]?.Value ?? default(ushort)),
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
		 Use = (ushort) (managementObject.Properties["Use"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 Weight = (float) (managementObject.Properties["Weight"]?.Value ?? default(float)),
		 Width = (float) (managementObject.Properties["Width"]?.Value ?? default(float))
                };
        }
    }
}