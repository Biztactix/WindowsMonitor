using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker
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

        public static IEnumerable<MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MicrosoftWindowsBitLockerDriverCountersProvider_BitLocker
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MaxReadSplitSize = (uint) (managementObject.Properties["MaxReadSplitSize"]?.Value ?? default(uint)),
		 MaxWriteSplitSize = (uint) (managementObject.Properties["MaxWriteSplitSize"]?.Value ?? default(uint)),
		 MinReadSplitSize = (uint) (managementObject.Properties["MinReadSplitSize"]?.Value ?? default(uint)),
		 MinWriteSplitSize = (uint) (managementObject.Properties["MinWriteSplitSize"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ReadRequestsPersec = (ulong) (managementObject.Properties["ReadRequestsPersec"]?.Value ?? default(ulong)),
		 ReadSubrequestsPersec = (ulong) (managementObject.Properties["ReadSubrequestsPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 WriteRequestsPersec = (ulong) (managementObject.Properties["WriteRequestsPersec"]?.Value ?? default(ulong)),
		 WriteSubrequestsPersec = (ulong) (managementObject.Properties["WriteSubrequestsPersec"]?.Value ?? default(ulong))
                };
        }
    }
}