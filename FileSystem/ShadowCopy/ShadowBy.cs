using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ShadowBy
    {
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }

        public static ShadowBy[] Retrieve(string remote, string username, string password)
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

        public static ShadowBy[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ShadowBy[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShadowBy");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ShadowBy>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ShadowBy
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value
                });

            return list.ToArray();
        }
    }
}