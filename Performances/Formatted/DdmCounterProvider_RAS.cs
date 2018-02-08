using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_DdmCounterProvider_RAS
    {
        public ulong BytesReceivedByDisconnectedClients { get; private set; }
        public ulong BytesTransmittedByDisconnectedClients { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint FailedAuthentications { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint MaxClients { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint TotalClients { get; private set; }

        public static PerfFormattedData_DdmCounterProvider_RAS[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_DdmCounterProvider_RAS[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_DdmCounterProvider_RAS[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_DdmCounterProvider_RAS");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_DdmCounterProvider_RAS>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_DdmCounterProvider_RAS
                {
                    BytesReceivedByDisconnectedClients =
                        (ulong) managementObject.Properties["BytesReceivedByDisconnectedClients"].Value,
                    BytesTransmittedByDisconnectedClients = (ulong) managementObject
                        .Properties["BytesTransmittedByDisconnectedClients"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FailedAuthentications = (uint) managementObject.Properties["FailedAuthentications"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MaxClients = (uint) managementObject.Properties["MaxClients"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TotalClients = (uint) managementObject.Properties["TotalClients"].Value
                });

            return list.ToArray();
        }
    }
}