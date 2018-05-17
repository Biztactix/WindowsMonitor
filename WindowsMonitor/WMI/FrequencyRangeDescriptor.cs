using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FrequencyRangeDescriptor
    {
		public uint ActiveHeight { get; private set; }
		public uint ActiveWidth { get; private set; }
		public uint ConstraintType { get; private set; }
		public uint MaxHSyncDenominator { get; private set; }
		public uint MaxHSyncNumerator { get; private set; }
		public uint MaxPixelRate { get; private set; }
		public uint MaxVSyncDenominator { get; private set; }
		public uint MaxVSyncNumerator { get; private set; }
		public uint MinHSyncDenominator { get; private set; }
		public uint MinHSyncNumerator { get; private set; }
		public uint MinVSyncDenominator { get; private set; }
		public uint MinVSyncNumerator { get; private set; }
		public byte Origin { get; private set; }

        public static IEnumerable<FrequencyRangeDescriptor> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FrequencyRangeDescriptor> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FrequencyRangeDescriptor> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FrequencyRangeDescriptor");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FrequencyRangeDescriptor
                {
                     ActiveHeight = (uint) (managementObject.Properties["ActiveHeight"]?.Value ?? default(uint)),
		 ActiveWidth = (uint) (managementObject.Properties["ActiveWidth"]?.Value ?? default(uint)),
		 ConstraintType = (uint) (managementObject.Properties["ConstraintType"]?.Value ?? default(uint)),
		 MaxHSyncDenominator = (uint) (managementObject.Properties["MaxHSyncDenominator"]?.Value ?? default(uint)),
		 MaxHSyncNumerator = (uint) (managementObject.Properties["MaxHSyncNumerator"]?.Value ?? default(uint)),
		 MaxPixelRate = (uint) (managementObject.Properties["MaxPixelRate"]?.Value ?? default(uint)),
		 MaxVSyncDenominator = (uint) (managementObject.Properties["MaxVSyncDenominator"]?.Value ?? default(uint)),
		 MaxVSyncNumerator = (uint) (managementObject.Properties["MaxVSyncNumerator"]?.Value ?? default(uint)),
		 MinHSyncDenominator = (uint) (managementObject.Properties["MinHSyncDenominator"]?.Value ?? default(uint)),
		 MinHSyncNumerator = (uint) (managementObject.Properties["MinHSyncNumerator"]?.Value ?? default(uint)),
		 MinVSyncDenominator = (uint) (managementObject.Properties["MinVSyncDenominator"]?.Value ?? default(uint)),
		 MinVSyncNumerator = (uint) (managementObject.Properties["MinVSyncNumerator"]?.Value ?? default(uint)),
		 Origin = (byte) (managementObject.Properties["Origin"]?.Value ?? default(byte))
                };
        }
    }
}