using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class RoamingUserHealthConfiguration
    {
        public byte HealthStatusForTempProfiles { get; private set; }
        public ushort LastProfileDownloadIntervalCautionInHours { get; private set; }
        public ushort LastProfileDownloadIntervalUnhealthyInHours { get; private set; }
        public ushort LastProfileUploadIntervalCautionInHours { get; private set; }
        public ushort LastProfileUploadIntervalUnhealthyInHours { get; private set; }

        public static RoamingUserHealthConfiguration[] Retrieve(string remote, string username, string password)
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

        public static RoamingUserHealthConfiguration[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static RoamingUserHealthConfiguration[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RoamingUserHealthConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<RoamingUserHealthConfiguration>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new RoamingUserHealthConfiguration
                {
                    HealthStatusForTempProfiles = (byte) managementObject.Properties["HealthStatusForTempProfiles"]
                        .Value,
                    LastProfileDownloadIntervalCautionInHours = (ushort) managementObject
                        .Properties["LastProfileDownloadIntervalCautionInHours"].Value,
                    LastProfileDownloadIntervalUnhealthyInHours = (ushort) managementObject
                        .Properties["LastProfileDownloadIntervalUnhealthyInHours"].Value,
                    LastProfileUploadIntervalCautionInHours = (ushort) managementObject
                        .Properties["LastProfileUploadIntervalCautionInHours"].Value,
                    LastProfileUploadIntervalUnhealthyInHours = (ushort) managementObject
                        .Properties["LastProfileUploadIntervalUnhealthyInHours"].Value
                });

            return list.ToArray();
        }
    }
}