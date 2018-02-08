using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
        /// <summary>
        /// 
        /// </summary>
	public sealed class NetworkAdapterConfiguration
	{
		public Boolean ArpAlwaysSourceRoute { get; private set; }
public Boolean ArpUseEtherSNAP { get; private set; }
public String Caption { get; private set; }
public String DatabasePath { get; private set; }
public Boolean DeadGWDetectEnabled { get; private set; }
public String[] DefaultIPGateway { get; private set; }
public Byte DefaultTOS { get; private set; }
public Byte DefaultTTL { get; private set; }
public String Description { get; private set; }
public Boolean DHCPEnabled { get; private set; }
public DateTime DHCPLeaseExpires { get; private set; }
public DateTime DHCPLeaseObtained { get; private set; }
public String DHCPServer { get; private set; }
public String DNSDomain { get; private set; }
public String[] DNSDomainSuffixSearchOrder { get; private set; }
public Boolean DNSEnabledForWINSResolution { get; private set; }
public String DNSHostName { get; private set; }
public String[] DNSServerSearchOrder { get; private set; }
public Boolean DomainDNSRegistrationEnabled { get; private set; }
public UInt32 ForwardBufferMemory { get; private set; }
public Boolean FullDNSRegistrationEnabled { get; private set; }
public UInt16[] GatewayCostMetric { get; private set; }
public Byte IGMPLevel { get; private set; }
public UInt32 Index { get; private set; }
public UInt32 InterfaceIndex { get; private set; }
public String[] IPAddress { get; private set; }
public UInt32 IPConnectionMetric { get; private set; }
public Boolean IPEnabled { get; private set; }
public Boolean IPFilterSecurityEnabled { get; private set; }
public Boolean IPPortSecurityEnabled { get; private set; }
public String[] IPSecPermitIPProtocols { get; private set; }
public String[] IPSecPermitTCPPorts { get; private set; }
public String[] IPSecPermitUDPPorts { get; private set; }
public String[] IPSubnet { get; private set; }
public Boolean IPUseZeroBroadcast { get; private set; }
public String IPXAddress { get; private set; }
public Boolean IPXEnabled { get; private set; }
public UInt32[] IPXFrameType { get; private set; }
public UInt32 IPXMediaType { get; private set; }
public String[] IPXNetworkNumber { get; private set; }
public String IPXVirtualNetNumber { get; private set; }
public UInt32 KeepAliveInterval { get; private set; }
public UInt32 KeepAliveTime { get; private set; }
public String MACAddress { get; private set; }
public UInt32 MTU { get; private set; }
public UInt32 NumForwardPackets { get; private set; }
public Boolean PMTUBHDetectEnabled { get; private set; }
public Boolean PMTUDiscoveryEnabled { get; private set; }
public String ServiceName { get; private set; }
public String SettingID { get; private set; }
public UInt32 TcpipNetbiosOptions { get; private set; }
public UInt32 TcpMaxConnectRetransmissions { get; private set; }
public UInt32 TcpMaxDataRetransmissions { get; private set; }
public UInt32 TcpNumConnections { get; private set; }
public Boolean TcpUseRFC1122UrgentPointer { get; private set; }
public UInt16 TcpWindowSize { get; private set; }
public Boolean WINSEnableLMHostsLookup { get; private set; }
public String WINSHostLookupFile { get; private set; }
public String WINSPrimaryServer { get; private set; }
public String WINSScopeID { get; private set; }
public String WINSSecondaryServer { get; private set; }
		
		public static NetworkAdapterConfiguration[] Retrieve(string remote, string username, string password)
		{
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"),options);
            managementScope.Connect();

			return Retrieve(managementScope);
		}

		public static NetworkAdapterConfiguration[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NetworkAdapterConfiguration[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NetworkAdapterConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NetworkAdapterConfiguration
				{
					ArpAlwaysSourceRoute = (Boolean) managementObject.Properties["ArpAlwaysSourceRoute"].Value,
ArpUseEtherSNAP = (Boolean) managementObject.Properties["ArpUseEtherSNAP"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
DatabasePath = (String) managementObject.Properties["DatabasePath"].Value,
DeadGWDetectEnabled = (Boolean) managementObject.Properties["DeadGWDetectEnabled"].Value,
DefaultIPGateway = (String[]) managementObject.Properties["DefaultIPGateway"].Value,
DefaultTOS = (Byte) managementObject.Properties["DefaultTOS"].Value,
DefaultTTL = (Byte) managementObject.Properties["DefaultTTL"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DHCPEnabled = (Boolean) managementObject.Properties["DHCPEnabled"].Value,
DHCPLeaseExpires = (DateTime) managementObject.Properties["DHCPLeaseExpires"].Value,
DHCPLeaseObtained = (DateTime) managementObject.Properties["DHCPLeaseObtained"].Value,
DHCPServer = (String) managementObject.Properties["DHCPServer"].Value,
DNSDomain = (String) managementObject.Properties["DNSDomain"].Value,
DNSDomainSuffixSearchOrder = (String[]) managementObject.Properties["DNSDomainSuffixSearchOrder"].Value,
DNSEnabledForWINSResolution = (Boolean) managementObject.Properties["DNSEnabledForWINSResolution"].Value,
DNSHostName = (String) managementObject.Properties["DNSHostName"].Value,
DNSServerSearchOrder = (String[]) managementObject.Properties["DNSServerSearchOrder"].Value,
DomainDNSRegistrationEnabled = (Boolean) managementObject.Properties["DomainDNSRegistrationEnabled"].Value,
ForwardBufferMemory = (UInt32) managementObject.Properties["ForwardBufferMemory"].Value,
FullDNSRegistrationEnabled = (Boolean) managementObject.Properties["FullDNSRegistrationEnabled"].Value,
GatewayCostMetric = (UInt16[]) managementObject.Properties["GatewayCostMetric"].Value,
IGMPLevel = (Byte) managementObject.Properties["IGMPLevel"].Value,
Index = (UInt32) managementObject.Properties["Index"].Value,
InterfaceIndex = (UInt32) managementObject.Properties["InterfaceIndex"].Value,
IPAddress = (String[]) managementObject.Properties["IPAddress"].Value,
IPConnectionMetric = (UInt32) managementObject.Properties["IPConnectionMetric"].Value,
IPEnabled = (Boolean) managementObject.Properties["IPEnabled"].Value,
IPFilterSecurityEnabled = (Boolean) managementObject.Properties["IPFilterSecurityEnabled"].Value,
IPPortSecurityEnabled = (Boolean) managementObject.Properties["IPPortSecurityEnabled"].Value,
IPSecPermitIPProtocols = (String[]) managementObject.Properties["IPSecPermitIPProtocols"].Value,
IPSecPermitTCPPorts = (String[]) managementObject.Properties["IPSecPermitTCPPorts"].Value,
IPSecPermitUDPPorts = (String[]) managementObject.Properties["IPSecPermitUDPPorts"].Value,
IPSubnet = (String[]) managementObject.Properties["IPSubnet"].Value,
IPUseZeroBroadcast = (Boolean) managementObject.Properties["IPUseZeroBroadcast"].Value,
IPXAddress = (String) managementObject.Properties["IPXAddress"].Value,
IPXEnabled = (Boolean) managementObject.Properties["IPXEnabled"].Value,
IPXFrameType = (UInt32[]) managementObject.Properties["IPXFrameType"].Value,
IPXMediaType = (UInt32) managementObject.Properties["IPXMediaType"].Value,
IPXNetworkNumber = (String[]) managementObject.Properties["IPXNetworkNumber"].Value,
IPXVirtualNetNumber = (String) managementObject.Properties["IPXVirtualNetNumber"].Value,
KeepAliveInterval = (UInt32) managementObject.Properties["KeepAliveInterval"].Value,
KeepAliveTime = (UInt32) managementObject.Properties["KeepAliveTime"].Value,
MACAddress = (String) managementObject.Properties["MACAddress"].Value,
MTU = (UInt32) managementObject.Properties["MTU"].Value,
NumForwardPackets = (UInt32) managementObject.Properties["NumForwardPackets"].Value,
PMTUBHDetectEnabled = (Boolean) managementObject.Properties["PMTUBHDetectEnabled"].Value,
PMTUDiscoveryEnabled = (Boolean) managementObject.Properties["PMTUDiscoveryEnabled"].Value,
ServiceName = (String) managementObject.Properties["ServiceName"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
TcpipNetbiosOptions = (UInt32) managementObject.Properties["TcpipNetbiosOptions"].Value,
TcpMaxConnectRetransmissions = (UInt32) managementObject.Properties["TcpMaxConnectRetransmissions"].Value,
TcpMaxDataRetransmissions = (UInt32) managementObject.Properties["TcpMaxDataRetransmissions"].Value,
TcpNumConnections = (UInt32) managementObject.Properties["TcpNumConnections"].Value,
TcpUseRFC1122UrgentPointer = (Boolean) managementObject.Properties["TcpUseRFC1122UrgentPointer"].Value,
TcpWindowSize = (UInt16) managementObject.Properties["TcpWindowSize"].Value,
WINSEnableLMHostsLookup = (Boolean) managementObject.Properties["WINSEnableLMHostsLookup"].Value,
WINSHostLookupFile = (String) managementObject.Properties["WINSHostLookupFile"].Value,
WINSPrimaryServer = (String) managementObject.Properties["WINSPrimaryServer"].Value,
WINSScopeID = (String) managementObject.Properties["WINSScopeID"].Value,
WINSSecondaryServer = (String) managementObject.Properties["WINSSecondaryServer"].Value,
				});
            }

			return list.ToArray();
		}
	}
}