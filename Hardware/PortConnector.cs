using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PortConnector
    {
        public string Caption { get; private set; }
        public string ConnectorPinout { get; private set; }
        public ushort[] ConnectorType { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string ExternalReferenceDesignator { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string InternalReferenceDesignator { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public string Name { get; private set; }
        public string OtherIdentifyingInfo { get; private set; }
        public string PartNumber { get; private set; }
        public ushort PortType { get; private set; }
        public bool PoweredOn { get; private set; }
        public string SerialNumber { get; private set; }
        public string SKU { get; private set; }
        public string Status { get; private set; }
        public string Tag { get; private set; }
        public string Version { get; private set; }

        public static PortConnector[] Retrieve(string remote, string username, string password)
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

        public static PortConnector[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PortConnector[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PortConnector");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PortConnector>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PortConnector
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectorPinout = (string) managementObject.Properties["ConnectorPinout"].Value,
                    ConnectorType = (ushort[]) managementObject.Properties["ConnectorType"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExternalReferenceDesignator = (string) managementObject.Properties["ExternalReferenceDesignator"]
                        .Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InternalReferenceDesignator = (string) managementObject.Properties["InternalReferenceDesignator"]
                        .Value,
                    Manufacturer = (string) managementObject.Properties["Manufacturer"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OtherIdentifyingInfo = (string) managementObject.Properties["OtherIdentifyingInfo"].Value,
                    PartNumber = (string) managementObject.Properties["PartNumber"].Value,
                    PortType = (ushort) managementObject.Properties["PortType"].Value,
                    PoweredOn = (bool) managementObject.Properties["PoweredOn"].Value,
                    SerialNumber = (string) managementObject.Properties["SerialNumber"].Value,
                    SKU = (string) managementObject.Properties["SKU"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Tag = (string) managementObject.Properties["Tag"].Value,
                    Version = (string) managementObject.Properties["Version"].Value
                });

            return list.ToArray();
        }
    }
}