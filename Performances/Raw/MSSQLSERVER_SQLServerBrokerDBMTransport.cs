using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport
    {
        public string Caption { get; private set; }
        public ulong CurrentBytesforRecvIO { get; private set; }
        public ulong CurrentBytesforSendIO { get; private set; }
        public ulong CurrentMsgFragsforSendIO { get; private set; }
        public ulong DecryptedIObytesPersec { get; private set; }
        public ulong DecryptionIPerOsPersec { get; private set; }
        public string Description { get; private set; }
        public ulong EncryptedIObytesPersec { get; private set; }
        public ulong EncryptionIPerOsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong MessageFragmentP10SendsPersec { get; private set; }
        public ulong MessageFragmentP1SendsPersec { get; private set; }
        public ulong MessageFragmentP2SendsPersec { get; private set; }
        public ulong MessageFragmentP3SendsPersec { get; private set; }
        public ulong MessageFragmentP4SendsPersec { get; private set; }
        public ulong MessageFragmentP5SendsPersec { get; private set; }
        public ulong MessageFragmentP6SendsPersec { get; private set; }
        public ulong MessageFragmentP7SendsPersec { get; private set; }
        public ulong MessageFragmentP8SendsPersec { get; private set; }
        public ulong MessageFragmentP9SendsPersec { get; private set; }
        public ulong MessageFragmentReceivesPersec { get; private set; }
        public ulong MessageFragmentSendsPersec { get; private set; }
        public ulong MsgFragmentRecvSizeAvg { get; private set; }
        public uint MsgFragmentRecvSizeAvg_Base { get; private set; }
        public ulong MsgFragmentSendSizeAvg { get; private set; }
        public uint MsgFragmentSendSizeAvg_Base { get; private set; }
        public string Name { get; private set; }
        public ulong OpenConnectionCount { get; private set; }
        public ulong PendingBytesforRecvIO { get; private set; }
        public ulong PendingBytesforSendIO { get; private set; }
        public ulong PendingMsgFragsforRecvIO { get; private set; }
        public ulong PendingMsgFragsforSendIO { get; private set; }
        public ulong ReceiveFlowControlEntersPersec { get; private set; }
        public ulong ReceiveFlowControlExitsPersec { get; private set; }
        public ulong ReceiveFlowControlGate { get; private set; }
        public ulong ReceiveIObytesPersec { get; private set; }
        public ulong ReceiveIOLenAvg { get; private set; }
        public uint ReceiveIOLenAvg_Base { get; private set; }
        public ulong ReceiveIPerOsPersec { get; private set; }
        public ulong RecvIOBufferCopiesbytesPersec { get; private set; }
        public ulong RecvIOBufferCopiesCount { get; private set; }
        public ulong SendFlowControlEntersPersec { get; private set; }
        public ulong SendFlowControlExitsPersec { get; private set; }
        public ulong SendFlowControlGate { get; private set; }
        public ulong SendIObytesPersec { get; private set; }
        public ulong SendIOLenAvg { get; private set; }
        public uint SendIOLenAvg_Base { get; private set; }
        public ulong SendIPerOsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerBrokerDBMTransport
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentBytesforRecvIO = (ulong) managementObject.Properties["CurrentBytesforRecvIO"].Value,
                    CurrentBytesforSendIO = (ulong) managementObject.Properties["CurrentBytesforSendIO"].Value,
                    CurrentMsgFragsforSendIO = (ulong) managementObject.Properties["CurrentMsgFragsforSendIO"].Value,
                    DecryptedIObytesPersec = (ulong) managementObject.Properties["DecryptedIObytesPersec"].Value,
                    DecryptionIPerOsPersec = (ulong) managementObject.Properties["DecryptionIPerOsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EncryptedIObytesPersec = (ulong) managementObject.Properties["EncryptedIObytesPersec"].Value,
                    EncryptionIPerOsPersec = (ulong) managementObject.Properties["EncryptionIPerOsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MessageFragmentP10SendsPersec =
                        (ulong) managementObject.Properties["MessageFragmentP10SendsPersec"].Value,
                    MessageFragmentP1SendsPersec = (ulong) managementObject.Properties["MessageFragmentP1SendsPersec"]
                        .Value,
                    MessageFragmentP2SendsPersec = (ulong) managementObject.Properties["MessageFragmentP2SendsPersec"]
                        .Value,
                    MessageFragmentP3SendsPersec = (ulong) managementObject.Properties["MessageFragmentP3SendsPersec"]
                        .Value,
                    MessageFragmentP4SendsPersec = (ulong) managementObject.Properties["MessageFragmentP4SendsPersec"]
                        .Value,
                    MessageFragmentP5SendsPersec = (ulong) managementObject.Properties["MessageFragmentP5SendsPersec"]
                        .Value,
                    MessageFragmentP6SendsPersec = (ulong) managementObject.Properties["MessageFragmentP6SendsPersec"]
                        .Value,
                    MessageFragmentP7SendsPersec = (ulong) managementObject.Properties["MessageFragmentP7SendsPersec"]
                        .Value,
                    MessageFragmentP8SendsPersec = (ulong) managementObject.Properties["MessageFragmentP8SendsPersec"]
                        .Value,
                    MessageFragmentP9SendsPersec = (ulong) managementObject.Properties["MessageFragmentP9SendsPersec"]
                        .Value,
                    MessageFragmentReceivesPersec =
                        (ulong) managementObject.Properties["MessageFragmentReceivesPersec"].Value,
                    MessageFragmentSendsPersec =
                        (ulong) managementObject.Properties["MessageFragmentSendsPersec"].Value,
                    MsgFragmentRecvSizeAvg = (ulong) managementObject.Properties["MsgFragmentRecvSizeAvg"].Value,
                    MsgFragmentRecvSizeAvg_Base = (uint) managementObject.Properties["MsgFragmentRecvSizeAvg_Base"]
                        .Value,
                    MsgFragmentSendSizeAvg = (ulong) managementObject.Properties["MsgFragmentSendSizeAvg"].Value,
                    MsgFragmentSendSizeAvg_Base = (uint) managementObject.Properties["MsgFragmentSendSizeAvg_Base"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OpenConnectionCount = (ulong) managementObject.Properties["OpenConnectionCount"].Value,
                    PendingBytesforRecvIO = (ulong) managementObject.Properties["PendingBytesforRecvIO"].Value,
                    PendingBytesforSendIO = (ulong) managementObject.Properties["PendingBytesforSendIO"].Value,
                    PendingMsgFragsforRecvIO = (ulong) managementObject.Properties["PendingMsgFragsforRecvIO"].Value,
                    PendingMsgFragsforSendIO = (ulong) managementObject.Properties["PendingMsgFragsforSendIO"].Value,
                    ReceiveFlowControlEntersPersec =
                        (ulong) managementObject.Properties["ReceiveFlowControlEntersPersec"].Value,
                    ReceiveFlowControlExitsPersec =
                        (ulong) managementObject.Properties["ReceiveFlowControlExitsPersec"].Value,
                    ReceiveFlowControlGate = (ulong) managementObject.Properties["ReceiveFlowControlGate"].Value,
                    ReceiveIObytesPersec = (ulong) managementObject.Properties["ReceiveIObytesPersec"].Value,
                    ReceiveIOLenAvg = (ulong) managementObject.Properties["ReceiveIOLenAvg"].Value,
                    ReceiveIOLenAvg_Base = (uint) managementObject.Properties["ReceiveIOLenAvg_Base"].Value,
                    ReceiveIPerOsPersec = (ulong) managementObject.Properties["ReceiveIPerOsPersec"].Value,
                    RecvIOBufferCopiesbytesPersec =
                        (ulong) managementObject.Properties["RecvIOBufferCopiesbytesPersec"].Value,
                    RecvIOBufferCopiesCount = (ulong) managementObject.Properties["RecvIOBufferCopiesCount"].Value,
                    SendFlowControlEntersPersec = (ulong) managementObject.Properties["SendFlowControlEntersPersec"]
                        .Value,
                    SendFlowControlExitsPersec =
                        (ulong) managementObject.Properties["SendFlowControlExitsPersec"].Value,
                    SendFlowControlGate = (ulong) managementObject.Properties["SendFlowControlGate"].Value,
                    SendIObytesPersec = (ulong) managementObject.Properties["SendIObytesPersec"].Value,
                    SendIOLenAvg = (ulong) managementObject.Properties["SendIOLenAvg"].Value,
                    SendIOLenAvg_Base = (uint) managementObject.Properties["SendIOLenAvg_Base"].Value,
                    SendIPerOsPersec = (ulong) managementObject.Properties["SendIPerOsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}