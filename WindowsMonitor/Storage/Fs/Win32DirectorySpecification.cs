using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.Fs
{
    /// <summary>
    /// </summary>
    public sealed class Win32DirectorySpecification
    {
		public string Caption { get; private set; }
		public string CheckID { get; private set; }
		public bool CheckMode { get; private set; }
		public string DefaultDir { get; private set; }
		public string Description { get; private set; }
		public string Directory { get; private set; }
		public string DirectoryPath { get; private set; }
		public ushort DirectoryType { get; private set; }
		public string Name { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<Win32DirectorySpecification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Win32DirectorySpecification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Win32DirectorySpecification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DirectorySpecification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32DirectorySpecification
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CheckID = (string) (managementObject.Properties["CheckID"]?.Value),
		 CheckMode = (bool) (managementObject.Properties["CheckMode"]?.Value ?? default(bool)),
		 DefaultDir = (string) (managementObject.Properties["DefaultDir"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Directory = (string) (managementObject.Properties["Directory"]?.Value),
		 DirectoryPath = (string) (managementObject.Properties["DirectoryPath"]?.Value),
		 DirectoryType = (ushort) (managementObject.Properties["DirectoryType"]?.Value ?? default(ushort)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}