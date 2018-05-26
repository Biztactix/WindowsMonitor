using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted.Network.IpSec
{
    /// <summary>
    /// </summary>
    public sealed class CountersIPsecConnections
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public uint Maxnumberofconnectionssinceboot { get; private set; }
		public string Name { get; private set; }
		public ulong Numberoffailedauthentications { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }
		public ulong TotalBytesInsincestart { get; private set; }
		public ulong TotalBytesOutsincestart { get; private set; }
		public uint TotalNumbercurrentConnections { get; private set; }
		public ulong Totalnumberofcumulativeconnectionssinceboot { get; private set; }

        public static IEnumerable<CountersIPsecConnections> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<CountersIPsecConnections> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CountersIPsecConnections> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPsecConnections");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CountersIPsecConnections
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FrequencyObject = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 FrequencyPerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 FrequencySys100Ns = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Maxnumberofconnectionssinceboot = (uint) (managementObject.Properties["Maxnumberofconnectionssinceboot"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Numberoffailedauthentications = (ulong) (managementObject.Properties["Numberoffailedauthentications"]?.Value ?? default(ulong)),
		 TimestampObject = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 TimestampPerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 TimestampSys100Ns = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalBytesInsincestart = (ulong) (managementObject.Properties["TotalBytesInsincestart"]?.Value ?? default(ulong)),
		 TotalBytesOutsincestart = (ulong) (managementObject.Properties["TotalBytesOutsincestart"]?.Value ?? default(ulong)),
		 TotalNumbercurrentConnections = (uint) (managementObject.Properties["TotalNumbercurrentConnections"]?.Value ?? default(uint)),
		 Totalnumberofcumulativeconnectionssinceboot = (ulong) (managementObject.Properties["Totalnumberofcumulativeconnectionssinceboot"]?.Value ?? default(ulong))
                };
        }
    }
}