using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport
    {
		public string Caption { get; private set; }
		public ulong CurrentBytesforRecvIO { get; private set; }
		public ulong CurrentBytesforSendIO { get; private set; }
		public ulong CurrentMsgFragsforSendIO { get; private set; }
		public string Description { get; private set; }
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
		public ulong ReceiveIObytesPersec { get; private set; }
		public ulong ReceiveIOLenAvg { get; private set; }
		public uint ReceiveIOLenAvg_Base { get; private set; }
		public ulong ReceiveIPerOsPersec { get; private set; }
		public ulong RecvIOBufferCopiesbytesPersec { get; private set; }
		public ulong RecvIOBufferCopiesCount { get; private set; }
		public ulong SendIObytesPersec { get; private set; }
		public ulong SendIOLenAvg { get; private set; }
		public uint SendIOLenAvg_Base { get; private set; }
		public ulong SendIPerOsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CurrentBytesforRecvIO = (ulong) (managementObject.Properties["CurrentBytesforRecvIO"]?.Value ?? default(ulong)),
		 CurrentBytesforSendIO = (ulong) (managementObject.Properties["CurrentBytesforSendIO"]?.Value ?? default(ulong)),
		 CurrentMsgFragsforSendIO = (ulong) (managementObject.Properties["CurrentMsgFragsforSendIO"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MessageFragmentP10SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP10SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP1SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP1SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP2SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP2SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP3SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP3SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP4SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP4SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP5SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP5SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP6SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP6SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP7SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP7SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP8SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP8SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP9SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP9SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentReceivesPersec = (ulong) (managementObject.Properties["MessageFragmentReceivesPersec"]?.Value ?? default(ulong)),
		 MessageFragmentSendsPersec = (ulong) (managementObject.Properties["MessageFragmentSendsPersec"]?.Value ?? default(ulong)),
		 MsgFragmentRecvSizeAvg = (ulong) (managementObject.Properties["MsgFragmentRecvSizeAvg"]?.Value ?? default(ulong)),
		 MsgFragmentRecvSizeAvg_Base = (uint) (managementObject.Properties["MsgFragmentRecvSizeAvg_Base"]?.Value ?? default(uint)),
		 MsgFragmentSendSizeAvg = (ulong) (managementObject.Properties["MsgFragmentSendSizeAvg"]?.Value ?? default(ulong)),
		 MsgFragmentSendSizeAvg_Base = (uint) (managementObject.Properties["MsgFragmentSendSizeAvg_Base"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OpenConnectionCount = (ulong) (managementObject.Properties["OpenConnectionCount"]?.Value ?? default(ulong)),
		 PendingBytesforRecvIO = (ulong) (managementObject.Properties["PendingBytesforRecvIO"]?.Value ?? default(ulong)),
		 PendingBytesforSendIO = (ulong) (managementObject.Properties["PendingBytesforSendIO"]?.Value ?? default(ulong)),
		 PendingMsgFragsforRecvIO = (ulong) (managementObject.Properties["PendingMsgFragsforRecvIO"]?.Value ?? default(ulong)),
		 PendingMsgFragsforSendIO = (ulong) (managementObject.Properties["PendingMsgFragsforSendIO"]?.Value ?? default(ulong)),
		 ReceiveIObytesPersec = (ulong) (managementObject.Properties["ReceiveIObytesPersec"]?.Value ?? default(ulong)),
		 ReceiveIOLenAvg = (ulong) (managementObject.Properties["ReceiveIOLenAvg"]?.Value ?? default(ulong)),
		 ReceiveIOLenAvg_Base = (uint) (managementObject.Properties["ReceiveIOLenAvg_Base"]?.Value ?? default(uint)),
		 ReceiveIPerOsPersec = (ulong) (managementObject.Properties["ReceiveIPerOsPersec"]?.Value ?? default(ulong)),
		 RecvIOBufferCopiesbytesPersec = (ulong) (managementObject.Properties["RecvIOBufferCopiesbytesPersec"]?.Value ?? default(ulong)),
		 RecvIOBufferCopiesCount = (ulong) (managementObject.Properties["RecvIOBufferCopiesCount"]?.Value ?? default(ulong)),
		 SendIObytesPersec = (ulong) (managementObject.Properties["SendIObytesPersec"]?.Value ?? default(ulong)),
		 SendIOLenAvg = (ulong) (managementObject.Properties["SendIOLenAvg"]?.Value ?? default(ulong)),
		 SendIOLenAvg_Base = (uint) (managementObject.Properties["SendIOLenAvg_Base"]?.Value ?? default(uint)),
		 SendIPerOsPersec = (ulong) (managementObject.Properties["SendIPerOsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}