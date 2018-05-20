using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Windows.Win32Reg
{
    /// <summary>
    /// </summary>
    public sealed class SMSGuestVirtualMachine64
    {
		public string InstanceKey { get; private set; }
		public string PhysicalHostName { get; private set; }
		public string PhysicalHostNameFullyQualified { get; private set; }

        public static IEnumerable<SMSGuestVirtualMachine64> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SMSGuestVirtualMachine64> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SMSGuestVirtualMachine64> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32Reg_SMSGuestVirtualMachine64");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SMSGuestVirtualMachine64
                {
                     InstanceKey = (string) (managementObject.Properties["InstanceKey"]?.Value),
		 PhysicalHostName = (string) (managementObject.Properties["PhysicalHostName"]?.Value),
		 PhysicalHostNameFullyQualified = (string) (managementObject.Properties["PhysicalHostNameFullyQualified"]?.Value)
                };
        }
    }
}