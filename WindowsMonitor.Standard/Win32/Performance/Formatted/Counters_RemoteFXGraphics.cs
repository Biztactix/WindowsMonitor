using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_RemoteFXGraphics
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

        public static IEnumerable<Counters_RemoteFXGraphics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_RemoteFXGraphics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_RemoteFXGraphics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_RemoteFXGraphics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_RemoteFXGraphics
                {
                     AverageEncodingTime = (uint) (managementObject.Properties["AverageEncodingTime"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FrameQuality = (uint) (managementObject.Properties["FrameQuality"]?.Value ?? default(uint)),
		 FramesSkippedPerSecondInsufficientClientResources = (uint) (managementObject.Properties["FramesSkippedPerSecondInsufficientClientResources"]?.Value ?? default(uint)),
		 FramesSkippedPerSecondInsufficientNetworkResources = (uint) (managementObject.Properties["FramesSkippedPerSecondInsufficientNetworkResources"]?.Value ?? default(uint)),
		 FramesSkippedPerSecondInsufficientServerResources = (uint) (managementObject.Properties["FramesSkippedPerSecondInsufficientServerResources"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GraphicsCompressionratio = (uint) (managementObject.Properties["GraphicsCompressionratio"]?.Value ?? default(uint)),
		 InputFramesPerSecond = (uint) (managementObject.Properties["InputFramesPerSecond"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutputFramesPerSecond = (uint) (managementObject.Properties["OutputFramesPerSecond"]?.Value ?? default(uint)),
		 SourceFramesPerSecond = (uint) (managementObject.Properties["SourceFramesPerSecond"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}