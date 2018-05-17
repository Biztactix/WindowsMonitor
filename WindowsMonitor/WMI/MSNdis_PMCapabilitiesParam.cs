using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_PMCapabilitiesParam
    {
		public dynamic DeviceSleepOnDisconnect { get; private set; }
		public dynamic Header { get; private set; }
		public dynamic PMARPOffload { get; private set; }
		public dynamic PMNDOffload { get; private set; }
		public dynamic PMWiFiRekeyOffload { get; private set; }
		public dynamic WakeOnMagicPacket { get; private set; }
		public dynamic WakeOnPattern { get; private set; }

        public static IEnumerable<MSNdis_PMCapabilitiesParam> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_PMCapabilitiesParam> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_PMCapabilitiesParam> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_PMCapabilitiesParam");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_PMCapabilitiesParam
                {
                     DeviceSleepOnDisconnect = (dynamic) (managementObject.Properties["DeviceSleepOnDisconnect"]?.Value ?? default(dynamic)),
		 Header = (dynamic) (managementObject.Properties["Header"]?.Value ?? default(dynamic)),
		 PMARPOffload = (dynamic) (managementObject.Properties["PMARPOffload"]?.Value ?? default(dynamic)),
		 PMNDOffload = (dynamic) (managementObject.Properties["PMNDOffload"]?.Value ?? default(dynamic)),
		 PMWiFiRekeyOffload = (dynamic) (managementObject.Properties["PMWiFiRekeyOffload"]?.Value ?? default(dynamic)),
		 WakeOnMagicPacket = (dynamic) (managementObject.Properties["WakeOnMagicPacket"]?.Value ?? default(dynamic)),
		 WakeOnPattern = (dynamic) (managementObject.Properties["WakeOnPattern"]?.Value ?? default(dynamic))
                };
        }
    }
}