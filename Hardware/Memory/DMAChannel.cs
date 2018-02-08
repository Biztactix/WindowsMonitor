using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DMAChannel
    {
        public ushort AddressSize { get; private set; }
        public ushort Availability { get; private set; }
        public bool BurstMode { get; private set; }
        public ushort ByteMode { get; private set; }
        public string Caption { get; private set; }
        public ushort ChannelTiming { get; private set; }
        public string CreationClassName { get; private set; }
        public string CSCreationClassName { get; private set; }
        public string CSName { get; private set; }
        public string Description { get; private set; }
        public uint Channel { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint MaxTransferSize { get; private set; }
        public string Name { get; private set; }
        public uint Port { get; private set; }
        public string Status { get; private set; }
        public ushort[] TransferWidths { get; private set; }
        public ushort TypeCTiming { get; private set; }
        public ushort WordMode { get; private set; }

        public static DMAChannel[] Retrieve(string remote, string username, string password)
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

        public static DMAChannel[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DMAChannel[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DMAChannel");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DMAChannel>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DMAChannel
                {
                    AddressSize = (ushort) managementObject.Properties["AddressSize"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BurstMode = (bool) managementObject.Properties["BurstMode"].Value,
                    ByteMode = (ushort) managementObject.Properties["ByteMode"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ChannelTiming = (ushort) managementObject.Properties["ChannelTiming"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CSCreationClassName = (string) managementObject.Properties["CSCreationClassName"].Value,
                    CSName = (string) managementObject.Properties["CSName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Channel = (uint) managementObject.Properties["DMAChannel"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    MaxTransferSize = (uint) managementObject.Properties["MaxTransferSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Port = (uint) managementObject.Properties["Port"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    TransferWidths = (ushort[]) managementObject.Properties["TransferWidths"].Value,
                    TypeCTiming = (ushort) managementObject.Properties["TypeCTiming"].Value,
                    WordMode = (ushort) managementObject.Properties["WordMode"].Value
                });

            return list.ToArray();
        }
    }
}