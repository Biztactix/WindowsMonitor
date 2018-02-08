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
	public sealed class NetworkLoginProfile
	{
		public DateTime AccountExpires { get; private set; }
public UInt32 AuthorizationFlags { get; private set; }
public UInt32 BadPasswordCount { get; private set; }
public String Caption { get; private set; }
public UInt32 CodePage { get; private set; }
public String Comment { get; private set; }
public UInt32 CountryCode { get; private set; }
public String Description { get; private set; }
public UInt32 Flags { get; private set; }
public String FullName { get; private set; }
public String HomeDirectory { get; private set; }
public String HomeDirectoryDrive { get; private set; }
public DateTime LastLogoff { get; private set; }
public DateTime LastLogon { get; private set; }
public String LogonHours { get; private set; }
public String LogonServer { get; private set; }
public UInt64 MaximumStorage { get; private set; }
public String Name { get; private set; }
public UInt32 NumberOfLogons { get; private set; }
public String Parameters { get; private set; }
public DateTime PasswordAge { get; private set; }
public DateTime PasswordExpires { get; private set; }
public UInt32 PrimaryGroupId { get; private set; }
public UInt32 Privileges { get; private set; }
public String Profile { get; private set; }
public String ScriptPath { get; private set; }
public String SettingID { get; private set; }
public UInt32 UnitsPerWeek { get; private set; }
public String UserComment { get; private set; }
public UInt32 UserId { get; private set; }
public String UserType { get; private set; }
public String Workstations { get; private set; }
		
		public static NetworkLoginProfile[] Retrieve(string remote, string username, string password)
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

		public static NetworkLoginProfile[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static NetworkLoginProfile[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkLoginProfile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<NetworkLoginProfile>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new NetworkLoginProfile
				{
					AccountExpires = (DateTime) managementObject.Properties["AccountExpires"].Value,
AuthorizationFlags = (UInt32) managementObject.Properties["AuthorizationFlags"].Value,
BadPasswordCount = (UInt32) managementObject.Properties["BadPasswordCount"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
CodePage = (UInt32) managementObject.Properties["CodePage"].Value,
Comment = (String) managementObject.Properties["Comment"].Value,
CountryCode = (UInt32) managementObject.Properties["CountryCode"].Value,
Description = (String) managementObject.Properties["Description"].Value,
Flags = (UInt32) managementObject.Properties["Flags"].Value,
FullName = (String) managementObject.Properties["FullName"].Value,
HomeDirectory = (String) managementObject.Properties["HomeDirectory"].Value,
HomeDirectoryDrive = (String) managementObject.Properties["HomeDirectoryDrive"].Value,
LastLogoff = (DateTime) managementObject.Properties["LastLogoff"].Value,
LastLogon = (DateTime) managementObject.Properties["LastLogon"].Value,
LogonHours = (String) managementObject.Properties["LogonHours"].Value,
LogonServer = (String) managementObject.Properties["LogonServer"].Value,
MaximumStorage = (UInt64) managementObject.Properties["MaximumStorage"].Value,
Name = (String) managementObject.Properties["Name"].Value,
NumberOfLogons = (UInt32) managementObject.Properties["NumberOfLogons"].Value,
Parameters = (String) managementObject.Properties["Parameters"].Value,
PasswordAge = (DateTime) managementObject.Properties["PasswordAge"].Value,
PasswordExpires = (DateTime) managementObject.Properties["PasswordExpires"].Value,
PrimaryGroupId = (UInt32) managementObject.Properties["PrimaryGroupId"].Value,
Privileges = (UInt32) managementObject.Properties["Privileges"].Value,
Profile = (String) managementObject.Properties["Profile"].Value,
ScriptPath = (String) managementObject.Properties["ScriptPath"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
UnitsPerWeek = (UInt32) managementObject.Properties["UnitsPerWeek"].Value,
UserComment = (String) managementObject.Properties["UserComment"].Value,
UserId = (UInt32) managementObject.Properties["UserId"].Value,
UserType = (String) managementObject.Properties["UserType"].Value,
Workstations = (String) managementObject.Properties["Workstations"].Value,
				});
            }

			return list.ToArray();
		}
	}
}