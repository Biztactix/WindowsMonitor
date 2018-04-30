using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.NamedJobs
{
    /// <summary>
    /// </summary>
    public sealed class NamedJobObjectLimit
    {
		public short Collection { get; private set; }
		public short Setting { get; private set; }

        public static IEnumerable<NamedJobObjectLimit> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NamedJobObjectLimit> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NamedJobObjectLimit> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NamedJobObjectLimit");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NamedJobObjectLimit
                {
                     Collection = (short) (managementObject.Properties["Collection"]?.Value ?? default(short)),
		 Setting = (short) (managementObject.Properties["Setting"]?.Value ?? default(short))
                };
        }
    }
}