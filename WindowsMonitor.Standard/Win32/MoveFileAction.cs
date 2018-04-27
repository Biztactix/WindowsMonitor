using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class MoveFileAction
    {
		public string ActionID { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string DestFolder { get; private set; }
		public string DestName { get; private set; }
		public ushort Direction { get; private set; }
		public string FileKey { get; private set; }
		public string Name { get; private set; }
		public ushort Options { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public string SourceFolder { get; private set; }
		public string SourceName { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<MoveFileAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MoveFileAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MoveFileAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_MoveFileAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MoveFileAction
                {
                     ActionID = (string) (managementObject.Properties["ActionID"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DestFolder = (string) (managementObject.Properties["DestFolder"]?.Value ?? default(string)),
		 DestName = (string) (managementObject.Properties["DestName"]?.Value ?? default(string)),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 FileKey = (string) (managementObject.Properties["FileKey"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Options = (ushort) (managementObject.Properties["Options"]?.Value ?? default(ushort)),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value ?? default(string)),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 SourceFolder = (string) (managementObject.Properties["SourceFolder"]?.Value ?? default(string)),
		 SourceName = (string) (managementObject.Properties["SourceName"]?.Value ?? default(string)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string))
                };
        }
    }
}