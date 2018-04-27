using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ServiceSpecification
    {
		public string Caption { get; private set; }
		public string CheckID { get; private set; }
		public bool CheckMode { get; private set; }
		public string Dependencies { get; private set; }
		public string Description { get; private set; }
		public string DisplayName { get; private set; }
		public int ErrorControl { get; private set; }
		public string ID { get; private set; }
		public string LoadOrderGroup { get; private set; }
		public string Name { get; private set; }
		public string Password { get; private set; }
		public int ServiceType { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string StartName { get; private set; }
		public int StartType { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<ServiceSpecification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServiceSpecification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServiceSpecification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServiceSpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServiceSpecification
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CheckID = (string) (managementObject.Properties["CheckID"]?.Value ?? default(string)),
		 CheckMode = (bool) (managementObject.Properties["CheckMode"]?.Value ?? default(bool)),
		 Dependencies = (string) (managementObject.Properties["Dependencies"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DisplayName = (string) (managementObject.Properties["DisplayName"]?.Value ?? default(string)),
		 ErrorControl = (int) (managementObject.Properties["ErrorControl"]?.Value ?? default(int)),
		 ID = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 LoadOrderGroup = (string) (managementObject.Properties["LoadOrderGroup"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Password = (string) (managementObject.Properties["Password"]?.Value ?? default(string)),
		 ServiceType = (int) (managementObject.Properties["ServiceType"]?.Value ?? default(int)),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value ?? default(string)),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 StartName = (string) (managementObject.Properties["StartName"]?.Value ?? default(string)),
		 StartType = (int) (managementObject.Properties["StartType"]?.Value ?? default(int)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}