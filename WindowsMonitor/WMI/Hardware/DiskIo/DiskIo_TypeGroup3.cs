using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class DiskIo_TypeGroup3
    {
		public uint DiskNumber { get; private set; }
		public uint Flags { get; private set; }
		public ulong HighResResponseTime { get; private set; }
		public uint Irp { get; private set; }
		public uint IrpFlags { get; private set; }
		public uint IssuingThreadId { get; private set; }

        public static IEnumerable<DiskIo_TypeGroup3> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DiskIo_TypeGroup3> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DiskIo_TypeGroup3> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM DiskIo_TypeGroup3");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DiskIo_TypeGroup3
                {
                     DiskNumber = (uint) (managementObject.Properties["DiskNumber"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HighResResponseTime = (ulong) (managementObject.Properties["HighResResponseTime"]?.Value ?? default(ulong)),
		 Irp = (uint) (managementObject.Properties["Irp"]?.Value ?? default(uint)),
		 IrpFlags = (uint) (managementObject.Properties["IrpFlags"]?.Value ?? default(uint)),
		 IssuingThreadId = (uint) (managementObject.Properties["IssuingThreadId"]?.Value ?? default(uint))
                };
        }
    }
}