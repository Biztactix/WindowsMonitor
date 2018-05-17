using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class AuthenticodeVerification
    {
		public uint ErrorCode { get; private set; }
		public string ModulePath { get; private set; }
		public uint VerificationFlags { get; private set; }

        public static IEnumerable<AuthenticodeVerification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AuthenticodeVerification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AuthenticodeVerification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM AuthenticodeVerification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AuthenticodeVerification
                {
                     ErrorCode = (uint) (managementObject.Properties["ErrorCode"]?.Value ?? default(uint)),
		 ModulePath = (string) (managementObject.Properties["ModulePath"]?.Value ?? default(string)),
		 VerificationFlags = (uint) (managementObject.Properties["VerificationFlags"]?.Value ?? default(uint))
                };
        }
    }
}