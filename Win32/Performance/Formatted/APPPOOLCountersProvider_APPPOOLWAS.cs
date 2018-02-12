using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class APPPOOLCountersProvider_APPPOOLWAS
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

        public static IEnumerable<APPPOOLCountersProvider_APPPOOLWAS> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<APPPOOLCountersProvider_APPPOOLWAS> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<APPPOOLCountersProvider_APPPOOLWAS> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_APPPOOLCountersProvider_APPPOOLWAS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new APPPOOLCountersProvider_APPPOOLWAS
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CurrentApplicationPoolState = (uint) (managementObject.Properties["CurrentApplicationPoolState"]?.Value ?? default(uint)),
		 CurrentApplicationPoolUptime = (ulong) (managementObject.Properties["CurrentApplicationPoolUptime"]?.Value ?? default(ulong)),
		 CurrentWorkerProcesses = (uint) (managementObject.Properties["CurrentWorkerProcesses"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MaximumWorkerProcesses = (uint) (managementObject.Properties["MaximumWorkerProcesses"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 RecentWorkerProcessFailures = (uint) (managementObject.Properties["RecentWorkerProcessFailures"]?.Value ?? default(uint)),
		 TimeSinceLastWorkerProcessFailure = (ulong) (managementObject.Properties["TimeSinceLastWorkerProcessFailure"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalApplicationPoolRecycles = (uint) (managementObject.Properties["TotalApplicationPoolRecycles"]?.Value ?? default(uint)),
		 TotalApplicationPoolUptime = (ulong) (managementObject.Properties["TotalApplicationPoolUptime"]?.Value ?? default(ulong)),
		 TotalWorkerProcessesCreated = (uint) (managementObject.Properties["TotalWorkerProcessesCreated"]?.Value ?? default(uint)),
		 TotalWorkerProcessFailures = (uint) (managementObject.Properties["TotalWorkerProcessFailures"]?.Value ?? default(uint)),
		 TotalWorkerProcessPingFailures = (uint) (managementObject.Properties["TotalWorkerProcessPingFailures"]?.Value ?? default(uint)),
		 TotalWorkerProcessShutdownFailures = (uint) (managementObject.Properties["TotalWorkerProcessShutdownFailures"]?.Value ?? default(uint)),
		 TotalWorkerProcessStartupFailures = (uint) (managementObject.Properties["TotalWorkerProcessStartupFailures"]?.Value ?? default(uint))
                };
        }
    }
}