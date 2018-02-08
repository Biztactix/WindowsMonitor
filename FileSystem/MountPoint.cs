using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class MountPoint
    {
        public string Directory { get; private set; }
        public string Volume { get; private set; }

        public static MountPoint[] Retrieve(string remote, string username, string password)
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

        public static MountPoint[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static MountPoint[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_MountPoint");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<MountPoint>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new MountPoint
                {
                    Directory = (string) managementObject.Properties["Directory"].Value,
                    Volume = (string) managementObject.Properties["Volume"].Value
                });

            return list.ToArray();
        }
    }
}