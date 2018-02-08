using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_Counters_IPHTTPSGlobal
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong DropsNeighborresolutiontimeouts { get; private set; }
        public ulong ErrorsAuthenticationErrors { get; private set; }
        public ulong ErrorsReceiveerrorsontheserver { get; private set; }
        public ulong ErrorsTransmiterrorsontheserver { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong InTotalbytesreceived { get; private set; }
        public ulong InTotalpacketsreceived { get; private set; }
        public string Name { get; private set; }
        public ulong OutTotalbytesforwarded { get; private set; }
        public ulong OutTotalbytessent { get; private set; }
        public ulong OutTotalpacketssent { get; private set; }
        public ulong SessionsTotalsessions { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfFormattedData_Counters_IPHTTPSGlobal[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_Counters_IPHTTPSGlobal[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_Counters_IPHTTPSGlobal[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_IPHTTPSGlobal");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_Counters_IPHTTPSGlobal>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_Counters_IPHTTPSGlobal
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DropsNeighborresolutiontimeouts =
                        (ulong) managementObject.Properties["DropsNeighborresolutiontimeouts"].Value,
                    ErrorsAuthenticationErrors =
                        (ulong) managementObject.Properties["ErrorsAuthenticationErrors"].Value,
                    ErrorsReceiveerrorsontheserver =
                        (ulong) managementObject.Properties["ErrorsReceiveerrorsontheserver"].Value,
                    ErrorsTransmiterrorsontheserver =
                        (ulong) managementObject.Properties["ErrorsTransmiterrorsontheserver"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    InTotalbytesreceived = (ulong) managementObject.Properties["InTotalbytesreceived"].Value,
                    InTotalpacketsreceived = (ulong) managementObject.Properties["InTotalpacketsreceived"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    OutTotalbytesforwarded = (ulong) managementObject.Properties["OutTotalbytesforwarded"].Value,
                    OutTotalbytessent = (ulong) managementObject.Properties["OutTotalbytessent"].Value,
                    OutTotalpacketssent = (ulong) managementObject.Properties["OutTotalpacketssent"].Value,
                    SessionsTotalsessions = (ulong) managementObject.Properties["SessionsTotalsessions"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}