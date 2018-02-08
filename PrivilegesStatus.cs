using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PrivilegesStatus
    {
        public string Description { get; private set; }
        public string Operation { get; private set; }
        public string ParameterInfo { get; private set; }
        public string[] PrivilegesNotHeld { get; private set; }
        public string[] PrivilegesRequired { get; private set; }
        public string ProviderName { get; private set; }
        public uint StatusCode { get; private set; }

        public static PrivilegesStatus[] Retrieve(string remote, string username, string password)
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

        public static PrivilegesStatus[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PrivilegesStatus[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrivilegesStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PrivilegesStatus>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PrivilegesStatus
                {
                    Description = (string) managementObject.Properties["Description"].Value,
                    Operation = (string) managementObject.Properties["Operation"].Value,
                    ParameterInfo = (string) managementObject.Properties["ParameterInfo"].Value,
                    PrivilegesNotHeld = (string[]) managementObject.Properties["PrivilegesNotHeld"].Value,
                    PrivilegesRequired = (string[]) managementObject.Properties["PrivilegesRequired"].Value,
                    ProviderName = (string) managementObject.Properties["ProviderName"].Value,
                    StatusCode = (uint) managementObject.Properties["StatusCode"].Value
                });

            return list.ToArray();
        }
    }
}