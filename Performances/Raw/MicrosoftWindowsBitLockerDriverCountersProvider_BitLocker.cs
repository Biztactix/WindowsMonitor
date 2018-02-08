using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MaxReadSplitSize { get; private set; }
        public uint MaxWriteSplitSize { get; private set; }
        public uint MinReadSplitSize { get; private set; }
        public uint MinWriteSplitSize { get; private set; }
        public string Name { get; private set; }
        public ulong ReadRequestsPersec { get; private set; }
        public ulong ReadSubrequestsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong WriteRequestsPersec { get; private set; }
        public ulong WriteSubrequestsPersec { get; private set; }

        public static PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaxReadSplitSize = (uint) managementObject.Properties["MaxReadSplitSize"].Value,
                    MaxWriteSplitSize = (uint) managementObject.Properties["MaxWriteSplitSize"].Value,
                    MinReadSplitSize = (uint) managementObject.Properties["MinReadSplitSize"].Value,
                    MinWriteSplitSize = (uint) managementObject.Properties["MinWriteSplitSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReadRequestsPersec = (ulong) managementObject.Properties["ReadRequestsPersec"].Value,
                    ReadSubrequestsPersec = (ulong) managementObject.Properties["ReadSubrequestsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WriteRequestsPersec = (ulong) managementObject.Properties["WriteRequestsPersec"].Value,
                    WriteSubrequestsPersec = (ulong) managementObject.Properties["WriteSubrequestsPersec"].Value
                });

            return list.ToArray();
        }
    }
}