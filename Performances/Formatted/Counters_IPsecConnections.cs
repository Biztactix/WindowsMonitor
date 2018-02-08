using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_IPsecConnections
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

        public static PerfFormattedData_Counters_IPsecConnections[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_IPsecConnections[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_IPsecConnections[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPsecConnections");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_IPsecConnections>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_IPsecConnections
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Maxnumberofconnectionssinceboot =
                        (uint) managementObject.Properties["Maxnumberofconnectionssinceboot"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Numberoffailedauthentications =
                        (ulong) managementObject.Properties["Numberoffailedauthentications"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalBytesInsincestart = (ulong) managementObject.Properties["TotalBytesInsincestart"].Value,
                    TotalBytesOutsincestart = (ulong) managementObject.Properties["TotalBytesOutsincestart"].Value,
                    TotalNumbercurrentConnections = (uint) managementObject.Properties["TotalNumbercurrentConnections"]
                        .Value,
                    Totalnumberofcumulativeconnectionssinceboot = (ulong) managementObject
                        .Properties["Totalnumberofcumulativeconnectionssinceboot"].Value
                });

            return list.ToArray();
        }
    }
}