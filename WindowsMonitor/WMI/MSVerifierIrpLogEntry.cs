using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSVerifierIrpLogEntry
    {
		public ulong Arg1 { get; private set; }
		public ulong Arg2 { get; private set; }
		public ulong Arg3 { get; private set; }
		public ulong Arg4 { get; private set; }
		public byte Control { get; private set; }
		public uint Count { get; private set; }
		public byte Flags { get; private set; }
		public byte Major { get; private set; }
		public byte Minor { get; private set; }

        public static IEnumerable<MSVerifierIrpLogEntry> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSVerifierIrpLogEntry> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSVerifierIrpLogEntry> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSVerifierIrpLogEntry");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSVerifierIrpLogEntry
                {
                     Arg1 = (ulong) (managementObject.Properties["Arg1"]?.Value ?? default(ulong)),
		 Arg2 = (ulong) (managementObject.Properties["Arg2"]?.Value ?? default(ulong)),
		 Arg3 = (ulong) (managementObject.Properties["Arg3"]?.Value ?? default(ulong)),
		 Arg4 = (ulong) (managementObject.Properties["Arg4"]?.Value ?? default(ulong)),
		 Control = (byte) (managementObject.Properties["Control"]?.Value ?? default(byte)),
		 Count = (uint) (managementObject.Properties["Count"]?.Value ?? default(uint)),
		 Flags = (byte) (managementObject.Properties["Flags"]?.Value ?? default(byte)),
		 Major = (byte) (managementObject.Properties["Major"]?.Value ?? default(byte)),
		 Minor = (byte) (managementObject.Properties["Minor"]?.Value ?? default(byte))
                };
        }
    }
}