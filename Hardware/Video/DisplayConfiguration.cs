using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DisplayConfiguration
    {
        public uint BitsPerPel { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string DeviceName { get; private set; }
        public uint DisplayFlags { get; private set; }
        public uint DisplayFrequency { get; private set; }
        public uint DitherType { get; private set; }
        public string DriverVersion { get; private set; }
        public uint ICMIntent { get; private set; }
        public uint ICMMethod { get; private set; }
        public uint LogPixels { get; private set; }
        public uint PelsHeight { get; private set; }
        public uint PelsWidth { get; private set; }
        public string SettingID { get; private set; }
        public uint SpecificationVersion { get; private set; }

        public static DisplayConfiguration[] Retrieve(string remote, string username, string password)
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

        public static DisplayConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DisplayConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DisplayConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DisplayConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DisplayConfiguration
                {
                    BitsPerPel = (uint) managementObject.Properties["BitsPerPel"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceName = (string) managementObject.Properties["DeviceName"].Value,
                    DisplayFlags = (uint) managementObject.Properties["DisplayFlags"].Value,
                    DisplayFrequency = (uint) managementObject.Properties["DisplayFrequency"].Value,
                    DitherType = (uint) managementObject.Properties["DitherType"].Value,
                    DriverVersion = (string) managementObject.Properties["DriverVersion"].Value,
                    ICMIntent = (uint) managementObject.Properties["ICMIntent"].Value,
                    ICMMethod = (uint) managementObject.Properties["ICMMethod"].Value,
                    LogPixels = (uint) managementObject.Properties["LogPixels"].Value,
                    PelsHeight = (uint) managementObject.Properties["PelsHeight"].Value,
                    PelsWidth = (uint) managementObject.Properties["PelsWidth"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    SpecificationVersion = (uint) managementObject.Properties["SpecificationVersion"].Value
                });

            return list.ToArray();
        }
    }
}