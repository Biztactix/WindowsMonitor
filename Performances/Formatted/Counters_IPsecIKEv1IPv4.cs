using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_IPsecIKEv1IPv4
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

        public static PerfFormattedData_Counters_IPsecIKEv1IPv4[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_IPsecIKEv1IPv4[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_IPsecIKEv1IPv4[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPsecIKEv1IPv4");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_IPsecIKEv1IPv4>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_IPsecIKEv1IPv4
                {
                    ActiveMainModeSAs = (uint) managementObject.Properties["ActiveMainModeSAs"].Value,
                    ActiveQuickModeSAs = (uint) managementObject.Properties["ActiveQuickModeSAs"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FailedMainModeNegotiations = (uint) managementObject.Properties["FailedMainModeNegotiations"].Value,
                    FailedMainModeNegotiationsPersec =
                        (uint) managementObject.Properties["FailedMainModeNegotiationsPersec"].Value,
                    FailedQuickModeNegotiations = (uint) managementObject.Properties["FailedQuickModeNegotiations"]
                        .Value,
                    FailedQuickModeNegotiationsPersec =
                        (uint) managementObject.Properties["FailedQuickModeNegotiationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MainModeNegotiationRequestsReceived =
                        (uint) managementObject.Properties["MainModeNegotiationRequestsReceived"].Value,
                    MainModeNegotiationRequestsReceivedPersec = (uint) managementObject
                        .Properties["MainModeNegotiationRequestsReceivedPersec"].Value,
                    MainModeNegotiations = (uint) managementObject.Properties["MainModeNegotiations"].Value,
                    MainModeNegotiationsPersec = (uint) managementObject.Properties["MainModeNegotiationsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PendingMainModeNegotiations = (uint) managementObject.Properties["PendingMainModeNegotiations"]
                        .Value,
                    PendingQuickModeNegotiations = (uint) managementObject.Properties["PendingQuickModeNegotiations"]
                        .Value,
                    QuickModeNegotiations = (uint) managementObject.Properties["QuickModeNegotiations"].Value,
                    QuickModeNegotiationsPersec = (uint) managementObject.Properties["QuickModeNegotiationsPersec"]
                        .Value,
                    SuccessfulMainModeNegotiations =
                        (uint) managementObject.Properties["SuccessfulMainModeNegotiations"].Value,
                    SuccessfulMainModeNegotiationsPersec = (uint) managementObject
                        .Properties["SuccessfulMainModeNegotiationsPersec"].Value,
                    SuccessfulQuickModeNegotiations =
                        (uint) managementObject.Properties["SuccessfulQuickModeNegotiations"].Value,
                    SuccessfulQuickModeNegotiationsPersec = (uint) managementObject
                        .Properties["SuccessfulQuickModeNegotiationsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}