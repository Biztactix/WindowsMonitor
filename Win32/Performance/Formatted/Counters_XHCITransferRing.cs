using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_XHCITransferRing
    {
		public uint BytesPerSec { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public uint FailedTransferCount { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint IsochTDFailuresPersec { get; private set; }
		public uint IsochTDPersec { get; private set; }
		public uint MissedServiceErrorCount { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TransfersPersec { get; private set; }
		public uint UnderrunOverruncount { get; private set; }

        public static IEnumerable<Counters_XHCITransferRing> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_XHCITransferRing> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_XHCITransferRing> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_XHCITransferRing");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_XHCITransferRing
                {
                     BytesPerSec = (uint) (managementObject.Properties["BytesPerSec"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FailedTransferCount = (uint) (managementObject.Properties["FailedTransferCount"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IsochTDFailuresPersec = (uint) (managementObject.Properties["IsochTDFailuresPersec"]?.Value ?? default(uint)),
		 IsochTDPersec = (uint) (managementObject.Properties["IsochTDPersec"]?.Value ?? default(uint)),
		 MissedServiceErrorCount = (uint) (managementObject.Properties["MissedServiceErrorCount"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransfersPersec = (uint) (managementObject.Properties["TransfersPersec"]?.Value ?? default(uint)),
		 UnderrunOverruncount = (uint) (managementObject.Properties["UnderrunOverruncount"]?.Value ?? default(uint))
                };
        }
    }
}