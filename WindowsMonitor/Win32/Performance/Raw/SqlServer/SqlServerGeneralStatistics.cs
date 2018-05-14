using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerGeneralStatistics
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

        public static IEnumerable<SqlServerGeneralStatistics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerGeneralStatistics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerGeneralStatistics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerGeneralStatistics
                {
                     ActiveTempTables = (ulong) (managementObject.Properties["ActiveTempTables"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ConnectionResetPersec = (ulong) (managementObject.Properties["ConnectionResetPersec"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 EventNotificationsDelayedDrop = (ulong) (managementObject.Properties["EventNotificationsDelayedDrop"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 HTTPAuthenticatedRequests = (ulong) (managementObject.Properties["HTTPAuthenticatedRequests"]?.Value ?? default(ulong)),
		 LogicalConnections = (ulong) (managementObject.Properties["LogicalConnections"]?.Value ?? default(ulong)),
		 LoginsPersec = (ulong) (managementObject.Properties["LoginsPersec"]?.Value ?? default(ulong)),
		 LogoutsPersec = (ulong) (managementObject.Properties["LogoutsPersec"]?.Value ?? default(ulong)),
		 MarsDeadlocks = (ulong) (managementObject.Properties["MarsDeadlocks"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Nonatomicyieldrate = (ulong) (managementObject.Properties["Nonatomicyieldrate"]?.Value ?? default(ulong)),
		 Processesblocked = (ulong) (managementObject.Properties["Processesblocked"]?.Value ?? default(ulong)),
		 SOAPEmptyRequests = (ulong) (managementObject.Properties["SOAPEmptyRequests"]?.Value ?? default(ulong)),
		 SOAPMethodInvocations = (ulong) (managementObject.Properties["SOAPMethodInvocations"]?.Value ?? default(ulong)),
		 SOAPSessionInitiateRequests = (ulong) (managementObject.Properties["SOAPSessionInitiateRequests"]?.Value ?? default(ulong)),
		 SOAPSessionTerminateRequests = (ulong) (managementObject.Properties["SOAPSessionTerminateRequests"]?.Value ?? default(ulong)),
		 SOAPSQLRequests = (ulong) (managementObject.Properties["SOAPSQLRequests"]?.Value ?? default(ulong)),
		 SOAPWSDLRequests = (ulong) (managementObject.Properties["SOAPWSDLRequests"]?.Value ?? default(ulong)),
		 SQLTraceIOProviderLockWaits = (ulong) (managementObject.Properties["SQLTraceIOProviderLockWaits"]?.Value ?? default(ulong)),
		 Tempdbrecoveryunitid = (ulong) (managementObject.Properties["Tempdbrecoveryunitid"]?.Value ?? default(ulong)),
		 Tempdbrowsetid = (ulong) (managementObject.Properties["Tempdbrowsetid"]?.Value ?? default(ulong)),
		 TempTablesCreationRate = (ulong) (managementObject.Properties["TempTablesCreationRate"]?.Value ?? default(ulong)),
		 TempTablesForDestruction = (ulong) (managementObject.Properties["TempTablesForDestruction"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TraceEventNotificationQueue = (ulong) (managementObject.Properties["TraceEventNotificationQueue"]?.Value ?? default(ulong)),
		 Transactions = (ulong) (managementObject.Properties["Transactions"]?.Value ?? default(ulong)),
		 UserConnections = (ulong) (managementObject.Properties["UserConnections"]?.Value ?? default(ulong))
                };
        }
    }
}