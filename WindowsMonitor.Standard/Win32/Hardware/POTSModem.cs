using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware
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

        public static IEnumerable<POTSModem> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<POTSModem> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<POTSModem> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_POTSModem");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new POTSModem
                {
                     AnswerMode = (ushort) (managementObject.Properties["AnswerMode"]?.Value ?? default(ushort)),
		 AttachedTo = (string) (managementObject.Properties["AttachedTo"]?.Value ?? default(string)),
		 Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 BlindOff = (string) (managementObject.Properties["BlindOff"]?.Value ?? default(string)),
		 BlindOn = (string) (managementObject.Properties["BlindOn"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CompatibilityFlags = (string) (managementObject.Properties["CompatibilityFlags"]?.Value ?? default(string)),
		 CompressionInfo = (ushort) (managementObject.Properties["CompressionInfo"]?.Value ?? default(ushort)),
		 CompressionOff = (string) (managementObject.Properties["CompressionOff"]?.Value ?? default(string)),
		 CompressionOn = (string) (managementObject.Properties["CompressionOn"]?.Value ?? default(string)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 ConfigurationDialog = (string) (managementObject.Properties["ConfigurationDialog"]?.Value ?? default(string)),
		 CountriesSupported = (string[]) (managementObject.Properties["CountriesSupported"]?.Value ?? new string[0]),
		 CountrySelected = (string) (managementObject.Properties["CountrySelected"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CurrentPasswords = (string[]) (managementObject.Properties["CurrentPasswords"]?.Value ?? new string[0]),
		 DCB = (byte[]) (managementObject.Properties["DCB"]?.Value ?? new byte[0]),
		 Default = (byte[]) (managementObject.Properties["Default"]?.Value ?? new byte[0]),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 DeviceLoader = (string) (managementObject.Properties["DeviceLoader"]?.Value ?? default(string)),
		 DeviceType = (string) (managementObject.Properties["DeviceType"]?.Value ?? default(string)),
		 DialType = (ushort) (managementObject.Properties["DialType"]?.Value ?? default(ushort)),
		 DriverDate = (DateTime) (managementObject.Properties["DriverDate"]?.Value ?? default(DateTime)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorControlForced = (string) (managementObject.Properties["ErrorControlForced"]?.Value ?? default(string)),
		 ErrorControlInfo = (ushort) (managementObject.Properties["ErrorControlInfo"]?.Value ?? default(ushort)),
		 ErrorControlOff = (string) (managementObject.Properties["ErrorControlOff"]?.Value ?? default(string)),
		 ErrorControlOn = (string) (managementObject.Properties["ErrorControlOn"]?.Value ?? default(string)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 FlowControlHard = (string) (managementObject.Properties["FlowControlHard"]?.Value ?? default(string)),
		 FlowControlOff = (string) (managementObject.Properties["FlowControlOff"]?.Value ?? default(string)),
		 FlowControlSoft = (string) (managementObject.Properties["FlowControlSoft"]?.Value ?? default(string)),
		 InactivityScale = (string) (managementObject.Properties["InactivityScale"]?.Value ?? default(string)),
		 InactivityTimeout = (uint) (managementObject.Properties["InactivityTimeout"]?.Value ?? default(uint)),
		 Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 IndexEx = (string) (managementObject.Properties["IndexEx"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 MaxBaudRateToPhone = (uint) (managementObject.Properties["MaxBaudRateToPhone"]?.Value ?? default(uint)),
		 MaxBaudRateToSerialPort = (uint) (managementObject.Properties["MaxBaudRateToSerialPort"]?.Value ?? default(uint)),
		 MaxNumberOfPasswords = (ushort) (managementObject.Properties["MaxNumberOfPasswords"]?.Value ?? default(ushort)),
		 Model = (string) (managementObject.Properties["Model"]?.Value ?? default(string)),
		 ModemInfPath = (string) (managementObject.Properties["ModemInfPath"]?.Value ?? default(string)),
		 ModemInfSection = (string) (managementObject.Properties["ModemInfSection"]?.Value ?? default(string)),
		 ModulationBell = (string) (managementObject.Properties["ModulationBell"]?.Value ?? default(string)),
		 ModulationCCITT = (string) (managementObject.Properties["ModulationCCITT"]?.Value ?? default(string)),
		 ModulationScheme = (ushort) (managementObject.Properties["ModulationScheme"]?.Value ?? default(ushort)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PortSubClass = (string) (managementObject.Properties["PortSubClass"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 Prefix = (string) (managementObject.Properties["Prefix"]?.Value ?? default(string)),
		 Properties = (byte[]) (managementObject.Properties["Properties"]?.Value ?? new byte[0]),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value ?? default(string)),
		 Pulse = (string) (managementObject.Properties["Pulse"]?.Value ?? default(string)),
		 Reset = (string) (managementObject.Properties["Reset"]?.Value ?? default(string)),
		 ResponsesKeyName = (string) (managementObject.Properties["ResponsesKeyName"]?.Value ?? default(string)),
		 RingsBeforeAnswer = (byte) (managementObject.Properties["RingsBeforeAnswer"]?.Value ?? default(byte)),
		 SpeakerModeDial = (string) (managementObject.Properties["SpeakerModeDial"]?.Value ?? default(string)),
		 SpeakerModeOff = (string) (managementObject.Properties["SpeakerModeOff"]?.Value ?? default(string)),
		 SpeakerModeOn = (string) (managementObject.Properties["SpeakerModeOn"]?.Value ?? default(string)),
		 SpeakerModeSetup = (string) (managementObject.Properties["SpeakerModeSetup"]?.Value ?? default(string)),
		 SpeakerVolumeHigh = (string) (managementObject.Properties["SpeakerVolumeHigh"]?.Value ?? default(string)),
		 SpeakerVolumeInfo = (ushort) (managementObject.Properties["SpeakerVolumeInfo"]?.Value ?? default(ushort)),
		 SpeakerVolumeLow = (string) (managementObject.Properties["SpeakerVolumeLow"]?.Value ?? default(string)),
		 SpeakerVolumeMed = (string) (managementObject.Properties["SpeakerVolumeMed"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 StringFormat = (string) (managementObject.Properties["StringFormat"]?.Value ?? default(string)),
		 SupportsCallback = (bool) (managementObject.Properties["SupportsCallback"]?.Value ?? default(bool)),
		 SupportsSynchronousConnect = (bool) (managementObject.Properties["SupportsSynchronousConnect"]?.Value ?? default(bool)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 Terminator = (string) (managementObject.Properties["Terminator"]?.Value ?? default(string)),
		 TimeOfLastReset = (DateTime) (managementObject.Properties["TimeOfLastReset"]?.Value ?? default(DateTime)),
		 Tone = (string) (managementObject.Properties["Tone"]?.Value ?? default(string)),
		 VoiceSwitchFeature = (string) (managementObject.Properties["VoiceSwitchFeature"]?.Value ?? default(string))
                };
        }
    }
}