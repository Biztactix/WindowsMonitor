using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterDriver class represents the drivers for a Win32_Printer.
    /// </summary>
    public sealed class PrinterDriver
    {
        public string Caption { get; private set; }

        /// <summary>
        ///     The ConfigFile property contains the configuration file for this printer driver, (example: pscrptui.dll).
        /// </summary>
        public string ConfigFile { get; private set; }

        public string CreationClassName { get; private set; }

        /// <summary>
        ///     The DataFile property contains the data file for this printer driver, (example: qms810.ppd).
        /// </summary>
        public string DataFile { get; private set; }

        /// <summary>
        ///     The DefaultDataType property indicates the default data type for this printer driver, (example: EMF).
        /// </summary>
        public string DefaultDataType { get; private set; }

        /// <summary>
        ///     The DependentFiles property contains a list of dependent files for this printer driver.
        /// </summary>
        public string[] DependentFiles { get; private set; }

        public string Description { get; private set; }

        /// <summary>
        ///     The DriverPath property contains the path for this printer driver, (example: C:\drivers\pscript.dll).
        /// </summary>
        public string DriverPath { get; private set; }

        /// <summary>
        ///     The FilePath property contains the path to the INF file being used, (Example: c:\temp\driver).
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        ///     The HelpFile property contains the help file for this printer driver, (example: pscrptui.hlp).
        /// </summary>
        public string HelpFile { get; private set; }

        /// <summary>
        ///     The InfName property contains the name of the INF file being used. The default is 'ntprint.INF'.  This will only be
        ///     different if the drivers are provided directly by the manufacturer of the printer and not the operating system.
        /// </summary>
        public string InfName { get; private set; }

        public DateTime InstallDate { get; private set; }

        /// <summary>
        ///     The MonitorName property contains the name of the of the monitor for this printer driver, (example: PJL monitor).
        /// </summary>
        public string MonitorName { get; private set; }

        /// <summary>
        ///     The Name property indicates the driver name for this printer.  This is a compound key composed of the Name, Version
        ///     and SupportedPlatform values.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     The OEMUrl property provides a world wide web link to the printer manufacturer's web site.  Note that this property
        ///     is not populated when the Win32.INF file is used and is only applicable for drivers provided directly from the
        ///     manufacturer.
        /// </summary>
        public string OEMUrl { get; private set; }

        public bool Started { get; private set; }
        public string StartMode { get; private set; }
        public string Status { get; private set; }

        /// <summary>
        ///     The SupportedPlatform property indicates the operating environments that the driver is intended for.  Examples are
        ///     'Windows NT x86' or 'Windows IA64'.
        /// </summary>
        public string SupportedPlatform { get; private set; }

        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }

        /// <summary>
        ///     The Version property indicates the operating system version that the driver is intended for.
        /// </summary>
        public ushort Version { get; private set; }

        public static PrinterDriver[] Retrieve(string remote, string username, string password)
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

        public static PrinterDriver[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterDriver[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterDriver");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterDriver>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterDriver
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigFile = (string) managementObject.Properties["ConfigFile"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    DataFile = (string) managementObject.Properties["DataFile"].Value,
                    DefaultDataType = (string) managementObject.Properties["DefaultDataType"].Value,
                    DependentFiles = (string[]) managementObject.Properties["DependentFiles"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DriverPath = (string) managementObject.Properties["DriverPath"].Value,
                    FilePath = (string) managementObject.Properties["FilePath"].Value,
                    HelpFile = (string) managementObject.Properties["HelpFile"].Value,
                    InfName = (string) managementObject.Properties["InfName"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    MonitorName = (string) managementObject.Properties["MonitorName"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OEMUrl = (string) managementObject.Properties["OEMUrl"].Value,
                    Started = (bool) managementObject.Properties["Started"].Value,
                    StartMode = (string) managementObject.Properties["StartMode"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    SupportedPlatform = (string) managementObject.Properties["SupportedPlatform"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    Version = (ushort) managementObject.Properties["Version"].Value
                });

            return list.ToArray();
        }
    }
}