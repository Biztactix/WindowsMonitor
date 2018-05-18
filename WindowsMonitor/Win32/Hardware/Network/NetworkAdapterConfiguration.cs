using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Network
{
    /// <summary>
    /// </summary>
    public sealed class NetworkAdapterConfiguration
    {
		public bool ArpAlwaysSourceRoute { get; private set; }
		public bool ArpUseEtherSNAP { get; private set; }
		public string Caption { get; private set; }
		public string DatabasePath { get; private set; }
		public bool DeadGWDetectEnabled { get; private set; }
		public string[] DefaultIPGateway { get; private set; }
		public byte DefaultTOS { get; private set; }
		public byte DefaultTTL { get; private set; }
		public string Description { get; private set; }
		public bool DHCPEnabled { get; private set; }
		public DateTime DHCPLeaseExpires { get; private set; }
		public DateTime DHCPLeaseObtained { get; private set; }
		public string DHCPServer { get; private set; }
		public string DNSDomain { get; private set; }
		public string[] DNSDomainSuffixSearchOrder { get; private set; }
		public bool DNSEnabledForWINSResolution { get; private set; }
		public string DNSHostName { get; private set; }
		public string[] DNSServerSearchOrder { get; private set; }
		public bool DomainDNSRegistrationEnabled { get; private set; }
		public uint ForwardBufferMemory { get; private set; }
		public bool FullDNSRegistrationEnabled { get; private set; }
		public ushort[] GatewayCostMetric { get; private set; }
		public byte IGMPLevel { get; private set; }
		public uint Index { get; private set; }
		public uint InterfaceIndex { get; private set; }
		public string[] IPAddress { get; private set; }
		public uint IPConnectionMetric { get; private set; }
		public bool IPEnabled { get; private set; }
		public bool IPFilterSecurityEnabled { get; private set; }
		public bool IPPortSecurityEnabled { get; private set; }
		public string[] IPSecPermitIPProtocols { get; private set; }
		public string[] IPSecPermitTCPPorts { get; private set; }
		public string[] IPSecPermitUDPPorts { get; private set; }
		public string[] IPSubnet { get; private set; }
		public bool IPUseZeroBroadcast { get; private set; }
		public string IPXAddress { get; private set; }
		public bool IPXEnabled { get; private set; }
		public uint[] IPXFrameType { get; private set; }
		public uint IPXMediaType { get; private set; }
		public string[] IPXNetworkNumber { get; private set; }
		public string IPXVirtualNetNumber { get; private set; }
		public uint KeepAliveInterval { get; private set; }
		public uint KeepAliveTime { get; private set; }
		public string MACAddress { get; private set; }
		public uint MTU { get; private set; }
		public uint NumForwardPackets { get; private set; }
		public bool PMTUBHDetectEnabled { get; private set; }
		public bool PMTUDiscoveryEnabled { get; private set; }
		public string ServiceName { get; private set; }
		public string SettingID { get; private set; }
		public uint TcpipNetbiosOptions { get; private set; }
		public uint TcpMaxConnectRetransmissions { get; private set; }
		public uint TcpMaxDataRetransmissions { get; private set; }
		public uint TcpNumConnections { get; private set; }
		public bool TcpUseRFC1122UrgentPointer { get; private set; }
		public ushort TcpWindowSize { get; private set; }
		public bool WINSEnableLMHostsLookup { get; private set; }
		public string WINSHostLookupFile { get; private set; }
		public string WINSPrimaryServer { get; private set; }
		public string WINSScopeID { get; private set; }
		public string WINSSecondaryServer { get; private set; }

        public static IEnumerable<NetworkAdapterConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetworkAdapterConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetworkAdapterConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetworkAdapterConfiguration
                {
                     ArpAlwaysSourceRoute = (bool) (managementObject.Properties["ArpAlwaysSourceRoute"]?.Value ?? default(bool)),
		 ArpUseEtherSNAP = (bool) (managementObject.Properties["ArpUseEtherSNAP"]?.Value ?? default(bool)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DatabasePath = (string) (managementObject.Properties["DatabasePath"]?.Value),
		 DeadGWDetectEnabled = (bool) (managementObject.Properties["DeadGWDetectEnabled"]?.Value ?? default(bool)),
		 DefaultIPGateway = (string[]) (managementObject.Properties["DefaultIPGateway"]?.Value ?? new string[0]),
		 DefaultTOS = (byte) (managementObject.Properties["DefaultTOS"]?.Value ?? default(byte)),
		 DefaultTTL = (byte) (managementObject.Properties["DefaultTTL"]?.Value ?? default(byte)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DHCPEnabled = (bool) (managementObject.Properties["DHCPEnabled"]?.Value ?? default(bool)),
		 DHCPLeaseExpires = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["DHCPLeaseExpires"]?.Value as string ?? "00010102000000.000000+060"),
		 DHCPLeaseObtained = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["DHCPLeaseObtained"]?.Value as string ?? "00010102000000.000000+060"),
		 DHCPServer = (string) (managementObject.Properties["DHCPServer"]?.Value),
		 DNSDomain = (string) (managementObject.Properties["DNSDomain"]?.Value),
		 DNSDomainSuffixSearchOrder = (string[]) (managementObject.Properties["DNSDomainSuffixSearchOrder"]?.Value ?? new string[0]),
		 DNSEnabledForWINSResolution = (bool) (managementObject.Properties["DNSEnabledForWINSResolution"]?.Value ?? default(bool)),
		 DNSHostName = (string) (managementObject.Properties["DNSHostName"]?.Value),
		 DNSServerSearchOrder = (string[]) (managementObject.Properties["DNSServerSearchOrder"]?.Value ?? new string[0]),
		 DomainDNSRegistrationEnabled = (bool) (managementObject.Properties["DomainDNSRegistrationEnabled"]?.Value ?? default(bool)),
		 ForwardBufferMemory = (uint) (managementObject.Properties["ForwardBufferMemory"]?.Value ?? default(uint)),
		 FullDNSRegistrationEnabled = (bool) (managementObject.Properties["FullDNSRegistrationEnabled"]?.Value ?? default(bool)),
		 GatewayCostMetric = (ushort[]) (managementObject.Properties["GatewayCostMetric"]?.Value ?? new ushort[0]),
		 IGMPLevel = (byte) (managementObject.Properties["IGMPLevel"]?.Value ?? default(byte)),
		 Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 InterfaceIndex = (uint) (managementObject.Properties["InterfaceIndex"]?.Value ?? default(uint)),
		 IPAddress = (string[]) (managementObject.Properties["IPAddress"]?.Value ?? new string[0]),
		 IPConnectionMetric = (uint) (managementObject.Properties["IPConnectionMetric"]?.Value ?? default(uint)),
		 IPEnabled = (bool) (managementObject.Properties["IPEnabled"]?.Value ?? default(bool)),
		 IPFilterSecurityEnabled = (bool) (managementObject.Properties["IPFilterSecurityEnabled"]?.Value ?? default(bool)),
		 IPPortSecurityEnabled = (bool) (managementObject.Properties["IPPortSecurityEnabled"]?.Value ?? default(bool)),
		 IPSecPermitIPProtocols = (string[]) (managementObject.Properties["IPSecPermitIPProtocols"]?.Value ?? new string[0]),
		 IPSecPermitTCPPorts = (string[]) (managementObject.Properties["IPSecPermitTCPPorts"]?.Value ?? new string[0]),
		 IPSecPermitUDPPorts = (string[]) (managementObject.Properties["IPSecPermitUDPPorts"]?.Value ?? new string[0]),
		 IPSubnet = (string[]) (managementObject.Properties["IPSubnet"]?.Value ?? new string[0]),
		 IPUseZeroBroadcast = (bool) (managementObject.Properties["IPUseZeroBroadcast"]?.Value ?? default(bool)),
		 IPXAddress = (string) (managementObject.Properties["IPXAddress"]?.Value),
		 IPXEnabled = (bool) (managementObject.Properties["IPXEnabled"]?.Value ?? default(bool)),
		 IPXFrameType = (uint[]) (managementObject.Properties["IPXFrameType"]?.Value ?? new uint[0]),
		 IPXMediaType = (uint) (managementObject.Properties["IPXMediaType"]?.Value ?? default(uint)),
		 IPXNetworkNumber = (string[]) (managementObject.Properties["IPXNetworkNumber"]?.Value ?? new string[0]),
		 IPXVirtualNetNumber = (string) (managementObject.Properties["IPXVirtualNetNumber"]?.Value),
		 KeepAliveInterval = (uint) (managementObject.Properties["KeepAliveInterval"]?.Value ?? default(uint)),
		 KeepAliveTime = (uint) (managementObject.Properties["KeepAliveTime"]?.Value ?? default(uint)),
		 MACAddress = (string) (managementObject.Properties["MACAddress"]?.Value),
		 MTU = (uint) (managementObject.Properties["MTU"]?.Value ?? default(uint)),
		 NumForwardPackets = (uint) (managementObject.Properties["NumForwardPackets"]?.Value ?? default(uint)),
		 PMTUBHDetectEnabled = (bool) (managementObject.Properties["PMTUBHDetectEnabled"]?.Value ?? default(bool)),
		 PMTUDiscoveryEnabled = (bool) (managementObject.Properties["PMTUDiscoveryEnabled"]?.Value ?? default(bool)),
		 ServiceName = (string) (managementObject.Properties["ServiceName"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value),
		 TcpipNetbiosOptions = (uint) (managementObject.Properties["TcpipNetbiosOptions"]?.Value ?? default(uint)),
		 TcpMaxConnectRetransmissions = (uint) (managementObject.Properties["TcpMaxConnectRetransmissions"]?.Value ?? default(uint)),
		 TcpMaxDataRetransmissions = (uint) (managementObject.Properties["TcpMaxDataRetransmissions"]?.Value ?? default(uint)),
		 TcpNumConnections = (uint) (managementObject.Properties["TcpNumConnections"]?.Value ?? default(uint)),
		 TcpUseRFC1122UrgentPointer = (bool) (managementObject.Properties["TcpUseRFC1122UrgentPointer"]?.Value ?? default(bool)),
		 TcpWindowSize = (ushort) (managementObject.Properties["TcpWindowSize"]?.Value ?? default(ushort)),
		 WINSEnableLMHostsLookup = (bool) (managementObject.Properties["WINSEnableLMHostsLookup"]?.Value ?? default(bool)),
		 WINSHostLookupFile = (string) (managementObject.Properties["WINSHostLookupFile"]?.Value),
		 WINSPrimaryServer = (string) (managementObject.Properties["WINSPrimaryServer"]?.Value),
		 WINSScopeID = (string) (managementObject.Properties["WINSScopeID"]?.Value),
		 WINSSecondaryServer = (string) (managementObject.Properties["WINSSecondaryServer"]?.Value)
                };
        }
    }
}