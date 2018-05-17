using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSWmi_MofData
    {
		public bool Active { get; private set; }
		public byte[] BinaryMofData { get; private set; }
		public string InstanceName { get; private set; }
		public uint Size { get; private set; }
		public uint Unused1 { get; private set; }
		public uint Unused2 { get; private set; }
		public uint Unused4 { get; private set; }

        public static IEnumerable<MSWmi_MofData> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSWmi_MofData> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSWmi_MofData> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSWmi_MofData");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSWmi_MofData
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 BinaryMofData = (byte[]) (managementObject.Properties["BinaryMofData"]?.Value ?? new byte[0]),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 Unused1 = (uint) (managementObject.Properties["Unused1"]?.Value ?? default(uint)),
		 Unused2 = (uint) (managementObject.Properties["Unused2"]?.Value ?? default(uint)),
		 Unused4 = (uint) (managementObject.Properties["Unused4"]?.Value ?? default(uint))
                };
        }
    }
}