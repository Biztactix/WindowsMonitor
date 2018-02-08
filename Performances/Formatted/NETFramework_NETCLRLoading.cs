using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETFramework_NETCLRLoading
    {
        public uint AssemblySearchLength { get; private set; }
        public uint BytesinLoaderHeap { get; private set; }
        public string Caption { get; private set; }
        public uint Currentappdomains { get; private set; }
        public uint CurrentAssemblies { get; private set; }
        public uint CurrentClassesLoaded { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong PercentTimeLoading { get; private set; }
        public uint Rateofappdomains { get; private set; }
        public uint Rateofappdomainsunloaded { get; private set; }
        public uint RateofAssemblies { get; private set; }
        public uint RateofClassesLoaded { get; private set; }
        public uint RateofLoadFailures { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalAppdomains { get; private set; }
        public uint Totalappdomainsunloaded { get; private set; }
        public uint TotalAssemblies { get; private set; }
        public uint TotalClassesLoaded { get; private set; }
        public uint TotalNumberofLoadFailures { get; private set; }

        public static PerfFormattedData_NETFramework_NETCLRLoading[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_NETFramework_NETCLRLoading[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETFramework_NETCLRLoading[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRLoading");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETFramework_NETCLRLoading>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETFramework_NETCLRLoading
                {
                    AssemblySearchLength = (uint) managementObject.Properties["AssemblySearchLength"].Value,
                    BytesinLoaderHeap = (uint) managementObject.Properties["BytesinLoaderHeap"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Currentappdomains = (uint) managementObject.Properties["Currentappdomains"].Value,
                    CurrentAssemblies = (uint) managementObject.Properties["CurrentAssemblies"].Value,
                    CurrentClassesLoaded = (uint) managementObject.Properties["CurrentClassesLoaded"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PercentTimeLoading = (ulong) managementObject.Properties["PercentTimeLoading"].Value,
                    Rateofappdomains = (uint) managementObject.Properties["Rateofappdomains"].Value,
                    Rateofappdomainsunloaded = (uint) managementObject.Properties["Rateofappdomainsunloaded"].Value,
                    RateofAssemblies = (uint) managementObject.Properties["RateofAssemblies"].Value,
                    RateofClassesLoaded = (uint) managementObject.Properties["RateofClassesLoaded"].Value,
                    RateofLoadFailures = (uint) managementObject.Properties["RateofLoadFailures"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalAppdomains = (uint) managementObject.Properties["TotalAppdomains"].Value,
                    Totalappdomainsunloaded = (uint) managementObject.Properties["Totalappdomainsunloaded"].Value,
                    TotalAssemblies = (uint) managementObject.Properties["TotalAssemblies"].Value,
                    TotalClassesLoaded = (uint) managementObject.Properties["TotalClassesLoaded"].Value,
                    TotalNumberofLoadFailures = (uint) managementObject.Properties["TotalNumberofLoadFailures"].Value
                });

            return list.ToArray();
        }
    }
}