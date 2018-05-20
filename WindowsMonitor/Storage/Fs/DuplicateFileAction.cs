using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.Fs
{
    /// <summary>
    /// </summary>
    public sealed class DuplicateFileAction
    {
		public string ActionID { get; private set; }
		public string Caption { get; private set; }
		public bool DeleteAfterCopy { get; private set; }
		public string Description { get; private set; }
		public string Destination { get; private set; }
		public ushort Direction { get; private set; }
		public string FileKey { get; private set; }
		public string Name { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string Source { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<DuplicateFileAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DuplicateFileAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DuplicateFileAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DuplicateFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DuplicateFileAction
                {
                     ActionID = (string) (managementObject.Properties["ActionID"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DeleteAfterCopy = (bool) (managementObject.Properties["DeleteAfterCopy"]?.Value ?? default(bool)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Destination = (string) (managementObject.Properties["Destination"]?.Value),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 FileKey = (string) (managementObject.Properties["FileKey"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 Source = (string) (managementObject.Properties["Source"]?.Value),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}