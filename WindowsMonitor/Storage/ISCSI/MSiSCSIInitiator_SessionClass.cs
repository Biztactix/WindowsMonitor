using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_SessionClass
    {
		public dynamic[] ConnectionInformation { get; private set; }
		public dynamic[] Devices { get; private set; }
		public string InitiatorName { get; private set; }
		public byte[] ISID { get; private set; }
		public string SessionId { get; private set; }
		public string TargetName { get; private set; }
		public string TargetNodeName { get; private set; }
		public byte[] TSID { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_SessionClass> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_SessionClass> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_SessionClass> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_SessionClass");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_SessionClass
                {
                     ConnectionInformation = (dynamic[]) (managementObject.Properties["ConnectionInformation"]?.Value ?? new dynamic[0]),
		 Devices = (dynamic[]) (managementObject.Properties["Devices"]?.Value ?? new dynamic[0]),
		 InitiatorName = (string) (managementObject.Properties["InitiatorName"]?.Value ?? default(string)),
		 ISID = (byte[]) (managementObject.Properties["ISID"]?.Value ?? new byte[0]),
		 SessionId = (string) (managementObject.Properties["SessionId"]?.Value ?? default(string)),
		 TargetName = (string) (managementObject.Properties["TargetName"]?.Value ?? default(string)),
		 TargetNodeName = (string) (managementObject.Properties["TargetNodeName"]?.Value ?? default(string)),
		 TSID = (byte[]) (managementObject.Properties["TSID"]?.Value ?? new byte[0])
                };
        }
    }
}