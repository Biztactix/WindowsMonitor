using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly
    {
        public ulong Activelogcatchupscans { get; private set; }
        public ulong Activepartitioncopyscans { get; private set; }
        public ulong Activepartitiondeletescans { get; private set; }
        public string Caption { get; private set; }
        public ulong Combinedqueuessizebytes { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Pendingpartitioncopyscans { get; private set; }
        public ulong Pendingpartitiondeletescans { get; private set; }
        public ulong Primarycommittedtransrate { get; private set; }
        public ulong Secondarycommittedtransrate { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly[] Retrieve(string remote,
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

        public static PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_MSSQLSERVER_SQLServerCloudDBReplication_Costly
                {
                    Activelogcatchupscans = (ulong) managementObject.Properties["Activelogcatchupscans"].Value,
                    Activepartitioncopyscans = (ulong) managementObject.Properties["Activepartitioncopyscans"].Value,
                    Activepartitiondeletescans =
                        (ulong) managementObject.Properties["Activepartitiondeletescans"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Combinedqueuessizebytes = (ulong) managementObject.Properties["Combinedqueuessizebytes"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Pendingpartitioncopyscans = (ulong) managementObject.Properties["Pendingpartitioncopyscans"].Value,
                    Pendingpartitiondeletescans = (ulong) managementObject.Properties["Pendingpartitiondeletescans"]
                        .Value,
                    Primarycommittedtransrate = (ulong) managementObject.Properties["Primarycommittedtransrate"].Value,
                    Secondarycommittedtransrate = (ulong) managementObject.Properties["Secondarycommittedtransrate"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}