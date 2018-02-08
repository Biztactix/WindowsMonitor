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
	public sealed class NetworkProtocol
	{
		public String Caption { get; private set; }
public Boolean ConnectionlessService { get; private set; }
public String Description { get; private set; }
public Boolean GuaranteesDelivery { get; private set; }
public Boolean GuaranteesSequencing { get; private set; }
public DateTime InstallDate { get; private set; }
public UInt32 MaximumAddressSize { get; private set; }
public UInt32 MaximumMessageSize { get; private set; }
public Boolean MessageOriented { get; private set; }
public UInt32 MinimumAddressSize { get; private set; }
public String Name { get; private set; }
public Boolean PseudoStreamOriented { get; private set; }
public String Status { get; private set; }
public Boolean SupportsBroadcasting { get; private set; }
public Boolean SupportsConnectData { get; private set; }
public Boolean SupportsDisconnectData { get; private set; }
public Boolean SupportsEncryption { get; private set; }
public Boolean SupportsExpeditedData { get; private set; }
public Boolean SupportsFragmentation { get; private set; }
public Boolean SupportsGracefulClosing { get; private set; }
public Boolean SupportsGuaranteedBandwidth { get; private set; }
public Boolean SupportsMulticasting { get; private set; }
public Boolean SupportsQualityofService { get; private set; }
		
		public static NetworkProtocol[] Retrieve(string remote, string username, string password)
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

		public static NetworkProtocol[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NetworkProtocol[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkProtocol");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NetworkProtocol>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NetworkProtocol
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
ConnectionlessService = (Boolean) managementObject.Properties["ConnectionlessService"].Value,
Description = (String) managementObject.Properties["Description"].Value,
GuaranteesDelivery = (Boolean) managementObject.Properties["GuaranteesDelivery"].Value,
GuaranteesSequencing = (Boolean) managementObject.Properties["GuaranteesSequencing"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
MaximumAddressSize = (UInt32) managementObject.Properties["MaximumAddressSize"].Value,
MaximumMessageSize = (UInt32) managementObject.Properties["MaximumMessageSize"].Value,
MessageOriented = (Boolean) managementObject.Properties["MessageOriented"].Value,
MinimumAddressSize = (UInt32) managementObject.Properties["MinimumAddressSize"].Value,
Name = (String) managementObject.Properties["Name"].Value,
PseudoStreamOriented = (Boolean) managementObject.Properties["PseudoStreamOriented"].Value,
Status = (String) managementObject.Properties["Status"].Value,
SupportsBroadcasting = (Boolean) managementObject.Properties["SupportsBroadcasting"].Value,
SupportsConnectData = (Boolean) managementObject.Properties["SupportsConnectData"].Value,
SupportsDisconnectData = (Boolean) managementObject.Properties["SupportsDisconnectData"].Value,
SupportsEncryption = (Boolean) managementObject.Properties["SupportsEncryption"].Value,
SupportsExpeditedData = (Boolean) managementObject.Properties["SupportsExpeditedData"].Value,
SupportsFragmentation = (Boolean) managementObject.Properties["SupportsFragmentation"].Value,
SupportsGracefulClosing = (Boolean) managementObject.Properties["SupportsGracefulClosing"].Value,
SupportsGuaranteedBandwidth = (Boolean) managementObject.Properties["SupportsGuaranteedBandwidth"].Value,
SupportsMulticasting = (Boolean) managementObject.Properties["SupportsMulticasting"].Value,
SupportsQualityofService = (Boolean) managementObject.Properties["SupportsQualityofService"].Value,
				});
            }

			return list.ToArray();
		}
	}
}