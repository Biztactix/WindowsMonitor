using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ExtensionInfoAction
    {
		public string ActionID { get; private set; }
		public string Argument { get; private set; }
		public string Caption { get; private set; }
		public string Command { get; private set; }
		public string Description { get; private set; }
		public ushort Direction { get; private set; }
		public string Extension { get; private set; }
		public string MIME { get; private set; }
		public string Name { get; private set; }
		public string ProgID { get; private set; }
		public string ShellNew { get; private set; }
		public string ShellNewValue { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Verb { get; private set; }
		public string Version { get; private set; }

        public static IEnumerable<ExtensionInfoAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ExtensionInfoAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ExtensionInfoAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ExtensionInfoAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ExtensionInfoAction
                {
                     ActionID = (string) (managementObject.Properties["ActionID"]?.Value),
		 Argument = (string) (managementObject.Properties["Argument"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Command = (string) (managementObject.Properties["Command"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 Extension = (string) (managementObject.Properties["Extension"]?.Value),
		 MIME = (string) (managementObject.Properties["MIME"]?.Value),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 ProgID = (string) (managementObject.Properties["ProgID"]?.Value),
		 ShellNew = (string) (managementObject.Properties["ShellNew"]?.Value),
		 ShellNewValue = (string) (managementObject.Properties["ShellNewValue"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Verb = (string) (managementObject.Properties["Verb"]?.Value),
		 Version = (string) (managementObject.Properties["Version"]?.Value)
                };
        }
    }
}