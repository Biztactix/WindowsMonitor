using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Users
{
    /// <summary>
    /// </summary>
    public sealed class GroupInDomain
    {
		public string GroupComponent { get; private set; }
		public string PartComponent { get; private set; }

        public static IEnumerable<GroupInDomain> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<GroupInDomain> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<GroupInDomain> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_GroupInDomain");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new GroupInDomain
                {
                     GroupComponent = (string) (managementObject.Properties["GroupComponent"]?.Value ?? default(string)),
		 PartComponent = (string) (managementObject.Properties["PartComponent"]?.Value ?? default(string))
                };
        }
    }
}