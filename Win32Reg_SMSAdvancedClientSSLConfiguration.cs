using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class Win32Reg_SMSAdvancedClientSSLConfiguration
    {
		public string CertificateSelectionCriteria { get; private set; }
		public string CertificateStore { get; private set; }
		public uint ClientAlwaysOnInternet { get; private set; }
		public uint HttpsStateFlags { get; private set; }
		public string InstanceKey { get; private set; }
		public string InternetMPHostName { get; private set; }
		public uint SelectFirstCertificate { get; private set; }

        public static IEnumerable<Win32Reg_SMSAdvancedClientSSLConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Win32Reg_SMSAdvancedClientSSLConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Win32Reg_SMSAdvancedClientSSLConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32Reg_SMSAdvancedClientSSLConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Win32Reg_SMSAdvancedClientSSLConfiguration
                {
                     CertificateSelectionCriteria = (string) (managementObject.Properties["CertificateSelectionCriteria"]?.Value ?? default(string)),
		 CertificateStore = (string) (managementObject.Properties["CertificateStore"]?.Value ?? default(string)),
		 ClientAlwaysOnInternet = (uint) (managementObject.Properties["ClientAlwaysOnInternet"]?.Value ?? default(uint)),
		 HttpsStateFlags = (uint) (managementObject.Properties["HttpsStateFlags"]?.Value ?? default(uint)),
		 InstanceKey = (string) (managementObject.Properties["InstanceKey"]?.Value ?? default(string)),
		 InternetMPHostName = (string) (managementObject.Properties["InternetMPHostName"]?.Value ?? default(string)),
		 SelectFirstCertificate = (uint) (managementObject.Properties["SelectFirstCertificate"]?.Value ?? default(uint))
                };
        }
    }
}