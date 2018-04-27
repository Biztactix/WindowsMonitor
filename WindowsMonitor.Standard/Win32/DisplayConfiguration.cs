using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
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

        public static IEnumerable<DisplayConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DisplayConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DisplayConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DisplayConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DisplayConfiguration
                {
                     BitsPerPel = (uint) (managementObject.Properties["BitsPerPel"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceName = (string) (managementObject.Properties["DeviceName"]?.Value ?? default(string)),
		 DisplayFlags = (uint) (managementObject.Properties["DisplayFlags"]?.Value ?? default(uint)),
		 DisplayFrequency = (uint) (managementObject.Properties["DisplayFrequency"]?.Value ?? default(uint)),
		 DitherType = (uint) (managementObject.Properties["DitherType"]?.Value ?? default(uint)),
		 DriverVersion = (string) (managementObject.Properties["DriverVersion"]?.Value ?? default(string)),
		 ICMIntent = (uint) (managementObject.Properties["ICMIntent"]?.Value ?? default(uint)),
		 ICMMethod = (uint) (managementObject.Properties["ICMMethod"]?.Value ?? default(uint)),
		 LogPixels = (uint) (managementObject.Properties["LogPixels"]?.Value ?? default(uint)),
		 PelsHeight = (uint) (managementObject.Properties["PelsHeight"]?.Value ?? default(uint)),
		 PelsWidth = (uint) (managementObject.Properties["PelsWidth"]?.Value ?? default(uint)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 SpecificationVersion = (uint) (managementObject.Properties["SpecificationVersion"]?.Value ?? default(uint))
                };
        }
    }
}