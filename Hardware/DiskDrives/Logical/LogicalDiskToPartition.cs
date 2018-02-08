using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LogicalDiskToPartition
    {
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }
        public ulong EndingAddress { get; private set; }
        public ulong StartingAddress { get; private set; }

        public static LogicalDiskToPartition[] Retrieve(string remote, string username, string password)
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

        public static LogicalDiskToPartition[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LogicalDiskToPartition[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogicalDiskToPartition");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LogicalDiskToPartition>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LogicalDiskToPartition
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value,
                    EndingAddress = (ulong) managementObject.Properties["EndingAddress"].Value,
                    StartingAddress = (ulong) managementObject.Properties["StartingAddress"].Value
                });

            return list.ToArray();
        }
    }
}