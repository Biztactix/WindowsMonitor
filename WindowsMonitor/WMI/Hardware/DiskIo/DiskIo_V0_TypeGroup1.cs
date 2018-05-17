using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class DiskIo_V0_TypeGroup1
    {
		public ulong ByteOffset { get; private set; }
		public uint DiskNumber { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public uint IrpFlags { get; private set; }
		public uint Reserved { get; private set; }
		public uint TransferSize { get; private set; }

        public static IEnumerable<DiskIo_V0_TypeGroup1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DiskIo_V0_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DiskIo_V0_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM DiskIo_V0_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DiskIo_V0_TypeGroup1
                {
                     ByteOffset = (ulong) (managementObject.Properties["ByteOffset"]?.Value ?? default(ulong)),
		 DiskNumber = (uint) (managementObject.Properties["DiskNumber"]?.Value ?? default(uint)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IrpFlags = (uint) (managementObject.Properties["IrpFlags"]?.Value ?? default(uint)),
		 Reserved = (uint) (managementObject.Properties["Reserved"]?.Value ?? default(uint)),
		 TransferSize = (uint) (managementObject.Properties["TransferSize"]?.Value ?? default(uint))
                };
        }
    }
}