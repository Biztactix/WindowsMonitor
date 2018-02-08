using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class AssociatedProcessorMemory
    {
        public string Antecedent { get; private set; }
        public uint BusSpeed { get; private set; }
        public string Dependent { get; private set; }

        public static AssociatedProcessorMemory[] Retrieve(string remote, string username, string password)
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

        public static AssociatedProcessorMemory[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static AssociatedProcessorMemory[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_AssociatedProcessorMemory");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<AssociatedProcessorMemory>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new AssociatedProcessorMemory
                {
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    BusSpeed = (uint) managementObject.Properties["BusSpeed"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value
                });

            return list.ToArray();
        }
    }
}