using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2
    {
        public uint AuthIPMainModeNegotiationTime { get; private set; }
        public uint AuthIPQuickModeNegotiationTime { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint ExtendedModeNegotiationTime { get; private set; }
        public uint FailedNegotiations { get; private set; }
        public uint FailedNegotiationsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IKEv1MainModeNegotiationTime { get; private set; }
        public uint IKEv1QuickModeNegotiationTime { get; private set; }
        public uint IKEv2MainModeNegotiationTime { get; private set; }
        public uint IKEv2QuickModeNegotiationTime { get; private set; }
        public uint InvalidPacketsReceivedPersec { get; private set; }
        public string Name { get; private set; }
        public uint PacketsReceivedPersec { get; private set; }
        public uint SuccessfulNegotiations { get; private set; }
        public uint SuccessfulNegotiationsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_GenericIKEv1AuthIPandIKEv2
                {
                    AuthIPMainModeNegotiationTime = (uint) managementObject.Properties["AuthIPMainModeNegotiationTime"]
                        .Value,
                    AuthIPQuickModeNegotiationTime =
                        (uint) managementObject.Properties["AuthIPQuickModeNegotiationTime"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExtendedModeNegotiationTime = (uint) managementObject.Properties["ExtendedModeNegotiationTime"]
                        .Value,
                    FailedNegotiations = (uint) managementObject.Properties["FailedNegotiations"].Value,
                    FailedNegotiationsPersec = (uint) managementObject.Properties["FailedNegotiationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IKEv1MainModeNegotiationTime = (uint) managementObject.Properties["IKEv1MainModeNegotiationTime"]
                        .Value,
                    IKEv1QuickModeNegotiationTime = (uint) managementObject.Properties["IKEv1QuickModeNegotiationTime"]
                        .Value,
                    IKEv2MainModeNegotiationTime = (uint) managementObject.Properties["IKEv2MainModeNegotiationTime"]
                        .Value,
                    IKEv2QuickModeNegotiationTime = (uint) managementObject.Properties["IKEv2QuickModeNegotiationTime"]
                        .Value,
                    InvalidPacketsReceivedPersec = (uint) managementObject.Properties["InvalidPacketsReceivedPersec"]
                        .Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PacketsReceivedPersec = (uint) managementObject.Properties["PacketsReceivedPersec"].Value,
                    SuccessfulNegotiations = (uint) managementObject.Properties["SuccessfulNegotiations"].Value,
                    SuccessfulNegotiationsPersec = (uint) managementObject.Properties["SuccessfulNegotiationsPersec"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}