using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class SystemConfig_V3_CPU
    {
		public uint AllocationGranularity { get; private set; }
		public char[] ComputerName { get; private set; }
		public char[] DomainName { get; private set; }
		public uint Flags { get; private set; }
		public uint HighestUserAddress { get; private set; }
		public uint HyperThreadingFlag { get; private set; }
		public uint MemorySpeed { get; private set; }
		public uint MemSize { get; private set; }
		public uint MHz { get; private set; }
		public uint NumberOfProcessors { get; private set; }
		public byte NxEnabled { get; private set; }
		public byte PaeEnabled { get; private set; }
		public uint PageSize { get; private set; }
		public ushort ProcessorArchitecture { get; private set; }
		public ushort ProcessorLevel { get; private set; }
		public ushort ProcessorRevision { get; private set; }

        public static IEnumerable<SystemConfig_V3_CPU> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SystemConfig_V3_CPU> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SystemConfig_V3_CPU> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SystemConfig_V3_CPU");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SystemConfig_V3_CPU
                {
                     AllocationGranularity = (uint) (managementObject.Properties["AllocationGranularity"]?.Value ?? default(uint)),
		 ComputerName = (char[]) (managementObject.Properties["ComputerName"]?.Value ?? new char[0]),
		 DomainName = (char[]) (managementObject.Properties["DomainName"]?.Value ?? new char[0]),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HighestUserAddress = (uint) (managementObject.Properties["HighestUserAddress"]?.Value ?? default(uint)),
		 HyperThreadingFlag = (uint) (managementObject.Properties["HyperThreadingFlag"]?.Value ?? default(uint)),
		 MemorySpeed = (uint) (managementObject.Properties["MemorySpeed"]?.Value ?? default(uint)),
		 MemSize = (uint) (managementObject.Properties["MemSize"]?.Value ?? default(uint)),
		 MHz = (uint) (managementObject.Properties["MHz"]?.Value ?? default(uint)),
		 NumberOfProcessors = (uint) (managementObject.Properties["NumberOfProcessors"]?.Value ?? default(uint)),
		 NxEnabled = (byte) (managementObject.Properties["NxEnabled"]?.Value ?? default(byte)),
		 PaeEnabled = (byte) (managementObject.Properties["PaeEnabled"]?.Value ?? default(byte)),
		 PageSize = (uint) (managementObject.Properties["PageSize"]?.Value ?? default(uint)),
		 ProcessorArchitecture = (ushort) (managementObject.Properties["ProcessorArchitecture"]?.Value ?? default(ushort)),
		 ProcessorLevel = (ushort) (managementObject.Properties["ProcessorLevel"]?.Value ?? default(ushort)),
		 ProcessorRevision = (ushort) (managementObject.Properties["ProcessorRevision"]?.Value ?? default(ushort))
                };
        }
    }
}