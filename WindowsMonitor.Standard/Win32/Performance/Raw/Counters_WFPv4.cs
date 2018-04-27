using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_WFPv4
    {
		public uint ActiveInboundConnections { get; private set; }
		public uint ActiveOutboundConnections { get; private set; }
		public uint AllowedClassifiesPersec { get; private set; }
		public uint BlockedBinds { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint InboundConnections { get; private set; }
		public uint InboundConnectionsAllowedPersec { get; private set; }
		public uint InboundConnectionsBlockedPersec { get; private set; }
		public uint InboundPacketsDiscardedPersec { get; private set; }
		public string Name { get; private set; }
		public uint OutboundConnections { get; private set; }
		public uint OutboundConnectionsAllowedPersec { get; private set; }
		public uint OutboundConnectionsBlockedPersec { get; private set; }
		public uint OutboundPacketsDiscardedPersec { get; private set; }
		public uint PacketsDiscardedPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_WFPv4> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_WFPv4> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_WFPv4> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_WFPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_WFPv4
                {
                     ActiveInboundConnections = (uint) (managementObject.Properties["ActiveInboundConnections"]?.Value ?? default(uint)),
		 ActiveOutboundConnections = (uint) (managementObject.Properties["ActiveOutboundConnections"]?.Value ?? default(uint)),
		 AllowedClassifiesPersec = (uint) (managementObject.Properties["AllowedClassifiesPersec"]?.Value ?? default(uint)),
		 BlockedBinds = (uint) (managementObject.Properties["BlockedBinds"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InboundConnections = (uint) (managementObject.Properties["InboundConnections"]?.Value ?? default(uint)),
		 InboundConnectionsAllowedPersec = (uint) (managementObject.Properties["InboundConnectionsAllowedPersec"]?.Value ?? default(uint)),
		 InboundConnectionsBlockedPersec = (uint) (managementObject.Properties["InboundConnectionsBlockedPersec"]?.Value ?? default(uint)),
		 InboundPacketsDiscardedPersec = (uint) (managementObject.Properties["InboundPacketsDiscardedPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutboundConnections = (uint) (managementObject.Properties["OutboundConnections"]?.Value ?? default(uint)),
		 OutboundConnectionsAllowedPersec = (uint) (managementObject.Properties["OutboundConnectionsAllowedPersec"]?.Value ?? default(uint)),
		 OutboundConnectionsBlockedPersec = (uint) (managementObject.Properties["OutboundConnectionsBlockedPersec"]?.Value ?? default(uint)),
		 OutboundPacketsDiscardedPersec = (uint) (managementObject.Properties["OutboundPacketsDiscardedPersec"]?.Value ?? default(uint)),
		 PacketsDiscardedPersec = (uint) (managementObject.Properties["PacketsDiscardedPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}