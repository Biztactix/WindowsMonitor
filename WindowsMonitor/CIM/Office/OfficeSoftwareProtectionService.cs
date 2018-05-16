using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM.Office
{
    /// <summary>
    /// </summary>
    public sealed class OfficeSoftwareProtectionService
    {
        public string ClientMachineId { get; private set; }
        public uint IsKeyManagementServiceMachine { get; private set; }
        public bool KeyManagementServiceActivationDisabled { get; private set; }
        public uint KeyManagementServiceCurrentCount { get; private set; }
        public bool KeyManagementServiceDnsPublishing { get; private set; }
        public uint KeyManagementServiceFailedRequests { get; private set; }
        public bool KeyManagementServiceHostCaching { get; private set; }
        public uint KeyManagementServiceLicensedRequests { get; private set; }
        public uint KeyManagementServiceListeningPort { get; private set; }
        public bool KeyManagementServiceLowPriority { get; private set; }
        public string KeyManagementServiceMachine { get; private set; }
        public uint KeyManagementServiceNonGenuineGraceRequests { get; private set; }
        public uint KeyManagementServiceNotificationRequests { get; private set; }
        public uint KeyManagementServiceOobGraceRequests { get; private set; }
        public uint KeyManagementServiceOotGraceRequests { get; private set; }
        public uint KeyManagementServicePort { get; private set; }
        public uint KeyManagementServiceTotalRequests { get; private set; }
        public uint KeyManagementServiceUnlicensedRequests { get; private set; }
        public uint PolicyCacheRefreshRequired { get; private set; }
        public uint RequiredClientCount { get; private set; }
        public string Version { get; private set; }
        public uint VlActivationInterval { get; private set; }
        public uint VlRenewalInterval { get; private set; }

        public static IEnumerable<OfficeSoftwareProtectionService> Retrieve(string remote, string username,
            string password)
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

        public static IEnumerable<OfficeSoftwareProtectionService> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OfficeSoftwareProtectionService> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM OfficeSoftwareProtectionService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OfficeSoftwareProtectionService
                {
                    ClientMachineId =
                        (string) managementObject.Properties["ClientMachineID"]?.Value,
                    IsKeyManagementServiceMachine =
                        (uint) (managementObject.Properties["IsKeyManagementServiceMachine"]?.Value ?? default(uint)),
                    KeyManagementServiceActivationDisabled =
                        (bool) (managementObject.Properties["KeyManagementServiceActivationDisabled"]?.Value ??
                                default(bool)),
                    KeyManagementServiceCurrentCount =
                        (uint) (managementObject.Properties["KeyManagementServiceCurrentCount"]?.Value ??
                                default(uint)),
                    KeyManagementServiceDnsPublishing =
                        (bool) (managementObject.Properties["KeyManagementServiceDnsPublishing"]?.Value ??
                                default(bool)),
                    KeyManagementServiceFailedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceFailedRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceHostCaching =
                        (bool) (managementObject.Properties["KeyManagementServiceHostCaching"]?.Value ?? default(bool)),
                    KeyManagementServiceLicensedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceLicensedRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceListeningPort =
                        (uint) (managementObject.Properties["KeyManagementServiceListeningPort"]?.Value ??
                                default(uint)),
                    KeyManagementServiceLowPriority =
                        (bool) (managementObject.Properties["KeyManagementServiceLowPriority"]?.Value ?? default(bool)),
                    KeyManagementServiceMachine =
                        (string) managementObject.Properties["KeyManagementServiceMachine"]?.Value,
                    KeyManagementServiceNonGenuineGraceRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceNonGenuineGraceRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceNotificationRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceNotificationRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceOobGraceRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceOOBGraceRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceOotGraceRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceOOTGraceRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServicePort =
                        (uint) (managementObject.Properties["KeyManagementServicePort"]?.Value ?? default(uint)),
                    KeyManagementServiceTotalRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceTotalRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceUnlicensedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceUnlicensedRequests"]?.Value ??
                                default(uint)),
                    PolicyCacheRefreshRequired =
                        (uint) (managementObject.Properties["PolicyCacheRefreshRequired"]?.Value ?? default(uint)),
                    RequiredClientCount =
                        (uint) (managementObject.Properties["RequiredClientCount"]?.Value ?? default(uint)),
                    Version = (string) managementObject.Properties["Version"]?.Value,
                    VlActivationInterval =
                        (uint) (managementObject.Properties["VLActivationInterval"]?.Value ?? default(uint)),
                    VlRenewalInterval =
                        (uint) (managementObject.Properties["VLRenewalInterval"]?.Value ?? default(uint))
                };
        }
    }
}