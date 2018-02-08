using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ServerSession
    {
        public uint ActiveTime { get; private set; }
        public string Caption { get; private set; }
        public string ClientType { get; private set; }
        public string ComputerName { get; private set; }
        public string Description { get; private set; }
        public uint IdleTime { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public uint ResourcesOpened { get; private set; }
        public uint SessionType { get; private set; }
        public string Status { get; private set; }
        public string TransportName { get; private set; }
        public string UserName { get; private set; }

        public static ServerSession[] Retrieve(string remote, string username, string password)
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

        public static ServerSession[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ServerSession[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServerSession");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ServerSession>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ServerSession
                {
                    ActiveTime = (uint) managementObject.Properties["ActiveTime"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ClientType = (string) managementObject.Properties["ClientType"].Value,
                    ComputerName = (string) managementObject.Properties["ComputerName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    IdleTime = (uint) managementObject.Properties["IdleTime"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ResourcesOpened = (uint) managementObject.Properties["ResourcesOpened"].Value,
                    SessionType = (uint) managementObject.Properties["SessionType"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    TransportName = (string) managementObject.Properties["TransportName"].Value,
                    UserName = (string) managementObject.Properties["UserName"].Value
                });

            return list.ToArray();
        }
    }
}