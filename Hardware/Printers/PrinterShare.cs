using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterShare class represents an association between a local printer and the share that represents it as
    ///     it is viewed over a network.
    /// </summary>
    public sealed class PrinterShare
    {
        /// <summary>
        ///     The Win32_Printer antecedent reference indicates the Win32_Printer representing the local printer shared in this
        ///     association.
        /// </summary>
        public string Antecedent { get; private set; }

        /// <summary>
        ///     The Win32_Share dependent referenceindicates the Win32_Share representing the network share of the printer in this
        ///     association.
        /// </summary>
        public string Dependent { get; private set; }

        public static PrinterShare[] Retrieve(string remote, string username, string password)
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

        public static PrinterShare[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterShare[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterShare");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterShare>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterShare
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value
                });

            return list.ToArray();
        }
    }
}