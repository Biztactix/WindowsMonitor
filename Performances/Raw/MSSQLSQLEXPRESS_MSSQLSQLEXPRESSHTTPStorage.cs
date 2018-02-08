using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage
    {
        public ulong AvgBytesPerRead { get; private set; }
        public uint AvgBytesPerRead_Base { get; private set; }
        public ulong AvgBytesPerTransfer { get; private set; }
        public uint AvgBytesPerTransfer_Base { get; private set; }
        public ulong AvgBytesPerWrite { get; private set; }
        public uint AvgBytesPerWrite_Base { get; private set; }
        public ulong AvgmicrosecPerRead { get; private set; }
        public uint AvgmicrosecPerRead_Base { get; private set; }
        public ulong AvgmicrosecPerTransfer { get; private set; }
        public uint AvgmicrosecPerTransfer_Base { get; private set; }
        public ulong AvgmicrosecPerWrite { get; private set; }
        public uint AvgmicrosecPerWrite_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage
                {
                    AvgBytesPerRead = (ulong) managementObject.Properties["AvgBytesPerRead"].Value,
                    AvgBytesPerRead_Base = (uint) managementObject.Properties["AvgBytesPerRead_Base"].Value,
                    AvgBytesPerTransfer = (ulong) managementObject.Properties["AvgBytesPerTransfer"].Value,
                    AvgBytesPerTransfer_Base = (uint) managementObject.Properties["AvgBytesPerTransfer_Base"].Value,
                    AvgBytesPerWrite = (ulong) managementObject.Properties["AvgBytesPerWrite"].Value,
                    AvgBytesPerWrite_Base = (uint) managementObject.Properties["AvgBytesPerWrite_Base"].Value,
                    AvgmicrosecPerRead = (ulong) managementObject.Properties["AvgmicrosecPerRead"].Value,
                    AvgmicrosecPerRead_Base = (uint) managementObject.Properties["AvgmicrosecPerRead_Base"].Value,
                    AvgmicrosecPerTransfer = (ulong) managementObject.Properties["AvgmicrosecPerTransfer"].Value,
                    AvgmicrosecPerTransfer_Base = (uint) managementObject.Properties["AvgmicrosecPerTransfer_Base"]
                        .Value,
                    AvgmicrosecPerWrite = (ulong) managementObject.Properties["AvgmicrosecPerWrite"].Value,
                    AvgmicrosecPerWrite_Base = (uint) managementObject.Properties["AvgmicrosecPerWrite_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
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