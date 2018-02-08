using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager
    {
        public ulong BackgroundwriterpagesPersec { get; private set; }
        public ulong Buffercachehitratio { get; private set; }
        public string Caption { get; private set; }
        public ulong CheckpointpagesPersec { get; private set; }
        public ulong Databasepages { get; private set; }
        public string Description { get; private set; }
        public ulong Extensionallocatedpages { get; private set; }
        public ulong Extensionfreepages { get; private set; }
        public ulong Extensioninuseaspercentage { get; private set; }
        public ulong ExtensionoutstandingIOcounter { get; private set; }
        public ulong ExtensionpageevictionsPersec { get; private set; }
        public ulong ExtensionpagereadsPersec { get; private set; }
        public ulong Extensionpageunreferencedtime { get; private set; }
        public ulong ExtensionpagewritesPersec { get; private set; }
        public ulong FreeliststallsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong IntegralControllerSlope { get; private set; }
        public ulong LazywritesPersec { get; private set; }
        public string Name { get; private set; }
        public ulong Pagelifeexpectancy { get; private set; }
        public ulong PagelookupsPersec { get; private set; }
        public ulong PagereadsPersec { get; private set; }
        public ulong PagewritesPersec { get; private set; }
        public ulong ReadaheadpagesPersec { get; private set; }
        public ulong ReadaheadtimePersec { get; private set; }
        public ulong Targetpages { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBufferManager
                {
                    BackgroundwriterpagesPersec = (ulong) managementObject.Properties["BackgroundwriterpagesPersec"]
                        .Value,
                    Buffercachehitratio = (ulong) managementObject.Properties["Buffercachehitratio"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CheckpointpagesPersec = (ulong) managementObject.Properties["CheckpointpagesPersec"].Value,
                    Databasepages = (ulong) managementObject.Properties["Databasepages"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Extensionallocatedpages = (ulong) managementObject.Properties["Extensionallocatedpages"].Value,
                    Extensionfreepages = (ulong) managementObject.Properties["Extensionfreepages"].Value,
                    Extensioninuseaspercentage =
                        (ulong) managementObject.Properties["Extensioninuseaspercentage"].Value,
                    ExtensionoutstandingIOcounter =
                        (ulong) managementObject.Properties["ExtensionoutstandingIOcounter"].Value,
                    ExtensionpageevictionsPersec = (ulong) managementObject.Properties["ExtensionpageevictionsPersec"]
                        .Value,
                    ExtensionpagereadsPersec = (ulong) managementObject.Properties["ExtensionpagereadsPersec"].Value,
                    Extensionpageunreferencedtime =
                        (ulong) managementObject.Properties["Extensionpageunreferencedtime"].Value,
                    ExtensionpagewritesPersec = (ulong) managementObject.Properties["ExtensionpagewritesPersec"].Value,
                    FreeliststallsPersec = (ulong) managementObject.Properties["FreeliststallsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IntegralControllerSlope = (ulong) managementObject.Properties["IntegralControllerSlope"].Value,
                    LazywritesPersec = (ulong) managementObject.Properties["LazywritesPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Pagelifeexpectancy = (ulong) managementObject.Properties["Pagelifeexpectancy"].Value,
                    PagelookupsPersec = (ulong) managementObject.Properties["PagelookupsPersec"].Value,
                    PagereadsPersec = (ulong) managementObject.Properties["PagereadsPersec"].Value,
                    PagewritesPersec = (ulong) managementObject.Properties["PagewritesPersec"].Value,
                    ReadaheadpagesPersec = (ulong) managementObject.Properties["ReadaheadpagesPersec"].Value,
                    ReadaheadtimePersec = (ulong) managementObject.Properties["ReadaheadtimePersec"].Value,
                    Targetpages = (ulong) managementObject.Properties["Targetpages"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}