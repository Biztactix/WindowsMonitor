using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PortResource
    {
        public bool Alias { get; private set; }
        public string Caption { get; private set; }
        public string CreationClassName { get; private set; }
        public string CSCreationClassName { get; private set; }
        public string CSName { get; private set; }
        public string Description { get; private set; }
        public ulong EndingAddress { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public ulong StartingAddress { get; private set; }
        public string Status { get; private set; }

        public static PortResource[] Retrieve(string remote, string username, string password)
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

        public static PortResource[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PortResource[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PortResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PortResource>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PortResource
                {
                    Alias = (bool) managementObject.Properties["Alias"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CSCreationClassName = (string) managementObject.Properties["CSCreationClassName"].Value,
                    CSName = (string) managementObject.Properties["CSName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    EndingAddress = (ulong) managementObject.Properties["EndingAddress"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    StartingAddress = (ulong) managementObject.Properties["StartingAddress"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}