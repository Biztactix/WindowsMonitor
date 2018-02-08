using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ServerConnection
    {
        public uint ActiveTime { get; private set; }
        public string Caption { get; private set; }
        public string ComputerName { get; private set; }
        public uint ConnectionID { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public uint NumberOfFiles { get; private set; }
        public uint NumberOfUsers { get; private set; }
        public string ShareName { get; private set; }
        public string Status { get; private set; }
        public string UserName { get; private set; }

        public static ServerConnection[] Retrieve(string remote, string username, string password)
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

        public static ServerConnection[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ServerConnection[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServerConnection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ServerConnection>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ServerConnection
                {
                    ActiveTime = (uint) managementObject.Properties["ActiveTime"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ComputerName = (string) managementObject.Properties["ComputerName"].Value,
                    ConnectionID = (uint) managementObject.Properties["ConnectionID"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    NumberOfFiles = (uint) managementObject.Properties["NumberOfFiles"].Value,
                    NumberOfUsers = (uint) managementObject.Properties["NumberOfUsers"].Value,
                    ShareName = (string) managementObject.Properties["ShareName"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    UserName = (string) managementObject.Properties["UserName"].Value
                });

            return list.ToArray();
        }
    }
}