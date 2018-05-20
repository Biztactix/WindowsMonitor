using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Window.Services
{
    /// <summary>
    /// </summary>
    public sealed class ServiceAccessPoint
    {
        public string Caption { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint Type { get; private set; }

        public static IEnumerable<ServiceAccessPoint> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServiceAccessPoint> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServiceAccessPoint> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ServiceAccessPoint");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServiceAccessPoint
                {
                    Caption = (string) managementObject.Properties["Caption"]?.Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"]?.Value,
                    Description = (string) managementObject.Properties["Description"]?.Value,
                    InstallDate =
                        ManagementDateTimeConverter.ToDateTime(
                            managementObject.Properties["InstallDate"]?.Value as string ?? "00010102000000.000000+060"),
                    Name = (string) managementObject.Properties["Name"]?.Value,
                    Status = (string) managementObject.Properties["Status"]?.Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"]?.Value,
                    SystemName = (string) managementObject.Properties["SystemName"]?.Value,
                    Type = (uint) (managementObject.Properties["Type"]?.Value ?? default(uint))
                };
        }
    }
}