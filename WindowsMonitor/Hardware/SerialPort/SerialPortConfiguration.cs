using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware.Ports
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

        public static IEnumerable<SerialPortConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SerialPortConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SerialPortConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SerialPortConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SerialPortConfiguration
                {
                     AbortReadWriteOnError = (bool) (managementObject.Properties["AbortReadWriteOnError"]?.Value ?? default(bool)),
		 BaudRate = (uint) (managementObject.Properties["BaudRate"]?.Value ?? default(uint)),
		 BinaryModeEnabled = (bool) (managementObject.Properties["BinaryModeEnabled"]?.Value ?? default(bool)),
		 BitsPerByte = (uint) (managementObject.Properties["BitsPerByte"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ContinueXMitOnXOff = (bool) (managementObject.Properties["ContinueXMitOnXOff"]?.Value ?? default(bool)),
		 CTSOutflowControl = (bool) (managementObject.Properties["CTSOutflowControl"]?.Value ?? default(bool)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 DiscardNULLBytes = (bool) (managementObject.Properties["DiscardNULLBytes"]?.Value ?? default(bool)),
		 DSROutflowControl = (bool) (managementObject.Properties["DSROutflowControl"]?.Value ?? default(bool)),
		 DSRSensitivity = (bool) (managementObject.Properties["DSRSensitivity"]?.Value ?? default(bool)),
		 DTRFlowControlType = (string) (managementObject.Properties["DTRFlowControlType"]?.Value),
		 EOFCharacter = (uint) (managementObject.Properties["EOFCharacter"]?.Value ?? default(uint)),
		 ErrorReplaceCharacter = (uint) (managementObject.Properties["ErrorReplaceCharacter"]?.Value ?? default(uint)),
		 ErrorReplacementEnabled = (bool) (managementObject.Properties["ErrorReplacementEnabled"]?.Value ?? default(bool)),
		 EventCharacter = (uint) (managementObject.Properties["EventCharacter"]?.Value ?? default(uint)),
		 IsBusy = (bool) (managementObject.Properties["IsBusy"]?.Value ?? default(bool)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Parity = (string) (managementObject.Properties["Parity"]?.Value),
		 ParityCheckEnabled = (bool) (managementObject.Properties["ParityCheckEnabled"]?.Value ?? default(bool)),
		 RTSFlowControlType = (string) (managementObject.Properties["RTSFlowControlType"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value),
		 StopBits = (string) (managementObject.Properties["StopBits"]?.Value),
		 XOffCharacter = (uint) (managementObject.Properties["XOffCharacter"]?.Value ?? default(uint)),
		 XOffXMitThreshold = (uint) (managementObject.Properties["XOffXMitThreshold"]?.Value ?? default(uint)),
		 XOnCharacter = (uint) (managementObject.Properties["XOnCharacter"]?.Value ?? default(uint)),
		 XOnXMitThreshold = (uint) (managementObject.Properties["XOnXMitThreshold"]?.Value ?? default(uint)),
		 XOnXOffInFlowControl = (uint) (managementObject.Properties["XOnXOffInFlowControl"]?.Value ?? default(uint)),
		 XOnXOffOutFlowControl = (uint) (managementObject.Properties["XOnXOffOutFlowControl"]?.Value ?? default(uint))
                };
        }
    }
}