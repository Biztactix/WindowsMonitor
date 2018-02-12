using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class Counters_IPsecConnections
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint Maxnumberofconnectionssinceboot { get; private set; }
		public string Name { get; private set; }
		public ulong Numberoffailedauthentications { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalBytesInsincestart { get; private set; }
		public ulong TotalBytesOutsincestart { get; private set; }
		public uint TotalNumbercurrentConnections { get; private set; }
		public ulong Totalnumberofcumulativeconnectionssinceboot { get; private set; }

        public static IEnumerable<Counters_IPsecConnections> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_IPsecConnections> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_IPsecConnections> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPsecConnections");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_IPsecConnections
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Maxnumberofconnectionssinceboot = (uint) (managementObject.Properties["Maxnumberofconnectionssinceboot"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Numberoffailedauthentications = (ulong) (managementObject.Properties["Numberoffailedauthentications"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalBytesInsincestart = (ulong) (managementObject.Properties["TotalBytesInsincestart"]?.Value ?? default(ulong)),
		 TotalBytesOutsincestart = (ulong) (managementObject.Properties["TotalBytesOutsincestart"]?.Value ?? default(ulong)),
		 TotalNumbercurrentConnections = (uint) (managementObject.Properties["TotalNumbercurrentConnections"]?.Value ?? default(uint)),
		 Totalnumberofcumulativeconnectionssinceboot = (ulong) (managementObject.Properties["Totalnumberofcumulativeconnectionssinceboot"]?.Value ?? default(ulong))
                };
        }
    }
}