using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSiSCSIInitiator_ConnectionInformation
    {
		public byte[] CID { get; private set; }
		public string ConnectionID { get; private set; }
		public string InitiatorAddress { get; private set; }
		public ushort InitiatorPort { get; private set; }
		public string TargetAddress { get; private set; }
		public ushort TargetPort { get; private set; }

        public static IEnumerable<MSiSCSIInitiator_ConnectionInformation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSiSCSIInitiator_ConnectionInformation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSiSCSIInitiator_ConnectionInformation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSiSCSIInitiator_ConnectionInformation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSiSCSIInitiator_ConnectionInformation
                {
                     CID = (byte[]) (managementObject.Properties["CID"]?.Value ?? new byte[0]),
		 ConnectionID = (string) (managementObject.Properties["ConnectionID"]?.Value ?? default(string)),
		 InitiatorAddress = (string) (managementObject.Properties["InitiatorAddress"]?.Value ?? default(string)),
		 InitiatorPort = (ushort) (managementObject.Properties["InitiatorPort"]?.Value ?? default(ushort)),
		 TargetAddress = (string) (managementObject.Properties["TargetAddress"]?.Value ?? default(string)),
		 TargetPort = (ushort) (managementObject.Properties["TargetPort"]?.Value ?? default(ushort))
                };
        }
    }
}