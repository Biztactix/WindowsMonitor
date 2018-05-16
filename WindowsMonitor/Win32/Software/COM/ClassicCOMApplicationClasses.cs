using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software.COM
{
    /// <summary>
    /// </summary>
    public sealed class ClassicCOMApplicationClasses
    {
		public string GroupComponent { get; private set; }
		public string PartComponent { get; private set; }

        public static IEnumerable<ClassicCOMApplicationClasses> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClassicCOMApplicationClasses> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClassicCOMApplicationClasses> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClassicCOMApplicationClasses");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClassicCOMApplicationClasses
                {
                     GroupComponent =  (managementObject.Properties["GroupComponent"]?.Value?.ToString()),
		 PartComponent =  (managementObject.Properties["PartComponent"]?.Value?.ToString())
                };
        }
    }
}