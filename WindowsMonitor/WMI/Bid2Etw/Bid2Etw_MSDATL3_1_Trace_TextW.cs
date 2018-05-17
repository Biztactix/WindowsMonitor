using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Bid2Etw_MSDATL3_1_Trace_TextW
    {
		public uint ModID { get; private set; }
		public dynamic msgStr { get; private set; }

        public static IEnumerable<Bid2Etw_MSDATL3_1_Trace_TextW> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Bid2Etw_MSDATL3_1_Trace_TextW> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Bid2Etw_MSDATL3_1_Trace_TextW> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Bid2Etw_MSDATL3_1_Trace_TextW");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Bid2Etw_MSDATL3_1_Trace_TextW
                {
                     ModID = (uint) (managementObject.Properties["ModID"]?.Value ?? default(uint)),
		 msgStr = (dynamic) (managementObject.Properties["msgStr"]?.Value ?? default(dynamic))
                };
        }
    }
}