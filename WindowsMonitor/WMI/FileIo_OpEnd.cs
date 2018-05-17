using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FileIo_OpEnd
    {
		public uint ExtraInfo { get; private set; }
		public uint Flags { get; private set; }
		public uint IrpPtr { get; private set; }
		public uint NtStatus { get; private set; }

        public static IEnumerable<FileIo_OpEnd> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileIo_OpEnd> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileIo_OpEnd> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FileIo_OpEnd");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileIo_OpEnd
                {
                     ExtraInfo = (uint) (managementObject.Properties["ExtraInfo"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 IrpPtr = (uint) (managementObject.Properties["IrpPtr"]?.Value ?? default(uint)),
		 NtStatus = (uint) (managementObject.Properties["NtStatus"]?.Value ?? default(uint))
                };
        }
    }
}