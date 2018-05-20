using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Hardware.SerialPort
{
    /// <summary>
    /// </summary>
    public sealed class SerialCommProperties
    {
        public bool Active { get; private set; }
        public uint dwCurrentRxQueue { get; private set; }
        public uint dwCurrentTxQueue { get; private set; }
        public uint dwMaxBaud { get; private set; }
        public uint dwMaxRxQueue { get; private set; }
        public uint dwMaxTxQueue { get; private set; }
        public uint dwProvCapabilities { get; private set; }
        public uint dwProvCharSize { get; private set; }
        public uint dwProvSpec1 { get; private set; }
        public uint dwProvSpec2 { get; private set; }
        public uint dwProvSubType { get; private set; }
        public uint dwReserved1 { get; private set; }
        public uint dwServiceMask { get; private set; }
        public uint dwSettableBaud { get; private set; }
        public uint dwSettableParams { get; private set; }
        public string InstanceName { get; private set; }
        public byte[] wcProvChar { get; private set; }
        public ushort wPacketLength { get; private set; }
        public ushort wPacketVersion { get; private set; }
        public ushort wSettableData { get; private set; }
        public ushort wSettableStopParity { get; private set; }

        public static IEnumerable<SerialCommProperties> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<SerialCommProperties> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SerialCommProperties> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSSerial_CommProperties");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SerialCommProperties
                {
                    Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
                    dwCurrentRxQueue = (uint) (managementObject.Properties["dwCurrentRxQueue"]?.Value ?? default(uint)),
                    dwCurrentTxQueue = (uint) (managementObject.Properties["dwCurrentTxQueue"]?.Value ?? default(uint)),
                    dwMaxBaud = (uint) (managementObject.Properties["dwMaxBaud"]?.Value ?? default(uint)),
                    dwMaxRxQueue = (uint) (managementObject.Properties["dwMaxRxQueue"]?.Value ?? default(uint)),
                    dwMaxTxQueue = (uint) (managementObject.Properties["dwMaxTxQueue"]?.Value ?? default(uint)),
                    dwProvCapabilities =
                        (uint) (managementObject.Properties["dwProvCapabilities"]?.Value ?? default(uint)),
                    dwProvCharSize = (uint) (managementObject.Properties["dwProvCharSize"]?.Value ?? default(uint)),
                    dwProvSpec1 = (uint) (managementObject.Properties["dwProvSpec1"]?.Value ?? default(uint)),
                    dwProvSpec2 = (uint) (managementObject.Properties["dwProvSpec2"]?.Value ?? default(uint)),
                    dwProvSubType = (uint) (managementObject.Properties["dwProvSubType"]?.Value ?? default(uint)),
                    dwReserved1 = (uint) (managementObject.Properties["dwReserved1"]?.Value ?? default(uint)),
                    dwServiceMask = (uint) (managementObject.Properties["dwServiceMask"]?.Value ?? default(uint)),
                    dwSettableBaud = (uint) (managementObject.Properties["dwSettableBaud"]?.Value ?? default(uint)),
                    dwSettableParams = (uint) (managementObject.Properties["dwSettableParams"]?.Value ?? default(uint)),
                    InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
                    wcProvChar = (byte[]) (managementObject.Properties["wcProvChar"]?.Value ?? new byte[0]),
                    wPacketLength = (ushort) (managementObject.Properties["wPacketLength"]?.Value ?? default(ushort)),
                    wPacketVersion = (ushort) (managementObject.Properties["wPacketVersion"]?.Value ?? default(ushort)),
                    wSettableData = (ushort) (managementObject.Properties["wSettableData"]?.Value ?? default(ushort)),
                    wSettableStopParity =
                        (ushort) (managementObject.Properties["wSettableStopParity"]?.Value ?? default(ushort))
                };
        }
    }
}