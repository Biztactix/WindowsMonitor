using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRJit
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint ILBytesJittedPersec { get; private set; }
		public string Name { get; private set; }
		public uint NumberofILBytesJitted { get; private set; }
		public uint NumberofMethodsJitted { get; private set; }
		public uint PercentTimeinJit { get; private set; }
		public uint PercentTimeinJit_Base { get; private set; }
		public uint StandardJitFailures { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalNumberofILBytesJitted { get; private set; }

        public static IEnumerable<NETFramework_NETCLRJit> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRJit> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRJit> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETFramework_NETCLRJit");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRJit
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 ILBytesJittedPersec = (uint) (managementObject.Properties["ILBytesJittedPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofILBytesJitted = (uint) (managementObject.Properties["NumberofILBytesJitted"]?.Value ?? default(uint)),
		 NumberofMethodsJitted = (uint) (managementObject.Properties["NumberofMethodsJitted"]?.Value ?? default(uint)),
		 PercentTimeinJit = (uint) (managementObject.Properties["PercentTimeinJit"]?.Value ?? default(uint)),
		 PercentTimeinJit_Base = (uint) (managementObject.Properties["PercentTimeinJit_Base"]?.Value ?? default(uint)),
		 StandardJitFailures = (uint) (managementObject.Properties["StandardJitFailures"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalNumberofILBytesJitted = (uint) (managementObject.Properties["TotalNumberofILBytesJitted"]?.Value ?? default(uint))
                };
        }
    }
}