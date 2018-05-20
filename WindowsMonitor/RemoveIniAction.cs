using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class RemoveIniAction
    {
		public ushort Action { get; private set; }
		public string ActionID { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ushort Direction { get; private set; }
		public string key { get; private set; }
		public string Name { get; private set; }
		public string Section { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Value { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<RemoveIniAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<RemoveIniAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<RemoveIniAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RemoveIniAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new RemoveIniAction
                {
                     Action = (ushort) (managementObject.Properties["Action"]?.Value ?? default(ushort)),
		 ActionID = (string) (managementObject.Properties["ActionID"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 key = (string) (managementObject.Properties["key"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Section = (string) (managementObject.Properties["Section"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Value = (string) (managementObject.Properties["Value"]?.Value),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}