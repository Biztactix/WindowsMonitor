using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    ///     The Win32_TCPIPPrinterPort class represents a TCP//IP service access point. For example a TCP/IP printer port.
    ///     Note:  The SE_LOAD_DRIVER_PRIVILEGE privilege is required on this class.
    /// </summary>
    public sealed class TCPIPPrinterPort
    {
        /// <summary>
        ///     The ByteCount property, when true, causes the computer to count the number of bytes in a document before sending
        ///     them to the printer and the printer to report back the number of bytes actually read.  This is used for diagnostics
        ///     when one discovers that bytes are missing from the print output.
        /// </summary>
        public bool ByteCount { get; private set; }

        public string Caption { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        ///     The HostAddress property indicates the address of device or print server
        /// </summary>
        public string HostAddress { get; private set; }

        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        ///     The PortNumber property indicates the number of the TCP port used by the port monitor to communitcate with the
        ///     device.
        /// </summary>
        public uint PortNumber { get; private set; }

        /// <summary>
        ///     The Protocol property has two values: 'Raw' indicates printing directly to a device and 'Lpr' indicates printing to
        ///     device or print server; LPR is a legacy protocol, which will eventually be replaced by RAW. Some printers support
        ///     only LPR.
        /// </summary>
        public uint Protocol { get; private set; }

        /// <summary>
        ///     The Queue property is used with the LPR protocol to indicate the name of the print queue on the server.
        /// </summary>
        public string Queue { get; private set; }

        /// <summary>
        ///     The SNMPCommunity property contains a security level value for the device.  For example 'public'.
        /// </summary>
        public string SNMPCommunity { get; private set; }

        /// <summary>
        ///     The property SNMPDevIndex indicates the SNMP index number of this device for the SNMP agent.
        /// </summary>
        public uint SNMPDevIndex { get; private set; }

        /// <summary>
        ///     The SNMPEnabled property, when true, indicates that this printer supports RFC1759 (Simple Network Management
        ///     Protocol) and can provide rich status information from the device.
        /// </summary>
        public bool SNMPEnabled { get; private set; }

        public string Status { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint Type { get; private set; }

        public static TCPIPPrinterPort[] Retrieve(string remote, string username, string password)
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

        public static TCPIPPrinterPort[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static TCPIPPrinterPort[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_TCPIPPrinterPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<TCPIPPrinterPort>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new TCPIPPrinterPort
                {
                    ByteCount = (bool) managementObject.Properties["ByteCount"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    HostAddress = (string) managementObject.Properties["HostAddress"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PortNumber = (uint) managementObject.Properties["PortNumber"].Value,
                    Protocol = (uint) managementObject.Properties["Protocol"].Value,
                    Queue = (string) managementObject.Properties["Queue"].Value,
                    SNMPCommunity = (string) managementObject.Properties["SNMPCommunity"].Value,
                    SNMPDevIndex = (uint) managementObject.Properties["SNMPDevIndex"].Value,
                    SNMPEnabled = (bool) managementObject.Properties["SNMPEnabled"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    Type = (uint) managementObject.Properties["Type"].Value
                });

            return list.ToArray();
        }
    }
}