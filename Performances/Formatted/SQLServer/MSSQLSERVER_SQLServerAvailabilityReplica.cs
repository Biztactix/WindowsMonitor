using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica
    {
        public ulong BytesReceivedfromReplicaPersec { get; private set; }
        public ulong BytesSenttoReplicaPersec { get; private set; }
        public ulong BytesSenttoTransportPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong FlowControlPersec { get; private set; }
        public ulong FlowControlTimemsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong ReceivesfromReplicaPersec { get; private set; }
        public ulong ResentMessagesPersec { get; private set; }
        public ulong SendstoReplicaPersec { get; private set; }
        public ulong SendstoTransportPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerAvailabilityReplica
                {
                    BytesReceivedfromReplicaPersec =
                        (ulong) managementObject.Properties["BytesReceivedfromReplicaPersec"].Value,
                    BytesSenttoReplicaPersec = (ulong) managementObject.Properties["BytesSenttoReplicaPersec"].Value,
                    BytesSenttoTransportPersec =
                        (ulong) managementObject.Properties["BytesSenttoTransportPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FlowControlPersec = (ulong) managementObject.Properties["FlowControlPersec"].Value,
                    FlowControlTimemsPersec = (ulong) managementObject.Properties["FlowControlTimemsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReceivesfromReplicaPersec = (ulong) managementObject.Properties["ReceivesfromReplicaPersec"].Value,
                    ResentMessagesPersec = (ulong) managementObject.Properties["ResentMessagesPersec"].Value,
                    SendstoReplicaPersec = (ulong) managementObject.Properties["SendstoReplicaPersec"].Value,
                    SendstoTransportPersec = (ulong) managementObject.Properties["SendstoTransportPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}