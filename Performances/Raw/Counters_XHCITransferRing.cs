using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_XHCITransferRing
    {
        public uint BytesPerSec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint FailedTransferCount { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IsochTDFailuresPersec { get; private set; }
        public uint IsochTDPersec { get; private set; }
        public uint MissedServiceErrorCount { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TransfersPersec { get; private set; }
        public uint UnderrunOverruncount { get; private set; }

        public static PerfRawData_Counters_XHCITransferRing[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_XHCITransferRing[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_XHCITransferRing[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_XHCITransferRing");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_XHCITransferRing>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_XHCITransferRing
                {
                    BytesPerSec = (uint) managementObject.Properties["BytesPerSec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FailedTransferCount = (uint) managementObject.Properties["FailedTransferCount"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IsochTDFailuresPersec = (uint) managementObject.Properties["IsochTDFailuresPersec"].Value,
                    IsochTDPersec = (uint) managementObject.Properties["IsochTDPersec"].Value,
                    MissedServiceErrorCount = (uint) managementObject.Properties["MissedServiceErrorCount"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransfersPersec = (uint) managementObject.Properties["TransfersPersec"].Value,
                    UnderrunOverruncount = (uint) managementObject.Properties["UnderrunOverruncount"].Value
                });

            return list.ToArray();
        }
    }
}