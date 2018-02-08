using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class LogonSession
    {
        public string AuthenticationPackage { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string LogonId { get; private set; }
        public uint LogonType { get; private set; }
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public string Status { get; private set; }

        public static LogonSession[] Retrieve(string remote, string username, string password)
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

        public static LogonSession[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static LogonSession[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_LogonSession");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<LogonSession>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new LogonSession
                {
                    AuthenticationPackage = (string) managementObject.Properties["AuthenticationPackage"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LogonId = (string) managementObject.Properties["LogonId"].Value,
                    LogonType = (uint) managementObject.Properties["LogonType"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    StartTime = (DateTime) managementObject.Properties["StartTime"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}