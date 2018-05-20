using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class ClassInfoAction
    {
		public string ActionID { get; private set; }
		public string AppID { get; private set; }
		public string Argument { get; private set; }
		public string Caption { get; private set; }
		public string CLSID { get; private set; }
		public string Context { get; private set; }
		public string DefInprocHandler { get; private set; }
		public string Description { get; private set; }
		public ushort Direction { get; private set; }
		public string FileTypeMask { get; private set; }
		public ushort Insertable { get; private set; }
		public string Name { get; private set; }
		public string ProgID { get; private set; }
		public string RemoteName { get; private set; }
		public string SoftwareElementID { get; private set; }
		public ushort SoftwareElementState { get; private set; }
		public ushort TargetOperatingSystem { get; private set; }
		public string Version { get; private set; }
		public string VIProgID { get; private set; }

        public static IEnumerable<ClassInfoAction> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClassInfoAction> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClassInfoAction> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClassInfoAction");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClassInfoAction
                {
                     ActionID = (string) (managementObject.Properties["ActionID"]?.Value),
		 AppID = (string) (managementObject.Properties["AppID"]?.Value),
		 Argument = (string) (managementObject.Properties["Argument"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CLSID = (string) (managementObject.Properties["CLSID"]?.Value),
		 Context = (string) (managementObject.Properties["Context"]?.Value),
		 DefInprocHandler = (string) (managementObject.Properties["DefInprocHandler"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Direction = (ushort) (managementObject.Properties["Direction"]?.Value ?? default(ushort)),
		 FileTypeMask = (string) (managementObject.Properties["FileTypeMask"]?.Value),
		 Insertable = (ushort) (managementObject.Properties["Insertable"]?.Value ?? default(ushort)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 ProgID = (string) (managementObject.Properties["ProgID"]?.Value),
		 RemoteName = (string) (managementObject.Properties["RemoteName"]?.Value),
		 SoftwareElementID = (string) (managementObject.Properties["SoftwareElementID"]?.Value),
		 SoftwareElementState = (ushort) (managementObject.Properties["SoftwareElementState"]?.Value ?? default(ushort)),
		 TargetOperatingSystem = (ushort) (managementObject.Properties["TargetOperatingSystem"]?.Value ?? default(ushort)),
		 Version = (string) (managementObject.Properties["Version"]?.Value),
		 VIProgID = (string) (managementObject.Properties["VIProgID"]?.Value)
                };
        }
    }
}