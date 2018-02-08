using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_W3SVC_WebService
    {
        public uint AnonymousUsersPersec { get; private set; }
        public ulong BytesReceivedPersec { get; private set; }
        public ulong BytesSentPersec { get; private set; }
        public ulong BytesTotalPersec { get; private set; }
        public string Caption { get; private set; }
        public uint CGIRequestsPersec { get; private set; }
        public uint ConnectionAttemptsPersec { get; private set; }
        public uint CopyRequestsPersec { get; private set; }
        public uint CurrentAnonymousUsers { get; private set; }
        public uint CurrentBlockedAsyncIORequests { get; private set; }
        public uint Currentblockedbandwidthbytes { get; private set; }
        public uint CurrentCALcountforauthenticatedusers { get; private set; }
        public uint CurrentCALcountforSSLconnections { get; private set; }
        public uint CurrentCGIRequests { get; private set; }
        public uint CurrentConnections { get; private set; }
        public uint CurrentISAPIExtensionRequests { get; private set; }
        public uint CurrentNonAnonymousUsers { get; private set; }
        public uint DeleteRequestsPersec { get; private set; }
        public string Description { get; private set; }
        public uint FilesPersec { get; private set; }
        public uint FilesReceivedPersec { get; private set; }
        public uint FilesSentPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint GetRequestsPersec { get; private set; }
        public uint HeadRequestsPersec { get; private set; }
        public uint ISAPIExtensionRequestsPersec { get; private set; }
        public uint LockedErrorsPersec { get; private set; }
        public uint LockRequestsPersec { get; private set; }
        public uint LogonAttemptsPersec { get; private set; }
        public uint MaximumAnonymousUsers { get; private set; }
        public uint MaximumCALcountforauthenticatedusers { get; private set; }
        public uint MaximumCALcountforSSLconnections { get; private set; }
        public uint MaximumCGIRequests { get; private set; }
        public uint MaximumConnections { get; private set; }
        public uint MaximumISAPIExtensionRequests { get; private set; }
        public uint MaximumNonAnonymousUsers { get; private set; }
        public uint MeasuredAsyncIOBandwidthUsage { get; private set; }
        public uint MkcolRequestsPersec { get; private set; }
        public uint MoveRequestsPersec { get; private set; }
        public string Name { get; private set; }
        public uint NonAnonymousUsersPersec { get; private set; }
        public uint NotFoundErrorsPersec { get; private set; }
        public uint OptionsRequestsPersec { get; private set; }
        public uint OtherRequestMethodsPersec { get; private set; }
        public uint PostRequestsPersec { get; private set; }
        public uint PropfindRequestsPersec { get; private set; }
        public uint ProppatchRequestsPersec { get; private set; }
        public uint PutRequestsPersec { get; private set; }
        public uint SearchRequestsPersec { get; private set; }
        public uint ServiceUptime { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalAllowedAsyncIORequests { get; private set; }
        public uint TotalAnonymousUsers { get; private set; }
        public uint TotalBlockedAsyncIORequests { get; private set; }
        public uint Totalblockedbandwidthbytes { get; private set; }
        public ulong TotalBytesReceived { get; private set; }
        public ulong TotalBytesSent { get; private set; }
        public ulong TotalBytesTransferred { get; private set; }
        public uint TotalCGIRequests { get; private set; }
        public uint TotalConnectionAttemptsallinstances { get; private set; }
        public uint TotalCopyRequests { get; private set; }
        public uint TotalcountoffailedCALrequestsforauthenticatedusers { get; private set; }
        public uint TotalcountoffailedCALrequestsforSSLconnections { get; private set; }
        public uint TotalDeleteRequests { get; private set; }
        public uint TotalFilesReceived { get; private set; }
        public uint TotalFilesSent { get; private set; }
        public uint TotalFilesTransferred { get; private set; }
        public uint TotalGetRequests { get; private set; }
        public uint TotalHeadRequests { get; private set; }
        public uint TotalISAPIExtensionRequests { get; private set; }
        public uint TotalLockedErrors { get; private set; }
        public uint TotalLockRequests { get; private set; }
        public uint TotalLogonAttempts { get; private set; }
        public uint TotalMethodRequests { get; private set; }
        public uint TotalMethodRequestsPersec { get; private set; }
        public uint TotalMkcolRequests { get; private set; }
        public uint TotalMoveRequests { get; private set; }
        public uint TotalNonAnonymousUsers { get; private set; }
        public uint TotalNotFoundErrors { get; private set; }
        public uint TotalOptionsRequests { get; private set; }
        public uint TotalOtherRequestMethods { get; private set; }
        public uint TotalPostRequests { get; private set; }
        public uint TotalPropfindRequests { get; private set; }
        public uint TotalProppatchRequests { get; private set; }
        public uint TotalPutRequests { get; private set; }
        public uint TotalRejectedAsyncIORequests { get; private set; }
        public uint TotalSearchRequests { get; private set; }
        public uint TotalTraceRequests { get; private set; }
        public uint TotalUnlockRequests { get; private set; }
        public uint TraceRequestsPersec { get; private set; }
        public uint UnlockRequestsPersec { get; private set; }

        public static PerfFormattedData_W3SVC_WebService[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_W3SVC_WebService[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_W3SVC_WebService[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_W3SVC_WebService>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_W3SVC_WebService
                {
                    AnonymousUsersPersec = (uint) managementObject.Properties["AnonymousUsersPersec"].Value,
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesSentPersec = (ulong) managementObject.Properties["BytesSentPersec"].Value,
                    BytesTotalPersec = (ulong) managementObject.Properties["BytesTotalPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CGIRequestsPersec = (uint) managementObject.Properties["CGIRequestsPersec"].Value,
                    ConnectionAttemptsPersec = (uint) managementObject.Properties["ConnectionAttemptsPersec"].Value,
                    CopyRequestsPersec = (uint) managementObject.Properties["CopyRequestsPersec"].Value,
                    CurrentAnonymousUsers = (uint) managementObject.Properties["CurrentAnonymousUsers"].Value,
                    CurrentBlockedAsyncIORequests = (uint) managementObject.Properties["CurrentBlockedAsyncIORequests"]
                        .Value,
                    Currentblockedbandwidthbytes = (uint) managementObject.Properties["Currentblockedbandwidthbytes"]
                        .Value,
                    CurrentCALcountforauthenticatedusers = (uint) managementObject
                        .Properties["CurrentCALcountforauthenticatedusers"].Value,
                    CurrentCALcountforSSLconnections =
                        (uint) managementObject.Properties["CurrentCALcountforSSLconnections"].Value,
                    CurrentCGIRequests = (uint) managementObject.Properties["CurrentCGIRequests"].Value,
                    CurrentConnections = (uint) managementObject.Properties["CurrentConnections"].Value,
                    CurrentISAPIExtensionRequests = (uint) managementObject.Properties["CurrentISAPIExtensionRequests"]
                        .Value,
                    CurrentNonAnonymousUsers = (uint) managementObject.Properties["CurrentNonAnonymousUsers"].Value,
                    DeleteRequestsPersec = (uint) managementObject.Properties["DeleteRequestsPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FilesPersec = (uint) managementObject.Properties["FilesPersec"].Value,
                    FilesReceivedPersec = (uint) managementObject.Properties["FilesReceivedPersec"].Value,
                    FilesSentPersec = (uint) managementObject.Properties["FilesSentPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GetRequestsPersec = (uint) managementObject.Properties["GetRequestsPersec"].Value,
                    HeadRequestsPersec = (uint) managementObject.Properties["HeadRequestsPersec"].Value,
                    ISAPIExtensionRequestsPersec = (uint) managementObject.Properties["ISAPIExtensionRequestsPersec"]
                        .Value,
                    LockedErrorsPersec = (uint) managementObject.Properties["LockedErrorsPersec"].Value,
                    LockRequestsPersec = (uint) managementObject.Properties["LockRequestsPersec"].Value,
                    LogonAttemptsPersec = (uint) managementObject.Properties["LogonAttemptsPersec"].Value,
                    MaximumAnonymousUsers = (uint) managementObject.Properties["MaximumAnonymousUsers"].Value,
                    MaximumCALcountforauthenticatedusers = (uint) managementObject
                        .Properties["MaximumCALcountforauthenticatedusers"].Value,
                    MaximumCALcountforSSLconnections =
                        (uint) managementObject.Properties["MaximumCALcountforSSLconnections"].Value,
                    MaximumCGIRequests = (uint) managementObject.Properties["MaximumCGIRequests"].Value,
                    MaximumConnections = (uint) managementObject.Properties["MaximumConnections"].Value,
                    MaximumISAPIExtensionRequests = (uint) managementObject.Properties["MaximumISAPIExtensionRequests"]
                        .Value,
                    MaximumNonAnonymousUsers = (uint) managementObject.Properties["MaximumNonAnonymousUsers"].Value,
                    MeasuredAsyncIOBandwidthUsage = (uint) managementObject.Properties["MeasuredAsyncIOBandwidthUsage"]
                        .Value,
                    MkcolRequestsPersec = (uint) managementObject.Properties["MkcolRequestsPersec"].Value,
                    MoveRequestsPersec = (uint) managementObject.Properties["MoveRequestsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NonAnonymousUsersPersec = (uint) managementObject.Properties["NonAnonymousUsersPersec"].Value,
                    NotFoundErrorsPersec = (uint) managementObject.Properties["NotFoundErrorsPersec"].Value,
                    OptionsRequestsPersec = (uint) managementObject.Properties["OptionsRequestsPersec"].Value,
                    OtherRequestMethodsPersec = (uint) managementObject.Properties["OtherRequestMethodsPersec"].Value,
                    PostRequestsPersec = (uint) managementObject.Properties["PostRequestsPersec"].Value,
                    PropfindRequestsPersec = (uint) managementObject.Properties["PropfindRequestsPersec"].Value,
                    ProppatchRequestsPersec = (uint) managementObject.Properties["ProppatchRequestsPersec"].Value,
                    PutRequestsPersec = (uint) managementObject.Properties["PutRequestsPersec"].Value,
                    SearchRequestsPersec = (uint) managementObject.Properties["SearchRequestsPersec"].Value,
                    ServiceUptime = (uint) managementObject.Properties["ServiceUptime"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalAllowedAsyncIORequests = (uint) managementObject.Properties["TotalAllowedAsyncIORequests"]
                        .Value,
                    TotalAnonymousUsers = (uint) managementObject.Properties["TotalAnonymousUsers"].Value,
                    TotalBlockedAsyncIORequests = (uint) managementObject.Properties["TotalBlockedAsyncIORequests"]
                        .Value,
                    Totalblockedbandwidthbytes = (uint) managementObject.Properties["Totalblockedbandwidthbytes"].Value,
                    TotalBytesReceived = (ulong) managementObject.Properties["TotalBytesReceived"].Value,
                    TotalBytesSent = (ulong) managementObject.Properties["TotalBytesSent"].Value,
                    TotalBytesTransferred = (ulong) managementObject.Properties["TotalBytesTransferred"].Value,
                    TotalCGIRequests = (uint) managementObject.Properties["TotalCGIRequests"].Value,
                    TotalConnectionAttemptsallinstances =
                        (uint) managementObject.Properties["TotalConnectionAttemptsallinstances"].Value,
                    TotalCopyRequests = (uint) managementObject.Properties["TotalCopyRequests"].Value,
                    TotalcountoffailedCALrequestsforauthenticatedusers = (uint) managementObject
                        .Properties["TotalcountoffailedCALrequestsforauthenticatedusers"].Value,
                    TotalcountoffailedCALrequestsforSSLconnections = (uint) managementObject
                        .Properties["TotalcountoffailedCALrequestsforSSLconnections"].Value,
                    TotalDeleteRequests = (uint) managementObject.Properties["TotalDeleteRequests"].Value,
                    TotalFilesReceived = (uint) managementObject.Properties["TotalFilesReceived"].Value,
                    TotalFilesSent = (uint) managementObject.Properties["TotalFilesSent"].Value,
                    TotalFilesTransferred = (uint) managementObject.Properties["TotalFilesTransferred"].Value,
                    TotalGetRequests = (uint) managementObject.Properties["TotalGetRequests"].Value,
                    TotalHeadRequests = (uint) managementObject.Properties["TotalHeadRequests"].Value,
                    TotalISAPIExtensionRequests = (uint) managementObject.Properties["TotalISAPIExtensionRequests"]
                        .Value,
                    TotalLockedErrors = (uint) managementObject.Properties["TotalLockedErrors"].Value,
                    TotalLockRequests = (uint) managementObject.Properties["TotalLockRequests"].Value,
                    TotalLogonAttempts = (uint) managementObject.Properties["TotalLogonAttempts"].Value,
                    TotalMethodRequests = (uint) managementObject.Properties["TotalMethodRequests"].Value,
                    TotalMethodRequestsPersec = (uint) managementObject.Properties["TotalMethodRequestsPersec"].Value,
                    TotalMkcolRequests = (uint) managementObject.Properties["TotalMkcolRequests"].Value,
                    TotalMoveRequests = (uint) managementObject.Properties["TotalMoveRequests"].Value,
                    TotalNonAnonymousUsers = (uint) managementObject.Properties["TotalNonAnonymousUsers"].Value,
                    TotalNotFoundErrors = (uint) managementObject.Properties["TotalNotFoundErrors"].Value,
                    TotalOptionsRequests = (uint) managementObject.Properties["TotalOptionsRequests"].Value,
                    TotalOtherRequestMethods = (uint) managementObject.Properties["TotalOtherRequestMethods"].Value,
                    TotalPostRequests = (uint) managementObject.Properties["TotalPostRequests"].Value,
                    TotalPropfindRequests = (uint) managementObject.Properties["TotalPropfindRequests"].Value,
                    TotalProppatchRequests = (uint) managementObject.Properties["TotalProppatchRequests"].Value,
                    TotalPutRequests = (uint) managementObject.Properties["TotalPutRequests"].Value,
                    TotalRejectedAsyncIORequests = (uint) managementObject.Properties["TotalRejectedAsyncIORequests"]
                        .Value,
                    TotalSearchRequests = (uint) managementObject.Properties["TotalSearchRequests"].Value,
                    TotalTraceRequests = (uint) managementObject.Properties["TotalTraceRequests"].Value,
                    TotalUnlockRequests = (uint) managementObject.Properties["TotalUnlockRequests"].Value,
                    TraceRequestsPersec = (uint) managementObject.Properties["TraceRequestsPersec"].Value,
                    UnlockRequestsPersec = (uint) managementObject.Properties["UnlockRequestsPersec"].Value
                });

            return list.ToArray();
        }
    }
}