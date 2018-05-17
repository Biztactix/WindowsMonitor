using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FileIo_V2_DirEnum
    {
		public uint FileIndex { get; private set; }
		public uint FileKey { get; private set; }
		public string FileName { get; private set; }
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public uint InfoClass { get; private set; }
		public uint IrpPtr { get; private set; }
		public uint Length { get; private set; }
		public uint TTID { get; private set; }

        public static IEnumerable<FileIo_V2_DirEnum> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileIo_V2_DirEnum> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileIo_V2_DirEnum> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FileIo_V2_DirEnum");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileIo_V2_DirEnum
                {
                     FileIndex = (uint) (managementObject.Properties["FileIndex"]?.Value ?? default(uint)),
		 FileKey = (uint) (managementObject.Properties["FileKey"]?.Value ?? default(uint)),
		 FileName = (string) (managementObject.Properties["FileName"]?.Value ?? default(string)),
		 FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InfoClass = (uint) (managementObject.Properties["InfoClass"]?.Value ?? default(uint)),
		 IrpPtr = (uint) (managementObject.Properties["IrpPtr"]?.Value ?? default(uint)),
		 Length = (uint) (managementObject.Properties["Length"]?.Value ?? default(uint)),
		 TTID = (uint) (managementObject.Properties["TTID"]?.Value ?? default(uint))
                };
        }
    }
}