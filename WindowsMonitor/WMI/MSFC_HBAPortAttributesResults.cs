using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSFC_HBAPortAttributesResults
    {
		public byte[] FabricName { get; private set; }
		public byte[] NodeWWN { get; private set; }
		public uint NumberofDiscoveredPorts { get; private set; }
		public byte[] PortActiveFc4Types { get; private set; }
		public uint PortFcId { get; private set; }
		public uint PortMaxFrameSize { get; private set; }
		public uint PortSpeed { get; private set; }
		public uint PortState { get; private set; }
		public uint PortSupportedClassofService { get; private set; }
		public byte[] PortSupportedFc4Types { get; private set; }
		public uint PortSupportedSpeed { get; private set; }
		public uint PortType { get; private set; }
		public byte[] PortWWN { get; private set; }

        public static IEnumerable<MSFC_HBAPortAttributesResults> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSFC_HBAPortAttributesResults> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSFC_HBAPortAttributesResults> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFC_HBAPortAttributesResults");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSFC_HBAPortAttributesResults
                {
                     FabricName = (byte[]) (managementObject.Properties["FabricName"]?.Value ?? new byte[0]),
		 NodeWWN = (byte[]) (managementObject.Properties["NodeWWN"]?.Value ?? new byte[0]),
		 NumberofDiscoveredPorts = (uint) (managementObject.Properties["NumberofDiscoveredPorts"]?.Value ?? default(uint)),
		 PortActiveFc4Types = (byte[]) (managementObject.Properties["PortActiveFc4Types"]?.Value ?? new byte[0]),
		 PortFcId = (uint) (managementObject.Properties["PortFcId"]?.Value ?? default(uint)),
		 PortMaxFrameSize = (uint) (managementObject.Properties["PortMaxFrameSize"]?.Value ?? default(uint)),
		 PortSpeed = (uint) (managementObject.Properties["PortSpeed"]?.Value ?? default(uint)),
		 PortState = (uint) (managementObject.Properties["PortState"]?.Value ?? default(uint)),
		 PortSupportedClassofService = (uint) (managementObject.Properties["PortSupportedClassofService"]?.Value ?? default(uint)),
		 PortSupportedFc4Types = (byte[]) (managementObject.Properties["PortSupportedFc4Types"]?.Value ?? new byte[0]),
		 PortSupportedSpeed = (uint) (managementObject.Properties["PortSupportedSpeed"]?.Value ?? default(uint)),
		 PortType = (uint) (managementObject.Properties["PortType"]?.Value ?? default(uint)),
		 PortWWN = (byte[]) (managementObject.Properties["PortWWN"]?.Value ?? new byte[0])
                };
        }
    }
}