using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ReliabilityStabilityMetrics
    {
        public DateTime EndMeasurementDate { get; private set; }
        public string RelID { get; private set; }
        public DateTime StartMeasurementDate { get; private set; }
        public double SystemStabilityIndex { get; private set; }
        public DateTime TimeGenerated { get; private set; }

        public static ReliabilityStabilityMetrics[] Retrieve(string remote, string username, string password)
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

        public static ReliabilityStabilityMetrics[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ReliabilityStabilityMetrics[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ReliabilityStabilityMetrics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ReliabilityStabilityMetrics>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ReliabilityStabilityMetrics
                {
                    EndMeasurementDate = (DateTime) managementObject.Properties["EndMeasurementDate"].Value,
                    RelID = (string) managementObject.Properties["RelID"].Value,
                    StartMeasurementDate = (DateTime) managementObject.Properties["StartMeasurementDate"].Value,
                    SystemStabilityIndex = (double) managementObject.Properties["SystemStabilityIndex"].Value,
                    TimeGenerated = (DateTime) managementObject.Properties["TimeGenerated"].Value
                });

            return list.ToArray();
        }
    }
}