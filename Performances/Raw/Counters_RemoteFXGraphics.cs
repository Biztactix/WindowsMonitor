using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_RemoteFXGraphics
    {
        public uint AverageEncodingTime { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint FrameQuality { get; private set; }
        public uint FramesSkippedPerSecondInsufficientClientResources { get; private set; }
        public uint FramesSkippedPerSecondInsufficientNetworkResources { get; private set; }
        public uint FramesSkippedPerSecondInsufficientServerResources { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint GraphicsCompressionratio { get; private set; }
        public uint InputFramesPerSecond { get; private set; }
        public string Name { get; private set; }
        public uint OutputFramesPerSecond { get; private set; }
        public uint SourceFramesPerSecond { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_RemoteFXGraphics[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_RemoteFXGraphics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_RemoteFXGraphics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_RemoteFXGraphics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_RemoteFXGraphics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_RemoteFXGraphics
                {
                    AverageEncodingTime = (uint) managementObject.Properties["AverageEncodingTime"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FrameQuality = (uint) managementObject.Properties["FrameQuality"].Value,
                    FramesSkippedPerSecondInsufficientClientResources = (uint) managementObject
                        .Properties["FramesSkippedPerSecondInsufficientClientResources"].Value,
                    FramesSkippedPerSecondInsufficientNetworkResources = (uint) managementObject
                        .Properties["FramesSkippedPerSecondInsufficientNetworkResources"].Value,
                    FramesSkippedPerSecondInsufficientServerResources = (uint) managementObject
                        .Properties["FramesSkippedPerSecondInsufficientServerResources"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GraphicsCompressionratio = (uint) managementObject.Properties["GraphicsCompressionratio"].Value,
                    InputFramesPerSecond = (uint) managementObject.Properties["InputFramesPerSecond"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutputFramesPerSecond = (uint) managementObject.Properties["OutputFramesPerSecond"].Value,
                    SourceFramesPerSecond = (uint) managementObject.Properties["SourceFramesPerSecond"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}