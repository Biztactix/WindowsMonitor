using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Spooler_PrintQueue
    {
        public uint AddNetworkPrinterCalls { get; private set; }
        public ulong BytesPrintedPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint EnumerateNetworkPrinterCalls { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint JobErrors { get; private set; }
        public uint Jobs { get; private set; }
        public uint JobsSpooling { get; private set; }
        public uint MaxJobsSpooling { get; private set; }
        public uint MaxReferences { get; private set; }
        public string Name { get; private set; }
        public uint NotReadyErrors { get; private set; }
        public uint OutofPaperErrors { get; private set; }
        public uint References { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalJobsPrinted { get; private set; }
        public uint TotalPagesPrinted { get; private set; }

        public static PerfFormattedData_Spooler_PrintQueue[] Retrieve(string remote, string username, string password)
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

        public static PerfFormattedData_Spooler_PrintQueue[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Spooler_PrintQueue[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Spooler_PrintQueue");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Spooler_PrintQueue>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Spooler_PrintQueue
                {
                    AddNetworkPrinterCalls = (uint) managementObject.Properties["AddNetworkPrinterCalls"].Value,
                    BytesPrintedPersec = (ulong) managementObject.Properties["BytesPrintedPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EnumerateNetworkPrinterCalls = (uint) managementObject.Properties["EnumerateNetworkPrinterCalls"]
                        .Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    JobErrors = (uint) managementObject.Properties["JobErrors"].Value,
                    Jobs = (uint) managementObject.Properties["Jobs"].Value,
                    JobsSpooling = (uint) managementObject.Properties["JobsSpooling"].Value,
                    MaxJobsSpooling = (uint) managementObject.Properties["MaxJobsSpooling"].Value,
                    MaxReferences = (uint) managementObject.Properties["MaxReferences"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NotReadyErrors = (uint) managementObject.Properties["NotReadyErrors"].Value,
                    OutofPaperErrors = (uint) managementObject.Properties["OutofPaperErrors"].Value,
                    References = (uint) managementObject.Properties["References"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalJobsPrinted = (uint) managementObject.Properties["TotalJobsPrinted"].Value,
                    TotalPagesPrinted = (uint) managementObject.Properties["TotalPagesPrinted"].Value
                });

            return list.ToArray();
        }
    }
}