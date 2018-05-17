using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class LoaderDllSearchResults
    {
		public uint Flags { get; private set; }
		public string FullDllName { get; private set; }
		public uint LdrLoadFlags { get; private set; }
		public uint LdrSearchFlags { get; private set; }
		public uint LoadReason { get; private set; }
		public uint SearchInfo { get; private set; }

        public static IEnumerable<LoaderDllSearchResults> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LoaderDllSearchResults> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LoaderDllSearchResults> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM LoaderDllSearchResults");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LoaderDllSearchResults
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 FullDllName = (string) (managementObject.Properties["FullDllName"]?.Value ?? default(string)),
		 LdrLoadFlags = (uint) (managementObject.Properties["LdrLoadFlags"]?.Value ?? default(uint)),
		 LdrSearchFlags = (uint) (managementObject.Properties["LdrSearchFlags"]?.Value ?? default(uint)),
		 LoadReason = (uint) (managementObject.Properties["LoadReason"]?.Value ?? default(uint)),
		 SearchInfo = (uint) (managementObject.Properties["SearchInfo"]?.Value ?? default(uint))
                };
        }
    }
}