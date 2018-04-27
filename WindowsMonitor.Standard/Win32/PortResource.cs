using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class PortResource
    {
		public bool Alias { get; private set; }
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public ulong EndingAddress { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public ulong StartingAddress { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<PortResource> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PortResource> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PortResource> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PortResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PortResource
                {
                     Alias = (bool) (managementObject.Properties["Alias"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EndingAddress = (ulong) (managementObject.Properties["EndingAddress"]?.Value ?? default(ulong)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 StartingAddress = (ulong) (managementObject.Properties["StartingAddress"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}