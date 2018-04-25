using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class VolumeUserQuota
    {
		public short Account { get; private set; }
		public ulong DiskSpaceUsed { get; private set; }
		public ulong Limit { get; private set; }
		public uint Status { get; private set; }
		public short Volume { get; private set; }
		public ulong WarningLimit { get; private set; }

        public static IEnumerable<VolumeUserQuota> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VolumeUserQuota> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VolumeUserQuota> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_VolumeUserQuota");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VolumeUserQuota
                {
                     Account = (short) (managementObject.Properties["Account"]?.Value ?? default(short)),
		 DiskSpaceUsed = (ulong) (managementObject.Properties["DiskSpaceUsed"]?.Value ?? default(ulong)),
		 Limit = (ulong) (managementObject.Properties["Limit"]?.Value ?? default(ulong)),
		 Status = (uint) (managementObject.Properties["Status"]?.Value ?? default(uint)),
		 Volume = (short) (managementObject.Properties["Volume"]?.Value ?? default(short)),
		 WarningLimit = (ulong) (managementObject.Properties["WarningLimit"]?.Value ?? default(ulong))
                };
        }
    }
}