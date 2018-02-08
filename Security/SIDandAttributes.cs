using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SIDandAttributes
    {
        public uint Attributes { get; private set; }
        public object SID { get; private set; }

        public static SIDandAttributes[] Retrieve(string remote, string username, string password)
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

        public static SIDandAttributes[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SIDandAttributes[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SIDandAttributes");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SIDandAttributes>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SIDandAttributes
                {
                    Attributes = (uint) managementObject.Properties["Attributes"].Value,
                    SID = managementObject.Properties["SID"].Value
                });

            return list.ToArray();
        }
    }
}