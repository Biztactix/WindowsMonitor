using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_UGatherer_SearchGathererProjects
    {
        public uint AccessedFileRate { get; private set; }
        public uint AccessedFiles { get; private set; }
        public uint AdaptiveCrawlErrors { get; private set; }
        public string Caption { get; private set; }
        public uint ChangedDocuments { get; private set; }
        public uint Crawlsinprogress { get; private set; }
        public uint DelayedDocuments { get; private set; }
        public string Description { get; private set; }
        public uint DocumentAdditions { get; private set; }
        public uint DocumentAddRate { get; private set; }
        public uint DocumentDeleteRate { get; private set; }
        public uint DocumentDeletes { get; private set; }
        public uint DocumentModifies { get; private set; }
        public uint DocumentModifiesRate { get; private set; }
        public uint DocumentMoveandRenameRate { get; private set; }
        public uint DocumentMovesPerRenames { get; private set; }
        public uint DocumentsInProgress { get; private set; }
        public uint DocumentsOnHold { get; private set; }
        public uint ErrorRate { get; private set; }
        public uint FileErrors { get; private set; }
        public uint FileErrorsRate { get; private set; }
        public uint FilteredOffice { get; private set; }
        public uint FilteredOfficeRate { get; private set; }
        public uint FilteredText { get; private set; }
        public uint FilteredTextRate { get; private set; }
        public uint FilteringDocuments { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint GathererPausedFlag { get; private set; }
        public uint HistoryRecoveryProgress { get; private set; }
        public uint IncrementalCrawls { get; private set; }
        public uint IteratingHistoryInProgressFlag { get; private set; }
        public string Name { get; private set; }
        public uint NotModified { get; private set; }
        public uint ProcessedDocuments { get; private set; }
        public uint ProcessedDocumentsRate { get; private set; }
        public uint RecoveryInProgressFlag { get; private set; }
        public uint Retries { get; private set; }
        public uint RetriesRate { get; private set; }
        public uint StartedDocuments { get; private set; }
        public uint StatusError { get; private set; }
        public uint StatusSuccess { get; private set; }
        public uint SuccessRate { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint UniqueDocuments { get; private set; }
        public uint URLsinHistory { get; private set; }
        public uint WaitingDocuments { get; private set; }

        public static PerfRawData_UGatherer_SearchGathererProjects[] Retrieve(string remote, string username,
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

        public static PerfRawData_UGatherer_SearchGathererProjects[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_UGatherer_SearchGathererProjects[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_UGatherer_SearchGathererProjects");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_UGatherer_SearchGathererProjects>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_UGatherer_SearchGathererProjects
                {
                    AccessedFileRate = (uint) managementObject.Properties["AccessedFileRate"].Value,
                    AccessedFiles = (uint) managementObject.Properties["AccessedFiles"].Value,
                    AdaptiveCrawlErrors = (uint) managementObject.Properties["AdaptiveCrawlErrors"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ChangedDocuments = (uint) managementObject.Properties["ChangedDocuments"].Value,
                    Crawlsinprogress = (uint) managementObject.Properties["Crawlsinprogress"].Value,
                    DelayedDocuments = (uint) managementObject.Properties["DelayedDocuments"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DocumentAdditions = (uint) managementObject.Properties["DocumentAdditions"].Value,
                    DocumentAddRate = (uint) managementObject.Properties["DocumentAddRate"].Value,
                    DocumentDeleteRate = (uint) managementObject.Properties["DocumentDeleteRate"].Value,
                    DocumentDeletes = (uint) managementObject.Properties["DocumentDeletes"].Value,
                    DocumentModifies = (uint) managementObject.Properties["DocumentModifies"].Value,
                    DocumentModifiesRate = (uint) managementObject.Properties["DocumentModifiesRate"].Value,
                    DocumentMoveandRenameRate = (uint) managementObject.Properties["DocumentMoveandRenameRate"].Value,
                    DocumentMovesPerRenames = (uint) managementObject.Properties["DocumentMovesPerRenames"].Value,
                    DocumentsInProgress = (uint) managementObject.Properties["DocumentsInProgress"].Value,
                    DocumentsOnHold = (uint) managementObject.Properties["DocumentsOnHold"].Value,
                    ErrorRate = (uint) managementObject.Properties["ErrorRate"].Value,
                    FileErrors = (uint) managementObject.Properties["FileErrors"].Value,
                    FileErrorsRate = (uint) managementObject.Properties["FileErrorsRate"].Value,
                    FilteredOffice = (uint) managementObject.Properties["FilteredOffice"].Value,
                    FilteredOfficeRate = (uint) managementObject.Properties["FilteredOfficeRate"].Value,
                    FilteredText = (uint) managementObject.Properties["FilteredText"].Value,
                    FilteredTextRate = (uint) managementObject.Properties["FilteredTextRate"].Value,
                    FilteringDocuments = (uint) managementObject.Properties["FilteringDocuments"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GathererPausedFlag = (uint) managementObject.Properties["GathererPausedFlag"].Value,
                    HistoryRecoveryProgress = (uint) managementObject.Properties["HistoryRecoveryProgress"].Value,
                    IncrementalCrawls = (uint) managementObject.Properties["IncrementalCrawls"].Value,
                    IteratingHistoryInProgressFlag =
                        (uint) managementObject.Properties["IteratingHistoryInProgressFlag"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NotModified = (uint) managementObject.Properties["NotModified"].Value,
                    ProcessedDocuments = (uint) managementObject.Properties["ProcessedDocuments"].Value,
                    ProcessedDocumentsRate = (uint) managementObject.Properties["ProcessedDocumentsRate"].Value,
                    RecoveryInProgressFlag = (uint) managementObject.Properties["RecoveryInProgressFlag"].Value,
                    Retries = (uint) managementObject.Properties["Retries"].Value,
                    RetriesRate = (uint) managementObject.Properties["RetriesRate"].Value,
                    StartedDocuments = (uint) managementObject.Properties["StartedDocuments"].Value,
                    StatusError = (uint) managementObject.Properties["StatusError"].Value,
                    StatusSuccess = (uint) managementObject.Properties["StatusSuccess"].Value,
                    SuccessRate = (uint) managementObject.Properties["SuccessRate"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UniqueDocuments = (uint) managementObject.Properties["UniqueDocuments"].Value,
                    URLsinHistory = (uint) managementObject.Properties["URLsinHistory"].Value,
                    WaitingDocuments = (uint) managementObject.Properties["WaitingDocuments"].Value
                });

            return list.ToArray();
        }
    }
}