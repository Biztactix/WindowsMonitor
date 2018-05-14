using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareLicensingTokenActivationLicense
    {
		public string AdditionalInfo { get; private set; }
		public uint AuthorizationStatus { get; private set; }
		public string Description { get; private set; }
		public DateTime ExpirationDate { get; private set; }
		public string ID { get; private set; }
		public string ILID { get; private set; }
		public uint ILVID { get; private set; }

        public static IEnumerable<SoftwareLicensingTokenActivationLicense> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareLicensingTokenActivationLicense> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareLicensingTokenActivationLicense> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SoftwareLicensingTokenActivationLicense");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareLicensingTokenActivationLicense
                {
                     AdditionalInfo = (string) (managementObject.Properties["AdditionalInfo"]?.Value),
		 AuthorizationStatus = (uint) (managementObject.Properties["AuthorizationStatus"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 ExpirationDate = (DateTime) (managementObject.Properties["ExpirationDate"]?.Value ?? default(DateTime)),
		 ID = (string) (managementObject.Properties["ID"]?.Value),
		 ILID = (string) (managementObject.Properties["ILID"]?.Value),
		 ILVID = (uint) (managementObject.Properties["ILVID"]?.Value ?? default(uint))
                };
        }
    }
}