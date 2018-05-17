using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class Registry_ChangeNotification
    {
		public uint Flags { get; private set; }
		public uint KeyHandle { get; private set; }
		public uint Notification { get; private set; }
		public byte Primary { get; private set; }
		public byte Type { get; private set; }
		public byte WatchSubtree { get; private set; }

        public static IEnumerable<Registry_ChangeNotification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Registry_ChangeNotification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Registry_ChangeNotification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Registry_ChangeNotification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Registry_ChangeNotification
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 KeyHandle = (uint) (managementObject.Properties["KeyHandle"]?.Value ?? default(uint)),
		 Notification = (uint) (managementObject.Properties["Notification"]?.Value ?? default(uint)),
		 Primary = (byte) (managementObject.Properties["Primary"]?.Value ?? default(byte)),
		 Type = (byte) (managementObject.Properties["Type"]?.Value ?? default(byte)),
		 WatchSubtree = (byte) (managementObject.Properties["WatchSubtree"]?.Value ?? default(byte))
                };
        }
    }
}