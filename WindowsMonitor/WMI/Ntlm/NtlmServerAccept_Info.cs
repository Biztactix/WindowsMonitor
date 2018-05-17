using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class NtlmServerAccept_Info
    {
		public string DomainName { get; private set; }
		public uint Flags { get; private set; }
		public uint InContext { get; private set; }
		public uint OutContext { get; private set; }
		public uint StageHint { get; private set; }
		public string UserName { get; private set; }
		public string Workstation { get; private set; }

        public static IEnumerable<NtlmServerAccept_Info> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NtlmServerAccept_Info> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NtlmServerAccept_Info> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM NtlmServerAccept_Info");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NtlmServerAccept_Info
                {
                     DomainName = (string) (managementObject.Properties["DomainName"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InContext = (uint) (managementObject.Properties["InContext"]?.Value ?? default(uint)),
		 OutContext = (uint) (managementObject.Properties["OutContext"]?.Value ?? default(uint)),
		 StageHint = (uint) (managementObject.Properties["StageHint"]?.Value ?? default(uint)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value ?? default(string)),
		 Workstation = (string) (managementObject.Properties["Workstation"]?.Value ?? default(string))
                };
        }
    }
}