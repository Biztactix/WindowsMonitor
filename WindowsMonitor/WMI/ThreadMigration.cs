using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ThreadMigration
    {
		public uint Flags { get; private set; }
		public bool IdealProcessorAdjust { get; private set; }
		public ushort OldIdealProcessorIndex { get; private set; }
		public byte Priority { get; private set; }
		public ushort SourceProcessorIndex { get; private set; }
		public ushort TargetProcessorIndex { get; private set; }
		public uint ThreadId { get; private set; }

        public static IEnumerable<ThreadMigration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ThreadMigration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ThreadMigration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ThreadMigration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ThreadMigration
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IdealProcessorAdjust = (bool) (managementObject.Properties["IdealProcessorAdjust"]?.Value ?? default(bool)),
		 OldIdealProcessorIndex = (ushort) (managementObject.Properties["OldIdealProcessorIndex"]?.Value ?? default(ushort)),
		 Priority = (byte) (managementObject.Properties["Priority"]?.Value ?? default(byte)),
		 SourceProcessorIndex = (ushort) (managementObject.Properties["SourceProcessorIndex"]?.Value ?? default(ushort)),
		 TargetProcessorIndex = (ushort) (managementObject.Properties["TargetProcessorIndex"]?.Value ?? default(ushort)),
		 ThreadId = (uint) (managementObject.Properties["ThreadId"]?.Value ?? default(uint))
                };
        }
    }
}