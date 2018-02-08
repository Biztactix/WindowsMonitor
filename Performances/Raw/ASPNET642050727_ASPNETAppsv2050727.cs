using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_ASPNET642050727_ASPNETAppsv2050727
    {
        public uint AnonymousRequests { get; private set; }
        public uint AnonymousRequestsPerSec { get; private set; }
        public uint ApplicationLifetimeEvents { get; private set; }
        public uint ApplicationLifetimeEventsPerSec { get; private set; }
        public uint AuditFailureEventsRaised { get; private set; }
        public uint AuditSuccessEventsRaised { get; private set; }
        public uint CacheAPIEntries { get; private set; }
        public uint CacheAPIHitRatio { get; private set; }
        public uint CacheAPIHitRatio_Base { get; private set; }
        public uint CacheAPIHits { get; private set; }
        public uint CacheAPIMisses { get; private set; }
        public uint CacheAPITrims { get; private set; }
        public uint CacheAPITurnoverRate { get; private set; }
        public uint CachePercentMachineMemoryLimitUsed { get; private set; }
        public uint CachePercentMachineMemoryLimitUsed_Base { get; private set; }
        public uint CachePercentProcessMemoryLimitUsed { get; private set; }
        public uint CachePercentProcessMemoryLimitUsed_Base { get; private set; }
        public uint CacheTotalEntries { get; private set; }
        public uint CacheTotalHitRatio { get; private set; }
        public uint CacheTotalHitRatio_Base { get; private set; }
        public uint CacheTotalHits { get; private set; }
        public uint CacheTotalMisses { get; private set; }
        public uint CacheTotalTrims { get; private set; }
        public uint CacheTotalTurnoverRate { get; private set; }
        public string Caption { get; private set; }
        public uint CompilationsTotal { get; private set; }
        public uint DebuggingRequests { get; private set; }
        public string Description { get; private set; }
        public uint ErrorEventsRaised { get; private set; }
        public uint ErrorEventsRaisedPerSec { get; private set; }
        public uint ErrorsDuringCompilation { get; private set; }
        public uint ErrorsDuringExecution { get; private set; }
        public uint ErrorsDuringPreprocessing { get; private set; }
        public uint ErrorsTotal { get; private set; }
        public uint ErrorsTotalPerSec { get; private set; }
        public uint ErrorsUnhandledDuringExecution { get; private set; }
        public uint ErrorsUnhandledDuringExecutionPerSec { get; private set; }
        public uint EventsRaised { get; private set; }
        public uint EventsRaisedPerSec { get; private set; }
        public uint FormsAuthenticationFailure { get; private set; }
        public uint FormsAuthenticationSuccess { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint InfrastructureErrorEventsRaised { get; private set; }
        public uint InfrastructureErrorEventsRaisedPerSec { get; private set; }
        public uint MembershipAuthenticationFailure { get; private set; }
        public uint MembershipAuthenticationSuccess { get; private set; }
        public string Name { get; private set; }
        public uint OutputCacheEntries { get; private set; }
        public uint OutputCacheHitRatio { get; private set; }
        public uint OutputCacheHitRatio_Base { get; private set; }
        public uint OutputCacheHits { get; private set; }
        public uint OutputCacheMisses { get; private set; }
        public uint OutputCacheTrims { get; private set; }
        public uint OutputCacheTurnoverRate { get; private set; }
        public uint PipelineInstanceCount { get; private set; }
        public uint RequestBytesInTotal { get; private set; }
        public uint RequestBytesOutTotal { get; private set; }
        public uint RequestErrorEventsRaised { get; private set; }
        public uint RequestErrorEventsRaisedPerSec { get; private set; }
        public uint RequestEventsRaised { get; private set; }
        public uint RequestEventsRaisedPerSec { get; private set; }
        public uint RequestExecutionTime { get; private set; }
        public uint RequestsDisconnected { get; private set; }
        public uint RequestsExecuting { get; private set; }
        public uint RequestsFailed { get; private set; }
        public uint RequestsInApplicationQueue { get; private set; }
        public uint RequestsNotAuthorized { get; private set; }
        public uint RequestsNotFound { get; private set; }
        public uint RequestsPerSec { get; private set; }
        public uint RequestsRejected { get; private set; }
        public uint RequestsSucceeded { get; private set; }
        public uint RequestsTimedOut { get; private set; }
        public uint RequestsTotal { get; private set; }
        public uint RequestWaitTime { get; private set; }
        public uint SessionsAbandoned { get; private set; }
        public uint SessionsActive { get; private set; }
        public uint SessionSQLServerconnectionstotal { get; private set; }
        public uint SessionStateServerconnectionstotal { get; private set; }
        public uint SessionsTimedOut { get; private set; }
        public uint SessionsTotal { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TransactionsAborted { get; private set; }
        public uint TransactionsCommitted { get; private set; }
        public uint TransactionsPending { get; private set; }
        public uint TransactionsPerSec { get; private set; }
        public uint TransactionsTotal { get; private set; }
        public uint ViewstateMACValidationFailure { get; private set; }

        public static PerfRawData_ASPNET642050727_ASPNETAppsv2050727[] Retrieve(string remote, string username,
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

        public static PerfRawData_ASPNET642050727_ASPNETAppsv2050727[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_ASPNET642050727_ASPNETAppsv2050727[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ASPNET642050727_ASPNETAppsv2050727");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_ASPNET642050727_ASPNETAppsv2050727>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_ASPNET642050727_ASPNETAppsv2050727
                {
                    AnonymousRequests = (uint) managementObject.Properties["AnonymousRequests"].Value,
                    AnonymousRequestsPerSec = (uint) managementObject.Properties["AnonymousRequestsPerSec"].Value,
                    ApplicationLifetimeEvents = (uint) managementObject.Properties["ApplicationLifetimeEvents"].Value,
                    ApplicationLifetimeEventsPerSec =
                        (uint) managementObject.Properties["ApplicationLifetimeEventsPerSec"].Value,
                    AuditFailureEventsRaised = (uint) managementObject.Properties["AuditFailureEventsRaised"].Value,
                    AuditSuccessEventsRaised = (uint) managementObject.Properties["AuditSuccessEventsRaised"].Value,
                    CacheAPIEntries = (uint) managementObject.Properties["CacheAPIEntries"].Value,
                    CacheAPIHitRatio = (uint) managementObject.Properties["CacheAPIHitRatio"].Value,
                    CacheAPIHitRatio_Base = (uint) managementObject.Properties["CacheAPIHitRatio_Base"].Value,
                    CacheAPIHits = (uint) managementObject.Properties["CacheAPIHits"].Value,
                    CacheAPIMisses = (uint) managementObject.Properties["CacheAPIMisses"].Value,
                    CacheAPITrims = (uint) managementObject.Properties["CacheAPITrims"].Value,
                    CacheAPITurnoverRate = (uint) managementObject.Properties["CacheAPITurnoverRate"].Value,
                    CachePercentMachineMemoryLimitUsed =
                        (uint) managementObject.Properties["CachePercentMachineMemoryLimitUsed"].Value,
                    CachePercentMachineMemoryLimitUsed_Base = (uint) managementObject
                        .Properties["CachePercentMachineMemoryLimitUsed_Base"].Value,
                    CachePercentProcessMemoryLimitUsed =
                        (uint) managementObject.Properties["CachePercentProcessMemoryLimitUsed"].Value,
                    CachePercentProcessMemoryLimitUsed_Base = (uint) managementObject
                        .Properties["CachePercentProcessMemoryLimitUsed_Base"].Value,
                    CacheTotalEntries = (uint) managementObject.Properties["CacheTotalEntries"].Value,
                    CacheTotalHitRatio = (uint) managementObject.Properties["CacheTotalHitRatio"].Value,
                    CacheTotalHitRatio_Base = (uint) managementObject.Properties["CacheTotalHitRatio_Base"].Value,
                    CacheTotalHits = (uint) managementObject.Properties["CacheTotalHits"].Value,
                    CacheTotalMisses = (uint) managementObject.Properties["CacheTotalMisses"].Value,
                    CacheTotalTrims = (uint) managementObject.Properties["CacheTotalTrims"].Value,
                    CacheTotalTurnoverRate = (uint) managementObject.Properties["CacheTotalTurnoverRate"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CompilationsTotal = (uint) managementObject.Properties["CompilationsTotal"].Value,
                    DebuggingRequests = (uint) managementObject.Properties["DebuggingRequests"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ErrorEventsRaised = (uint) managementObject.Properties["ErrorEventsRaised"].Value,
                    ErrorEventsRaisedPerSec = (uint) managementObject.Properties["ErrorEventsRaisedPerSec"].Value,
                    ErrorsDuringCompilation = (uint) managementObject.Properties["ErrorsDuringCompilation"].Value,
                    ErrorsDuringExecution = (uint) managementObject.Properties["ErrorsDuringExecution"].Value,
                    ErrorsDuringPreprocessing = (uint) managementObject.Properties["ErrorsDuringPreprocessing"].Value,
                    ErrorsTotal = (uint) managementObject.Properties["ErrorsTotal"].Value,
                    ErrorsTotalPerSec = (uint) managementObject.Properties["ErrorsTotalPerSec"].Value,
                    ErrorsUnhandledDuringExecution =
                        (uint) managementObject.Properties["ErrorsUnhandledDuringExecution"].Value,
                    ErrorsUnhandledDuringExecutionPerSec = (uint) managementObject
                        .Properties["ErrorsUnhandledDuringExecutionPerSec"].Value,
                    EventsRaised = (uint) managementObject.Properties["EventsRaised"].Value,
                    EventsRaisedPerSec = (uint) managementObject.Properties["EventsRaisedPerSec"].Value,
                    FormsAuthenticationFailure = (uint) managementObject.Properties["FormsAuthenticationFailure"].Value,
                    FormsAuthenticationSuccess = (uint) managementObject.Properties["FormsAuthenticationSuccess"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InfrastructureErrorEventsRaised =
                        (uint) managementObject.Properties["InfrastructureErrorEventsRaised"].Value,
                    InfrastructureErrorEventsRaisedPerSec = (uint) managementObject
                        .Properties["InfrastructureErrorEventsRaisedPerSec"].Value,
                    MembershipAuthenticationFailure =
                        (uint) managementObject.Properties["MembershipAuthenticationFailure"].Value,
                    MembershipAuthenticationSuccess =
                        (uint) managementObject.Properties["MembershipAuthenticationSuccess"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutputCacheEntries = (uint) managementObject.Properties["OutputCacheEntries"].Value,
                    OutputCacheHitRatio = (uint) managementObject.Properties["OutputCacheHitRatio"].Value,
                    OutputCacheHitRatio_Base = (uint) managementObject.Properties["OutputCacheHitRatio_Base"].Value,
                    OutputCacheHits = (uint) managementObject.Properties["OutputCacheHits"].Value,
                    OutputCacheMisses = (uint) managementObject.Properties["OutputCacheMisses"].Value,
                    OutputCacheTrims = (uint) managementObject.Properties["OutputCacheTrims"].Value,
                    OutputCacheTurnoverRate = (uint) managementObject.Properties["OutputCacheTurnoverRate"].Value,
                    PipelineInstanceCount = (uint) managementObject.Properties["PipelineInstanceCount"].Value,
                    RequestBytesInTotal = (uint) managementObject.Properties["RequestBytesInTotal"].Value,
                    RequestBytesOutTotal = (uint) managementObject.Properties["RequestBytesOutTotal"].Value,
                    RequestErrorEventsRaised = (uint) managementObject.Properties["RequestErrorEventsRaised"].Value,
                    RequestErrorEventsRaisedPerSec =
                        (uint) managementObject.Properties["RequestErrorEventsRaisedPerSec"].Value,
                    RequestEventsRaised = (uint) managementObject.Properties["RequestEventsRaised"].Value,
                    RequestEventsRaisedPerSec = (uint) managementObject.Properties["RequestEventsRaisedPerSec"].Value,
                    RequestExecutionTime = (uint) managementObject.Properties["RequestExecutionTime"].Value,
                    RequestsDisconnected = (uint) managementObject.Properties["RequestsDisconnected"].Value,
                    RequestsExecuting = (uint) managementObject.Properties["RequestsExecuting"].Value,
                    RequestsFailed = (uint) managementObject.Properties["RequestsFailed"].Value,
                    RequestsInApplicationQueue = (uint) managementObject.Properties["RequestsInApplicationQueue"].Value,
                    RequestsNotAuthorized = (uint) managementObject.Properties["RequestsNotAuthorized"].Value,
                    RequestsNotFound = (uint) managementObject.Properties["RequestsNotFound"].Value,
                    RequestsPerSec = (uint) managementObject.Properties["RequestsPerSec"].Value,
                    RequestsRejected = (uint) managementObject.Properties["RequestsRejected"].Value,
                    RequestsSucceeded = (uint) managementObject.Properties["RequestsSucceeded"].Value,
                    RequestsTimedOut = (uint) managementObject.Properties["RequestsTimedOut"].Value,
                    RequestsTotal = (uint) managementObject.Properties["RequestsTotal"].Value,
                    RequestWaitTime = (uint) managementObject.Properties["RequestWaitTime"].Value,
                    SessionsAbandoned = (uint) managementObject.Properties["SessionsAbandoned"].Value,
                    SessionsActive = (uint) managementObject.Properties["SessionsActive"].Value,
                    SessionSQLServerconnectionstotal =
                        (uint) managementObject.Properties["SessionSQLServerconnectionstotal"].Value,
                    SessionStateServerconnectionstotal =
                        (uint) managementObject.Properties["SessionStateServerconnectionstotal"].Value,
                    SessionsTimedOut = (uint) managementObject.Properties["SessionsTimedOut"].Value,
                    SessionsTotal = (uint) managementObject.Properties["SessionsTotal"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionsAborted = (uint) managementObject.Properties["TransactionsAborted"].Value,
                    TransactionsCommitted = (uint) managementObject.Properties["TransactionsCommitted"].Value,
                    TransactionsPending = (uint) managementObject.Properties["TransactionsPending"].Value,
                    TransactionsPerSec = (uint) managementObject.Properties["TransactionsPerSec"].Value,
                    TransactionsTotal = (uint) managementObject.Properties["TransactionsTotal"].Value,
                    ViewstateMACValidationFailure = (uint) managementObject.Properties["ViewstateMACValidationFailure"]
                        .Value
                });

            return list.ToArray();
        }
    }
}