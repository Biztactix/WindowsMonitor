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
	public sealed class PnPEntity
	{
		public UInt16 Availability { get; private set; }
public String Caption { get; private set; }
public String ClassGuid { get; private set; }
public String[] CompatibleID { get; private set; }
public UInt32 ConfigManagerErrorCode { get; private set; }
public Boolean ConfigManagerUserConfig { get; private set; }
public String CreationClassName { get; private set; }
public String Description { get; private set; }
public String DeviceID { get; private set; }
public Boolean ErrorCleared { get; private set; }
public String ErrorDescription { get; private set; }
public String[] HardwareID { get; private set; }
public DateTime InstallDate { get; private set; }
public UInt32 LastErrorCode { get; private set; }
public String Manufacturer { get; private set; }
public String Name { get; private set; }
public String PNPClass { get; private set; }
public String PNPDeviceID { get; private set; }
public UInt16[] PowerManagementCapabilities { get; private set; }
public Boolean PowerManagementSupported { get; private set; }
public Boolean Present { get; private set; }
public String Service { get; private set; }
public String Status { get; private set; }
public UInt16 StatusInfo { get; private set; }
public String SystemCreationClassName { get; private set; }
public String SystemName { get; private set; }
		
		public static PnPEntity[] Retrieve(string remote, string username, string password)
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

		public static PnPEntity[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PnPEntity[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PnPEntity>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PnPEntity
				{
					Availability = (UInt16) managementObject.Properties["Availability"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
ClassGuid = (String) managementObject.Properties["ClassGuid"].Value,
CompatibleID = (String[]) managementObject.Properties["CompatibleID"].Value,
ConfigManagerErrorCode = (UInt32) managementObject.Properties["ConfigManagerErrorCode"].Value,
ConfigManagerUserConfig = (Boolean) managementObject.Properties["ConfigManagerUserConfig"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DeviceID = (String) managementObject.Properties["DeviceID"].Value,
ErrorCleared = (Boolean) managementObject.Properties["ErrorCleared"].Value,
ErrorDescription = (String) managementObject.Properties["ErrorDescription"].Value,
HardwareID = (String[]) managementObject.Properties["HardwareID"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
LastErrorCode = (UInt32) managementObject.Properties["LastErrorCode"].Value,
Manufacturer = (String) managementObject.Properties["Manufacturer"].Value,
Name = (String) managementObject.Properties["Name"].Value,
PNPClass = (String) managementObject.Properties["PNPClass"].Value,
PNPDeviceID = (String) managementObject.Properties["PNPDeviceID"].Value,
PowerManagementCapabilities = (UInt16[]) managementObject.Properties["PowerManagementCapabilities"].Value,
PowerManagementSupported = (Boolean) managementObject.Properties["PowerManagementSupported"].Value,
Present = (Boolean) managementObject.Properties["Present"].Value,
Service = (String) managementObject.Properties["Service"].Value,
Status = (String) managementObject.Properties["Status"].Value,
StatusInfo = (UInt16) managementObject.Properties["StatusInfo"].Value,
SystemCreationClassName = (String) managementObject.Properties["SystemCreationClassName"].Value,
SystemName = (String) managementObject.Properties["SystemName"].Value,
				});
            }

			return list.ToArray();
		}
	}
}