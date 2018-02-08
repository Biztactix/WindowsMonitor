using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_HTTPServiceUrlGroups
    {
        public uint AllRequests { get; private set; }
        public ulong BytesReceivedRate { get; private set; }
        public ulong BytesSentRate { get; private set; }
        public ulong BytesTransferredRate { get; private set; }
        public string Caption { get; private set; }
        public uint ConnectionAttempts { get; private set; }
        public uint CurrentConnections { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint GetRequests { get; private set; }
        public uint HeadRequests { get; private set; }
        public uint MaxConnections { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_HTTPServiceUrlGroups[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_HTTPServiceUrlGroups[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_HTTPServiceUrlGroups[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_HTTPServiceUrlGroups");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_HTTPServiceUrlGroups>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_HTTPServiceUrlGroups
                {
                    AllRequests = (uint) managementObject.Properties["AllRequests"].Value,
                    BytesReceivedRate = (ulong) managementObject.Properties["BytesReceivedRate"].Value,
                    BytesSentRate = (ulong) managementObject.Properties["BytesSentRate"].Value,
                    BytesTransferredRate = (ulong) managementObject.Properties["BytesTransferredRate"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionAttempts = (uint) managementObject.Properties["ConnectionAttempts"].Value,
                    CurrentConnections = (uint) managementObject.Properties["CurrentConnections"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    GetRequests = (uint) managementObject.Properties["GetRequests"].Value,
                    HeadRequests = (uint) managementObject.Properties["HeadRequests"].Value,
                    MaxConnections = (uint) managementObject.Properties["MaxConnections"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}