using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class Slot
    {
		public string Caption { get; private set; }
		public string ConnectorPinout { get; private set; }
		public ushort[] ConnectorType { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public float HeightAllowed { get; private set; }
		public DateTime InstallDate { get; private set; }
		public float LengthAllowed { get; private set; }
		public string Manufacturer { get; private set; }
		public ushort MaxDataWidth { get; private set; }
		public string Model { get; private set; }
		public string Name { get; private set; }
		public ushort Number { get; private set; }
		public string OtherIdentifyingInfo { get; private set; }
		public string PartNumber { get; private set; }
		public bool PoweredOn { get; private set; }
		public string PurposeDescription { get; private set; }
		public string SerialNumber { get; private set; }
		public string SKU { get; private set; }
		public bool SpecialPurpose { get; private set; }
		public string Status { get; private set; }
		public bool SupportsHotPlug { get; private set; }
		public string Tag { get; private set; }
		public uint ThermalRating { get; private set; }
		public ushort[] VccMixedVoltageSupport { get; private set; }
		public string Version { get; private set; }
		public ushort[] VppMixedVoltageSupport { get; private set; }

        public static IEnumerable<Slot> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Slot> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Slot> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_Slot");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Slot
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConnectorPinout = (string) (managementObject.Properties["ConnectorPinout"]?.Value ?? default(string)),
		 ConnectorType = (ushort[]) (managementObject.Properties["ConnectorType"]?.Value ?? new ushort[0]),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 HeightAllowed = (float) (managementObject.Properties["HeightAllowed"]?.Value ?? default(float)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LengthAllowed = (float) (managementObject.Properties["LengthAllowed"]?.Value ?? default(float)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MaxDataWidth = (ushort) (managementObject.Properties["MaxDataWidth"]?.Value ?? default(ushort)),
		 Model = (string) (managementObject.Properties["Model"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Number = (ushort) (managementObject.Properties["Number"]?.Value ?? default(ushort)),
		 OtherIdentifyingInfo = (string) (managementObject.Properties["OtherIdentifyingInfo"]?.Value ?? default(string)),
		 PartNumber = (string) (managementObject.Properties["PartNumber"]?.Value ?? default(string)),
		 PoweredOn = (bool) (managementObject.Properties["PoweredOn"]?.Value ?? default(bool)),
		 PurposeDescription = (string) (managementObject.Properties["PurposeDescription"]?.Value ?? default(string)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 SKU = (string) (managementObject.Properties["SKU"]?.Value ?? default(string)),
		 SpecialPurpose = (bool) (managementObject.Properties["SpecialPurpose"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 SupportsHotPlug = (bool) (managementObject.Properties["SupportsHotPlug"]?.Value ?? default(bool)),
		 Tag = (string) (managementObject.Properties["Tag"]?.Value ?? default(string)),
		 ThermalRating = (uint) (managementObject.Properties["ThermalRating"]?.Value ?? default(uint)),
		 VccMixedVoltageSupport = (ushort[]) (managementObject.Properties["VccMixedVoltageSupport"]?.Value ?? new ushort[0]),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 VppMixedVoltageSupport = (ushort[]) (managementObject.Properties["VppMixedVoltageSupport"]?.Value ?? new ushort[0])
                };
        }
    }
}