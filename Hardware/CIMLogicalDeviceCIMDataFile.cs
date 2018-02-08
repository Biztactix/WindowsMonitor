using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class CIMLogicalDeviceCIMDataFile
    {
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }
        public ushort Purpose { get; private set; }
        public string PurposeDescription { get; private set; }

        public static CIMLogicalDeviceCIMDataFile[] Retrieve(string remote, string username, string password)
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

        public static CIMLogicalDeviceCIMDataFile[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static CIMLogicalDeviceCIMDataFile[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_CIMLogicalDeviceCIMDataFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<CIMLogicalDeviceCIMDataFile>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new CIMLogicalDeviceCIMDataFile
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value,
                    Purpose = (ushort) managementObject.Properties["Purpose"].Value,
                    PurposeDescription = (string) managementObject.Properties["PurposeDescription"].Value
                });

            return list.ToArray();
        }
    }
}