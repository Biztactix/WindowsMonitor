using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS
    {
        public string Caption { get; private set; }
        public uint CurrentApplicationPoolState { get; private set; }
        public ulong CurrentApplicationPoolUptime { get; private set; }
        public uint CurrentWorkerProcesses { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MaximumWorkerProcesses { get; private set; }
        public string Name { get; private set; }
        public uint RecentWorkerProcessFailures { get; private set; }
        public ulong TimeSinceLastWorkerProcessFailure { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalApplicationPoolRecycles { get; private set; }
        public ulong TotalApplicationPoolUptime { get; private set; }
        public uint TotalWorkerProcessesCreated { get; private set; }
        public uint TotalWorkerProcessFailures { get; private set; }
        public uint TotalWorkerProcessPingFailures { get; private set; }
        public uint TotalWorkerProcessShutdownFailures { get; private set; }
        public uint TotalWorkerProcessStartupFailures { get; private set; }

        public static PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentApplicationPoolState = (uint) managementObject.Properties["CurrentApplicationPoolState"]
                        .Value,
                    CurrentApplicationPoolUptime = (ulong) managementObject.Properties["CurrentApplicationPoolUptime"]
                        .Value,
                    CurrentWorkerProcesses = (uint) managementObject.Properties["CurrentWorkerProcesses"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaximumWorkerProcesses = (uint) managementObject.Properties["MaximumWorkerProcesses"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RecentWorkerProcessFailures = (uint) managementObject.Properties["RecentWorkerProcessFailures"]
                        .Value,
                    TimeSinceLastWorkerProcessFailure =
                        (ulong) managementObject.Properties["TimeSinceLastWorkerProcessFailure"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalApplicationPoolRecycles = (uint) managementObject.Properties["TotalApplicationPoolRecycles"]
                        .Value,
                    TotalApplicationPoolUptime =
                        (ulong) managementObject.Properties["TotalApplicationPoolUptime"].Value,
                    TotalWorkerProcessesCreated = (uint) managementObject.Properties["TotalWorkerProcessesCreated"]
                        .Value,
                    TotalWorkerProcessFailures = (uint) managementObject.Properties["TotalWorkerProcessFailures"].Value,
                    TotalWorkerProcessPingFailures =
                        (uint) managementObject.Properties["TotalWorkerProcessPingFailures"].Value,
                    TotalWorkerProcessShutdownFailures =
                        (uint) managementObject.Properties["TotalWorkerProcessShutdownFailures"].Value,
                    TotalWorkerProcessStartupFailures =
                        (uint) managementObject.Properties["TotalWorkerProcessStartupFailures"].Value
                });

            return list.ToArray();
        }
    }
}