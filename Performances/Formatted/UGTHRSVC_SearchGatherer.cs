using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_UGTHRSVC_SearchGatherer
    {
        public uint ActiveQueueLength { get; private set; }
        public uint AdminClients { get; private set; }
        public uint AllNotificationsReceived { get; private set; }
        public string Caption { get; private set; }
        public uint DelayedDocuments { get; private set; }
        public string Description { get; private set; }
        public uint DocumentEntries { get; private set; }
        public uint DocumentsDelayedRetry { get; private set; }
        public uint DocumentsFiltered { get; private set; }
        public uint DocumentsFilteredRate { get; private set; }
        public uint DocumentsSuccessfullyFiltered { get; private set; }
        public uint DocumentsSuccessfullyFilteredRate { get; private set; }
        public uint ExtNotificationsRate { get; private set; }
        public uint ExtNotificationsReceived { get; private set; }
        public uint FilteringThreads { get; private set; }
        public uint FilterObjects { get; private set; }
        public uint FilterProcessCreated { get; private set; }
        public uint FilterProcesses { get; private set; }
        public uint FilterProcessesMax { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Heartbeats { get; private set; }
        public uint HeartbeatsRate { get; private set; }
        public uint IdleThreads { get; private set; }
        public string Name { get; private set; }
        public uint NotificationSources { get; private set; }
        public uint NotificationsRate { get; private set; }
        public uint PerformanceLevel { get; private set; }
        public uint Reasontobackoff { get; private set; }
        public uint ServerObjects { get; private set; }
        public uint ServerObjectsCreated { get; private set; }
        public uint ServersCurrentlyUnavailable { get; private set; }
        public uint ServersUnavailable { get; private set; }
        public uint StemmersCached { get; private set; }
        public uint SystemIOtrafficrate { get; private set; }
        public uint ThreadsAccessingNetwork { get; private set; }
        public uint Threadsblockedduetobackoff { get; private set; }
        public uint ThreadsInPlugins { get; private set; }
        public uint TimeOuts { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint WordBreakersCached { get; private set; }

        public static PerfFormattedData_UGTHRSVC_SearchGatherer[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_UGTHRSVC_SearchGatherer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_UGTHRSVC_SearchGatherer[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_UGTHRSVC_SearchGatherer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_UGTHRSVC_SearchGatherer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_UGTHRSVC_SearchGatherer
                {
                    ActiveQueueLength = (uint) managementObject.Properties["ActiveQueueLength"].Value,
                    AdminClients = (uint) managementObject.Properties["AdminClients"].Value,
                    AllNotificationsReceived = (uint) managementObject.Properties["AllNotificationsReceived"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    DelayedDocuments = (uint) managementObject.Properties["DelayedDocuments"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DocumentEntries = (uint) managementObject.Properties["DocumentEntries"].Value,
                    DocumentsDelayedRetry = (uint) managementObject.Properties["DocumentsDelayedRetry"].Value,
                    DocumentsFiltered = (uint) managementObject.Properties["DocumentsFiltered"].Value,
                    DocumentsFilteredRate = (uint) managementObject.Properties["DocumentsFilteredRate"].Value,
                    DocumentsSuccessfullyFiltered = (uint) managementObject.Properties["DocumentsSuccessfullyFiltered"]
                        .Value,
                    DocumentsSuccessfullyFilteredRate =
                        (uint) managementObject.Properties["DocumentsSuccessfullyFilteredRate"].Value,
                    ExtNotificationsRate = (uint) managementObject.Properties["ExtNotificationsRate"].Value,
                    ExtNotificationsReceived = (uint) managementObject.Properties["ExtNotificationsReceived"].Value,
                    FilteringThreads = (uint) managementObject.Properties["FilteringThreads"].Value,
                    FilterObjects = (uint) managementObject.Properties["FilterObjects"].Value,
                    FilterProcessCreated = (uint) managementObject.Properties["FilterProcessCreated"].Value,
                    FilterProcesses = (uint) managementObject.Properties["FilterProcesses"].Value,
                    FilterProcessesMax = (uint) managementObject.Properties["FilterProcessesMax"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Heartbeats = (uint) managementObject.Properties["Heartbeats"].Value,
                    HeartbeatsRate = (uint) managementObject.Properties["HeartbeatsRate"].Value,
                    IdleThreads = (uint) managementObject.Properties["IdleThreads"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NotificationSources = (uint) managementObject.Properties["NotificationSources"].Value,
                    NotificationsRate = (uint) managementObject.Properties["NotificationsRate"].Value,
                    PerformanceLevel = (uint) managementObject.Properties["PerformanceLevel"].Value,
                    Reasontobackoff = (uint) managementObject.Properties["Reasontobackoff"].Value,
                    ServerObjects = (uint) managementObject.Properties["ServerObjects"].Value,
                    ServerObjectsCreated = (uint) managementObject.Properties["ServerObjectsCreated"].Value,
                    ServersCurrentlyUnavailable = (uint) managementObject.Properties["ServersCurrentlyUnavailable"]
                        .Value,
                    ServersUnavailable = (uint) managementObject.Properties["ServersUnavailable"].Value,
                    StemmersCached = (uint) managementObject.Properties["StemmersCached"].Value,
                    SystemIOtrafficrate = (uint) managementObject.Properties["SystemIOtrafficrate"].Value,
                    ThreadsAccessingNetwork = (uint) managementObject.Properties["ThreadsAccessingNetwork"].Value,
                    Threadsblockedduetobackoff = (uint) managementObject.Properties["Threadsblockedduetobackoff"].Value,
                    ThreadsInPlugins = (uint) managementObject.Properties["ThreadsInPlugins"].Value,
                    TimeOuts = (uint) managementObject.Properties["TimeOuts"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WordBreakersCached = (uint) managementObject.Properties["WordBreakersCached"].Value
                });

            return list.ToArray();
        }
    }
}