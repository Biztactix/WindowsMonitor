using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterSetting class represents an association between a printer and its configuration settings.
    /// </summary>
    public sealed class PrinterSetting
    {
        /// <summary>
        ///     The Element reference represents the printer that can be configured with the Settings member.
        /// </summary>
        public string Element { get; private set; }

        /// <summary>
        ///     The Setting reference represents the printer configuration settings that can be applied to the associated printer.
        /// </summary>
        public string Setting { get; private set; }

        public static PrinterSetting[] Retrieve(string remote, string username, string password)
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

        public static PrinterSetting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterSetting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterSetting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterSetting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterSetting
                {
                    Element = (string) managementObject.Properties["Element"].Value,
                    Setting = (string) managementObject.Properties["Setting"].Value
                });

            return list.ToArray();
        }
    }
}