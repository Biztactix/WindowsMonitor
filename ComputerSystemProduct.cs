using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ComputerSystemProduct
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string IdentifyingNumber { get; private set; }
        public string Name { get; private set; }
        public string SKUNumber { get; private set; }
        public string UUID { get; private set; }
        public string Vendor { get; private set; }
        public string Version { get; private set; }

        public static ComputerSystemProduct[] Retrieve(string remote, string username, string password)
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

        public static ComputerSystemProduct[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ComputerSystemProduct[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ComputerSystemProduct");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ComputerSystemProduct>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ComputerSystemProduct
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    IdentifyingNumber = (string) managementObject.Properties["IdentifyingNumber"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SKUNumber = (string) managementObject.Properties["SKUNumber"].Value,
                    UUID = (string) managementObject.Properties["UUID"].Value,
                    Vendor = (string) managementObject.Properties["Vendor"].Value,
                    Version = (string) managementObject.Properties["Version"].Value
                });

            return list.ToArray();
        }
    }
}