using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSDTCBridge4000_MSDTCBridge4000
    {
        public uint Averageparticipantcommitresponsetime { get; private set; }
        public uint Averageparticipantcommitresponsetime_Base { get; private set; }
        public uint Averageparticipantprepareresponsetime { get; private set; }
        public uint Averageparticipantprepareresponsetime_Base { get; private set; }
        public string Caption { get; private set; }
        public uint CommitretrycountPersec { get; private set; }
        public string Description { get; private set; }
        public uint FaultsreceivedcountPersec { get; private set; }
        public uint FaultssentcountPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MessagesendfailuresPersec { get; private set; }
        public string Name { get; private set; }
        public uint PreparedretrycountPersec { get; private set; }
        public uint PrepareretrycountPersec { get; private set; }
        public uint ReplayretrycountPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSDTCBridge4000_MSDTCBridge4000[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSDTCBridge4000_MSDTCBridge4000[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSDTCBridge4000_MSDTCBridge4000[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSDTCBridge4000_MSDTCBridge4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSDTCBridge4000_MSDTCBridge4000>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSDTCBridge4000_MSDTCBridge4000
                {
                    Averageparticipantcommitresponsetime = (uint) managementObject
                        .Properties["Averageparticipantcommitresponsetime"].Value,
                    Averageparticipantcommitresponsetime_Base = (uint) managementObject
                        .Properties["Averageparticipantcommitresponsetime_Base"].Value,
                    Averageparticipantprepareresponsetime = (uint) managementObject
                        .Properties["Averageparticipantprepareresponsetime"].Value,
                    Averageparticipantprepareresponsetime_Base = (uint) managementObject
                        .Properties["Averageparticipantprepareresponsetime_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CommitretrycountPersec = (uint) managementObject.Properties["CommitretrycountPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FaultsreceivedcountPersec = (uint) managementObject.Properties["FaultsreceivedcountPersec"].Value,
                    FaultssentcountPersec = (uint) managementObject.Properties["FaultssentcountPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MessagesendfailuresPersec = (uint) managementObject.Properties["MessagesendfailuresPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PreparedretrycountPersec = (uint) managementObject.Properties["PreparedretrycountPersec"].Value,
                    PrepareretrycountPersec = (uint) managementObject.Properties["PrepareretrycountPersec"].Value,
                    ReplayretrycountPersec = (uint) managementObject.Properties["ReplayretrycountPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}