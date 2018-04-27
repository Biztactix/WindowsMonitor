using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Network
{
    /// <summary>
    /// </summary>
    public sealed class NetworkAdapterSetting
    {
		public short Element { get; private set; }
		public short Setting { get; private set; }

        public static IEnumerable<NetworkAdapterSetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetworkAdapterSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetworkAdapterSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetworkAdapterSetting
                {
                     Element = (short) (managementObject.Properties["Element"]?.Value ?? default(short)),
		 Setting = (short) (managementObject.Properties["Setting"]?.Value ?? default(short))
                };
        }
    }
}