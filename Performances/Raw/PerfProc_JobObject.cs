using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_PerfProc_JobObject
    {
        public string Caption { get; private set; }
        public ulong CurrentPercentKernelModeTime { get; private set; }
        public ulong CurrentPercentProcessorTime { get; private set; }
        public ulong CurrentPercentUserModeTime { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint PagesPerSec { get; private set; }
        public uint ProcessCountActive { get; private set; }
        public uint ProcessCountTerminated { get; private set; }
        public uint ProcessCountTotal { get; private set; }
        public ulong ThisPeriodmSecKernelMode { get; private set; }
        public ulong ThisPeriodmSecProcessor { get; private set; }
        public ulong ThisPeriodmSecUserMode { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TotalmSecKernelMode { get; private set; }
        public ulong TotalmSecProcessor { get; private set; }
        public ulong TotalmSecUserMode { get; private set; }

        public static PerfRawData_PerfProc_JobObject[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_PerfProc_JobObject[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_PerfProc_JobObject[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_PerfProc_JobObject");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_PerfProc_JobObject>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_PerfProc_JobObject
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentPercentKernelModeTime = (ulong) managementObject.Properties["CurrentPercentKernelModeTime"]
                        .Value,
                    CurrentPercentProcessorTime = (ulong) managementObject.Properties["CurrentPercentProcessorTime"]
                        .Value,
                    CurrentPercentUserModeTime =
                        (ulong) managementObject.Properties["CurrentPercentUserModeTime"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PagesPerSec = (uint) managementObject.Properties["PagesPerSec"].Value,
                    ProcessCountActive = (uint) managementObject.Properties["ProcessCountActive"].Value,
                    ProcessCountTerminated = (uint) managementObject.Properties["ProcessCountTerminated"].Value,
                    ProcessCountTotal = (uint) managementObject.Properties["ProcessCountTotal"].Value,
                    ThisPeriodmSecKernelMode = (ulong) managementObject.Properties["ThisPeriodmSecKernelMode"].Value,
                    ThisPeriodmSecProcessor = (ulong) managementObject.Properties["ThisPeriodmSecProcessor"].Value,
                    ThisPeriodmSecUserMode = (ulong) managementObject.Properties["ThisPeriodmSecUserMode"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalmSecKernelMode = (ulong) managementObject.Properties["TotalmSecKernelMode"].Value,
                    TotalmSecProcessor = (ulong) managementObject.Properties["TotalmSecProcessor"].Value,
                    TotalmSecUserMode = (ulong) managementObject.Properties["TotalmSecUserMode"].Value
                });

            return list.ToArray();
        }
    }
}