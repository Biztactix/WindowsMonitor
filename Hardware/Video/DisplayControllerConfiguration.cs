using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DisplayControllerConfiguration
    {
        public uint BitsPerPixel { get; private set; }
        public string Caption { get; private set; }
        public uint ColorPlanes { get; private set; }
        public string Description { get; private set; }
        public uint DeviceEntriesInAColorTable { get; private set; }
        public uint DeviceSpecificPens { get; private set; }
        public uint HorizontalResolution { get; private set; }
        public string Name { get; private set; }
        public int RefreshRate { get; private set; }
        public uint ReservedSystemPaletteEntries { get; private set; }
        public string SettingID { get; private set; }
        public uint SystemPaletteEntries { get; private set; }
        public uint VerticalResolution { get; private set; }
        public string VideoMode { get; private set; }

        public static DisplayControllerConfiguration[] Retrieve(string remote, string username, string password)
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

        public static DisplayControllerConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DisplayControllerConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DisplayControllerConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DisplayControllerConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DisplayControllerConfiguration
                {
                    BitsPerPixel = (uint) managementObject.Properties["BitsPerPixel"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ColorPlanes = (uint) managementObject.Properties["ColorPlanes"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceEntriesInAColorTable = (uint) managementObject.Properties["DeviceEntriesInAColorTable"].Value,
                    DeviceSpecificPens = (uint) managementObject.Properties["DeviceSpecificPens"].Value,
                    HorizontalResolution = (uint) managementObject.Properties["HorizontalResolution"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RefreshRate = (int) managementObject.Properties["RefreshRate"].Value,
                    ReservedSystemPaletteEntries = (uint) managementObject.Properties["ReservedSystemPaletteEntries"]
                        .Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    SystemPaletteEntries = (uint) managementObject.Properties["SystemPaletteEntries"].Value,
                    VerticalResolution = (uint) managementObject.Properties["VerticalResolution"].Value,
                    VideoMode = (string) managementObject.Properties["VideoMode"].Value
                });

            return list.ToArray();
        }
    }
}