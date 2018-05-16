using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ActionSequence
    {
		public string Next { get; private set; }
		public string Prior { get; private set; }

        public static IEnumerable<ActionSequence> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ActionSequence> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ActionSequence> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ActionSequence");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ActionSequence
                {
                     Next = (string) (managementObject.Properties["Next"]?.Value ?? default(string)),
		 Prior = (string) (managementObject.Properties["Prior"]?.Value ?? default(string))
                };
        }
    }
}