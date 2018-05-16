using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Software
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareLicensingService
    {
		public string ClientMachineID { get; private set; }
		public string DiscoveredKeyManagementServiceMachineIpAddress { get; private set; }
		public string DiscoveredKeyManagementServiceMachineName { get; private set; }
		public uint DiscoveredKeyManagementServiceMachinePort { get; private set; }
		public uint IsKeyManagementServiceMachine { get; private set; }
		public uint KeyManagementServiceCurrentCount { get; private set; }
		public bool KeyManagementServiceDnsPublishing { get; private set; }
		public uint KeyManagementServiceFailedRequests { get; private set; }
		public bool KeyManagementServiceHostCaching { get; private set; }
		public uint KeyManagementServiceLicensedRequests { get; private set; }
		public uint KeyManagementServiceListeningPort { get; private set; }
		public string KeyManagementServiceLookupDomain { get; private set; }
		public bool KeyManagementServiceLowPriority { get; private set; }
		public string KeyManagementServiceMachine { get; private set; }
		public uint KeyManagementServiceNonGenuineGraceRequests { get; private set; }
		public uint KeyManagementServiceNotificationRequests { get; private set; }
		public uint KeyManagementServiceOOBGraceRequests { get; private set; }
		public uint KeyManagementServiceOOTGraceRequests { get; private set; }
		public uint KeyManagementServicePort { get; private set; }
		public string KeyManagementServiceProductKeyID { get; private set; }
		public uint KeyManagementServiceTotalRequests { get; private set; }
		public uint KeyManagementServiceUnlicensedRequests { get; private set; }
		public uint OA2xBiosMarkerMinorVersion { get; private set; }
		public uint OA2xBiosMarkerStatus { get; private set; }
		public string OA3xOriginalProductKey { get; private set; }
		public string OA3xOriginalProductKeyDescription { get; private set; }
		public string OA3xOriginalProductKeyPkPn { get; private set; }
		public uint PolicyCacheRefreshRequired { get; private set; }
		public uint RemainingWindowsReArmCount { get; private set; }
		public uint RequiredClientCount { get; private set; }
		public string TokenActivationAdditionalInfo { get; private set; }
		public string TokenActivationCertificateThumbprint { get; private set; }
		public uint TokenActivationGrantNumber { get; private set; }
		public string TokenActivationILID { get; private set; }
		public uint TokenActivationILVID { get; private set; }
		public string Version { get; private set; }
		public uint VLActivationInterval { get; private set; }
		public uint VLRenewalInterval { get; private set; }

        public static IEnumerable<SoftwareLicensingService> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareLicensingService> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareLicensingService> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SoftwareLicensingService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareLicensingService
                {
                     ClientMachineID = (string) (managementObject.Properties["ClientMachineID"]?.Value),
		 DiscoveredKeyManagementServiceMachineIpAddress = (string) (managementObject.Properties["DiscoveredKeyManagementServiceMachineIpAddress"]?.Value),
		 DiscoveredKeyManagementServiceMachineName = (string) (managementObject.Properties["DiscoveredKeyManagementServiceMachineName"]?.Value),
		 DiscoveredKeyManagementServiceMachinePort = (uint) (managementObject.Properties["DiscoveredKeyManagementServiceMachinePort"]?.Value ?? default(uint)),
		 IsKeyManagementServiceMachine = (uint) (managementObject.Properties["IsKeyManagementServiceMachine"]?.Value ?? default(uint)),
		 KeyManagementServiceCurrentCount = (uint) (managementObject.Properties["KeyManagementServiceCurrentCount"]?.Value ?? default(uint)),
		 KeyManagementServiceDnsPublishing = (bool) (managementObject.Properties["KeyManagementServiceDnsPublishing"]?.Value ?? default(bool)),
		 KeyManagementServiceFailedRequests = (uint) (managementObject.Properties["KeyManagementServiceFailedRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceHostCaching = (bool) (managementObject.Properties["KeyManagementServiceHostCaching"]?.Value ?? default(bool)),
		 KeyManagementServiceLicensedRequests = (uint) (managementObject.Properties["KeyManagementServiceLicensedRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceListeningPort = (uint) (managementObject.Properties["KeyManagementServiceListeningPort"]?.Value ?? default(uint)),
		 KeyManagementServiceLookupDomain = (string) (managementObject.Properties["KeyManagementServiceLookupDomain"]?.Value),
		 KeyManagementServiceLowPriority = (bool) (managementObject.Properties["KeyManagementServiceLowPriority"]?.Value ?? default(bool)),
		 KeyManagementServiceMachine = (string) (managementObject.Properties["KeyManagementServiceMachine"]?.Value),
		 KeyManagementServiceNonGenuineGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceNonGenuineGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceNotificationRequests = (uint) (managementObject.Properties["KeyManagementServiceNotificationRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceOOBGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceOOBGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceOOTGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceOOTGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServicePort = (uint) (managementObject.Properties["KeyManagementServicePort"]?.Value ?? default(uint)),
		 KeyManagementServiceProductKeyID = (string) (managementObject.Properties["KeyManagementServiceProductKeyID"]?.Value),
		 KeyManagementServiceTotalRequests = (uint) (managementObject.Properties["KeyManagementServiceTotalRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceUnlicensedRequests = (uint) (managementObject.Properties["KeyManagementServiceUnlicensedRequests"]?.Value ?? default(uint)),
		 OA2xBiosMarkerMinorVersion = (uint) (managementObject.Properties["OA2xBiosMarkerMinorVersion"]?.Value ?? default(uint)),
		 OA2xBiosMarkerStatus = (uint) (managementObject.Properties["OA2xBiosMarkerStatus"]?.Value ?? default(uint)),
		 OA3xOriginalProductKey = (string) (managementObject.Properties["OA3xOriginalProductKey"]?.Value),
		 OA3xOriginalProductKeyDescription = (string) (managementObject.Properties["OA3xOriginalProductKeyDescription"]?.Value),
		 OA3xOriginalProductKeyPkPn = (string) (managementObject.Properties["OA3xOriginalProductKeyPkPn"]?.Value),
		 PolicyCacheRefreshRequired = (uint) (managementObject.Properties["PolicyCacheRefreshRequired"]?.Value ?? default(uint)),
		 RemainingWindowsReArmCount = (uint) (managementObject.Properties["RemainingWindowsReArmCount"]?.Value ?? default(uint)),
		 RequiredClientCount = (uint) (managementObject.Properties["RequiredClientCount"]?.Value ?? default(uint)),
		 TokenActivationAdditionalInfo = (string) (managementObject.Properties["TokenActivationAdditionalInfo"]?.Value),
		 TokenActivationCertificateThumbprint = (string) (managementObject.Properties["TokenActivationCertificateThumbprint"]?.Value),
		 TokenActivationGrantNumber = (uint) (managementObject.Properties["TokenActivationGrantNumber"]?.Value ?? default(uint)),
		 TokenActivationILID = (string) (managementObject.Properties["TokenActivationILID"]?.Value),
		 TokenActivationILVID = (uint) (managementObject.Properties["TokenActivationILVID"]?.Value ?? default(uint)),
		 Version = (string) (managementObject.Properties["Version"]?.Value),
		 VLActivationInterval = (uint) (managementObject.Properties["VLActivationInterval"]?.Value ?? default(uint)),
		 VLRenewalInterval = (uint) (managementObject.Properties["VLRenewalInterval"]?.Value ?? default(uint))
                };
        }
    }
}