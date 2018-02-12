using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_SMBClientShares
    {
		public ulong AvgBytesPerRead { get; private set; }
		public ulong AvgBytesPerWrite { get; private set; }
		public ulong AvgDataBytesPerRequest { get; private set; }
		public ulong AvgDataQueueLength { get; private set; }
		public ulong AvgReadQueueLength { get; private set; }
		public uint AvgsecPerDataRequest { get; private set; }
		public uint AvgsecPerRead { get; private set; }
		public uint AvgsecPerWrite { get; private set; }
		public ulong AvgWriteQueueLength { get; private set; }
		public string Caption { get; private set; }
		public uint CreditStallsPersec { get; private set; }
		public uint CurrentDataQueueLength { get; private set; }
		public ulong DataBytesPersec { get; private set; }
		public uint DataRequestsPersec { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint MetadataRequestsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong ReadBytesPersec { get; private set; }
		public uint ReadRequestsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong WriteBytesPersec { get; private set; }
		public uint WriteRequestsPersec { get; private set; }

        public static IEnumerable<Counters_SMBClientShares> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_SMBClientShares> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_SMBClientShares> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_SMBClientShares");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_SMBClientShares
                {
                     AvgBytesPerRead = (ulong) (managementObject.Properties["AvgBytesPerRead"]?.Value ?? default(ulong)),
		 AvgBytesPerWrite = (ulong) (managementObject.Properties["AvgBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgDataBytesPerRequest = (ulong) (managementObject.Properties["AvgDataBytesPerRequest"]?.Value ?? default(ulong)),
		 AvgDataQueueLength = (ulong) (managementObject.Properties["AvgDataQueueLength"]?.Value ?? default(ulong)),
		 AvgReadQueueLength = (ulong) (managementObject.Properties["AvgReadQueueLength"]?.Value ?? default(ulong)),
		 AvgsecPerDataRequest = (uint) (managementObject.Properties["AvgsecPerDataRequest"]?.Value ?? default(uint)),
		 AvgsecPerRead = (uint) (managementObject.Properties["AvgsecPerRead"]?.Value ?? default(uint)),
		 AvgsecPerWrite = (uint) (managementObject.Properties["AvgsecPerWrite"]?.Value ?? default(uint)),
		 AvgWriteQueueLength = (ulong) (managementObject.Properties["AvgWriteQueueLength"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreditStallsPersec = (uint) (managementObject.Properties["CreditStallsPersec"]?.Value ?? default(uint)),
		 CurrentDataQueueLength = (uint) (managementObject.Properties["CurrentDataQueueLength"]?.Value ?? default(uint)),
		 DataBytesPersec = (ulong) (managementObject.Properties["DataBytesPersec"]?.Value ?? default(ulong)),
		 DataRequestsPersec = (uint) (managementObject.Properties["DataRequestsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MetadataRequestsPersec = (uint) (managementObject.Properties["MetadataRequestsPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ReadBytesPersec = (ulong) (managementObject.Properties["ReadBytesPersec"]?.Value ?? default(ulong)),
		 ReadRequestsPersec = (uint) (managementObject.Properties["ReadRequestsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 WriteBytesPersec = (ulong) (managementObject.Properties["WriteBytesPersec"]?.Value ?? default(ulong)),
		 WriteRequestsPersec = (uint) (managementObject.Properties["WriteRequestsPersec"]?.Value ?? default(uint))
                };
        }
    }
}