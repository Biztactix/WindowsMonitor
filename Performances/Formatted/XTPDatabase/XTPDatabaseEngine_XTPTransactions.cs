using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_XTPDatabaseEngine_XTPTransactions
    {
        public string Caption { get; private set; }
        public uint CascadingabortsPersec { get; private set; }
        public uint CommitdependenciestakenPersec { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint ReadonlytransactionspreparedPersec { get; private set; }
        public uint SavepointrefreshesPersec { get; private set; }
        public uint SavepointrollbacksPersec { get; private set; }
        public uint SavepointscreatedPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TransactionsabortedbyuserPersec { get; private set; }
        public uint TransactionsabortedPersec { get; private set; }
        public uint TransactionscreatedPersec { get; private set; }
        public uint TransactionvalidationfailuresPersec { get; private set; }

        public static PerfFormattedData_XTPDatabaseEngine_XTPTransactions[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_XTPDatabaseEngine_XTPTransactions[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_XTPDatabaseEngine_XTPTransactions[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_XTPDatabaseEngine_XTPTransactions");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_XTPDatabaseEngine_XTPTransactions>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_XTPDatabaseEngine_XTPTransactions
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CascadingabortsPersec = (uint) managementObject.Properties["CascadingabortsPersec"].Value,
                    CommitdependenciestakenPersec = (uint) managementObject.Properties["CommitdependenciestakenPersec"]
                        .Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ReadonlytransactionspreparedPersec =
                        (uint) managementObject.Properties["ReadonlytransactionspreparedPersec"].Value,
                    SavepointrefreshesPersec = (uint) managementObject.Properties["SavepointrefreshesPersec"].Value,
                    SavepointrollbacksPersec = (uint) managementObject.Properties["SavepointrollbacksPersec"].Value,
                    SavepointscreatedPersec = (uint) managementObject.Properties["SavepointscreatedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionsabortedbyuserPersec =
                        (uint) managementObject.Properties["TransactionsabortedbyuserPersec"].Value,
                    TransactionsabortedPersec = (uint) managementObject.Properties["TransactionsabortedPersec"].Value,
                    TransactionscreatedPersec = (uint) managementObject.Properties["TransactionscreatedPersec"].Value,
                    TransactionvalidationfailuresPersec =
                        (uint) managementObject.Properties["TransactionvalidationfailuresPersec"].Value
                });

            return list.ToArray();
        }
    }
}