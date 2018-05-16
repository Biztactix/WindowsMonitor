using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Storage.Security
{
    /// <summary>
    /// </summary>
    public sealed class SecuritySettingOwner
    {
		public short Owner { get; private set; }
		public short SecuritySetting { get; private set; }

        public static IEnumerable<SecuritySettingOwner> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SecuritySettingOwner> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SecuritySettingOwner> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SecuritySettingOwner");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SecuritySettingOwner
                {
                     Owner = (short) (managementObject.Properties["Owner"]?.Value ?? default(short)),
		 SecuritySetting = (short) (managementObject.Properties["SecuritySetting"]?.Value ?? default(short))
                };
        }
    }
}