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
	public sealed class ClassicCOMClassSetting
	{
		public String AppID { get; private set; }
public String AutoConvertToClsid { get; private set; }
public String AutoTreatAsClsid { get; private set; }
public String Caption { get; private set; }
public String ComponentId { get; private set; }
public Boolean Control { get; private set; }
public String DefaultIcon { get; private set; }
public String Description { get; private set; }
public String InprocHandler { get; private set; }
public String InprocHandler32 { get; private set; }
public String InprocServer { get; private set; }
public String InprocServer32 { get; private set; }
public Boolean Insertable { get; private set; }
public Boolean JavaClass { get; private set; }
public String LocalServer { get; private set; }
public String LocalServer32 { get; private set; }
public String LongDisplayName { get; private set; }
public String ProgId { get; private set; }
public String SettingID { get; private set; }
public String ShortDisplayName { get; private set; }
public String ThreadingModel { get; private set; }
public String ToolBoxBitmap32 { get; private set; }
public String TreatAsClsid { get; private set; }
public String TypeLibraryId { get; private set; }
public String Version { get; private set; }
public String VersionIndependentProgId { get; private set; }
		
		public static ClassicCOMClassSetting[] Retrieve(string remote, string username, string password)
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

		public static ClassicCOMClassSetting[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static ClassicCOMClassSetting[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClassicCOMClassSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<ClassicCOMClassSetting>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new ClassicCOMClassSetting
				{
					AppID = (String) managementObject.Properties["AppID"].Value,
AutoConvertToClsid = (String) managementObject.Properties["AutoConvertToClsid"].Value,
AutoTreatAsClsid = (String) managementObject.Properties["AutoTreatAsClsid"].Value,
Caption = (String) managementObject.Properties["Caption"].Value,
ComponentId = (String) managementObject.Properties["ComponentId"].Value,
Control = (Boolean) managementObject.Properties["Control"].Value,
DefaultIcon = (String) managementObject.Properties["DefaultIcon"].Value,
Description = (String) managementObject.Properties["Description"].Value,
InprocHandler = (String) managementObject.Properties["InprocHandler"].Value,
InprocHandler32 = (String) managementObject.Properties["InprocHandler32"].Value,
InprocServer = (String) managementObject.Properties["InprocServer"].Value,
InprocServer32 = (String) managementObject.Properties["InprocServer32"].Value,
Insertable = (Boolean) managementObject.Properties["Insertable"].Value,
JavaClass = (Boolean) managementObject.Properties["JavaClass"].Value,
LocalServer = (String) managementObject.Properties["LocalServer"].Value,
LocalServer32 = (String) managementObject.Properties["LocalServer32"].Value,
LongDisplayName = (String) managementObject.Properties["LongDisplayName"].Value,
ProgId = (String) managementObject.Properties["ProgId"].Value,
SettingID = (String) managementObject.Properties["SettingID"].Value,
ShortDisplayName = (String) managementObject.Properties["ShortDisplayName"].Value,
ThreadingModel = (String) managementObject.Properties["ThreadingModel"].Value,
ToolBoxBitmap32 = (String) managementObject.Properties["ToolBoxBitmap32"].Value,
TreatAsClsid = (String) managementObject.Properties["TreatAsClsid"].Value,
TypeLibraryId = (String) managementObject.Properties["TypeLibraryId"].Value,
Version = (String) managementObject.Properties["Version"].Value,
VersionIndependentProgId = (String) managementObject.Properties["VersionIndependentProgId"].Value,
				});
            }

			return list.ToArray();
		}
	}
}