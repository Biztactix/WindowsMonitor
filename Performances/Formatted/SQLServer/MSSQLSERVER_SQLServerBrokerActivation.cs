using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong StoredProceduresInvokedPersec { get; private set; }
        public ulong TaskLimitReached { get; private set; }
        public ulong TaskLimitReachedPersec { get; private set; }
        public ulong TasksAbortedPersec { get; private set; }
        public ulong TasksRunning { get; private set; }
        public ulong TasksStartedPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerBrokerActivation
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    StoredProceduresInvokedPersec =
                        (ulong) managementObject.Properties["StoredProceduresInvokedPersec"].Value,
                    TaskLimitReached = (ulong) managementObject.Properties["TaskLimitReached"].Value,
                    TaskLimitReachedPersec = (ulong) managementObject.Properties["TaskLimitReachedPersec"].Value,
                    TasksAbortedPersec = (ulong) managementObject.Properties["TasksAbortedPersec"].Value,
                    TasksRunning = (ulong) managementObject.Properties["TasksRunning"].Value,
                    TasksStartedPersec = (ulong) managementObject.Properties["TasksStartedPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}