using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ClassicCOMClassSetting
    {
		public string AppID { get; private set; }
		public string AutoConvertToClsid { get; private set; }
		public string AutoTreatAsClsid { get; private set; }
		public string Caption { get; private set; }
		public string ComponentId { get; private set; }
		public bool Control { get; private set; }
		public string DefaultIcon { get; private set; }
		public string Description { get; private set; }
		public string InprocHandler { get; private set; }
		public string InprocHandler32 { get; private set; }
		public string InprocServer { get; private set; }
		public string InprocServer32 { get; private set; }
		public bool Insertable { get; private set; }
		public bool JavaClass { get; private set; }
		public string LocalServer { get; private set; }
		public string LocalServer32 { get; private set; }
		public string LongDisplayName { get; private set; }
		public string ProgId { get; private set; }
		public string SettingID { get; private set; }
		public string ShortDisplayName { get; private set; }
		public string ThreadingModel { get; private set; }
		public string ToolBoxBitmap32 { get; private set; }
		public string TreatAsClsid { get; private set; }
		public string TypeLibraryId { get; private set; }
		public string Version { get; private set; }
		public string VersionIndependentProgId { get; private set; }

        public static IEnumerable<ClassicCOMClassSetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClassicCOMClassSetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClassicCOMClassSetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ClassicCOMClassSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClassicCOMClassSetting
                {
                     AppID = (string) (managementObject.Properties["AppID"]?.Value ?? default(string)),
		 AutoConvertToClsid = (string) (managementObject.Properties["AutoConvertToClsid"]?.Value ?? default(string)),
		 AutoTreatAsClsid = (string) (managementObject.Properties["AutoTreatAsClsid"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ComponentId = (string) (managementObject.Properties["ComponentId"]?.Value ?? default(string)),
		 Control = (bool) (managementObject.Properties["Control"]?.Value ?? default(bool)),
		 DefaultIcon = (string) (managementObject.Properties["DefaultIcon"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 InprocHandler = (string) (managementObject.Properties["InprocHandler"]?.Value ?? default(string)),
		 InprocHandler32 = (string) (managementObject.Properties["InprocHandler32"]?.Value ?? default(string)),
		 InprocServer = (string) (managementObject.Properties["InprocServer"]?.Value ?? default(string)),
		 InprocServer32 = (string) (managementObject.Properties["InprocServer32"]?.Value ?? default(string)),
		 Insertable = (bool) (managementObject.Properties["Insertable"]?.Value ?? default(bool)),
		 JavaClass = (bool) (managementObject.Properties["JavaClass"]?.Value ?? default(bool)),
		 LocalServer = (string) (managementObject.Properties["LocalServer"]?.Value ?? default(string)),
		 LocalServer32 = (string) (managementObject.Properties["LocalServer32"]?.Value ?? default(string)),
		 LongDisplayName = (string) (managementObject.Properties["LongDisplayName"]?.Value ?? default(string)),
		 ProgId = (string) (managementObject.Properties["ProgId"]?.Value ?? default(string)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 ShortDisplayName = (string) (managementObject.Properties["ShortDisplayName"]?.Value ?? default(string)),
		 ThreadingModel = (string) (managementObject.Properties["ThreadingModel"]?.Value ?? default(string)),
		 ToolBoxBitmap32 = (string) (managementObject.Properties["ToolBoxBitmap32"]?.Value ?? default(string)),
		 TreatAsClsid = (string) (managementObject.Properties["TreatAsClsid"]?.Value ?? default(string)),
		 TypeLibraryId = (string) (managementObject.Properties["TypeLibraryId"]?.Value ?? default(string)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 VersionIndependentProgId = (string) (managementObject.Properties["VersionIndependentProgId"]?.Value ?? default(string))
                };
        }
    }
}