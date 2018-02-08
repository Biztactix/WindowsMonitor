using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Session
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public string Status { get; private set; }

        public static Session[] Retrieve(string remote, string username, string password)
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

        public static Session[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Session[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Session");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Session>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Session
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    StartTime = (DateTime) managementObject.Properties["StartTime"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}