using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class UGatherer_SearchGathererProjects
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

        public static IEnumerable<UGatherer_SearchGathererProjects> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<UGatherer_SearchGathererProjects> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<UGatherer_SearchGathererProjects> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_UGatherer_SearchGathererProjects");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new UGatherer_SearchGathererProjects
                {
                     AccessedFileRate = (uint) (managementObject.Properties["AccessedFileRate"]?.Value ?? default(uint)),
		 AccessedFiles = (uint) (managementObject.Properties["AccessedFiles"]?.Value ?? default(uint)),
		 AdaptiveCrawlErrors = (uint) (managementObject.Properties["AdaptiveCrawlErrors"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ChangedDocuments = (uint) (managementObject.Properties["ChangedDocuments"]?.Value ?? default(uint)),
		 Crawlsinprogress = (uint) (managementObject.Properties["Crawlsinprogress"]?.Value ?? default(uint)),
		 DelayedDocuments = (uint) (managementObject.Properties["DelayedDocuments"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DocumentAdditions = (uint) (managementObject.Properties["DocumentAdditions"]?.Value ?? default(uint)),
		 DocumentAddRate = (uint) (managementObject.Properties["DocumentAddRate"]?.Value ?? default(uint)),
		 DocumentDeleteRate = (uint) (managementObject.Properties["DocumentDeleteRate"]?.Value ?? default(uint)),
		 DocumentDeletes = (uint) (managementObject.Properties["DocumentDeletes"]?.Value ?? default(uint)),
		 DocumentModifies = (uint) (managementObject.Properties["DocumentModifies"]?.Value ?? default(uint)),
		 DocumentModifiesRate = (uint) (managementObject.Properties["DocumentModifiesRate"]?.Value ?? default(uint)),
		 DocumentMoveandRenameRate = (uint) (managementObject.Properties["DocumentMoveandRenameRate"]?.Value ?? default(uint)),
		 DocumentMovesPerRenames = (uint) (managementObject.Properties["DocumentMovesPerRenames"]?.Value ?? default(uint)),
		 DocumentsInProgress = (uint) (managementObject.Properties["DocumentsInProgress"]?.Value ?? default(uint)),
		 DocumentsOnHold = (uint) (managementObject.Properties["DocumentsOnHold"]?.Value ?? default(uint)),
		 ErrorRate = (uint) (managementObject.Properties["ErrorRate"]?.Value ?? default(uint)),
		 FileErrors = (uint) (managementObject.Properties["FileErrors"]?.Value ?? default(uint)),
		 FileErrorsRate = (uint) (managementObject.Properties["FileErrorsRate"]?.Value ?? default(uint)),
		 FilteredOffice = (uint) (managementObject.Properties["FilteredOffice"]?.Value ?? default(uint)),
		 FilteredOfficeRate = (uint) (managementObject.Properties["FilteredOfficeRate"]?.Value ?? default(uint)),
		 FilteredText = (uint) (managementObject.Properties["FilteredText"]?.Value ?? default(uint)),
		 FilteredTextRate = (uint) (managementObject.Properties["FilteredTextRate"]?.Value ?? default(uint)),
		 FilteringDocuments = (uint) (managementObject.Properties["FilteringDocuments"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GathererPausedFlag = (uint) (managementObject.Properties["GathererPausedFlag"]?.Value ?? default(uint)),
		 HistoryRecoveryProgress = (uint) (managementObject.Properties["HistoryRecoveryProgress"]?.Value ?? default(uint)),
		 IncrementalCrawls = (uint) (managementObject.Properties["IncrementalCrawls"]?.Value ?? default(uint)),
		 IteratingHistoryInProgressFlag = (uint) (managementObject.Properties["IteratingHistoryInProgressFlag"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NotModified = (uint) (managementObject.Properties["NotModified"]?.Value ?? default(uint)),
		 ProcessedDocuments = (uint) (managementObject.Properties["ProcessedDocuments"]?.Value ?? default(uint)),
		 ProcessedDocumentsRate = (uint) (managementObject.Properties["ProcessedDocumentsRate"]?.Value ?? default(uint)),
		 RecoveryInProgressFlag = (uint) (managementObject.Properties["RecoveryInProgressFlag"]?.Value ?? default(uint)),
		 Retries = (uint) (managementObject.Properties["Retries"]?.Value ?? default(uint)),
		 RetriesRate = (uint) (managementObject.Properties["RetriesRate"]?.Value ?? default(uint)),
		 StartedDocuments = (uint) (managementObject.Properties["StartedDocuments"]?.Value ?? default(uint)),
		 StatusError = (uint) (managementObject.Properties["StatusError"]?.Value ?? default(uint)),
		 StatusSuccess = (uint) (managementObject.Properties["StatusSuccess"]?.Value ?? default(uint)),
		 SuccessRate = (uint) (managementObject.Properties["SuccessRate"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 UniqueDocuments = (uint) (managementObject.Properties["UniqueDocuments"]?.Value ?? default(uint)),
		 URLsinHistory = (uint) (managementObject.Properties["URLsinHistory"]?.Value ?? default(uint)),
		 WaitingDocuments = (uint) (managementObject.Properties["WaitingDocuments"]?.Value ?? default(uint))
                };
        }
    }
}