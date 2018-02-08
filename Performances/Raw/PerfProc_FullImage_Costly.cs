using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfProc_FullImage_Costly
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong ExecReadOnly { get; private set; }
        public ulong ExecReadPerWrite { get; private set; }
        public ulong Executable { get; private set; }
        public ulong ExecWriteCopy { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong NoAccess { get; private set; }
        public ulong ReadOnly { get; private set; }
        public ulong ReadPerWrite { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong WriteCopy { get; private set; }

        public static PerfRawData_PerfProc_FullImage_Costly[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfProc_FullImage_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfProc_FullImage_Costly[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfProc_FullImage_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfProc_FullImage_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfProc_FullImage_Costly
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExecReadOnly = (ulong) managementObject.Properties["ExecReadOnly"].Value,
                    ExecReadPerWrite = (ulong) managementObject.Properties["ExecReadPerWrite"].Value,
                    Executable = (ulong) managementObject.Properties["Executable"].Value,
                    ExecWriteCopy = (ulong) managementObject.Properties["ExecWriteCopy"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NoAccess = (ulong) managementObject.Properties["NoAccess"].Value,
                    ReadOnly = (ulong) managementObject.Properties["ReadOnly"].Value,
                    ReadPerWrite = (ulong) managementObject.Properties["ReadPerWrite"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WriteCopy = (ulong) managementObject.Properties["WriteCopy"].Value
                });

            return list.ToArray();
        }
    }
}