using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlExpressHTTPStorage
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

        public static IEnumerable<SqlExpressHTTPStorage> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlExpressHTTPStorage> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressHTTPStorage> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSHTTPStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlExpressHTTPStorage
                {
                     AvgBytesPerRead = (ulong) (managementObject.Properties["AvgBytesPerRead"]?.Value ?? default(ulong)),
		 AvgBytesPerRead_Base = (uint) (managementObject.Properties["AvgBytesPerRead_Base"]?.Value ?? default(uint)),
		 AvgBytesPerTransfer = (ulong) (managementObject.Properties["AvgBytesPerTransfer"]?.Value ?? default(ulong)),
		 AvgBytesPerTransfer_Base = (uint) (managementObject.Properties["AvgBytesPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgBytesPerWrite = (ulong) (managementObject.Properties["AvgBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgBytesPerWrite_Base = (uint) (managementObject.Properties["AvgBytesPerWrite_Base"]?.Value ?? default(uint)),
		 AvgmicrosecPerRead = (ulong) (managementObject.Properties["AvgmicrosecPerRead"]?.Value ?? default(ulong)),
		 AvgmicrosecPerRead_Base = (uint) (managementObject.Properties["AvgmicrosecPerRead_Base"]?.Value ?? default(uint)),
		 AvgmicrosecPerTransfer = (ulong) (managementObject.Properties["AvgmicrosecPerTransfer"]?.Value ?? default(ulong)),
		 AvgmicrosecPerTransfer_Base = (uint) (managementObject.Properties["AvgmicrosecPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgmicrosecPerWrite = (ulong) (managementObject.Properties["AvgmicrosecPerWrite"]?.Value ?? default(ulong)),
		 AvgmicrosecPerWrite_Base = (uint) (managementObject.Properties["AvgmicrosecPerWrite_Base"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HTTPStorageIOretryPersec = (ulong) (managementObject.Properties["HTTPStorageIOretryPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OutstandingHTTPStorageIO = (ulong) (managementObject.Properties["OutstandingHTTPStorageIO"]?.Value ?? default(ulong)),
		 ReadBytesPerSec = (ulong) (managementObject.Properties["ReadBytesPerSec"]?.Value ?? default(ulong)),
		 ReadsPerSec = (ulong) (managementObject.Properties["ReadsPerSec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalBytesPerSec = (ulong) (managementObject.Properties["TotalBytesPerSec"]?.Value ?? default(ulong)),
		 TransfersPerSec = (ulong) (managementObject.Properties["TransfersPerSec"]?.Value ?? default(ulong)),
		 WriteBytesPerSec = (ulong) (managementObject.Properties["WriteBytesPerSec"]?.Value ?? default(ulong)),
		 WritesPerSec = (ulong) (managementObject.Properties["WritesPerSec"]?.Value ?? default(ulong))
                };
        }
    }
}