using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class UserAccount
    {
        public uint AccountType { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public bool Disabled { get; private set; }
        public string Domain { get; private set; }
        public string FullName { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool LocalAccount { get; private set; }
        public bool Lockout { get; private set; }
        public string Name { get; private set; }
        public bool PasswordChangeable { get; private set; }
        public bool PasswordExpires { get; private set; }
        public bool PasswordRequired { get; private set; }
        public string SID { get; private set; }
        public byte SIDType { get; private set; }
        public string Status { get; private set; }

        public static UserAccount[] Retrieve(string remote, string username, string password)
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

        public static UserAccount[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static UserAccount[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_UserAccount");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<UserAccount>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new UserAccount
                {
                    AccountType = (uint) managementObject.Properties["AccountType"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Disabled = (bool) managementObject.Properties["Disabled"].Value,
                    Domain = (string) managementObject.Properties["Domain"].Value,
                    FullName = (string) managementObject.Properties["FullName"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    LocalAccount = (bool) managementObject.Properties["LocalAccount"].Value,
                    Lockout = (bool) managementObject.Properties["Lockout"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PasswordChangeable = (bool) managementObject.Properties["PasswordChangeable"].Value,
                    PasswordExpires = (bool) managementObject.Properties["PasswordExpires"].Value,
                    PasswordRequired = (bool) managementObject.Properties["PasswordRequired"].Value,
                    SID = (string) managementObject.Properties["SID"].Value,
                    SIDType = (byte) managementObject.Properties["SIDType"].Value,
                    Status = (string) managementObject.Properties["Status"].Value
                });

            return list.ToArray();
        }
    }
}