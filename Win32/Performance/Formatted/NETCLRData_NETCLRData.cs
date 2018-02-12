using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class NETCLRData_NETCLRData
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint SqlClientCurrentNumberconnectionpools { get; private set; }
		public uint SqlClientCurrentNumberpooledandnonpooledconnections { get; private set; }
		public uint SqlClientCurrentNumberpooledconnections { get; private set; }
		public uint SqlClientPeakNumberpooledconnections { get; private set; }
		public uint SqlClientTotalNumberfailedcommands { get; private set; }
		public uint SqlClientTotalNumberfailedconnects { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<NETCLRData_NETCLRData> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETCLRData_NETCLRData> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETCLRData_NETCLRData> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_NETCLRData_NETCLRData");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETCLRData_NETCLRData
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SqlClientCurrentNumberconnectionpools = (uint) (managementObject.Properties["SqlClientCurrentNumberconnectionpools"]?.Value ?? default(uint)),
		 SqlClientCurrentNumberpooledandnonpooledconnections = (uint) (managementObject.Properties["SqlClientCurrentNumberpooledandnonpooledconnections"]?.Value ?? default(uint)),
		 SqlClientCurrentNumberpooledconnections = (uint) (managementObject.Properties["SqlClientCurrentNumberpooledconnections"]?.Value ?? default(uint)),
		 SqlClientPeakNumberpooledconnections = (uint) (managementObject.Properties["SqlClientPeakNumberpooledconnections"]?.Value ?? default(uint)),
		 SqlClientTotalNumberfailedcommands = (uint) (managementObject.Properties["SqlClientTotalNumberfailedcommands"]?.Value ?? default(uint)),
		 SqlClientTotalNumberfailedconnects = (uint) (managementObject.Properties["SqlClientTotalNumberfailedconnects"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}