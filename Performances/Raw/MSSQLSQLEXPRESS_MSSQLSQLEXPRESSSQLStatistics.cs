using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics
    {
        public ulong AutoParamAttemptsPersec { get; private set; }
        public ulong BatchRequestsPersec { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong FailedAutoParamsPersec { get; private set; }
        public ulong ForcedParameterizationsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong GuidedplanexecutionsPersec { get; private set; }
        public ulong MisguidedplanexecutionsPersec { get; private set; }
        public string Name { get; private set; }
        public ulong SafeAutoParamsPersec { get; private set; }
        public ulong SQLAttentionrate { get; private set; }
        public ulong SQLCompilationsPersec { get; private set; }
        public ulong SQLReCompilationsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public ulong UnsafeAutoParamsPersec { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics[] Retrieve(string remote,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSSQLStatistics
                {
                    AutoParamAttemptsPersec = (ulong) managementObject.Properties["AutoParamAttemptsPersec"].Value,
                    BatchRequestsPersec = (ulong) managementObject.Properties["BatchRequestsPersec"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FailedAutoParamsPersec = (ulong) managementObject.Properties["FailedAutoParamsPersec"].Value,
                    ForcedParameterizationsPersec =
                        (ulong) managementObject.Properties["ForcedParameterizationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GuidedplanexecutionsPersec =
                        (ulong) managementObject.Properties["GuidedplanexecutionsPersec"].Value,
                    MisguidedplanexecutionsPersec =
                        (ulong) managementObject.Properties["MisguidedplanexecutionsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SafeAutoParamsPersec = (ulong) managementObject.Properties["SafeAutoParamsPersec"].Value,
                    SQLAttentionrate = (ulong) managementObject.Properties["SQLAttentionrate"].Value,
                    SQLCompilationsPersec = (ulong) managementObject.Properties["SQLCompilationsPersec"].Value,
                    SQLReCompilationsPersec = (ulong) managementObject.Properties["SQLReCompilationsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UnsafeAutoParamsPersec = (ulong) managementObject.Properties["UnsafeAutoParamsPersec"].Value
                });

            return list.ToArray();
        }
    }
}