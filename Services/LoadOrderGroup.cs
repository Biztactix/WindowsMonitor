using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LoadOrderGroup
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public bool DriverEnabled { get; private set; }
        public uint GroupOrder { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        public static LoadOrderGroup[] Retrieve(string remote, string username, string password)
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

        public static LoadOrderGroup[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LoadOrderGroup[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LoadOrderGroup");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LoadOrderGroup>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LoadOrderGroup
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DriverEnabled = (bool) managementObject.Properties["DriverEnabled"].Value,
                    GroupOrder = (uint) managementObject.Properties["GroupOrder"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}