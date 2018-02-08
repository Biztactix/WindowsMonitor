using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETFramework_NETCLRJit
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
        public uint StandardJitFailures { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalNumberofILBytesJitted { get; private set; }

        public static PerfFormattedData_NETFramework_NETCLRJit[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_NETFramework_NETCLRJit[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETFramework_NETCLRJit[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRJit");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETFramework_NETCLRJit>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETFramework_NETCLRJit
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    ILBytesJittedPersec = (uint) managementObject.Properties["ILBytesJittedPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberofILBytesJitted = (uint) managementObject.Properties["NumberofILBytesJitted"].Value,
                    NumberofMethodsJitted = (uint) managementObject.Properties["NumberofMethodsJitted"].Value,
                    PercentTimeinJit = (uint) managementObject.Properties["PercentTimeinJit"].Value,
                    StandardJitFailures = (uint) managementObject.Properties["StandardJitFailures"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalNumberofILBytesJitted = (uint) managementObject.Properties["TotalNumberofILBytesJitted"].Value
                });

            return list.ToArray();
        }
    }
}