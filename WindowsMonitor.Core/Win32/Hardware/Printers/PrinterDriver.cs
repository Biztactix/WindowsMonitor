using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Printers
{
    /// <summary>
    /// </summary>
    public sealed class PrinterDriver
    {
		public string Caption { get; private set; }
		public string ConfigFile { get; private set; }
		public string CreationClassName { get; private set; }
		public string DataFile { get; private set; }
		public string DefaultDataType { get; private set; }
		public string[] DependentFiles { get; private set; }
		public string Description { get; private set; }
		public string DriverPath { get; private set; }
		public string FilePath { get; private set; }
		public string HelpFile { get; private set; }
		public string InfName { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string MonitorName { get; private set; }
		public string Name { get; private set; }
		public string OEMUrl { get; private set; }
		public bool Started { get; private set; }
		public string StartMode { get; private set; }
		public string Status { get; private set; }
		public string SupportedPlatform { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public ushort Version { get; private set; }

        public static IEnumerable<PrinterDriver> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PrinterDriver> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PrinterDriver> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PrinterDriver
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConfigFile = (string) (managementObject.Properties["ConfigFile"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 DataFile = (string) (managementObject.Properties["DataFile"]?.Value ?? default(string)),
		 DefaultDataType = (string) (managementObject.Properties["DefaultDataType"]?.Value ?? default(string)),
		 DependentFiles = (string[]) (managementObject.Properties["DependentFiles"]?.Value ?? new string[0]),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DriverPath = (string) (managementObject.Properties["DriverPath"]?.Value ?? default(string)),
		 FilePath = (string) (managementObject.Properties["FilePath"]?.Value ?? default(string)),
		 HelpFile = (string) (managementObject.Properties["HelpFile"]?.Value ?? default(string)),
		 InfName = (string) (managementObject.Properties["InfName"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 MonitorName = (string) (managementObject.Properties["MonitorName"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OEMUrl = (string) (managementObject.Properties["OEMUrl"]?.Value ?? default(string)),
		 Started = (bool) (managementObject.Properties["Started"]?.Value ?? default(bool)),
		 StartMode = (string) (managementObject.Properties["StartMode"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 SupportedPlatform = (string) (managementObject.Properties["SupportedPlatform"]?.Value ?? default(string)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 Version = (ushort) (managementObject.Properties["Version"]?.Value ?? default(ushort))
                };
        }
    }
}