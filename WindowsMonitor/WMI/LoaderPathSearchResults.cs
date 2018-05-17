using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class LoaderPathSearchResults
    {
		public string AppDir { get; private set; }
		public string Cwd { get; private set; }
		public string DllDir { get; private set; }
		public string DllLoadDir { get; private set; }
		public uint Flags { get; private set; }
		public uint SearchInfo { get; private set; }

        public static IEnumerable<LoaderPathSearchResults> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<LoaderPathSearchResults> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<LoaderPathSearchResults> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM LoaderPathSearchResults");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new LoaderPathSearchResults
                {
                     AppDir = (string) (managementObject.Properties["AppDir"]?.Value ?? default(string)),
		 Cwd = (string) (managementObject.Properties["Cwd"]?.Value ?? default(string)),
		 DllDir = (string) (managementObject.Properties["DllDir"]?.Value ?? default(string)),
		 DllLoadDir = (string) (managementObject.Properties["DllLoadDir"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 SearchInfo = (uint) (managementObject.Properties["SearchInfo"]?.Value ?? default(uint))
                };
        }
    }
}