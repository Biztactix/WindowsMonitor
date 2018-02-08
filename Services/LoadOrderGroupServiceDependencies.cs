using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LoadOrderGroupServiceDependencies
    {
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }

        public static LoadOrderGroupServiceDependencies[] Retrieve(string remote, string username, string password)
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

        public static LoadOrderGroupServiceDependencies[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LoadOrderGroupServiceDependencies[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LoadOrderGroupServiceDependencies");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LoadOrderGroupServiceDependencies>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LoadOrderGroupServiceDependencies
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value
                });

            return list.ToArray();
        }
    }
}