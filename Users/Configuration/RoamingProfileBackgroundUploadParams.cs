using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class RoamingProfileBackgroundUploadParams
    {
        public ushort Interval { get; private set; }
        public byte SchedulingMethod { get; private set; }
        public ushort Time { get; private set; }

        public static RoamingProfileBackgroundUploadParams[] Retrieve(string remote, string username, string password)
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

        public static RoamingProfileBackgroundUploadParams[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static RoamingProfileBackgroundUploadParams[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RoamingProfileBackgroundUploadParams");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<RoamingProfileBackgroundUploadParams>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new RoamingProfileBackgroundUploadParams
                {
                    Interval = (ushort) managementObject.Properties["Interval"].Value,
                    SchedulingMethod = (byte) managementObject.Properties["SchedulingMethod"].Value,
                    Time = (ushort) managementObject.Properties["Time"].Value
                });

            return list.ToArray();
        }
    }
}