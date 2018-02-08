using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly
    {
        public ulong AGEresponsesreceivedPersec { get; private set; }
        public ulong AveragelifeofAGEbroadcast { get; private set; }
        public uint AveragelifeofAGEbroadcast_Base { get; private set; }
        public ulong AvgAGEhardeningtime { get; private set; }
        public uint AvgAGEhardeningtime_Base { get; private set; }
        public ulong AvgsizeofAGEMessage { get; private set; }
        public uint AvgsizeofAGEMessage_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong NumberofAGEbroadcastsPersec { get; private set; }
        public ulong OrdersbroadcastPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly[] Retrieve(string remote,
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

        public static PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly
                {
                    AGEresponsesreceivedPersec =
                        (ulong) managementObject.Properties["AGEresponsesreceivedPersec"].Value,
                    AveragelifeofAGEbroadcast = (ulong) managementObject.Properties["AveragelifeofAGEbroadcast"].Value,
                    AveragelifeofAGEbroadcast_Base =
                        (uint) managementObject.Properties["AveragelifeofAGEbroadcast_Base"].Value,
                    AvgAGEhardeningtime = (ulong) managementObject.Properties["AvgAGEhardeningtime"].Value,
                    AvgAGEhardeningtime_Base = (uint) managementObject.Properties["AvgAGEhardeningtime_Base"].Value,
                    AvgsizeofAGEMessage = (ulong) managementObject.Properties["AvgsizeofAGEMessage"].Value,
                    AvgsizeofAGEMessage_Base = (uint) managementObject.Properties["AvgsizeofAGEMessage_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberofAGEbroadcastsPersec = (ulong) managementObject.Properties["NumberofAGEbroadcastsPersec"]
                        .Value,
                    OrdersbroadcastPersec = (ulong) managementObject.Properties["OrdersbroadcastPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}