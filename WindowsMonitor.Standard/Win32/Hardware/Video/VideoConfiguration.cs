using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Video
{
    /// <summary>
    /// </summary>
    public sealed class VideoConfiguration
    {
		public uint ActualColorResolution { get; private set; }
		public string AdapterChipType { get; private set; }
		public string AdapterCompatibility { get; private set; }
		public string AdapterDACType { get; private set; }
		public string AdapterDescription { get; private set; }
		public uint AdapterRAM { get; private set; }
		public string AdapterType { get; private set; }
		public uint BitsPerPixel { get; private set; }
		public string Caption { get; private set; }
		public uint ColorPlanes { get; private set; }
		public uint ColorTableEntries { get; private set; }
		public string Description { get; private set; }
		public uint DeviceSpecificPens { get; private set; }
		public DateTime DriverDate { get; private set; }
		public uint HorizontalResolution { get; private set; }
		public string InfFilename { get; private set; }
		public string InfSection { get; private set; }
		public string InstalledDisplayDrivers { get; private set; }
		public string MonitorManufacturer { get; private set; }
		public string MonitorType { get; private set; }
		public string Name { get; private set; }
		public uint PixelsPerXLogicalInch { get; private set; }
		public uint PixelsPerYLogicalInch { get; private set; }
		public uint RefreshRate { get; private set; }
		public string ScanMode { get; private set; }
		public uint ScreenHeight { get; private set; }
		public uint ScreenWidth { get; private set; }
		public string SettingID { get; private set; }
		public uint SystemPaletteEntries { get; private set; }
		public uint VerticalResolution { get; private set; }

        public static IEnumerable<VideoConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VideoConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VideoConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_VideoConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VideoConfiguration
                {
                     ActualColorResolution = (uint) (managementObject.Properties["ActualColorResolution"]?.Value ?? default(uint)),
		 AdapterChipType = (string) (managementObject.Properties["AdapterChipType"]?.Value ?? default(string)),
		 AdapterCompatibility = (string) (managementObject.Properties["AdapterCompatibility"]?.Value ?? default(string)),
		 AdapterDACType = (string) (managementObject.Properties["AdapterDACType"]?.Value ?? default(string)),
		 AdapterDescription = (string) (managementObject.Properties["AdapterDescription"]?.Value ?? default(string)),
		 AdapterRAM = (uint) (managementObject.Properties["AdapterRAM"]?.Value ?? default(uint)),
		 AdapterType = (string) (managementObject.Properties["AdapterType"]?.Value ?? default(string)),
		 BitsPerPixel = (uint) (managementObject.Properties["BitsPerPixel"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ColorPlanes = (uint) (managementObject.Properties["ColorPlanes"]?.Value ?? default(uint)),
		 ColorTableEntries = (uint) (managementObject.Properties["ColorTableEntries"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceSpecificPens = (uint) (managementObject.Properties["DeviceSpecificPens"]?.Value ?? default(uint)),
		 DriverDate = (DateTime) (managementObject.Properties["DriverDate"]?.Value ?? default(DateTime)),
		 HorizontalResolution = (uint) (managementObject.Properties["HorizontalResolution"]?.Value ?? default(uint)),
		 InfFilename = (string) (managementObject.Properties["InfFilename"]?.Value ?? default(string)),
		 InfSection = (string) (managementObject.Properties["InfSection"]?.Value ?? default(string)),
		 InstalledDisplayDrivers = (string) (managementObject.Properties["InstalledDisplayDrivers"]?.Value ?? default(string)),
		 MonitorManufacturer = (string) (managementObject.Properties["MonitorManufacturer"]?.Value ?? default(string)),
		 MonitorType = (string) (managementObject.Properties["MonitorType"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PixelsPerXLogicalInch = (uint) (managementObject.Properties["PixelsPerXLogicalInch"]?.Value ?? default(uint)),
		 PixelsPerYLogicalInch = (uint) (managementObject.Properties["PixelsPerYLogicalInch"]?.Value ?? default(uint)),
		 RefreshRate = (uint) (managementObject.Properties["RefreshRate"]?.Value ?? default(uint)),
		 ScanMode = (string) (managementObject.Properties["ScanMode"]?.Value ?? default(string)),
		 ScreenHeight = (uint) (managementObject.Properties["ScreenHeight"]?.Value ?? default(uint)),
		 ScreenWidth = (uint) (managementObject.Properties["ScreenWidth"]?.Value ?? default(uint)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 SystemPaletteEntries = (uint) (managementObject.Properties["SystemPaletteEntries"]?.Value ?? default(uint)),
		 VerticalResolution = (uint) (managementObject.Properties["VerticalResolution"]?.Value ?? default(uint))
                };
        }
    }
}