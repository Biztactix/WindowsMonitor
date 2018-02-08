using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong Lockwaits { get; private set; }
        public ulong Logbufferwaits { get; private set; }
        public ulong Logwritewaits { get; private set; }
        public ulong Memorygrantqueuewaits { get; private set; }
        public string Name { get; private set; }
        public ulong NetworkIOwaits { get; private set; }
        public ulong NonPagelatchwaits { get; private set; }
        public ulong PageIOlatchwaits { get; private set; }
        public ulong Pagelatchwaits { get; private set; }
        public ulong Threadsafememoryobjectswaits { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong Transactionownershipwaits { get; private set; }
        public ulong Waitfortheworker { get; private set; }
        public ulong Workspacesynchronizationwaits { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics[] Retrieve(string remote,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSWaitStatistics
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Lockwaits = (ulong) managementObject.Properties["Lockwaits"].Value,
                    Logbufferwaits = (ulong) managementObject.Properties["Logbufferwaits"].Value,
                    Logwritewaits = (ulong) managementObject.Properties["Logwritewaits"].Value,
                    Memorygrantqueuewaits = (ulong) managementObject.Properties["Memorygrantqueuewaits"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NetworkIOwaits = (ulong) managementObject.Properties["NetworkIOwaits"].Value,
                    NonPagelatchwaits = (ulong) managementObject.Properties["NonPagelatchwaits"].Value,
                    PageIOlatchwaits = (ulong) managementObject.Properties["PageIOlatchwaits"].Value,
                    Pagelatchwaits = (ulong) managementObject.Properties["Pagelatchwaits"].Value,
                    Threadsafememoryobjectswaits = (ulong) managementObject.Properties["Threadsafememoryobjectswaits"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Transactionownershipwaits = (ulong) managementObject.Properties["Transactionownershipwaits"].Value,
                    Waitfortheworker = (ulong) managementObject.Properties["Waitfortheworker"].Value,
                    Workspacesynchronizationwaits =
                        (ulong) managementObject.Properties["Workspacesynchronizationwaits"].Value
                });

            return list.ToArray();
        }
    }
}