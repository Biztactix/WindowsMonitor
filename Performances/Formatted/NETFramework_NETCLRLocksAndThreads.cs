using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETFramework_NETCLRLocksAndThreads
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

        public static PerfFormattedData_NETFramework_NETCLRLocksAndThreads[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_NETFramework_NETCLRLocksAndThreads[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETFramework_NETCLRLocksAndThreads[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRLocksAndThreads");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETFramework_NETCLRLocksAndThreads>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETFramework_NETCLRLocksAndThreads
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ContentionRatePersec = (uint) managementObject.Properties["ContentionRatePersec"].Value,
                    CurrentQueueLength = (uint) managementObject.Properties["CurrentQueueLength"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberofcurrentlogicalThreads = (uint) managementObject.Properties["NumberofcurrentlogicalThreads"]
                        .Value,
                    NumberofcurrentphysicalThreads =
                        (uint) managementObject.Properties["NumberofcurrentphysicalThreads"].Value,
                    Numberofcurrentrecognizedthreads =
                        (uint) managementObject.Properties["Numberofcurrentrecognizedthreads"].Value,
                    Numberoftotalrecognizedthreads =
                        (uint) managementObject.Properties["Numberoftotalrecognizedthreads"].Value,
                    QueueLengthPeak = (uint) managementObject.Properties["QueueLengthPeak"].Value,
                    QueueLengthPersec = (uint) managementObject.Properties["QueueLengthPersec"].Value,
                    rateofrecognizedthreadsPersec = (uint) managementObject.Properties["rateofrecognizedthreadsPersec"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalNumberofContentions = (uint) managementObject.Properties["TotalNumberofContentions"].Value
                });

            return list.ToArray();
        }
    }
}