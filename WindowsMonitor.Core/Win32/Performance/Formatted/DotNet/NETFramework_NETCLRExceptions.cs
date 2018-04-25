using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRExceptions
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint NumberofExcepsThrown { get; private set; }
		public uint NumberofExcepsThrownPersec { get; private set; }
		public uint NumberofFiltersPersec { get; private set; }
		public uint NumberofFinallysPersec { get; private set; }
		public uint ThrowToCatchDepthPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<NETFramework_NETCLRExceptions> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRExceptions> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRExceptions> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRExceptions");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRExceptions
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofExcepsThrown = (uint) (managementObject.Properties["NumberofExcepsThrown"]?.Value ?? default(uint)),
		 NumberofExcepsThrownPersec = (uint) (managementObject.Properties["NumberofExcepsThrownPersec"]?.Value ?? default(uint)),
		 NumberofFiltersPersec = (uint) (managementObject.Properties["NumberofFiltersPersec"]?.Value ?? default(uint)),
		 NumberofFinallysPersec = (uint) (managementObject.Properties["NumberofFinallysPersec"]?.Value ?? default(uint)),
		 ThrowToCatchDepthPersec = (uint) (managementObject.Properties["ThrowToCatchDepthPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}