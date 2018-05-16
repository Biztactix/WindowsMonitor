using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareFeatureParent
    {
		public short Antecedent { get; private set; }
		public short Dependent { get; private set; }

        public static IEnumerable<SoftwareFeatureParent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareFeatureParent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareFeatureParent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SoftwareFeatureParent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareFeatureParent
                {
                     Antecedent = (short) (managementObject.Properties["Antecedent"]?.Value ?? default(short)),
		 Dependent = (short) (managementObject.Properties["Dependent"]?.Value ?? default(short))
                };
        }
    }
}