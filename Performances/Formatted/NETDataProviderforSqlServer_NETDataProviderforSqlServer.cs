using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint HardConnectsPerSecond { get; private set; }
        public uint HardDisconnectsPerSecond { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfActiveConnectionPoolGroups { get; private set; }
        public uint NumberOfActiveConnectionPools { get; private set; }
        public uint NumberOfActiveConnections { get; private set; }
        public uint NumberOfFreeConnections { get; private set; }
        public uint NumberOfInactiveConnectionPoolGroups { get; private set; }
        public uint NumberOfInactiveConnectionPools { get; private set; }
        public uint NumberOfNonPooledConnections { get; private set; }
        public uint NumberOfPooledConnections { get; private set; }
        public uint NumberOfReclaimedConnections { get; private set; }
        public uint NumberOfStasisConnections { get; private set; }
        public uint SoftConnectsPerSecond { get; private set; }
        public uint SoftDisconnectsPerSecond { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer[] Retrieve(
            string remote, string username, string password)
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

        public static PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HardConnectsPerSecond = (uint) managementObject.Properties["HardConnectsPerSecond"].Value,
                    HardDisconnectsPerSecond = (uint) managementObject.Properties["HardDisconnectsPerSecond"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfActiveConnectionPoolGroups =
                        (uint) managementObject.Properties["NumberOfActiveConnectionPoolGroups"].Value,
                    NumberOfActiveConnectionPools = (uint) managementObject.Properties["NumberOfActiveConnectionPools"]
                        .Value,
                    NumberOfActiveConnections = (uint) managementObject.Properties["NumberOfActiveConnections"].Value,
                    NumberOfFreeConnections = (uint) managementObject.Properties["NumberOfFreeConnections"].Value,
                    NumberOfInactiveConnectionPoolGroups = (uint) managementObject
                        .Properties["NumberOfInactiveConnectionPoolGroups"].Value,
                    NumberOfInactiveConnectionPools =
                        (uint) managementObject.Properties["NumberOfInactiveConnectionPools"].Value,
                    NumberOfNonPooledConnections = (uint) managementObject.Properties["NumberOfNonPooledConnections"]
                        .Value,
                    NumberOfPooledConnections = (uint) managementObject.Properties["NumberOfPooledConnections"].Value,
                    NumberOfReclaimedConnections = (uint) managementObject.Properties["NumberOfReclaimedConnections"]
                        .Value,
                    NumberOfStasisConnections = (uint) managementObject.Properties["NumberOfStasisConnections"].Value,
                    SoftConnectsPerSecond = (uint) managementObject.Properties["SoftConnectsPerSecond"].Value,
                    SoftDisconnectsPerSecond = (uint) managementObject.Properties["SoftDisconnectsPerSecond"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}