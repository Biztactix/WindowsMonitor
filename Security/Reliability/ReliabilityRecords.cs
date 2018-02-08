using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ReliabilityRecords
    {
        public string ComputerName { get; private set; }
        public uint EventIdentifier { get; private set; }
        public string[] InsertionStrings { get; private set; }
        public string Logfile { get; private set; }
        public string Message { get; private set; }
        public string ProductName { get; private set; }
        public uint RecordNumber { get; private set; }
        public string SourceName { get; private set; }
        public DateTime TimeGenerated { get; private set; }
        public string User { get; private set; }

        public static ReliabilityRecords[] Retrieve(string remote, string username, string password)
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

        public static ReliabilityRecords[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ReliabilityRecords[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ReliabilityRecords");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ReliabilityRecords>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ReliabilityRecords
                {
                    ComputerName = (string) managementObject.Properties["ComputerName"].Value,
                    EventIdentifier = (uint) managementObject.Properties["EventIdentifier"].Value,
                    InsertionStrings = (string[]) managementObject.Properties["InsertionStrings"].Value,
                    Logfile = (string) managementObject.Properties["Logfile"].Value,
                    Message = (string) managementObject.Properties["Message"].Value,
                    ProductName = (string) managementObject.Properties["ProductName"].Value,
                    RecordNumber = (uint) managementObject.Properties["RecordNumber"].Value,
                    SourceName = (string) managementObject.Properties["SourceName"].Value,
                    TimeGenerated = (DateTime) managementObject.Properties["TimeGenerated"].Value,
                    User = (string) managementObject.Properties["User"].Value
                });

            return list.ToArray();
        }
    }
}