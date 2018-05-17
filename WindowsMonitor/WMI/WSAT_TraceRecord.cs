using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class WSAT_TraceRecord
    {
		public dynamic ActivityID { get; private set; }
		public int EventID { get; private set; }
		public string TraceRecord { get; private set; }

        public static IEnumerable<WSAT_TraceRecord> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WSAT_TraceRecord> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WSAT_TraceRecord> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM WSAT_TraceRecord");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WSAT_TraceRecord
                {
                     ActivityID = (dynamic) (managementObject.Properties["ActivityID"]?.Value ?? default(dynamic)),
		 EventID = (int) (managementObject.Properties["EventID"]?.Value ?? default(int)),
		 TraceRecord = (string) (managementObject.Properties["TraceRecord"]?.Value ?? default(string))
                };
        }
    }
}