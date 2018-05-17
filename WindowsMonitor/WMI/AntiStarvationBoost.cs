using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class AntiStarvationBoost
    {
		public uint Flags { get; private set; }
		public byte Priority { get; private set; }
		public ushort ProcessorIndex { get; private set; }
		public byte Reserved { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<AntiStarvationBoost> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AntiStarvationBoost> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AntiStarvationBoost> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM AntiStarvationBoost");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AntiStarvationBoost
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Priority = (byte) (managementObject.Properties["Priority"]?.Value ?? default(byte)),
		 ProcessorIndex = (ushort) (managementObject.Properties["ProcessorIndex"]?.Value ?? default(ushort)),
		 Reserved = (byte) (managementObject.Properties["Reserved"]?.Value ?? default(byte)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}