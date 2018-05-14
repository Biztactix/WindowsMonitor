using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class OfficeSoftwareProtectionProduct
    {
        public string ApplicationId { get; private set; }
        public string Description { get; private set; }
        public string DiscoveredKeyManagementServiceMachineName { get; private set; }
        public uint DiscoveredKeyManagementServiceMachinePort { get; private set; }
        public DateTime EvaluationEndDate { get; private set; }
        public uint ExtendedGrace { get; private set; }
        public uint GenuineStatus { get; private set; }
        public uint GracePeriodRemaining { get; private set; }
        public string Id { get; private set; }
        public uint IsKeyManagementServiceMachine { get; private set; }
        public uint KeyManagementServiceCurrentCount { get; private set; }
        public uint KeyManagementServiceFailedRequests { get; private set; }
        public uint KeyManagementServiceLicensedRequests { get; private set; }
        public string KeyManagementServiceMachine { get; private set; }
        public uint KeyManagementServiceNonGenuineGraceRequests { get; private set; }
        public uint KeyManagementServiceNotificationRequests { get; private set; }
        public uint KeyManagementServiceOobGraceRequests { get; private set; }
        public uint KeyManagementServiceOotGraceRequests { get; private set; }
        public uint KeyManagementServicePort { get; private set; }
        public string KeyManagementServiceProductKeyId { get; private set; }
        public uint KeyManagementServiceTotalRequests { get; private set; }
        public uint KeyManagementServiceUnlicensedRequests { get; private set; }
        public string LicenseDependsOn { get; private set; }
        public string LicenseFamily { get; private set; }
        public bool LicenseIsAddon { get; private set; }
        public uint LicenseStatus { get; private set; }
        public uint LicenseStatusReason { get; private set; }
        public string MachineUrl { get; private set; }
        public string Name { get; private set; }
        public string OfflineInstallationId { get; private set; }
        public string PartialProductKey { get; private set; }
        public string ProcessorUrl { get; private set; }
        public string ProductKeyId { get; private set; }
        public string ProductKeyUrl { get; private set; }
        public uint RequiredClientCount { get; private set; }
        public string TokenActivationAdditionalInfo { get; private set; }
        public string TokenActivationCertificateThumbprint { get; private set; }
        public uint TokenActivationGrantNumber { get; private set; }
        public string TokenActivationIlid { get; private set; }
        public uint TokenActivationIlvid { get; private set; }
        public DateTime TrustedTime { get; private set; }
        public string UseLicenseUrl { get; private set; }
        public uint VlActivationInterval { get; private set; }
        public uint VlRenewalInterval { get; private set; }

        public static IEnumerable<OfficeSoftwareProtectionProduct> Retrieve(string remote, string username,
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

        public static IEnumerable<OfficeSoftwareProtectionProduct> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OfficeSoftwareProtectionProduct> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM OfficeSoftwareProtectionProduct");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OfficeSoftwareProtectionProduct
                {
                    ApplicationId = (string) (managementObject.Properties["ApplicationID"]?.Value),
                    Description = (string) (managementObject.Properties["Description"]?.Value),
                    DiscoveredKeyManagementServiceMachineName =
                        (string) (managementObject.Properties["DiscoveredKeyManagementServiceMachineName"]?.Value ??
                                  default(string)),
                    DiscoveredKeyManagementServiceMachinePort =
                        (uint) (managementObject.Properties["DiscoveredKeyManagementServiceMachinePort"]?.Value ??
                                default(uint)),
                    EvaluationEndDate =
                        (DateTime) (managementObject.Properties["EvaluationEndDate"]?.Value ?? default(DateTime)),
                    ExtendedGrace = (uint) (managementObject.Properties["ExtendedGrace"]?.Value ?? default(uint)),
                    GenuineStatus = (uint) (managementObject.Properties["GenuineStatus"]?.Value ?? default(uint)),
                    GracePeriodRemaining =
                        (uint) (managementObject.Properties["GracePeriodRemaining"]?.Value ?? default(uint)),
                    Id = (string) (managementObject.Properties["ID"]?.Value),
                    IsKeyManagementServiceMachine =
                        (uint) (managementObject.Properties["IsKeyManagementServiceMachine"]?.Value ?? default(uint)),
                    KeyManagementServiceCurrentCount =
                        (uint) (managementObject.Properties["KeyManagementServiceCurrentCount"]?.Value ??
                                default(uint)),
                    KeyManagementServiceFailedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceFailedRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceLicensedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceLicensedRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceMachine =
                        (string) (managementObject.Properties["KeyManagementServiceMachine"]?.Value),
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
                    KeyManagementServiceProductKeyId =
                        (string) (managementObject.Properties["KeyManagementServiceProductKeyID"]?.Value ??
                                  default(string)),
                    KeyManagementServiceTotalRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceTotalRequests"]?.Value ??
                                default(uint)),
                    KeyManagementServiceUnlicensedRequests =
                        (uint) (managementObject.Properties["KeyManagementServiceUnlicensedRequests"]?.Value ??
                                default(uint)),
                    LicenseDependsOn =
                        (string) (managementObject.Properties["LicenseDependsOn"]?.Value),
                    LicenseFamily = (string) (managementObject.Properties["LicenseFamily"]?.Value),
                    LicenseIsAddon = (bool) (managementObject.Properties["LicenseIsAddon"]?.Value ?? default(bool)),
                    LicenseStatus = (uint) (managementObject.Properties["LicenseStatus"]?.Value ?? default(uint)),
                    LicenseStatusReason =
                        (uint) (managementObject.Properties["LicenseStatusReason"]?.Value ?? default(uint)),
                    MachineUrl = (string) (managementObject.Properties["MachineURL"]?.Value),
                    Name = (string) (managementObject.Properties["Name"]?.Value),
                    OfflineInstallationId =
                        (string) (managementObject.Properties["OfflineInstallationId"]?.Value),
                    PartialProductKey =
                        (string) (managementObject.Properties["PartialProductKey"]?.Value),
                    ProcessorUrl = (string) (managementObject.Properties["ProcessorURL"]?.Value),
                    ProductKeyId = (string) (managementObject.Properties["ProductKeyID"]?.Value),
                    ProductKeyUrl = (string) (managementObject.Properties["ProductKeyURL"]?.Value),
                    RequiredClientCount =
                        (uint) (managementObject.Properties["RequiredClientCount"]?.Value ?? default(uint)),
                    TokenActivationAdditionalInfo =
                        (string) (managementObject.Properties["TokenActivationAdditionalInfo"]?.Value ??
                                  default(string)),
                    TokenActivationCertificateThumbprint =
                        (string) (managementObject.Properties["TokenActivationCertificateThumbprint"]?.Value ??
                                  default(string)),
                    TokenActivationGrantNumber =
                        (uint) (managementObject.Properties["TokenActivationGrantNumber"]?.Value ?? default(uint)),
                    TokenActivationIlid =
                        (string) (managementObject.Properties["TokenActivationILID"]?.Value),
                    TokenActivationIlvid =
                        (uint) (managementObject.Properties["TokenActivationILVID"]?.Value ?? default(uint)),
                    TrustedTime = (DateTime) (managementObject.Properties["TrustedTime"]?.Value ?? default(DateTime)),
                    UseLicenseUrl = (string) (managementObject.Properties["UseLicenseURL"]?.Value),
                    VlActivationInterval =
                        (uint) (managementObject.Properties["VLActivationInterval"]?.Value ?? default(uint)),
                    VlRenewalInterval =
                        (uint) (managementObject.Properties["VLRenewalInterval"]?.Value ?? default(uint))
                };
        }
    }
}