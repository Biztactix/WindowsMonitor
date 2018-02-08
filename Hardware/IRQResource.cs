using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class IRQResource
    {
        public ushort Availability { get; private set; }
        public string Caption { get; private set; }
        public string CreationClassName { get; private set; }
        public string CSCreationClassName { get; private set; }
        public string CSName { get; private set; }
        public string Description { get; private set; }
        public bool Hardware { get; private set; }
        public DateTime InstallDate { get; private set; }
        public uint IRQNumber { get; private set; }
        public string Name { get; private set; }
        public bool Shareable { get; private set; }
        public string Status { get; private set; }
        public ushort TriggerLevel { get; private set; }
        public ushort TriggerType { get; private set; }
        public uint Vector { get; private set; }

        public static IRQResource[] Retrieve(string remote, string username, string password)
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

        public static IRQResource[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IRQResource[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_IRQResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<IRQResource>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new IRQResource
                {
                    Availability = (ushort) managementObject.Properties["Availability"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    CSCreationClassName = (string) managementObject.Properties["CSCreationClassName"].Value,
                    CSName = (string) managementObject.Properties["CSName"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Hardware = (bool) managementObject.Properties["Hardware"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    IRQNumber = (uint) managementObject.Properties["IRQNumber"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Shareable = (bool) managementObject.Properties["Shareable"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    TriggerLevel = (ushort) managementObject.Properties["TriggerLevel"].Value,
                    TriggerType = (ushort) managementObject.Properties["TriggerType"].Value,
                    Vector = (uint) managementObject.Properties["Vector"].Value
                });

            return list.ToArray();
        }
    }
}