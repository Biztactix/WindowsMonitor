using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class POTSModem
    {
        public ushort AnswerMode { get; private set; }
        public string AttachedTo { get; private set; }
        public ushort Availability { get; private set; }
        public string BlindOff { get; private set; }
        public string BlindOn { get; private set; }
        public string Caption { get; private set; }
        public string CompatibilityFlags { get; private set; }
        public ushort CompressionInfo { get; private set; }
        public string CompressionOff { get; private set; }
        public string CompressionOn { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string ConfigurationDialog { get; private set; }
        public string[] CountriesSupported { get; private set; }
        public string CountrySelected { get; private set; }
        public string CreationClassName { get; private set; }
        public string[] CurrentPasswords { get; private set; }
        public byte[] DCB { get; private set; }
        public byte[] Default { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public string DeviceLoader { get; private set; }
        public string DeviceType { get; private set; }
        public ushort DialType { get; private set; }
        public DateTime DriverDate { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorControlForced { get; private set; }
        public ushort ErrorControlInfo { get; private set; }
        public string ErrorControlOff { get; private set; }
        public string ErrorControlOn { get; private set; }
        public string ErrorDescription { get; private set; }
        public string FlowControlHard { get; private set; }
        public string FlowControlOff { get; private set; }
        public string FlowControlSoft { get; private set; }
        public string InactivityScale { get; private set; }
        public uint InactivityTimeout { get; private set; }
        public uint Index { get; private set; }
        public string IndexEx { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint LastErrorCode { get; private set; }
        public uint MaxBaudRateToPhone { get; private set; }
        public uint MaxBaudRateToSerialPort { get; private set; }
        public ushort MaxNumberOfPasswords { get; private set; }
        public string Model { get; private set; }
        public string ModemInfPath { get; private set; }
        public string ModemInfSection { get; private set; }
        public string ModulationBell { get; private set; }
        public string ModulationCCITT { get; private set; }
        public ushort ModulationScheme { get; private set; }
        public string Name { get; private set; }
        public string PNPDeviceID { get; private set; }
        public string PortSubClass { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string Prefix { get; private set; }
        public byte[] Properties { get; private set; }
        public string ProviderName { get; private set; }
        public string Pulse { get; private set; }
        public string Reset { get; private set; }
        public string ResponsesKeyName { get; private set; }
        public byte RingsBeforeAnswer { get; private set; }
        public string SpeakerModeDial { get; private set; }
        public string SpeakerModeOff { get; private set; }
        public string SpeakerModeOn { get; private set; }
        public string SpeakerModeSetup { get; private set; }
        public string SpeakerVolumeHigh { get; private set; }
        public ushort SpeakerVolumeInfo { get; private set; }
        public string SpeakerVolumeLow { get; private set; }
        public string SpeakerVolumeMed { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string StringFormat { get; private set; }
        public bool SupportsCallback { get; private set; }
        public bool SupportsSynchronousConnect { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public string Terminator { get; private set; }
        public DateTime TimeOfLastReset { get; private set; }
        public string Tone { get; private set; }
        public string VoiceSwitchFeature { get; private set; }

        public static POTSModem[] Retrieve(string remote, string username, string password)
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

        public static POTSModem[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static POTSModem[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_POTSModem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<POTSModem>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new POTSModem
                {
                    AnswerMode = (ushort) managementObject.Properties["AnswerMode"].Value,
                    AttachedTo = (string) managementObject.Properties["AttachedTo"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    BlindOff = (string) managementObject.Properties["BlindOff"].Value,
                    BlindOn = (string) managementObject.Properties["BlindOn"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CompatibilityFlags = (string) managementObject.Properties["CompatibilityFlags"].Value,
                    CompressionInfo = (ushort) managementObject.Properties["CompressionInfo"].Value,
                    CompressionOff = (string) managementObject.Properties["CompressionOff"].Value,
                    CompressionOn = (string) managementObject.Properties["CompressionOn"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    ConfigurationDialog = (string) managementObject.Properties["ConfigurationDialog"].Value,
                    CountriesSupported = (string[]) managementObject.Properties["CountriesSupported"].Value,
                    CountrySelected = (string) managementObject.Properties["CountrySelected"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentPasswords = (string[]) managementObject.Properties["CurrentPasswords"].Value,
                    DCB = (byte[]) managementObject.Properties["DCB"].Value,
                    Default = (byte[]) managementObject.Properties["Default"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    DeviceLoader = (string) managementObject.Properties["DeviceLoader"].Value,
                    DeviceType = (string) managementObject.Properties["DeviceType"].Value,
                    DialType = (ushort) managementObject.Properties["DialType"].Value,
                    DriverDate = (DateTime) managementObject.Properties["DriverDate"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorControlForced = (string) managementObject.Properties["ErrorControlForced"].Value,
                    ErrorControlInfo = (ushort) managementObject.Properties["ErrorControlInfo"].Value,
                    ErrorControlOff = (string) managementObject.Properties["ErrorControlOff"].Value,
                    ErrorControlOn = (string) managementObject.Properties["ErrorControlOn"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    FlowControlHard = (string) managementObject.Properties["FlowControlHard"].Value,
                    FlowControlOff = (string) managementObject.Properties["FlowControlOff"].Value,
                    FlowControlSoft = (string) managementObject.Properties["FlowControlSoft"].Value,
                    InactivityScale = (string) managementObject.Properties["InactivityScale"].Value,
                    InactivityTimeout = (uint) managementObject.Properties["InactivityTimeout"].Value,
                    Index = (uint) managementObject.Properties["Index"].Value,
                    IndexEx = (string) managementObject.Properties["IndexEx"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    MaxBaudRateToPhone = (uint) managementObject.Properties["MaxBaudRateToPhone"].Value,
                    MaxBaudRateToSerialPort = (uint) managementObject.Properties["MaxBaudRateToSerialPort"].Value,
                    MaxNumberOfPasswords = (ushort) managementObject.Properties["MaxNumberOfPasswords"].Value,
                    Model = (string) managementObject.Properties["Model"].Value,
                    ModemInfPath = (string) managementObject.Properties["ModemInfPath"].Value,
                    ModemInfSection = (string) managementObject.Properties["ModemInfSection"].Value,
                    ModulationBell = (string) managementObject.Properties["ModulationBell"].Value,
                    ModulationCCITT = (string) managementObject.Properties["ModulationCCITT"].Value,
                    ModulationScheme = (ushort) managementObject.Properties["ModulationScheme"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PortSubClass = (string) managementObject.Properties["PortSubClass"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    Prefix = (string) managementObject.Properties["Prefix"].Value,
                    Properties = (byte[]) managementObject.Properties["Properties"].Value,
                    ProviderName = (string) managementObject.Properties["ProviderName"].Value,
                    Pulse = (string) managementObject.Properties["Pulse"].Value,
                    Reset = (string) managementObject.Properties["Reset"].Value,
                    ResponsesKeyName = (string) managementObject.Properties["ResponsesKeyName"].Value,
                    RingsBeforeAnswer = (byte) managementObject.Properties["RingsBeforeAnswer"].Value,
                    SpeakerModeDial = (string) managementObject.Properties["SpeakerModeDial"].Value,
                    SpeakerModeOff = (string) managementObject.Properties["SpeakerModeOff"].Value,
                    SpeakerModeOn = (string) managementObject.Properties["SpeakerModeOn"].Value,
                    SpeakerModeSetup = (string) managementObject.Properties["SpeakerModeSetup"].Value,
                    SpeakerVolumeHigh = (string) managementObject.Properties["SpeakerVolumeHigh"].Value,
                    SpeakerVolumeInfo = (ushort) managementObject.Properties["SpeakerVolumeInfo"].Value,
                    SpeakerVolumeLow = (string) managementObject.Properties["SpeakerVolumeLow"].Value,
                    SpeakerVolumeMed = (string) managementObject.Properties["SpeakerVolumeMed"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    StringFormat = (string) managementObject.Properties["StringFormat"].Value,
                    SupportsCallback = (bool) managementObject.Properties["SupportsCallback"].Value,
                    SupportsSynchronousConnect = (bool) managementObject.Properties["SupportsSynchronousConnect"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    Terminator = (string) managementObject.Properties["Terminator"].Value,
                    TimeOfLastReset = (DateTime) managementObject.Properties["TimeOfLastReset"].Value,
                    Tone = (string) managementObject.Properties["Tone"].Value,
                    VoiceSwitchFeature = (string) managementObject.Properties["VoiceSwitchFeature"].Value
                });

            return list.ToArray();
        }
    }
}