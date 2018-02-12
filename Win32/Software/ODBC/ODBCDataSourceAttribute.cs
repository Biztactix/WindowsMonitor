using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ODBCDataSourceAttribute
    {
		public short Check { get; private set; }
		public short Setting { get; private set; }

        public static IEnumerable<ODBCDataSourceAttribute> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ODBCDataSourceAttribute> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ODBCDataSourceAttribute> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ODBCDataSourceAttribute");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ODBCDataSourceAttribute
                {
                     Check = (short) (managementObject.Properties["Check"]?.Value ?? default(short)),
		 Setting = (short) (managementObject.Properties["Setting"]?.Value ?? default(short))
                };
        }
    }
}