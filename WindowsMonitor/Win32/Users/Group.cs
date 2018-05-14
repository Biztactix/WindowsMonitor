using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class Group
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Domain { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool LocalAccount { get; private set; }
		public string Name { get; private set; }
		public string SID { get; private set; }
		public byte SIDType { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<Group> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Group> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Group> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Group");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Group
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Domain = (string) (managementObject.Properties["Domain"]?.Value),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LocalAccount = (bool) (managementObject.Properties["LocalAccount"]?.Value ?? default(bool)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SID = (string) (managementObject.Properties["SID"]?.Value),
		 SIDType = (byte) (managementObject.Properties["SIDType"]?.Value ?? default(byte)),
		 Status = (string) (managementObject.Properties["Status"]?.Value)
                };
        }
    }
}