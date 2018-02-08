using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_PrinterController class represents an association between a printer and the local device to which the
    ///     printer is connected. Note that this class only returns instances for local printers.
    /// </summary>
    public sealed class PrinterController
    {
        public ushort AccessState { get; private set; }

        /// <summary>
        ///     The CIM_Controller antecedent reference represents the local device associated with this printer.
        /// </summary>
        public string Antecedent { get; private set; }

        /// <summary>
        ///     The Win32_Printer dependent reference represents the Win32_Printer
        /// </summary>
        public string Dependent { get; private set; }

        public uint NegotiatedDataWidth { get; private set; }
        public ulong NegotiatedSpeed { get; private set; }
        public uint NumberOfHardResets { get; private set; }
        public uint NumberOfSoftResets { get; private set; }

        public static PrinterController[] Retrieve(string remote, string username, string password)
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

        public static PrinterController[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrinterController[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterController");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrinterController>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrinterController
                {
                    AccessState = (ushort) managementObject.Properties["AccessState"].Value,
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value,
                    NegotiatedDataWidth = (uint) managementObject.Properties["NegotiatedDataWidth"].Value,
                    NegotiatedSpeed = (ulong) managementObject.Properties["NegotiatedSpeed"].Value,
                    NumberOfHardResets = (uint) managementObject.Properties["NumberOfHardResets"].Value,
                    NumberOfSoftResets = (uint) managementObject.Properties["NumberOfSoftResets"].Value
                });

            return list.ToArray();
        }
    }
}