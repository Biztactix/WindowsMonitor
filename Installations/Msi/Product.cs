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
	public sealed class Product
	{
		public UInt16 AssignmentType { get; private set; }
public String Caption { get; private set; }
public String Description { get; private set; }
public String HelpLink { get; private set; }
public String HelpTelephone { get; private set; }
public String IdentifyingNumber { get; private set; }
public String InstallDate { get; private set; }
public DateTime InstallDate2 { get; private set; }
public String InstallLocation { get; private set; }
public String InstallSource { get; private set; }
public Int16 InstallState { get; private set; }
public String Language { get; private set; }
public String LocalPackage { get; private set; }
public String Name { get; private set; }
public String PackageCache { get; private set; }
public String PackageCode { get; private set; }
public String PackageName { get; private set; }
public String ProductID { get; private set; }
public String RegCompany { get; private set; }
public String RegOwner { get; private set; }
public String SKUNumber { get; private set; }
public String Transforms { get; private set; }
public String URLInfoAbout { get; private set; }
public String URLUpdateInfo { get; private set; }
public String Vendor { get; private set; }
public String Version { get; private set; }
public UInt32 WordCount { get; private set; }
		
		public static Product[] Retrieve(string remote, string username, string password)
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

		public static Product[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Product[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Product");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Product>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Product
				{
					AssignmentType = (UInt16) managementObject.Properties["AssignmentType"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
Description = (String) managementObject.Properties["Description"].Value,
HelpLink = (String) managementObject.Properties["HelpLink"].Value,
HelpTelephone = (String) managementObject.Properties["HelpTelephone"].Value,
IdentifyingNumber = (String) managementObject.Properties["IdentifyingNumber"].Value,
InstallDate = (String) managementObject.Properties["InstallDate"].Value,
InstallDate2 = (DateTime) managementObject.Properties["InstallDate2"].Value,
InstallLocation = (String) managementObject.Properties["InstallLocation"].Value,
InstallSource = (String) managementObject.Properties["InstallSource"].Value,
InstallState = (Int16) managementObject.Properties["InstallState"].Value,
Language = (String) managementObject.Properties["Language"].Value,
LocalPackage = (String) managementObject.Properties["LocalPackage"].Value,
Name = (String) managementObject.Properties["Name"].Value,
PackageCache = (String) managementObject.Properties["PackageCache"].Value,
PackageCode = (String) managementObject.Properties["PackageCode"].Value,
PackageName = (String) managementObject.Properties["PackageName"].Value,
ProductID = (String) managementObject.Properties["ProductID"].Value,
RegCompany = (String) managementObject.Properties["RegCompany"].Value,
RegOwner = (String) managementObject.Properties["RegOwner"].Value,
SKUNumber = (String) managementObject.Properties["SKUNumber"].Value,
Transforms = (String) managementObject.Properties["Transforms"].Value,
URLInfoAbout = (String) managementObject.Properties["URLInfoAbout"].Value,
URLUpdateInfo = (String) managementObject.Properties["URLUpdateInfo"].Value,
Vendor = (String) managementObject.Properties["Vendor"].Value,
Version = (String) managementObject.Properties["Version"].Value,
WordCount = (UInt32) managementObject.Properties["WordCount"].Value,
				});
            }

			return list.ToArray();
		}
	}
}