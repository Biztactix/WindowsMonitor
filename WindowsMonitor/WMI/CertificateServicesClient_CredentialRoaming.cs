using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class CertificateServicesClient_CredentialRoaming
    {
		public uint Flags { get; private set; }

        public static IEnumerable<CertificateServicesClient_CredentialRoaming> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<CertificateServicesClient_CredentialRoaming> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<CertificateServicesClient_CredentialRoaming> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CertificateServicesClient_CredentialRoaming");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new CertificateServicesClient_CredentialRoaming
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint))
                };
        }
    }
}