using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_CcmFramework_CCMMessageQueue
    {
        public ulong BytesQueued { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public ulong MessagesCompleted { get; private set; }
        public uint MessagesCompletedPersecond { get; private set; }
        public ulong MessagesQueued { get; private set; }
        public ulong MessagesReceived { get; private set; }
        public uint MessagesReceivedPersecond { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_CcmFramework_CCMMessageQueue[] Retrieve(string remote, string username,
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

        public static PerfRawData_CcmFramework_CCMMessageQueue[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_CcmFramework_CCMMessageQueue[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_CcmFramework_CCMMessageQueue");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_CcmFramework_CCMMessageQueue>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_CcmFramework_CCMMessageQueue
                {
                    BytesQueued = (ulong) managementObject.Properties["BytesQueued"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    MessagesCompleted = (ulong) managementObject.Properties["MessagesCompleted"].Value,
                    MessagesCompletedPersecond = (uint) managementObject.Properties["MessagesCompletedPersecond"].Value,
                    MessagesQueued = (ulong) managementObject.Properties["MessagesQueued"].Value,
                    MessagesReceived = (ulong) managementObject.Properties["MessagesReceived"].Value,
                    MessagesReceivedPersecond = (uint) managementObject.Properties["MessagesReceivedPersecond"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}