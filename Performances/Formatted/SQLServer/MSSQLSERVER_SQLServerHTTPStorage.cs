using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage
    {
        public ulong AvgBytesPerRead { get; private set; }
        public ulong AvgBytesPerTransfer { get; private set; }
        public ulong AvgBytesPerWrite { get; private set; }
        public ulong AvgmicrosecPerRead { get; private set; }
        public ulong AvgmicrosecPerReadComp { get; private set; }
        public ulong AvgmicrosecPerTransfer { get; private set; }
        public ulong AvgmicrosecPerWrite { get; private set; }
        public ulong AvgmicrosecPerWriteComp { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong HTTPStorageIOfailedPersec { get; private set; }
        public ulong HTTPStorageIOretryPersec { get; private set; }
        public string Name { get; private set; }
        public ulong OutstandingHTTPStorageIO { get; private set; }
        public ulong ReadBytesPerSec { get; private set; }
        public ulong ReadsPerSec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalBytesPerSec { get; private set; }
        public ulong TransfersPerSec { get; private set; }
        public ulong WriteBytesPerSec { get; private set; }
        public ulong WritesPerSec { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerHTTPStorage
                {
                    AvgBytesPerRead = (ulong) managementObject.Properties["AvgBytesPerRead"].Value,
                    AvgBytesPerTransfer = (ulong) managementObject.Properties["AvgBytesPerTransfer"].Value,
                    AvgBytesPerWrite = (ulong) managementObject.Properties["AvgBytesPerWrite"].Value,
                    AvgmicrosecPerRead = (ulong) managementObject.Properties["AvgmicrosecPerRead"].Value,
                    AvgmicrosecPerReadComp = (ulong) managementObject.Properties["AvgmicrosecPerReadComp"].Value,
                    AvgmicrosecPerTransfer = (ulong) managementObject.Properties["AvgmicrosecPerTransfer"].Value,
                    AvgmicrosecPerWrite = (ulong) managementObject.Properties["AvgmicrosecPerWrite"].Value,
                    AvgmicrosecPerWriteComp = (ulong) managementObject.Properties["AvgmicrosecPerWriteComp"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HTTPStorageIOfailedPersec = (ulong) managementObject.Properties["HTTPStorageIOfailedPersec"].Value,
                    HTTPStorageIOretryPersec = (ulong) managementObject.Properties["HTTPStorageIOretryPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutstandingHTTPStorageIO = (ulong) managementObject.Properties["OutstandingHTTPStorageIO"].Value,
                    ReadBytesPerSec = (ulong) managementObject.Properties["ReadBytesPerSec"].Value,
                    ReadsPerSec = (ulong) managementObject.Properties["ReadsPerSec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalBytesPerSec = (ulong) managementObject.Properties["TotalBytesPerSec"].Value,
                    TransfersPerSec = (ulong) managementObject.Properties["TransfersPerSec"].Value,
                    WriteBytesPerSec = (ulong) managementObject.Properties["WriteBytesPerSec"].Value,
                    WritesPerSec = (ulong) managementObject.Properties["WritesPerSec"].Value
                });

            return list.ToArray();
        }
    }
}