using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Registry
    {
        public string Caption { get; private set; }
        public uint CurrentSize { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint MaximumSize { get; private set; }
        public string Name { get; private set; }
        public uint ProposedSize { get; private set; }
        public string Status { get; private set; }

        public static Registry[] Retrieve(string remote, string username, string password)
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

        public static Registry[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Registry[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Registry");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Registry>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Registry
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CurrentSize = (uint) managementObject.Properties["CurrentSize"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    MaximumSize = (uint) managementObject.Properties["MaximumSize"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ProposedSize = (uint) managementObject.Properties["ProposedSize"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}