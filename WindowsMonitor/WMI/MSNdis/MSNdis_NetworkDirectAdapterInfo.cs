using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_NetworkDirectAdapterInfo
    {
		public uint DeviceId { get; private set; }
		public uint FRMRPageCount { get; private set; }
		public bool InOrderDMA { get; private set; }
		public uint LargeRequestThreshold { get; private set; }
		public uint MaxCalleeData { get; private set; }
		public uint MaxCallerData { get; private set; }
		public uint MaxCqDepth { get; private set; }
		public uint MaxInboundReadLimit { get; private set; }
		public uint MaxInitiatorQueueDepth { get; private set; }
		public uint MaxInitiatorRequestSge { get; private set; }
		public uint MaxInlineDataSize { get; private set; }
		public uint MaxOutboundReadLimit { get; private set; }
		public uint MaxReadRequestSge { get; private set; }
		public uint MaxReceiveQueueDepth { get; private set; }
		public uint MaxReceiveRequestSge { get; private set; }
		public ulong MaxRegistrationSize { get; private set; }
		public uint MaxSrqDepth { get; private set; }
		public uint MaxTransferLength { get; private set; }
		public ulong MaxWindowSize { get; private set; }
		public bool SupportsCQResize { get; private set; }
		public bool SupportsLoopbackConnections { get; private set; }
		public uint VendorId { get; private set; }
		public dynamic Version { get; private set; }

        public static IEnumerable<MSNdis_NetworkDirectAdapterInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_NetworkDirectAdapterInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_NetworkDirectAdapterInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_NetworkDirectAdapterInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_NetworkDirectAdapterInfo
                {
                     DeviceId = (uint) (managementObject.Properties["DeviceId"]?.Value ?? default(uint)),
		 FRMRPageCount = (uint) (managementObject.Properties["FRMRPageCount"]?.Value ?? default(uint)),
		 InOrderDMA = (bool) (managementObject.Properties["InOrderDMA"]?.Value ?? default(bool)),
		 LargeRequestThreshold = (uint) (managementObject.Properties["LargeRequestThreshold"]?.Value ?? default(uint)),
		 MaxCalleeData = (uint) (managementObject.Properties["MaxCalleeData"]?.Value ?? default(uint)),
		 MaxCallerData = (uint) (managementObject.Properties["MaxCallerData"]?.Value ?? default(uint)),
		 MaxCqDepth = (uint) (managementObject.Properties["MaxCqDepth"]?.Value ?? default(uint)),
		 MaxInboundReadLimit = (uint) (managementObject.Properties["MaxInboundReadLimit"]?.Value ?? default(uint)),
		 MaxInitiatorQueueDepth = (uint) (managementObject.Properties["MaxInitiatorQueueDepth"]?.Value ?? default(uint)),
		 MaxInitiatorRequestSge = (uint) (managementObject.Properties["MaxInitiatorRequestSge"]?.Value ?? default(uint)),
		 MaxInlineDataSize = (uint) (managementObject.Properties["MaxInlineDataSize"]?.Value ?? default(uint)),
		 MaxOutboundReadLimit = (uint) (managementObject.Properties["MaxOutboundReadLimit"]?.Value ?? default(uint)),
		 MaxReadRequestSge = (uint) (managementObject.Properties["MaxReadRequestSge"]?.Value ?? default(uint)),
		 MaxReceiveQueueDepth = (uint) (managementObject.Properties["MaxReceiveQueueDepth"]?.Value ?? default(uint)),
		 MaxReceiveRequestSge = (uint) (managementObject.Properties["MaxReceiveRequestSge"]?.Value ?? default(uint)),
		 MaxRegistrationSize = (ulong) (managementObject.Properties["MaxRegistrationSize"]?.Value ?? default(ulong)),
		 MaxSrqDepth = (uint) (managementObject.Properties["MaxSrqDepth"]?.Value ?? default(uint)),
		 MaxTransferLength = (uint) (managementObject.Properties["MaxTransferLength"]?.Value ?? default(uint)),
		 MaxWindowSize = (ulong) (managementObject.Properties["MaxWindowSize"]?.Value ?? default(ulong)),
		 SupportsCQResize = (bool) (managementObject.Properties["SupportsCQResize"]?.Value ?? default(bool)),
		 SupportsLoopbackConnections = (bool) (managementObject.Properties["SupportsLoopbackConnections"]?.Value ?? default(bool)),
		 VendorId = (uint) (managementObject.Properties["VendorId"]?.Value ?? default(uint)),
		 Version = (dynamic) (managementObject.Properties["Version"]?.Value ?? default(dynamic))
                };
        }
    }
}