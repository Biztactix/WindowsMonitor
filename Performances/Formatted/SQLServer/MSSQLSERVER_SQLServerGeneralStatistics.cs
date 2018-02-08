using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics
    {
        public ulong ActiveTempTables { get; private set; }
        public string Caption { get; private set; }
        public ulong ConnectionResetPersec { get; private set; }
        public string Description { get; private set; }
        public ulong EventNotificationsDelayedDrop { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong HTTPAuthenticatedRequests { get; private set; }
        public ulong LogicalConnections { get; private set; }
        public ulong LoginsPersec { get; private set; }
        public ulong LogoutsPersec { get; private set; }
        public ulong MarsDeadlocks { get; private set; }
        public string Name { get; private set; }
        public ulong Nonatomicyieldrate { get; private set; }
        public ulong Processesblocked { get; private set; }
        public ulong SOAPEmptyRequests { get; private set; }
        public ulong SOAPMethodInvocations { get; private set; }
        public ulong SOAPSessionInitiateRequests { get; private set; }
        public ulong SOAPSessionTerminateRequests { get; private set; }
        public ulong SOAPSQLRequests { get; private set; }
        public ulong SOAPWSDLRequests { get; private set; }
        public ulong SQLTraceIOProviderLockWaits { get; private set; }
        public ulong Tempdbrecoveryunitid { get; private set; }
        public ulong Tempdbrowsetid { get; private set; }
        public ulong TempTablesCreationRate { get; private set; }
        public ulong TempTablesForDestruction { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong TraceEventNotificationQueue { get; private set; }
        public ulong Transactions { get; private set; }
        public ulong UserConnections { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerGeneralStatistics
                {
                    ActiveTempTables = (ulong) managementObject.Properties["ActiveTempTables"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionResetPersec = (ulong) managementObject.Properties["ConnectionResetPersec"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EventNotificationsDelayedDrop =
                        (ulong) managementObject.Properties["EventNotificationsDelayedDrop"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    HTTPAuthenticatedRequests = (ulong) managementObject.Properties["HTTPAuthenticatedRequests"].Value,
                    LogicalConnections = (ulong) managementObject.Properties["LogicalConnections"].Value,
                    LoginsPersec = (ulong) managementObject.Properties["LoginsPersec"].Value,
                    LogoutsPersec = (ulong) managementObject.Properties["LogoutsPersec"].Value,
                    MarsDeadlocks = (ulong) managementObject.Properties["MarsDeadlocks"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Nonatomicyieldrate = (ulong) managementObject.Properties["Nonatomicyieldrate"].Value,
                    Processesblocked = (ulong) managementObject.Properties["Processesblocked"].Value,
                    SOAPEmptyRequests = (ulong) managementObject.Properties["SOAPEmptyRequests"].Value,
                    SOAPMethodInvocations = (ulong) managementObject.Properties["SOAPMethodInvocations"].Value,
                    SOAPSessionInitiateRequests = (ulong) managementObject.Properties["SOAPSessionInitiateRequests"]
                        .Value,
                    SOAPSessionTerminateRequests = (ulong) managementObject.Properties["SOAPSessionTerminateRequests"]
                        .Value,
                    SOAPSQLRequests = (ulong) managementObject.Properties["SOAPSQLRequests"].Value,
                    SOAPWSDLRequests = (ulong) managementObject.Properties["SOAPWSDLRequests"].Value,
                    SQLTraceIOProviderLockWaits = (ulong) managementObject.Properties["SQLTraceIOProviderLockWaits"]
                        .Value,
                    Tempdbrecoveryunitid = (ulong) managementObject.Properties["Tempdbrecoveryunitid"].Value,
                    Tempdbrowsetid = (ulong) managementObject.Properties["Tempdbrowsetid"].Value,
                    TempTablesCreationRate = (ulong) managementObject.Properties["TempTablesCreationRate"].Value,
                    TempTablesForDestruction = (ulong) managementObject.Properties["TempTablesForDestruction"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TraceEventNotificationQueue = (ulong) managementObject.Properties["TraceEventNotificationQueue"]
                        .Value,
                    Transactions = (ulong) managementObject.Properties["Transactions"].Value,
                    UserConnections = (ulong) managementObject.Properties["UserConnections"].Value
                });

            return list.ToArray();
        }
    }
}