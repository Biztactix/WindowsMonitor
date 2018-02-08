using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Account
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public string Domain { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool LocalAccount { get; private set; }
        public string Name { get; private set; }
        public string SID { get; private set; }
        public byte SIDType { get; private set; }
        public string Status { get; private set; }

        public static Account[] Retrieve(string remote, string username, string password)
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

        public static Account[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Account[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Account");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Account>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Account
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Domain = (string) managementObject.Properties["Domain"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LocalAccount = (bool) managementObject.Properties["LocalAccount"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SID = (string) managementObject.Properties["SID"].Value,
                    SIDType = (byte) managementObject.Properties["SIDType"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}