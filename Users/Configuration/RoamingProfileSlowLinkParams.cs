using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class RoamingProfileSlowLinkParams
    {
        public uint ConnectionTransferRate { get; private set; }
        public ushort TimeOut { get; private set; }

        public static RoamingProfileSlowLinkParams[] Retrieve(string remote, string username, string password)
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

        public static RoamingProfileSlowLinkParams[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static RoamingProfileSlowLinkParams[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_RoamingProfileSlowLinkParams");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<RoamingProfileSlowLinkParams>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new RoamingProfileSlowLinkParams
                {
                    ConnectionTransferRate = (uint) managementObject.Properties["ConnectionTransferRate"].Value,
                    TimeOut = (ushort) managementObject.Properties["TimeOut"].Value
                });

            return list.ToArray();
        }
    }
}