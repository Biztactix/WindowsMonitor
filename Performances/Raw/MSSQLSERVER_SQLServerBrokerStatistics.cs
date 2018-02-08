using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics
    {
        public ulong ActivationErrorsTotal { get; private set; }
        public ulong BrokerTransactionRollbacks { get; private set; }
        public string Caption { get; private set; }
        public ulong CorruptedMessagesTotal { get; private set; }
        public ulong DequeuedTransmissionQMsgsPersec { get; private set; }
        public string Description { get; private set; }
        public ulong DialogTimerEventCount { get; private set; }
        public ulong DroppedMessagesTotal { get; private set; }
        public ulong EnqueuedLocalMessagesPersec { get; private set; }
        public ulong EnqueuedLocalMessagesTotal { get; private set; }
        public ulong EnqueuedMessagesPersec { get; private set; }
        public ulong EnqueuedMessagesTotal { get; private set; }
        public ulong EnqueuedP10MessagesPersec { get; private set; }
        public ulong EnqueuedP1MessagesPersec { get; private set; }
        public ulong EnqueuedP2MessagesPersec { get; private set; }
        public ulong EnqueuedP3MessagesPersec { get; private set; }
        public ulong EnqueuedP4MessagesPersec { get; private set; }
        public ulong EnqueuedP5MessagesPersec { get; private set; }
        public ulong EnqueuedP6MessagesPersec { get; private set; }
        public ulong EnqueuedP7MessagesPersec { get; private set; }
        public ulong EnqueuedP8MessagesPersec { get; private set; }
        public ulong EnqueuedP9MessagesPersec { get; private set; }
        public ulong EnqueuedTransmissionQMsgsPersec { get; private set; }
        public ulong EnqueuedTransportMsgFragsPersec { get; private set; }
        public ulong EnqueuedTransportMsgFragTot { get; private set; }
        public ulong EnqueuedTransportMsgsPersec { get; private set; }
        public ulong EnqueuedTransportMsgsTotal { get; private set; }
        public ulong ForwardedMessagesPersec { get; private set; }
        public ulong ForwardedMessagesTotal { get; private set; }
        public ulong ForwardedMsgBytesPersec { get; private set; }
        public ulong ForwardedMsgByteTotal { get; private set; }
        public ulong ForwardedMsgDiscardedTotal { get; private set; }
        public ulong ForwardedMsgsDiscardedPersec { get; private set; }
        public ulong ForwardedPendingMsgBytes { get; private set; }
        public ulong ForwardedPendingMsgCount { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong SQLRECEIVEsPersec { get; private set; }
        public ulong SQLRECEIVETotal { get; private set; }
        public ulong SQLSENDsPersec { get; private set; }
        public ulong SQLSENDTotal { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics[] Retrieve(string remote, string username,
            string password)
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

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerBrokerStatistics
                {
                    ActivationErrorsTotal = (ulong) managementObject.Properties["ActivationErrorsTotal"].Value,
                    BrokerTransactionRollbacks =
                        (ulong) managementObject.Properties["BrokerTransactionRollbacks"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CorruptedMessagesTotal = (ulong) managementObject.Properties["CorruptedMessagesTotal"].Value,
                    DequeuedTransmissionQMsgsPersec =
                        (ulong) managementObject.Properties["DequeuedTransmissionQMsgsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DialogTimerEventCount = (ulong) managementObject.Properties["DialogTimerEventCount"].Value,
                    DroppedMessagesTotal = (ulong) managementObject.Properties["DroppedMessagesTotal"].Value,
                    EnqueuedLocalMessagesPersec = (ulong) managementObject.Properties["EnqueuedLocalMessagesPersec"]
                        .Value,
                    EnqueuedLocalMessagesTotal =
                        (ulong) managementObject.Properties["EnqueuedLocalMessagesTotal"].Value,
                    EnqueuedMessagesPersec = (ulong) managementObject.Properties["EnqueuedMessagesPersec"].Value,
                    EnqueuedMessagesTotal = (ulong) managementObject.Properties["EnqueuedMessagesTotal"].Value,
                    EnqueuedP10MessagesPersec = (ulong) managementObject.Properties["EnqueuedP10MessagesPersec"].Value,
                    EnqueuedP1MessagesPersec = (ulong) managementObject.Properties["EnqueuedP1MessagesPersec"].Value,
                    EnqueuedP2MessagesPersec = (ulong) managementObject.Properties["EnqueuedP2MessagesPersec"].Value,
                    EnqueuedP3MessagesPersec = (ulong) managementObject.Properties["EnqueuedP3MessagesPersec"].Value,
                    EnqueuedP4MessagesPersec = (ulong) managementObject.Properties["EnqueuedP4MessagesPersec"].Value,
                    EnqueuedP5MessagesPersec = (ulong) managementObject.Properties["EnqueuedP5MessagesPersec"].Value,
                    EnqueuedP6MessagesPersec = (ulong) managementObject.Properties["EnqueuedP6MessagesPersec"].Value,
                    EnqueuedP7MessagesPersec = (ulong) managementObject.Properties["EnqueuedP7MessagesPersec"].Value,
                    EnqueuedP8MessagesPersec = (ulong) managementObject.Properties["EnqueuedP8MessagesPersec"].Value,
                    EnqueuedP9MessagesPersec = (ulong) managementObject.Properties["EnqueuedP9MessagesPersec"].Value,
                    EnqueuedTransmissionQMsgsPersec =
                        (ulong) managementObject.Properties["EnqueuedTransmissionQMsgsPersec"].Value,
                    EnqueuedTransportMsgFragsPersec =
                        (ulong) managementObject.Properties["EnqueuedTransportMsgFragsPersec"].Value,
                    EnqueuedTransportMsgFragTot = (ulong) managementObject.Properties["EnqueuedTransportMsgFragTot"]
                        .Value,
                    EnqueuedTransportMsgsPersec = (ulong) managementObject.Properties["EnqueuedTransportMsgsPersec"]
                        .Value,
                    EnqueuedTransportMsgsTotal =
                        (ulong) managementObject.Properties["EnqueuedTransportMsgsTotal"].Value,
                    ForwardedMessagesPersec = (ulong) managementObject.Properties["ForwardedMessagesPersec"].Value,
                    ForwardedMessagesTotal = (ulong) managementObject.Properties["ForwardedMessagesTotal"].Value,
                    ForwardedMsgBytesPersec = (ulong) managementObject.Properties["ForwardedMsgBytesPersec"].Value,
                    ForwardedMsgByteTotal = (ulong) managementObject.Properties["ForwardedMsgByteTotal"].Value,
                    ForwardedMsgDiscardedTotal =
                        (ulong) managementObject.Properties["ForwardedMsgDiscardedTotal"].Value,
                    ForwardedMsgsDiscardedPersec = (ulong) managementObject.Properties["ForwardedMsgsDiscardedPersec"]
                        .Value,
                    ForwardedPendingMsgBytes = (ulong) managementObject.Properties["ForwardedPendingMsgBytes"].Value,
                    ForwardedPendingMsgCount = (ulong) managementObject.Properties["ForwardedPendingMsgCount"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SQLRECEIVEsPersec = (ulong) managementObject.Properties["SQLRECEIVEsPersec"].Value,
                    SQLRECEIVETotal = (ulong) managementObject.Properties["SQLRECEIVETotal"].Value,
                    SQLSENDsPersec = (ulong) managementObject.Properties["SQLSENDsPersec"].Value,
                    SQLSENDTotal = (ulong) managementObject.Properties["SQLSENDTotal"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}