using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class WMI_GenericNonCOMEvent
    {
		public uint ProcessId { get; private set; }
		public string[] PropertyNames { get; private set; }
		public string[] PropertyValues { get; private set; }
		public string ProviderName { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<WMI_GenericNonCOMEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WMI_GenericNonCOMEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WMI_GenericNonCOMEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WMI_GenericNonCOMEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WMI_GenericNonCOMEvent
                {
                     ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 PropertyNames = (string[]) (managementObject.Properties["PropertyNames"]?.Value ?? new string[0]),
		 PropertyValues = (string[]) (managementObject.Properties["PropertyValues"]?.Value ?? new string[0]),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}