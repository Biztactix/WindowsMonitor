using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Image_Load
    {
		public uint DefaultBase { get; private set; }
		public string FileName { get; private set; }
		public uint Flags { get; private set; }
		public uint ImageBase { get; private set; }
		public uint ImageChecksum { get; private set; }
		public uint ImageSize { get; private set; }
		public uint ProcessId { get; private set; }
		public ushort Reserved0 { get; private set; }
		public uint Reserved1 { get; private set; }
		public uint Reserved2 { get; private set; }
		public uint Reserved3 { get; private set; }
		public uint Reserved4 { get; private set; }
		public byte SignatureLevel { get; private set; }
		public byte SignatureType { get; private set; }
		public uint TimeDateStamp { get; private set; }

        public static IEnumerable<Image_Load> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Image_Load> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Image_Load> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Image_Load");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Image_Load
                {
                     DefaultBase = (uint) (managementObject.Properties["DefaultBase"]?.Value ?? default(uint)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 ImageBase = (uint) (managementObject.Properties["ImageBase"]?.Value ?? default(uint)),
		 ImageChecksum = (uint) (managementObject.Properties["ImageChecksum"]?.Value ?? default(uint)),
		 ImageSize = (uint) (managementObject.Properties["ImageSize"]?.Value ?? default(uint)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 Reserved0 = (ushort) (managementObject.Properties["Reserved0"]?.Value ?? default(ushort)),
		 Reserved1 = (uint) (managementObject.Properties["Reserved1"]?.Value ?? default(uint)),
		 Reserved2 = (uint) (managementObject.Properties["Reserved2"]?.Value ?? default(uint)),
		 Reserved3 = (uint) (managementObject.Properties["Reserved3"]?.Value ?? default(uint)),
		 Reserved4 = (uint) (managementObject.Properties["Reserved4"]?.Value ?? default(uint)),
		 SignatureLevel = (byte) (managementObject.Properties["SignatureLevel"]?.Value ?? default(byte)),
		 SignatureType = (byte) (managementObject.Properties["SignatureType"]?.Value ?? default(byte)),
		 TimeDateStamp = (uint) (managementObject.Properties["TimeDateStamp"]?.Value ?? default(uint))
                };
        }
    }
}