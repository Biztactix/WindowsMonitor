using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class DfsNode
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public bool Root { get; private set; }
        public uint State { get; private set; }
        public string Status { get; private set; }
        public uint Timeout { get; private set; }

        public static DfsNode[] Retrieve(string remote, string username, string password)
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

        public static DfsNode[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static DfsNode[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DfsNode");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<DfsNode>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new DfsNode
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Root = (bool) managementObject.Properties["Root"].Value,
                    State = (uint) managementObject.Properties["State"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    Timeout = (uint) managementObject.Properties["Timeout"].Value
                });

            return list.ToArray();
        }
    }
}