using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_RemoteAccess_RASPort
    {
        public uint AlignmentErrors { get; private set; }
        public uint BufferOverrunErrors { get; private set; }
        public ulong BytesReceived { get; private set; }
        public uint BytesReceivedPerSec { get; private set; }
        public ulong BytesTransmitted { get; private set; }
        public uint BytesTransmittedPerSec { get; private set; }
        public string Caption { get; private set; }
        public uint CRCErrors { get; private set; }
        public string Description { get; private set; }
        public uint FramesReceived { get; private set; }
        public uint FramesReceivedPerSec { get; private set; }
        public uint FramesTransmitted { get; private set; }
        public uint FramesTransmittedPerSec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint PercentCompressionIn { get; private set; }
        public uint PercentCompressionOut { get; private set; }
        public uint SerialOverrunErrors { get; private set; }
        public uint TimeoutErrors { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalErrors { get; private set; }
        public uint TotalErrorsPerSec { get; private set; }

        public static PerfRawData_RemoteAccess_RASPort[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_RemoteAccess_RASPort[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_RemoteAccess_RASPort[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_RemoteAccess_RASPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_RemoteAccess_RASPort>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_RemoteAccess_RASPort
                {
                    AlignmentErrors = (uint) managementObject.Properties["AlignmentErrors"].Value,
                    BufferOverrunErrors = (uint) managementObject.Properties["BufferOverrunErrors"].Value,
                    BytesReceived = (ulong) managementObject.Properties["BytesReceived"].Value,
                    BytesReceivedPerSec = (uint) managementObject.Properties["BytesReceivedPerSec"].Value,
                    BytesTransmitted = (ulong) managementObject.Properties["BytesTransmitted"].Value,
                    BytesTransmittedPerSec = (uint) managementObject.Properties["BytesTransmittedPerSec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CRCErrors = (uint) managementObject.Properties["CRCErrors"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FramesReceived = (uint) managementObject.Properties["FramesReceived"].Value,
                    FramesReceivedPerSec = (uint) managementObject.Properties["FramesReceivedPerSec"].Value,
                    FramesTransmitted = (uint) managementObject.Properties["FramesTransmitted"].Value,
                    FramesTransmittedPerSec = (uint) managementObject.Properties["FramesTransmittedPerSec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentCompressionIn = (uint) managementObject.Properties["PercentCompressionIn"].Value,
                    PercentCompressionOut = (uint) managementObject.Properties["PercentCompressionOut"].Value,
                    SerialOverrunErrors = (uint) managementObject.Properties["SerialOverrunErrors"].Value,
                    TimeoutErrors = (uint) managementObject.Properties["TimeoutErrors"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalErrors = (uint) managementObject.Properties["TotalErrors"].Value,
                    TotalErrorsPerSec = (uint) managementObject.Properties["TotalErrorsPerSec"].Value
                });

            return list.ToArray();
        }
    }
}