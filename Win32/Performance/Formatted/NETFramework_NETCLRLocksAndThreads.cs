using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRLocksAndThreads
    {
		public string Caption { get; private set; }
		public uint ContentionRatePersec { get; private set; }
		public uint CurrentQueueLength { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint NumberofcurrentlogicalThreads { get; private set; }
		public uint NumberofcurrentphysicalThreads { get; private set; }
		public uint Numberofcurrentrecognizedthreads { get; private set; }
		public uint Numberoftotalrecognizedthreads { get; private set; }
		public uint QueueLengthPeak { get; private set; }
		public uint QueueLengthPersec { get; private set; }
		public uint rateofrecognizedthreadsPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalNumberofContentions { get; private set; }

        public static IEnumerable<NETFramework_NETCLRLocksAndThreads> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRLocksAndThreads> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRLocksAndThreads> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRLocksAndThreads");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRLocksAndThreads
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ContentionRatePersec = (uint) (managementObject.Properties["ContentionRatePersec"]?.Value ?? default(uint)),
		 CurrentQueueLength = (uint) (managementObject.Properties["CurrentQueueLength"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofcurrentlogicalThreads = (uint) (managementObject.Properties["NumberofcurrentlogicalThreads"]?.Value ?? default(uint)),
		 NumberofcurrentphysicalThreads = (uint) (managementObject.Properties["NumberofcurrentphysicalThreads"]?.Value ?? default(uint)),
		 Numberofcurrentrecognizedthreads = (uint) (managementObject.Properties["Numberofcurrentrecognizedthreads"]?.Value ?? default(uint)),
		 Numberoftotalrecognizedthreads = (uint) (managementObject.Properties["Numberoftotalrecognizedthreads"]?.Value ?? default(uint)),
		 QueueLengthPeak = (uint) (managementObject.Properties["QueueLengthPeak"]?.Value ?? default(uint)),
		 QueueLengthPersec = (uint) (managementObject.Properties["QueueLengthPersec"]?.Value ?? default(uint)),
		 rateofrecognizedthreadsPersec = (uint) (managementObject.Properties["rateofrecognizedthreadsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalNumberofContentions = (uint) (managementObject.Properties["TotalNumberofContentions"]?.Value ?? default(uint))
                };
        }
    }
}