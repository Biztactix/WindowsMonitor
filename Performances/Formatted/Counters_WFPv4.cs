using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_WFPv4
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

        public static PerfFormattedData_Counters_WFPv4[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Counters_WFPv4[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_WFPv4[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_WFPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_WFPv4>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_WFPv4
                {
                    ActiveInboundConnections = (uint) managementObject.Properties["ActiveInboundConnections"].Value,
                    ActiveOutboundConnections = (uint) managementObject.Properties["ActiveOutboundConnections"].Value,
                    AllowedClassifiesPersec = (uint) managementObject.Properties["AllowedClassifiesPersec"].Value,
                    BlockedBinds = (uint) managementObject.Properties["BlockedBinds"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InboundConnections = (uint) managementObject.Properties["InboundConnections"].Value,
                    InboundConnectionsAllowedPersec =
                        (uint) managementObject.Properties["InboundConnectionsAllowedPersec"].Value,
                    InboundConnectionsBlockedPersec =
                        (uint) managementObject.Properties["InboundConnectionsBlockedPersec"].Value,
                    InboundPacketsDiscardedPersec = (uint) managementObject.Properties["InboundPacketsDiscardedPersec"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutboundConnections = (uint) managementObject.Properties["OutboundConnections"].Value,
                    OutboundConnectionsAllowedPersec =
                        (uint) managementObject.Properties["OutboundConnectionsAllowedPersec"].Value,
                    OutboundConnectionsBlockedPersec =
                        (uint) managementObject.Properties["OutboundConnectionsBlockedPersec"].Value,
                    OutboundPacketsDiscardedPersec =
                        (uint) managementObject.Properties["OutboundPacketsDiscardedPersec"].Value,
                    PacketsDiscardedPersec = (uint) managementObject.Properties["PacketsDiscardedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}