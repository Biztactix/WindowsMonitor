using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_SMBServer
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong ReadBytesPersec { get; private set; }
        public ulong ReadRequestsPersec { get; private set; }
        public ulong ReceiveBytesPersec { get; private set; }
        public ulong SendBytesPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong WriteBytesPersec { get; private set; }
        public ulong WriteRequestsPersec { get; private set; }

        public static PerfRawData_Counters_SMBServer[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_SMBServer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_SMBServer[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_SMBServer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_SMBServer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_SMBServer
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReadBytesPersec = (ulong) managementObject.Properties["ReadBytesPersec"].Value,
                    ReadRequestsPersec = (ulong) managementObject.Properties["ReadRequestsPersec"].Value,
                    ReceiveBytesPersec = (ulong) managementObject.Properties["ReceiveBytesPersec"].Value,
                    SendBytesPersec = (ulong) managementObject.Properties["SendBytesPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WriteBytesPersec = (ulong) managementObject.Properties["WriteBytesPersec"].Value,
                    WriteRequestsPersec = (ulong) managementObject.Properties["WriteRequestsPersec"].Value
                });

            return list.ToArray();
        }
    }
}