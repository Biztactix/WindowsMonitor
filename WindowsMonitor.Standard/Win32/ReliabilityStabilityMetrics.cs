using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
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

        public static IEnumerable<ReliabilityStabilityMetrics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ReliabilityStabilityMetrics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ReliabilityStabilityMetrics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ReliabilityStabilityMetrics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ReliabilityStabilityMetrics
                {
                     EndMeasurementDate = (DateTime) (managementObject.Properties["EndMeasurementDate"]?.Value ?? default(DateTime)),
		 RelID = (string) (managementObject.Properties["RelID"]?.Value ?? default(string)),
		 StartMeasurementDate = (DateTime) (managementObject.Properties["StartMeasurementDate"]?.Value ?? default(DateTime)),
		 SystemStabilityIndex = (double) (managementObject.Properties["SystemStabilityIndex"]?.Value ?? default(double)),
		 TimeGenerated = (DateTime) (managementObject.Properties["TimeGenerated"]?.Value ?? default(DateTime))
                };
        }
    }
}