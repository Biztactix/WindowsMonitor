using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_DNS64Global
    {
        public ulong AAAAqueriesFailed { get; private set; }
        public ulong AAAAqueriesSuccessful { get; private set; }
        public ulong AAAASynthesizedrecords { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong IP6ARPAqueriesMatched { get; private set; }
        public string Name { get; private set; }
        public ulong OtherqueriesFailed { get; private set; }
        public ulong OtherqueriesSuccessful { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_DNS64Global[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_Counters_DNS64Global[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_DNS64Global[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_DNS64Global");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_DNS64Global>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_DNS64Global
                {
                    AAAAqueriesFailed = (ulong) managementObject.Properties["AAAAqueriesFailed"].Value,
                    AAAAqueriesSuccessful = (ulong) managementObject.Properties["AAAAqueriesSuccessful"].Value,
                    AAAASynthesizedrecords = (ulong) managementObject.Properties["AAAASynthesizedrecords"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IP6ARPAqueriesMatched = (ulong) managementObject.Properties["IP6ARPAqueriesMatched"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OtherqueriesFailed = (ulong) managementObject.Properties["OtherqueriesFailed"].Value,
                    OtherqueriesSuccessful = (ulong) managementObject.Properties["OtherqueriesSuccessful"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}