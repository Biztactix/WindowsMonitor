using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __NTLMUser9X
    {
		public string Authority { get; private set; }
		public int Flags { get; private set; }
		public int Mask { get; private set; }
		public string Name { get; private set; }
		public int Type { get; private set; }

        public static IEnumerable<__NTLMUser9X> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__NTLMUser9X> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__NTLMUser9X> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __NTLMUser9X");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __NTLMUser9X
                {
                     Authority = (string) (managementObject.Properties["Authority"]?.Value ?? default(string)),
		 Flags = (int) (managementObject.Properties["Flags"]?.Value ?? default(int)),
		 Mask = (int) (managementObject.Properties["Mask"]?.Value ?? default(int)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Type = (int) (managementObject.Properties["Type"]?.Value ?? default(int))
                };
        }
    }
}