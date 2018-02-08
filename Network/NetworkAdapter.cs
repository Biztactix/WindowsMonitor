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
	public sealed class NetworkAdapter
	{
		public String AdapterType { get; private set; }
public UInt16 AdapterTypeId { get; private set; }
public Boolean AutoSense { get; private set; }
public UInt16 Availability { get; private set; }
public String Caption { get; private set; }
public UInt32 ConfigManagerErrorCode { get; private set; }
public Boolean ConfigManagerUserConfig { get; private set; }
public String CreationClassName { get; private set; }
public String Description { get; private set; }
public String DeviceID { get; private set; }
public Boolean ErrorCleared { get; private set; }
public String ErrorDescription { get; private set; }
public String GUID { get; private set; }
public UInt32 Index { get; private set; }
public DateTime InstallDate { get; private set; }
public Boolean Installed { get; private set; }
public UInt32 InterfaceIndex { get; private set; }
public UInt32 LastErrorCode { get; private set; }
public String MACAddress { get; private set; }
public String Manufacturer { get; private set; }
public UInt32 MaxNumberControlled { get; private set; }
public UInt64 MaxSpeed { get; private set; }
public String Name { get; private set; }
public String NetConnectionID { get; private set; }
public UInt16 NetConnectionStatus { get; private set; }
public Boolean NetEnabled { get; private set; }
public String[] NetworkAddresses { get; private set; }
public String PermanentAddress { get; private set; }
public Boolean PhysicalAdapter { get; private set; }
public String PNPDeviceID { get; private set; }
public UInt16[] PowerManagementCapabilities { get; private set; }
public Boolean PowerManagementSupported { get; private set; }
public String ProductName { get; private set; }
public String ServiceName { get; private set; }
public UInt64 Speed { get; private set; }
public String Status { get; private set; }
public UInt16 StatusInfo { get; private set; }
public String SystemCreationClassName { get; private set; }
public String SystemName { get; private set; }
public DateTime TimeOfLastReset { get; private set; }
		
		public static NetworkAdapter[] Retrieve(string remote, string username, string password)
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

		public static NetworkAdapter[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NetworkAdapter[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NetworkAdapter>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NetworkAdapter
				{
					AdapterType = (String) managementObject.Properties["AdapterType"].Value,
AdapterTypeId = (UInt16) managementObject.Properties["AdapterTypeId"].Value,
AutoSense = (Boolean) managementObject.Properties["AutoSense"].Value,
Availability = (UInt16) managementObject.Properties["Availability"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
ConfigManagerErrorCode = (UInt32) managementObject.Properties["ConfigManagerErrorCode"].Value,
ConfigManagerUserConfig = (Boolean) managementObject.Properties["ConfigManagerUserConfig"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DeviceID = (String) managementObject.Properties["DeviceID"].Value,
ErrorCleared = (Boolean) managementObject.Properties["ErrorCleared"].Value,
ErrorDescription = (String) managementObject.Properties["ErrorDescription"].Value,
GUID = (String) managementObject.Properties["GUID"].Value,
Index = (UInt32) managementObject.Properties["Index"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
Installed = (Boolean) managementObject.Properties["Installed"].Value,
InterfaceIndex = (UInt32) managementObject.Properties["InterfaceIndex"].Value,
LastErrorCode = (UInt32) managementObject.Properties["LastErrorCode"].Value,
MACAddress = (String) managementObject.Properties["MACAddress"].Value,
Manufacturer = (String) managementObject.Properties["Manufacturer"].Value,
MaxNumberControlled = (UInt32) managementObject.Properties["MaxNumberControlled"].Value,
MaxSpeed = (UInt64) managementObject.Properties["MaxSpeed"].Value,
Name = (String) managementObject.Properties["Name"].Value,
NetConnectionID = (String) managementObject.Properties["NetConnectionID"].Value,
NetConnectionStatus = (UInt16) managementObject.Properties["NetConnectionStatus"].Value,
NetEnabled = (Boolean) managementObject.Properties["NetEnabled"].Value,
NetworkAddresses = (String[]) managementObject.Properties["NetworkAddresses"].Value,
PermanentAddress = (String) managementObject.Properties["PermanentAddress"].Value,
PhysicalAdapter = (Boolean) managementObject.Properties["PhysicalAdapter"].Value,
PNPDeviceID = (String) managementObject.Properties["PNPDeviceID"].Value,
PowerManagementCapabilities = (UInt16[]) managementObject.Properties["PowerManagementCapabilities"].Value,
PowerManagementSupported = (Boolean) managementObject.Properties["PowerManagementSupported"].Value,
ProductName = (String) managementObject.Properties["ProductName"].Value,
ServiceName = (String) managementObject.Properties["ServiceName"].Value,
Speed = (UInt64) managementObject.Properties["Speed"].Value,
Status = (String) managementObject.Properties["Status"].Value,
StatusInfo = (UInt16) managementObject.Properties["StatusInfo"].Value,
SystemCreationClassName = (String) managementObject.Properties["SystemCreationClassName"].Value,
SystemName = (String) managementObject.Properties["SystemName"].Value,
TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value,
				});
            }

			return list.ToArray();
		}
	}
}