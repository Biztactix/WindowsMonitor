using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class GroupUser
    {
        public string GroupComponent { get; private set; }
        public string PartComponent { get; private set; }

        public static GroupUser[] Retrieve(string remote, string username, string password)
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

        public static GroupUser[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static GroupUser[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_GroupUser");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<GroupUser>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new GroupUser
                {
                    GroupComponent = (string) managementObject.Properties["GroupComponent"].Value,
                    PartComponent = (string) managementObject.Properties["PartComponent"].Value
                });

            return list.ToArray();
        }
    }
}