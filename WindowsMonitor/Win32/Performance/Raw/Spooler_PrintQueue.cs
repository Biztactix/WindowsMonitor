using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Spooler_PrintQueue
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

        public static IEnumerable<Spooler_PrintQueue> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Spooler_PrintQueue> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Spooler_PrintQueue> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Spooler_PrintQueue");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Spooler_PrintQueue
                {
                     AddNetworkPrinterCalls = (uint) (managementObject.Properties["AddNetworkPrinterCalls"]?.Value ?? default(uint)),
		 BytesPrintedPersec = (ulong) (managementObject.Properties["BytesPrintedPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 EnumerateNetworkPrinterCalls = (uint) (managementObject.Properties["EnumerateNetworkPrinterCalls"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 JobErrors = (uint) (managementObject.Properties["JobErrors"]?.Value ?? default(uint)),
		 Jobs = (uint) (managementObject.Properties["Jobs"]?.Value ?? default(uint)),
		 JobsSpooling = (uint) (managementObject.Properties["JobsSpooling"]?.Value ?? default(uint)),
		 MaxJobsSpooling = (uint) (managementObject.Properties["MaxJobsSpooling"]?.Value ?? default(uint)),
		 MaxReferences = (uint) (managementObject.Properties["MaxReferences"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NotReadyErrors = (uint) (managementObject.Properties["NotReadyErrors"]?.Value ?? default(uint)),
		 OutofPaperErrors = (uint) (managementObject.Properties["OutofPaperErrors"]?.Value ?? default(uint)),
		 References = (uint) (managementObject.Properties["References"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalJobsPrinted = (uint) (managementObject.Properties["TotalJobsPrinted"]?.Value ?? default(uint)),
		 TotalPagesPrinted = (uint) (managementObject.Properties["TotalPagesPrinted"]?.Value ?? default(uint))
                };
        }
    }
}