using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SerialPortConfiguration
    {
        public bool AbortReadWriteOnError { get; private set; }
        public uint BaudRate { get; private set; }
        public bool BinaryModeEnabled { get; private set; }
        public uint BitsPerByte { get; private set; }
        public string Caption { get; private set; }
        public bool ContinueXMitOnXOff { get; private set; }
        public bool CTSOutflowControl { get; private set; }
        public string Description { get; private set; }
        public bool DiscardNULLBytes { get; private set; }
        public bool DSROutflowControl { get; private set; }
        public bool DSRSensitivity { get; private set; }
        public string DTRFlowControlType { get; private set; }
        public uint EOFCharacter { get; private set; }
        public uint ErrorReplaceCharacter { get; private set; }
        public bool ErrorReplacementEnabled { get; private set; }
        public uint EventCharacter { get; private set; }
        public bool IsBusy { get; private set; }
        public string Name { get; private set; }
        public string Parity { get; private set; }
        public bool ParityCheckEnabled { get; private set; }
        public string RTSFlowControlType { get; private set; }
        public string SettingID { get; private set; }
        public string StopBits { get; private set; }
        public uint XOffCharacter { get; private set; }
        public uint XOffXMitThreshold { get; private set; }
        public uint XOnCharacter { get; private set; }
        public uint XOnXMitThreshold { get; private set; }
        public uint XOnXOffInFlowControl { get; private set; }
        public uint XOnXOffOutFlowControl { get; private set; }

        public static SerialPortConfiguration[] Retrieve(string remote, string username, string password)
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

        public static SerialPortConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SerialPortConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SerialPortConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SerialPortConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SerialPortConfiguration
                {
                    AbortReadWriteOnError = (bool) managementObject.Properties["AbortReadWriteOnError"].Value,
                    BaudRate = (uint) managementObject.Properties["BaudRate"].Value,
                    BinaryModeEnabled = (bool) managementObject.Properties["BinaryModeEnabled"].Value,
                    BitsPerByte = (uint) managementObject.Properties["BitsPerByte"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContinueXMitOnXOff = (bool) managementObject.Properties["ContinueXMitOnXOff"].Value,
                    CTSOutflowControl = (bool) managementObject.Properties["CTSOutflowControl"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DiscardNULLBytes = (bool) managementObject.Properties["DiscardNULLBytes"].Value,
                    DSROutflowControl = (bool) managementObject.Properties["DSROutflowControl"].Value,
                    DSRSensitivity = (bool) managementObject.Properties["DSRSensitivity"].Value,
                    DTRFlowControlType = (string) managementObject.Properties["DTRFlowControlType"].Value,
                    EOFCharacter = (uint) managementObject.Properties["EOFCharacter"].Value,
                    ErrorReplaceCharacter = (uint) managementObject.Properties["ErrorReplaceCharacter"].Value,
                    ErrorReplacementEnabled = (bool) managementObject.Properties["ErrorReplacementEnabled"].Value,
                    EventCharacter = (uint) managementObject.Properties["EventCharacter"].Value,
                    IsBusy = (bool) managementObject.Properties["IsBusy"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Parity = (string) managementObject.Properties["Parity"].Value,
                    ParityCheckEnabled = (bool) managementObject.Properties["ParityCheckEnabled"].Value,
                    RTSFlowControlType = (string) managementObject.Properties["RTSFlowControlType"].Value,
                    SettingID = (string) managementObject.Properties["SettingID"].Value,
                    StopBits = (string) managementObject.Properties["StopBits"].Value,
                    XOffCharacter = (uint) managementObject.Properties["XOffCharacter"].Value,
                    XOffXMitThreshold = (uint) managementObject.Properties["XOffXMitThreshold"].Value,
                    XOnCharacter = (uint) managementObject.Properties["XOnCharacter"].Value,
                    XOnXMitThreshold = (uint) managementObject.Properties["XOnXMitThreshold"].Value,
                    XOnXOffInFlowControl = (uint) managementObject.Properties["XOnXOffInFlowControl"].Value,
                    XOnXOffOutFlowControl = (uint) managementObject.Properties["XOnXOffOutFlowControl"].Value
                });

            return list.ToArray();
        }
    }
}