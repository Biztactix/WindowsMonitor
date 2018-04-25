using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class RemoveFileAction
    {
		public string ActionID { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ushort Direction { get; private set; }
		public string DirProperty { get; private set; }
		public string File { get; private set; }
		public string FileKey { get; private set; }
		public string FileName { get; private set; }
		public ushort InstallMode { get; private set; }
		public string Name { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<RemoveFileAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<RemoveFileAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<RemoveFileAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RemoveFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new RemoveFileAction
                {
                     ActionID = (string) (managementObject.Properties["ActionID"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 DirProperty = (string) (managementObject.Properties["DirProperty"]?.Value ?? default(string)),
		 File = (string) (managementObject.Properties["File"]?.Value ?? default(string)),
		 FileKey = (string) (managementObject.Properties["FileKey"]?.Value ?? default(string)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 InstallMode = (ushort) (managementObject.Properties["InstallMode"]?.Value ?? default(ushort)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value ?? default(string)),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}