using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_PerfNet_Browser
    {
        public ulong AnnouncementsDomainPersec { get; private set; }
        public ulong AnnouncementsServerPersec { get; private set; }
        public ulong AnnouncementsTotalPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint DuplicateMasterAnnouncements { get; private set; }
        public uint ElectionPacketsPersec { get; private set; }
        public uint EnumerationsDomainPersec { get; private set; }
        public uint EnumerationsOtherPersec { get; private set; }
        public uint EnumerationsServerPersec { get; private set; }
        public uint EnumerationsTotalPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong IllegalDatagramsPersec { get; private set; }
        public uint MailslotAllocationsFailed { get; private set; }
        public uint MailslotOpensFailedPersec { get; private set; }
        public uint MailslotReceivesFailed { get; private set; }
        public uint MailslotWritesFailed { get; private set; }
        public uint MailslotWritesPersec { get; private set; }
        public uint MissedMailslotDatagrams { get; private set; }
        public uint MissedServerAnnouncements { get; private set; }
        public uint MissedServerListRequests { get; private set; }
        public string Name { get; private set; }
        public uint ServerAnnounceAllocationsFailedPersec { get; private set; }
        public uint ServerListRequestsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_PerfNet_Browser[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_PerfNet_Browser[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_PerfNet_Browser[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfNet_Browser");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_PerfNet_Browser>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_PerfNet_Browser
                {
                    AnnouncementsDomainPersec = (ulong) managementObject.Properties["AnnouncementsDomainPersec"].Value,
                    AnnouncementsServerPersec = (ulong) managementObject.Properties["AnnouncementsServerPersec"].Value,
                    AnnouncementsTotalPersec = (ulong) managementObject.Properties["AnnouncementsTotalPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DuplicateMasterAnnouncements = (uint) managementObject.Properties["DuplicateMasterAnnouncements"]
                        .Value,
                    ElectionPacketsPersec = (uint) managementObject.Properties["ElectionPacketsPersec"].Value,
                    EnumerationsDomainPersec = (uint) managementObject.Properties["EnumerationsDomainPersec"].Value,
                    EnumerationsOtherPersec = (uint) managementObject.Properties["EnumerationsOtherPersec"].Value,
                    EnumerationsServerPersec = (uint) managementObject.Properties["EnumerationsServerPersec"].Value,
                    EnumerationsTotalPersec = (uint) managementObject.Properties["EnumerationsTotalPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IllegalDatagramsPersec = (ulong) managementObject.Properties["IllegalDatagramsPersec"].Value,
                    MailslotAllocationsFailed = (uint) managementObject.Properties["MailslotAllocationsFailed"].Value,
                    MailslotOpensFailedPersec = (uint) managementObject.Properties["MailslotOpensFailedPersec"].Value,
                    MailslotReceivesFailed = (uint) managementObject.Properties["MailslotReceivesFailed"].Value,
                    MailslotWritesFailed = (uint) managementObject.Properties["MailslotWritesFailed"].Value,
                    MailslotWritesPersec = (uint) managementObject.Properties["MailslotWritesPersec"].Value,
                    MissedMailslotDatagrams = (uint) managementObject.Properties["MissedMailslotDatagrams"].Value,
                    MissedServerAnnouncements = (uint) managementObject.Properties["MissedServerAnnouncements"].Value,
                    MissedServerListRequests = (uint) managementObject.Properties["MissedServerListRequests"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ServerAnnounceAllocationsFailedPersec = (uint) managementObject
                        .Properties["ServerAnnounceAllocationsFailedPersec"].Value,
                    ServerListRequestsPersec = (uint) managementObject.Properties["ServerListRequestsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}