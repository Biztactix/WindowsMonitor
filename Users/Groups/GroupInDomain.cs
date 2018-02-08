using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class GroupInDomain
    {
        public string GroupComponent { get; private set; }
        public string PartComponent { get; private set; }

        public static GroupInDomain[] Retrieve(string remote, string username, string password)
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

        public static GroupInDomain[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static GroupInDomain[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_GroupInDomain");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<GroupInDomain>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new GroupInDomain
                {
                    GroupComponent = (string) managementObject.Properties["GroupComponent"].Value,
                    PartComponent = (string) managementObject.Properties["PartComponent"].Value
                });

            return list.ToArray();
        }
    }
}