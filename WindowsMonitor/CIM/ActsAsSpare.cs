using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ActsAsSpare
    {
        public string Group { get; private set; }
        public bool HotStandby { get; private set; }
        public string Spare { get; private set; }

        public static IEnumerable<ActsAsSpare> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ActsAsSpare> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ActsAsSpare> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ActsAsSpare");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ActsAsSpare
                {
                    Group = (string) (managementObject.Properties["Group"]?.Value ?? default(string)),
                    HotStandby = (bool) (managementObject.Properties["HotStandby"]?.Value ?? default(bool)),
                    Spare = (string) (managementObject.Properties["Spare"]?.Value ?? default(string))
                };
        }
    }
}