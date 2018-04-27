using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class RemoteAccess_RASPort
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

        public static IEnumerable<RemoteAccess_RASPort> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<RemoteAccess_RASPort> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<RemoteAccess_RASPort> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_RemoteAccess_RASPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new RemoteAccess_RASPort
                {
                     AlignmentErrors = (uint) (managementObject.Properties["AlignmentErrors"]?.Value ?? default(uint)),
		 BufferOverrunErrors = (uint) (managementObject.Properties["BufferOverrunErrors"]?.Value ?? default(uint)),
		 BytesReceived = (ulong) (managementObject.Properties["BytesReceived"]?.Value ?? default(ulong)),
		 BytesReceivedPerSec = (uint) (managementObject.Properties["BytesReceivedPerSec"]?.Value ?? default(uint)),
		 BytesTransmitted = (ulong) (managementObject.Properties["BytesTransmitted"]?.Value ?? default(ulong)),
		 BytesTransmittedPerSec = (uint) (managementObject.Properties["BytesTransmittedPerSec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CRCErrors = (uint) (managementObject.Properties["CRCErrors"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FramesReceived = (uint) (managementObject.Properties["FramesReceived"]?.Value ?? default(uint)),
		 FramesReceivedPerSec = (uint) (managementObject.Properties["FramesReceivedPerSec"]?.Value ?? default(uint)),
		 FramesTransmitted = (uint) (managementObject.Properties["FramesTransmitted"]?.Value ?? default(uint)),
		 FramesTransmittedPerSec = (uint) (managementObject.Properties["FramesTransmittedPerSec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentCompressionIn = (uint) (managementObject.Properties["PercentCompressionIn"]?.Value ?? default(uint)),
		 PercentCompressionOut = (uint) (managementObject.Properties["PercentCompressionOut"]?.Value ?? default(uint)),
		 SerialOverrunErrors = (uint) (managementObject.Properties["SerialOverrunErrors"]?.Value ?? default(uint)),
		 TimeoutErrors = (uint) (managementObject.Properties["TimeoutErrors"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalErrors = (uint) (managementObject.Properties["TotalErrors"]?.Value ?? default(uint)),
		 TotalErrorsPerSec = (uint) (managementObject.Properties["TotalErrorsPerSec"]?.Value ?? default(uint))
                };
        }
    }
}