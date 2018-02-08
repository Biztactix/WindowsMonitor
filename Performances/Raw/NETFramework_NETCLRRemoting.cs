using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_NETFramework_NETCLRRemoting
    {
        public string Caption { get; private set; }
        public uint Channels { get; private set; }
        public uint ContextBoundClassesLoaded { get; private set; }
        public uint ContextBoundObjectsAllocPersec { get; private set; }
        public uint ContextProxies { get; private set; }
        public uint Contexts { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint RemoteCallsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalRemoteCalls { get; private set; }

        public static PerfRawData_NETFramework_NETCLRRemoting[] Retrieve(string remote, string username,
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

        public static PerfRawData_NETFramework_NETCLRRemoting[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_NETFramework_NETCLRRemoting[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETFramework_NETCLRRemoting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_NETFramework_NETCLRRemoting>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_NETFramework_NETCLRRemoting
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Channels = (uint) managementObject.Properties["Channels"].Value,
                    ContextBoundClassesLoaded = (uint) managementObject.Properties["ContextBoundClassesLoaded"].Value,
                    ContextBoundObjectsAllocPersec =
                        (uint) managementObject.Properties["ContextBoundObjectsAllocPersec"].Value,
                    ContextProxies = (uint) managementObject.Properties["ContextProxies"].Value,
                    Contexts = (uint) managementObject.Properties["Contexts"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    RemoteCallsPersec = (uint) managementObject.Properties["RemoteCallsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalRemoteCalls = (uint) managementObject.Properties["TotalRemoteCalls"].Value
                });

            return list.ToArray();
        }
    }
}