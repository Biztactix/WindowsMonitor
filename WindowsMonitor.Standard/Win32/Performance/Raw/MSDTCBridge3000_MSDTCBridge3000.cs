using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSDTCBridge3000_MSDTCBridge3000
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

        public static IEnumerable<MSDTCBridge3000_MSDTCBridge3000> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSDTCBridge3000_MSDTCBridge3000> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSDTCBridge3000_MSDTCBridge3000> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSDTCBridge3000_MSDTCBridge3000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSDTCBridge3000_MSDTCBridge3000
                {
                     Averageparticipantcommitresponsetime = (uint) (managementObject.Properties["Averageparticipantcommitresponsetime"]?.Value ?? default(uint)),
		 Averageparticipantcommitresponsetime_Base = (uint) (managementObject.Properties["Averageparticipantcommitresponsetime_Base"]?.Value ?? default(uint)),
		 Averageparticipantprepareresponsetime = (uint) (managementObject.Properties["Averageparticipantprepareresponsetime"]?.Value ?? default(uint)),
		 Averageparticipantprepareresponsetime_Base = (uint) (managementObject.Properties["Averageparticipantprepareresponsetime_Base"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CommitretrycountPersec = (uint) (managementObject.Properties["CommitretrycountPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FaultsreceivedcountPersec = (uint) (managementObject.Properties["FaultsreceivedcountPersec"]?.Value ?? default(uint)),
		 FaultssentcountPersec = (uint) (managementObject.Properties["FaultssentcountPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MessagesendfailuresPersec = (uint) (managementObject.Properties["MessagesendfailuresPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PreparedretrycountPersec = (uint) (managementObject.Properties["PreparedretrycountPersec"]?.Value ?? default(uint)),
		 PrepareretrycountPersec = (uint) (managementObject.Properties["PrepareretrycountPersec"]?.Value ?? default(uint)),
		 ReplayretrycountPersec = (uint) (managementObject.Properties["ReplayretrycountPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}