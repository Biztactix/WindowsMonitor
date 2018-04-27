using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SMS_AI_Office14ProductMapping
    {
		public string ID { get; private set; }
		public string MPC { get; private set; }
		public string ProductName { get; private set; }

        public static IEnumerable<SMS_AI_Office14ProductMapping> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SMS_AI_Office14ProductMapping> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SMS_AI_Office14ProductMapping> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SMS_AI_Office14ProductMapping");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SMS_AI_Office14ProductMapping
                {
                     ID = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 MPC = (string) (managementObject.Properties["MPC"]?.Value ?? default(string)),
		 ProductName = (string) (managementObject.Properties["ProductName"]?.Value ?? default(string))
                };
        }
    }
}