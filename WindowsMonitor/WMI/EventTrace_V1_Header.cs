using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class EventTrace_V1_Header
    {
		public ulong BootTime { get; private set; }
		public uint BufferSize { get; private set; }
		public uint BuffersLost { get; private set; }
		public uint BuffersWritten { get; private set; }
		public uint CPUSpeed { get; private set; }
		public ulong EndTime { get; private set; }
		public uint EventsLost { get; private set; }
		public uint Flags { get; private set; }
		public uint LogFileMode { get; private set; }
		public uint LogFileName { get; private set; }
		public string LogFileNameString { get; private set; }
		public uint LoggerName { get; private set; }
		public uint MaxFileSize { get; private set; }
		public uint NumberOfProcessors { get; private set; }
		public ulong PerfFreq { get; private set; }
		public uint PointerSize { get; private set; }
		public uint ProviderVersion { get; private set; }
		public uint ReservedFlags { get; private set; }
		public string SessionNameString { get; private set; }
		public uint StartBuffers { get; private set; }
		public ulong StartTime { get; private set; }
		public uint TimerResolution { get; private set; }
		public byte[] TimeZoneInformation { get; private set; }
		public uint Version { get; private set; }

        public static IEnumerable<EventTrace_V1_Header> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<EventTrace_V1_Header> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<EventTrace_V1_Header> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM EventTrace_V1_Header");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new EventTrace_V1_Header
                {
                     BootTime = (ulong) (managementObject.Properties["BootTime"]?.Value ?? default(ulong)),
		 BufferSize = (uint) (managementObject.Properties["BufferSize"]?.Value ?? default(uint)),
		 BuffersLost = (uint) (managementObject.Properties["BuffersLost"]?.Value ?? default(uint)),
		 BuffersWritten = (uint) (managementObject.Properties["BuffersWritten"]?.Value ?? default(uint)),
		 CPUSpeed = (uint) (managementObject.Properties["CPUSpeed"]?.Value ?? default(uint)),
		 EndTime = (ulong) (managementObject.Properties["EndTime"]?.Value ?? default(ulong)),
		 EventsLost = (uint) (managementObject.Properties["EventsLost"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 LogFileMode = (uint) (managementObject.Properties["LogFileMode"]?.Value ?? default(uint)),
		 LogFileName = (uint) (managementObject.Properties["LogFileName"]?.Value ?? default(uint)),
		 LogFileNameString = (string) (managementObject.Properties["LogFileNameString"]?.Value ?? default(string)),
		 LoggerName = (uint) (managementObject.Properties["LoggerName"]?.Value ?? default(uint)),
		 MaxFileSize = (uint) (managementObject.Properties["MaxFileSize"]?.Value ?? default(uint)),
		 NumberOfProcessors = (uint) (managementObject.Properties["NumberOfProcessors"]?.Value ?? default(uint)),
		 PerfFreq = (ulong) (managementObject.Properties["PerfFreq"]?.Value ?? default(ulong)),
		 PointerSize = (uint) (managementObject.Properties["PointerSize"]?.Value ?? default(uint)),
		 ProviderVersion = (uint) (managementObject.Properties["ProviderVersion"]?.Value ?? default(uint)),
		 ReservedFlags = (uint) (managementObject.Properties["ReservedFlags"]?.Value ?? default(uint)),
		 SessionNameString = (string) (managementObject.Properties["SessionNameString"]?.Value ?? default(string)),
		 StartBuffers = (uint) (managementObject.Properties["StartBuffers"]?.Value ?? default(uint)),
		 StartTime = (ulong) (managementObject.Properties["StartTime"]?.Value ?? default(ulong)),
		 TimerResolution = (uint) (managementObject.Properties["TimerResolution"]?.Value ?? default(uint)),
		 TimeZoneInformation = (byte[]) (managementObject.Properties["TimeZoneInformation"]?.Value ?? new byte[0]),
		 Version = (uint) (managementObject.Properties["Version"]?.Value ?? default(uint))
                };
        }
    }
}