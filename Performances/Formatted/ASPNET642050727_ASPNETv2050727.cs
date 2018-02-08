using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_ASPNET642050727_ASPNETv2050727
    {
        public uint ApplicationRestarts { get; private set; }
        public uint ApplicationsRunning { get; private set; }
        public uint AuditFailureEventsRaised { get; private set; }
        public uint AuditSuccessEventsRaised { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint ErrorEventsRaised { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InfrastructureErrorEventsRaised { get; private set; }
        public string Name { get; private set; }
        public uint RequestErrorEventsRaised { get; private set; }
        public uint RequestExecutionTime { get; private set; }
        public uint RequestsCurrent { get; private set; }
        public uint RequestsDisconnected { get; private set; }
        public uint RequestsQueued { get; private set; }
        public uint RequestsRejected { get; private set; }
        public uint RequestWaitTime { get; private set; }
        public uint StateServerSessionsAbandoned { get; private set; }
        public uint StateServerSessionsActive { get; private set; }
        public uint StateServerSessionsTimedOut { get; private set; }
        public uint StateServerSessionsTotal { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint WorkerProcessesRunning { get; private set; }
        public uint WorkerProcessRestarts { get; private set; }

        public static PerfFormattedData_ASPNET642050727_ASPNETv2050727[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_ASPNET642050727_ASPNETv2050727[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_ASPNET642050727_ASPNETv2050727[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ASPNET642050727_ASPNETv2050727");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_ASPNET642050727_ASPNETv2050727>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_ASPNET642050727_ASPNETv2050727
                {
                    ApplicationRestarts = (uint) managementObject.Properties["ApplicationRestarts"].Value,
                    ApplicationsRunning = (uint) managementObject.Properties["ApplicationsRunning"].Value,
                    AuditFailureEventsRaised = (uint) managementObject.Properties["AuditFailureEventsRaised"].Value,
                    AuditSuccessEventsRaised = (uint) managementObject.Properties["AuditSuccessEventsRaised"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ErrorEventsRaised = (uint) managementObject.Properties["ErrorEventsRaised"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InfrastructureErrorEventsRaised =
                        (uint) managementObject.Properties["InfrastructureErrorEventsRaised"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RequestErrorEventsRaised = (uint) managementObject.Properties["RequestErrorEventsRaised"].Value,
                    RequestExecutionTime = (uint) managementObject.Properties["RequestExecutionTime"].Value,
                    RequestsCurrent = (uint) managementObject.Properties["RequestsCurrent"].Value,
                    RequestsDisconnected = (uint) managementObject.Properties["RequestsDisconnected"].Value,
                    RequestsQueued = (uint) managementObject.Properties["RequestsQueued"].Value,
                    RequestsRejected = (uint) managementObject.Properties["RequestsRejected"].Value,
                    RequestWaitTime = (uint) managementObject.Properties["RequestWaitTime"].Value,
                    StateServerSessionsAbandoned = (uint) managementObject.Properties["StateServerSessionsAbandoned"]
                        .Value,
                    StateServerSessionsActive = (uint) managementObject.Properties["StateServerSessionsActive"].Value,
                    StateServerSessionsTimedOut = (uint) managementObject.Properties["StateServerSessionsTimedOut"]
                        .Value,
                    StateServerSessionsTotal = (uint) managementObject.Properties["StateServerSessionsTotal"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WorkerProcessesRunning = (uint) managementObject.Properties["WorkerProcessesRunning"].Value,
                    WorkerProcessRestarts = (uint) managementObject.Properties["WorkerProcessRestarts"].Value
                });

            return list.ToArray();
        }
    }
}