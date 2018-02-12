using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSERVER_SQLServerAvailabilityReplica
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

        public static IEnumerable<MSSQLSERVER_SQLServerAvailabilityReplica> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSERVER_SQLServerAvailabilityReplica> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSERVER_SQLServerAvailabilityReplica> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerAvailabilityReplica");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSERVER_SQLServerAvailabilityReplica
                {
                     BytesReceivedfromReplicaPersec = (ulong) (managementObject.Properties["BytesReceivedfromReplicaPersec"]?.Value ?? default(ulong)),
		 BytesSenttoReplicaPersec = (ulong) (managementObject.Properties["BytesSenttoReplicaPersec"]?.Value ?? default(ulong)),
		 BytesSenttoTransportPersec = (ulong) (managementObject.Properties["BytesSenttoTransportPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FlowControlPersec = (ulong) (managementObject.Properties["FlowControlPersec"]?.Value ?? default(ulong)),
		 FlowControlTimemsPersec = (ulong) (managementObject.Properties["FlowControlTimemsPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ReceivesfromReplicaPersec = (ulong) (managementObject.Properties["ReceivesfromReplicaPersec"]?.Value ?? default(ulong)),
		 ResentMessagesPersec = (ulong) (managementObject.Properties["ResentMessagesPersec"]?.Value ?? default(ulong)),
		 SendstoReplicaPersec = (ulong) (managementObject.Properties["SendstoReplicaPersec"]?.Value ?? default(ulong)),
		 SendstoTransportPersec = (ulong) (managementObject.Properties["SendstoTransportPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}