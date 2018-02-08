using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_OfflineFiles_OfflineFiles
    {
        public ulong BytesReceived { get; private set; }
        public ulong BytesReceivedPersec { get; private set; }
        public uint BytesReceivedPersec_Base { get; private set; }
        public ulong BytesTransmitted { get; private set; }
        public ulong BytesTransmittedPersec { get; private set; }
        public uint BytesTransmittedPersec_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_OfflineFiles_OfflineFiles[] Retrieve(string remote, string username, string password)
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

        public static PerfRawData_OfflineFiles_OfflineFiles[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_OfflineFiles_OfflineFiles[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_OfflineFiles_OfflineFiles");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_OfflineFiles_OfflineFiles>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_OfflineFiles_OfflineFiles
                {
                    BytesReceived = (ulong) managementObject.Properties["BytesReceived"].Value,
                    BytesReceivedPersec = (ulong) managementObject.Properties["BytesReceivedPersec"].Value,
                    BytesReceivedPersec_Base = (uint) managementObject.Properties["BytesReceivedPersec_Base"].Value,
                    BytesTransmitted = (ulong) managementObject.Properties["BytesTransmitted"].Value,
                    BytesTransmittedPersec = (ulong) managementObject.Properties["BytesTransmittedPersec"].Value,
                    BytesTransmittedPersec_Base = (uint) managementObject.Properties["BytesTransmittedPersec_Base"]
                        .Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}