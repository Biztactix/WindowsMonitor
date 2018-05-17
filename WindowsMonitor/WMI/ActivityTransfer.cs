using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ActivityTransfer
    {
		public dynamic ActivityID { get; private set; }
		public dynamic RelatedActivityID { get; private set; }

        public static IEnumerable<ActivityTransfer> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ActivityTransfer> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ActivityTransfer> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ActivityTransfer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ActivityTransfer
                {
                     ActivityID = (dynamic) (managementObject.Properties["ActivityID"]?.Value ?? default(dynamic)),
		 RelatedActivityID = (dynamic) (managementObject.Properties["RelatedActivityID"]?.Value ?? default(dynamic))
                };
        }
    }
}