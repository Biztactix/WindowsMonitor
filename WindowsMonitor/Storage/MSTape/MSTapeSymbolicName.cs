using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.MSTape
{
    /// <summary>
    /// </summary>
    public sealed class MSTapeSymbolicName
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public string TapeSymbolicName { get; private set; }

        public static IEnumerable<MSTapeSymbolicName> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<MSTapeSymbolicName> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSTapeSymbolicName> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSTapeSymbolicName");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSTapeSymbolicName
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 TapeSymbolicName = (string) (managementObject.Properties["TapeSymbolicName"]?.Value ?? default(string))
                };
        }
    }
}