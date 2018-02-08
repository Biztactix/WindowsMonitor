using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterDriverDll class represents the association between a local printer and its driver file.
    /// </summary>
    public sealed class PrinterDriverDll
    {
        /// <summary>
        ///     The CIM_DataFile antecedent reference represents the driver file for this Win32 printer.
        /// </summary>
        public string Antecedent { get; private set; }

        /// <summary>
        ///     The Win32_Printer dependent reference represents the Win32_Printer.
        /// </summary>
        public string Dependent { get; private set; }

        public static PrinterDriverDll[] Retrieve(string remote, string username, string password)
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

        public static PrinterDriverDll[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterDriverDll[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterDriverDll");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterDriverDll>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterDriverDll
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value
                });

            return list.ToArray();
        }
    }
}