using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_WinNatCounters_WinNATUDP
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfBindings { get; private set; }
        public uint NumberOfSessions { get; private set; }
        public uint NumExtToIntTranslations { get; private set; }
        public uint NumIntToExtTranslations { get; private set; }
        public uint NumPacketsDropped { get; private set; }
        public uint NumSessionsTimedOut { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_WinNatCounters_WinNATUDP[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_WinNatCounters_WinNATUDP[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_WinNatCounters_WinNATUDP[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_WinNatCounters_WinNATUDP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_WinNatCounters_WinNATUDP>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_WinNatCounters_WinNATUDP
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfBindings = (uint) managementObject.Properties["NumberOfBindings"].Value,
                    NumberOfSessions = (uint) managementObject.Properties["NumberOfSessions"].Value,
                    NumExtToIntTranslations = (uint) managementObject.Properties["NumExtToIntTranslations"].Value,
                    NumIntToExtTranslations = (uint) managementObject.Properties["NumIntToExtTranslations"].Value,
                    NumPacketsDropped = (uint) managementObject.Properties["NumPacketsDropped"].Value,
                    NumSessionsTimedOut = (uint) managementObject.Properties["NumSessionsTimedOut"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}