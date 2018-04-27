using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ShadowStorage
    {
		public ulong AllocatedSpace { get; private set; }
		public short DiffVolume { get; private set; }
		public ulong MaxSpace { get; private set; }
		public ulong UsedSpace { get; private set; }
		public short Volume { get; private set; }

        public static IEnumerable<ShadowStorage> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ShadowStorage> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ShadowStorage> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ShadowStorage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ShadowStorage
                {
                     AllocatedSpace = (ulong) (managementObject.Properties["AllocatedSpace"]?.Value ?? default(ulong)),
		 DiffVolume = (short) (managementObject.Properties["DiffVolume"]?.Value ?? default(short)),
		 MaxSpace = (ulong) (managementObject.Properties["MaxSpace"]?.Value ?? default(ulong)),
		 UsedSpace = (ulong) (managementObject.Properties["UsedSpace"]?.Value ?? default(ulong)),
		 Volume = (short) (managementObject.Properties["Volume"]?.Value ?? default(short))
                };
        }
    }
}