using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class ClientApplicationSetting
    {
		public string Application { get; private set; }
		public string Client { get; private set; }

        public static IEnumerable<ClientApplicationSetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClientApplicationSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClientApplicationSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClientApplicationSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClientApplicationSetting
                {
                     Application =  (managementObject.Properties["Application"]?.Value?.ToString()),
		 Client =  (managementObject.Properties["Client"]?.Value?.ToString())
                };
        }
    }
}