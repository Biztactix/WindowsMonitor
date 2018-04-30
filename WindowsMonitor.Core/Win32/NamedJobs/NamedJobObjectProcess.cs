using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.NamedJobs
{
    /// <summary>
    /// </summary>
    public sealed class NamedJobObjectProcess
    {
		public short Collection { get; private set; }
		public short Member { get; private set; }

        public static IEnumerable<NamedJobObjectProcess> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NamedJobObjectProcess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NamedJobObjectProcess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NamedJobObjectProcess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NamedJobObjectProcess
                {
                     Collection = (short) (managementObject.Properties["Collection"]?.Value ?? default(short)),
		 Member = (short) (managementObject.Properties["Member"]?.Value ?? default(short))
                };
        }
    }
}