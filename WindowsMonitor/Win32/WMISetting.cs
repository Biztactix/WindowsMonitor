using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class WMISetting
    {
		public string ASPScriptDefaultNamespace { get; private set; }
		public bool ASPScriptEnabled { get; private set; }
		public string[] AutorecoverMofs { get; private set; }
		public uint AutoStartWin9X { get; private set; }
		public uint BackupInterval { get; private set; }
		public DateTime BackupLastTime { get; private set; }
		public string BuildVersion { get; private set; }
		public string Caption { get; private set; }
		public string DatabaseDirectory { get; private set; }
		public uint DatabaseMaxSize { get; private set; }
		public string Description { get; private set; }
		public bool EnableAnonWin9xConnections { get; private set; }
		public bool EnableEvents { get; private set; }
		public bool EnableStartupHeapPreallocation { get; private set; }
		public uint HighThresholdOnClientObjects { get; private set; }
		public uint HighThresholdOnEvents { get; private set; }
		public string InstallationDirectory { get; private set; }
		public uint LastStartupHeapPreallocation { get; private set; }
		public string LoggingDirectory { get; private set; }
		public uint LoggingLevel { get; private set; }
		public uint LowThresholdOnClientObjects { get; private set; }
		public uint LowThresholdOnEvents { get; private set; }
		public uint MaxLogFileSize { get; private set; }
		public uint MaxWaitOnClientObjects { get; private set; }
		public uint MaxWaitOnEvents { get; private set; }
		public string MofSelfInstallDirectory { get; private set; }
		public string SettingID { get; private set; }

        public static IEnumerable<WMISetting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WMISetting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WMISetting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_WMISetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WMISetting
                {
                     ASPScriptDefaultNamespace = (string) (managementObject.Properties["ASPScriptDefaultNamespace"]?.Value),
		 ASPScriptEnabled = (bool) (managementObject.Properties["ASPScriptEnabled"]?.Value ?? default(bool)),
		 AutorecoverMofs = (string[]) (managementObject.Properties["AutorecoverMofs"]?.Value ?? new string[0]),
		 AutoStartWin9X = (uint) (managementObject.Properties["AutoStartWin9X"]?.Value ?? default(uint)),
		 BackupInterval = (uint) (managementObject.Properties["BackupInterval"]?.Value ?? default(uint)),
		 BackupLastTime = ManagementDateTimeConverter.ToDateTime (managementObject.Properties["BackupLastTime"]?.Value as string ?? "00010101000000.000000+060"),
		 BuildVersion = (string) (managementObject.Properties["BuildVersion"]?.Value),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DatabaseDirectory = (string) (managementObject.Properties["DatabaseDirectory"]?.Value),
		 DatabaseMaxSize = (uint) (managementObject.Properties["DatabaseMaxSize"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 EnableAnonWin9xConnections = (bool) (managementObject.Properties["EnableAnonWin9xConnections"]?.Value ?? default(bool)),
		 EnableEvents = (bool) (managementObject.Properties["EnableEvents"]?.Value ?? default(bool)),
		 EnableStartupHeapPreallocation = (bool) (managementObject.Properties["EnableStartupHeapPreallocation"]?.Value ?? default(bool)),
		 HighThresholdOnClientObjects = (uint) (managementObject.Properties["HighThresholdOnClientObjects"]?.Value ?? default(uint)),
		 HighThresholdOnEvents = (uint) (managementObject.Properties["HighThresholdOnEvents"]?.Value ?? default(uint)),
		 InstallationDirectory = (string) (managementObject.Properties["InstallationDirectory"]?.Value),
		 LastStartupHeapPreallocation = (uint) (managementObject.Properties["LastStartupHeapPreallocation"]?.Value ?? default(uint)),
		 LoggingDirectory = (string) (managementObject.Properties["LoggingDirectory"]?.Value),
		 LoggingLevel = (uint) (managementObject.Properties["LoggingLevel"]?.Value ?? default(uint)),
		 LowThresholdOnClientObjects = (uint) (managementObject.Properties["LowThresholdOnClientObjects"]?.Value ?? default(uint)),
		 LowThresholdOnEvents = (uint) (managementObject.Properties["LowThresholdOnEvents"]?.Value ?? default(uint)),
		 MaxLogFileSize = (uint) (managementObject.Properties["MaxLogFileSize"]?.Value ?? default(uint)),
		 MaxWaitOnClientObjects = (uint) (managementObject.Properties["MaxWaitOnClientObjects"]?.Value ?? default(uint)),
		 MaxWaitOnEvents = (uint) (managementObject.Properties["MaxWaitOnEvents"]?.Value ?? default(uint)),
		 MofSelfInstallDirectory = (string) (managementObject.Properties["MofSelfInstallDirectory"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value)
                };
        }
    }
}