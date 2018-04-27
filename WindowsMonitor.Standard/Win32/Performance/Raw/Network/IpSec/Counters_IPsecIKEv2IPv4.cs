using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_IPsecIKEv2IPv4
    {
		public uint ActiveMainModeSAs { get; private set; }
		public uint ActiveQuickModeSAs { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint FailedMainModeNegotiations { get; private set; }
		public uint FailedMainModeNegotiationsPersec { get; private set; }
		public uint FailedQuickModeNegotiations { get; private set; }
		public uint FailedQuickModeNegotiationsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint MainModeNegotiationRequestsReceived { get; private set; }
		public uint MainModeNegotiationRequestsReceivedPersec { get; private set; }
		public uint MainModeNegotiations { get; private set; }
		public uint MainModeNegotiationsPersec { get; private set; }
		public string Name { get; private set; }
		public uint PendingMainModeNegotiations { get; private set; }
		public uint PendingQuickModeNegotiations { get; private set; }
		public uint QuickModeNegotiations { get; private set; }
		public uint QuickModeNegotiationsPersec { get; private set; }
		public uint SuccessfulMainModeNegotiations { get; private set; }
		public uint SuccessfulMainModeNegotiationsPersec { get; private set; }
		public uint SuccessfulQuickModeNegotiations { get; private set; }
		public uint SuccessfulQuickModeNegotiationsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_IPsecIKEv2IPv4> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_IPsecIKEv2IPv4> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_IPsecIKEv2IPv4> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_IPsecIKEv2IPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_IPsecIKEv2IPv4
                {
                     ActiveMainModeSAs = (uint) (managementObject.Properties["ActiveMainModeSAs"]?.Value ?? default(uint)),
		 ActiveQuickModeSAs = (uint) (managementObject.Properties["ActiveQuickModeSAs"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FailedMainModeNegotiations = (uint) (managementObject.Properties["FailedMainModeNegotiations"]?.Value ?? default(uint)),
		 FailedMainModeNegotiationsPersec = (uint) (managementObject.Properties["FailedMainModeNegotiationsPersec"]?.Value ?? default(uint)),
		 FailedQuickModeNegotiations = (uint) (managementObject.Properties["FailedQuickModeNegotiations"]?.Value ?? default(uint)),
		 FailedQuickModeNegotiationsPersec = (uint) (managementObject.Properties["FailedQuickModeNegotiationsPersec"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MainModeNegotiationRequestsReceived = (uint) (managementObject.Properties["MainModeNegotiationRequestsReceived"]?.Value ?? default(uint)),
		 MainModeNegotiationRequestsReceivedPersec = (uint) (managementObject.Properties["MainModeNegotiationRequestsReceivedPersec"]?.Value ?? default(uint)),
		 MainModeNegotiations = (uint) (managementObject.Properties["MainModeNegotiations"]?.Value ?? default(uint)),
		 MainModeNegotiationsPersec = (uint) (managementObject.Properties["MainModeNegotiationsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PendingMainModeNegotiations = (uint) (managementObject.Properties["PendingMainModeNegotiations"]?.Value ?? default(uint)),
		 PendingQuickModeNegotiations = (uint) (managementObject.Properties["PendingQuickModeNegotiations"]?.Value ?? default(uint)),
		 QuickModeNegotiations = (uint) (managementObject.Properties["QuickModeNegotiations"]?.Value ?? default(uint)),
		 QuickModeNegotiationsPersec = (uint) (managementObject.Properties["QuickModeNegotiationsPersec"]?.Value ?? default(uint)),
		 SuccessfulMainModeNegotiations = (uint) (managementObject.Properties["SuccessfulMainModeNegotiations"]?.Value ?? default(uint)),
		 SuccessfulMainModeNegotiationsPersec = (uint) (managementObject.Properties["SuccessfulMainModeNegotiationsPersec"]?.Value ?? default(uint)),
		 SuccessfulQuickModeNegotiations = (uint) (managementObject.Properties["SuccessfulQuickModeNegotiations"]?.Value ?? default(uint)),
		 SuccessfulQuickModeNegotiationsPersec = (uint) (managementObject.Properties["SuccessfulQuickModeNegotiationsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}