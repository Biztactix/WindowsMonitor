using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_HTTPServiceUrlGroups
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

        public static IEnumerable<Counters_HTTPServiceUrlGroups> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_HTTPServiceUrlGroups> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_HTTPServiceUrlGroups> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_HTTPServiceUrlGroups");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_HTTPServiceUrlGroups
                {
                     AllRequests = (uint) (managementObject.Properties["AllRequests"]?.Value ?? default(uint)),
		 BytesReceivedRate = (ulong) (managementObject.Properties["BytesReceivedRate"]?.Value ?? default(ulong)),
		 BytesSentRate = (ulong) (managementObject.Properties["BytesSentRate"]?.Value ?? default(ulong)),
		 BytesTransferredRate = (ulong) (managementObject.Properties["BytesTransferredRate"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ConnectionAttempts = (uint) (managementObject.Properties["ConnectionAttempts"]?.Value ?? default(uint)),
		 CurrentConnections = (uint) (managementObject.Properties["CurrentConnections"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 GetRequests = (uint) (managementObject.Properties["GetRequests"]?.Value ?? default(uint)),
		 HeadRequests = (uint) (managementObject.Properties["HeadRequests"]?.Value ?? default(uint)),
		 MaxConnections = (uint) (managementObject.Properties["MaxConnections"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}