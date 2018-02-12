using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRRemoting
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

        public static IEnumerable<NETFramework_NETCLRRemoting> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRRemoting> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRRemoting> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETFramework_NETCLRRemoting");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRRemoting
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Channels = (uint) (managementObject.Properties["Channels"]?.Value ?? default(uint)),
		 ContextBoundClassesLoaded = (uint) (managementObject.Properties["ContextBoundClassesLoaded"]?.Value ?? default(uint)),
		 ContextBoundObjectsAllocPersec = (uint) (managementObject.Properties["ContextBoundObjectsAllocPersec"]?.Value ?? default(uint)),
		 ContextProxies = (uint) (managementObject.Properties["ContextProxies"]?.Value ?? default(uint)),
		 Contexts = (uint) (managementObject.Properties["Contexts"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 RemoteCallsPersec = (uint) (managementObject.Properties["RemoteCallsPersec"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalRemoteCalls = (uint) (managementObject.Properties["TotalRemoteCalls"]?.Value ?? default(uint))
                };
        }
    }
}