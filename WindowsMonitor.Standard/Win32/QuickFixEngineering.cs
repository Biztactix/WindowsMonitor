using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class QuickFixEngineering
    {
		public string Caption { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public string FixComments { get; private set; }
		public string HotFixID { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string InstalledBy { get; private set; }
		public string InstalledOn { get; private set; }
		public string Name { get; private set; }
		public string ServicePackInEffect { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<QuickFixEngineering> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<QuickFixEngineering> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<QuickFixEngineering> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_QuickFixEngineering");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new QuickFixEngineering
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FixComments = (string) (managementObject.Properties["FixComments"]?.Value ?? default(string)),
		 HotFixID = (string) (managementObject.Properties["HotFixID"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InstalledBy = (string) (managementObject.Properties["InstalledBy"]?.Value ?? default(string)),
		 InstalledOn = (string) (managementObject.Properties["InstalledOn"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ServicePackInEffect = (string) (managementObject.Properties["ServicePackInEffect"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}