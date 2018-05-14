using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class Registry
    {
		public string Caption { get; private set; }
		public uint CurrentSize { get; private set; }
		public string Description { get; private set; }
		public DateTime InstallDate { get; private set; }
		public uint MaximumSize { get; private set; }
		public string Name { get; private set; }
		public uint ProposedSize { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<Registry> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Registry");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentSize = (uint) (managementObject.Properties["CurrentSize"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 MaximumSize = (uint) (managementObject.Properties["MaximumSize"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 ProposedSize = (uint) (managementObject.Properties["ProposedSize"]?.Value ?? default(uint)),
		 Status = (string) (managementObject.Properties["Status"]?.Value)
                };
        }
    }
}