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
	public sealed class PnPSignedDriver
	{
		public String Caption { get; private set; }
public String ClassGuid { get; private set; }
public String CompatID { get; private set; }
public String CreationClassName { get; private set; }
public String Description { get; private set; }
public String DeviceClass { get; private set; }
public String DeviceID { get; private set; }
public String DeviceName { get; private set; }
public String DevLoader { get; private set; }
public DateTime DriverDate { get; private set; }
public String DriverName { get; private set; }
public String DriverProviderName { get; private set; }
public String DriverVersion { get; private set; }
public String FriendlyName { get; private set; }
public String HardWareID { get; private set; }
public String InfName { get; private set; }
public DateTime InstallDate { get; private set; }
public Boolean IsSigned { get; private set; }
public String Location { get; private set; }
public String Manufacturer { get; private set; }
public String Name { get; private set; }
public String PDO { get; private set; }
public String Signer { get; private set; }
public Boolean Started { get; private set; }
public String StartMode { get; private set; }
public String Status { get; private set; }
public String SystemCreationClassName { get; private set; }
public String SystemName { get; private set; }
		
		public static PnPSignedDriver[] Retrieve(string remote, string username, string password)
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

		public static PnPSignedDriver[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static PnPSignedDriver[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPSignedDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<PnPSignedDriver>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new PnPSignedDriver
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
ClassGuid = (String) managementObject.Properties["ClassGuid"].Value,
CompatID = (String) managementObject.Properties["CompatID"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
DeviceClass = (String) managementObject.Properties["DeviceClass"].Value,
DeviceID = (String) managementObject.Properties["DeviceID"].Value,
DeviceName = (String) managementObject.Properties["DeviceName"].Value,
DevLoader = (String) managementObject.Properties["DevLoader"].Value,
DriverDate = (DateTime) managementObject.Properties["DriverDate"].Value,
DriverName = (String) managementObject.Properties["DriverName"].Value,
DriverProviderName = (String) managementObject.Properties["DriverProviderName"].Value,
DriverVersion = (String) managementObject.Properties["DriverVersion"].Value,
FriendlyName = (String) managementObject.Properties["FriendlyName"].Value,
HardWareID = (String) managementObject.Properties["HardWareID"].Value,
InfName = (String) managementObject.Properties["InfName"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
IsSigned = (Boolean) managementObject.Properties["IsSigned"].Value,
Location = (String) managementObject.Properties["Location"].Value,
Manufacturer = (String) managementObject.Properties["Manufacturer"].Value,
Name = (String) managementObject.Properties["Name"].Value,
PDO = (String) managementObject.Properties["PDO"].Value,
Signer = (String) managementObject.Properties["Signer"].Value,
Started = (Boolean) managementObject.Properties["Started"].Value,
StartMode = (String) managementObject.Properties["StartMode"].Value,
Status = (String) managementObject.Properties["Status"].Value,
SystemCreationClassName = (String) managementObject.Properties["SystemCreationClassName"].Value,
SystemName = (String) managementObject.Properties["SystemName"].Value,
				});
            }

			return list.ToArray();
		}
	}
}