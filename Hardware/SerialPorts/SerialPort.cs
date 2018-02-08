using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SerialPort
    {
        public ushort Availability { get; private set; }
        public bool Binary { get; private set; }
        public ushort[] Capabilities { get; private set; }
        public string[] CapabilityDescriptions { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public uint MaxBaudRate { get; private set; }
        public uint MaximumInputBufferSize { get; private set; }
        public uint MaximumOutputBufferSize { get; private set; }
        public uint MaxNumberControlled { get; private set; }
        public string Name { get; private set; }
        public bool OSAutoDiscovered { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public ushort ProtocolSupported { get; private set; }
        public string ProviderType { get; private set; }
        public bool SettableBaudRate { get; private set; }
        public bool SettableDataBits { get; private set; }
        public bool SettableFlowControl { get; private set; }
        public bool SettableParity { get; private set; }
        public bool SettableParityCheck { get; private set; }
        public bool SettableRLSD { get; private set; }
        public bool SettableStopBits { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public bool Supports16BitMode { get; private set; }
        public bool SupportsDTRDSR { get; private set; }
        public bool SupportsElapsedTimeouts { get; private set; }
        public bool SupportsIntTimeouts { get; private set; }
        public bool SupportsParityCheck { get; private set; }
        public bool SupportsRLSD { get; private set; }
        public bool SupportsRTSCTS { get; private set; }
        public bool SupportsSpecialCharacters { get; private set; }
        public bool SupportsXOnXOff { get; private set; }
        public bool SupportsXOnXOffSet { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public DateTime TimeOfLastReset { get; private set; }

        public static SerialPort[] Retrieve(string remote, string username, string password)
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

        public static SerialPort[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SerialPort[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SerialPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SerialPort>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SerialPort
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Binary = (bool) managementObject.Properties["Binary"].Value,
                    Capabilities = (ushort[]) managementObject.Properties["Capabilities"].Value,
                    CapabilityDescriptions = (string[]) managementObject.Properties["CapabilityDescriptions"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    MaxBaudRate = (uint) managementObject.Properties["MaxBaudRate"].Value,
                    MaximumInputBufferSize = (uint) managementObject.Properties["MaximumInputBufferSize"].Value,
                    MaximumOutputBufferSize = (uint) managementObject.Properties["MaximumOutputBufferSize"].Value,
                    MaxNumberControlled = (uint) managementObject.Properties["MaxNumberControlled"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OSAutoDiscovered = (bool) managementObject.Properties["OSAutoDiscovered"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    ProtocolSupported = (ushort) managementObject.Properties["ProtocolSupported"].Value,
                    ProviderType = (string) managementObject.Properties["ProviderType"].Value,
                    SettableBaudRate = (bool) managementObject.Properties["SettableBaudRate"].Value,
                    SettableDataBits = (bool) managementObject.Properties["SettableDataBits"].Value,
                    SettableFlowControl = (bool) managementObject.Properties["SettableFlowControl"].Value,
                    SettableParity = (bool) managementObject.Properties["SettableParity"].Value,
                    SettableParityCheck = (bool) managementObject.Properties["SettableParityCheck"].Value,
                    SettableRLSD = (bool) managementObject.Properties["SettableRLSD"].Value,
                    SettableStopBits = (bool) managementObject.Properties["SettableStopBits"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    Supports16BitMode = (bool) managementObject.Properties["Supports16BitMode"].Value,
                    SupportsDTRDSR = (bool) managementObject.Properties["SupportsDTRDSR"].Value,
                    SupportsElapsedTimeouts = (bool) managementObject.Properties["SupportsElapsedTimeouts"].Value,
                    SupportsIntTimeouts = (bool) managementObject.Properties["SupportsIntTimeouts"].Value,
                    SupportsParityCheck = (bool) managementObject.Properties["SupportsParityCheck"].Value,
                    SupportsRLSD = (bool) managementObject.Properties["SupportsRLSD"].Value,
                    SupportsRTSCTS = (bool) managementObject.Properties["SupportsRTSCTS"].Value,
                    SupportsSpecialCharacters = (bool) managementObject.Properties["SupportsSpecialCharacters"].Value,
                    SupportsXOnXOff = (bool) managementObject.Properties["SupportsXOnXOff"].Value,
                    SupportsXOnXOffSet = (bool) managementObject.Properties["SupportsXOnXOffSet"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value
                });

            return list.ToArray();
        }
    }
}