using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class VoltageProbe
    {
        public int Accuracy { get; private set; }
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public int CurrentReading { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool IsLinear { get; private set; }
        public uint LastErrorCode { get; private set; }
        public int LowerThresholdCritical { get; private set; }
        public int LowerThresholdFatal { get; private set; }
        public int LowerThresholdNonCritical { get; private set; }
        public int MaxReadable { get; private set; }
        public int MinReadable { get; private set; }
        public string Name { get; private set; }
        public int NominalReading { get; private set; }
        public int NormalMax { get; private set; }
        public int NormalMin { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort[] PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public uint Resolution { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public int Tolerance { get; private set; }
        public int UpperThresholdCritical { get; private set; }
        public int UpperThresholdFatal { get; private set; }
        public int UpperThresholdNonCritical { get; private set; }

        public static VoltageProbe[] Retrieve(string remote, string username, string password)
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

        public static VoltageProbe[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static VoltageProbe[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_VoltageProbe");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<VoltageProbe>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new VoltageProbe
                {
                    Accuracy = (int) managementObject.Properties["Accuracy"].Value,
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConfigManagerErrorCode = (uint) managementObject.Properties["ConfigManagerErrorCode"].Value,
                    ConfigManagerUserConfig = (bool) managementObject.Properties["ConfigManagerUserConfig"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CurrentReading = (int) managementObject.Properties["CurrentReading"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DeviceID = (string) managementObject.Properties["DeviceID"].Value,
                    ErrorCleared = (bool) managementObject.Properties["ErrorCleared"].Value,
                    ErrorDescription = (string) managementObject.Properties["ErrorDescription"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    IsLinear = (bool) managementObject.Properties["IsLinear"].Value,
                    LastErrorCode = (uint) managementObject.Properties["LastErrorCode"].Value,
                    LowerThresholdCritical = (int) managementObject.Properties["LowerThresholdCritical"].Value,
                    LowerThresholdFatal = (int) managementObject.Properties["LowerThresholdFatal"].Value,
                    LowerThresholdNonCritical = (int) managementObject.Properties["LowerThresholdNonCritical"].Value,
                    MaxReadable = (int) managementObject.Properties["MaxReadable"].Value,
                    MinReadable = (int) managementObject.Properties["MinReadable"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NominalReading = (int) managementObject.Properties["NominalReading"].Value,
                    NormalMax = (int) managementObject.Properties["NormalMax"].Value,
                    NormalMin = (int) managementObject.Properties["NormalMin"].Value,
                    PNPDeviceID = (string) managementObject.Properties["PNPDeviceID"].Value,
                    PowerManagementCapabilities =
                        (ushort[]) managementObject.Properties["PowerManagementCapabilities"].Value,
                    PowerManagementSupported = (bool) managementObject.Properties["PowerManagementSupported"].Value,
                    Resolution = (uint) managementObject.Properties["Resolution"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    StatusInfo = (ushort) managementObject.Properties["StatusInfo"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    Tolerance = (int) managementObject.Properties["Tolerance"].Value,
                    UpperThresholdCritical = (int) managementObject.Properties["UpperThresholdCritical"].Value,
                    UpperThresholdFatal = (int) managementObject.Properties["UpperThresholdFatal"].Value,
                    UpperThresholdNonCritical = (int) managementObject.Properties["UpperThresholdNonCritical"].Value
                });

            return list.ToArray();
        }
    }
}