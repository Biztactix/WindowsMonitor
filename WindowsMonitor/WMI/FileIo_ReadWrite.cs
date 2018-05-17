using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FileIo_ReadWrite
    {
		public uint FileKey { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public uint IoFlags { get; private set; }
		public uint IoSize { get; private set; }
		public uint IrpPtr { get; private set; }
		public ulong Offset { get; private set; }
		public uint TTID { get; private set; }

        public static IEnumerable<FileIo_ReadWrite> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileIo_ReadWrite> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileIo_ReadWrite> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FileIo_ReadWrite");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileIo_ReadWrite
                {
                     FileKey = (uint) (managementObject.Properties["FileKey"]?.Value ?? default(uint)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IoFlags = (uint) (managementObject.Properties["IoFlags"]?.Value ?? default(uint)),
		 IoSize = (uint) (managementObject.Properties["IoSize"]?.Value ?? default(uint)),
		 IrpPtr = (uint) (managementObject.Properties["IrpPtr"]?.Value ?? default(uint)),
		 Offset = (ulong) (managementObject.Properties["Offset"]?.Value ?? default(ulong)),
		 TTID = (uint) (managementObject.Properties["TTID"]?.Value ?? default(uint))
                };
        }
    }
}