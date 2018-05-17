using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class FileIo_V2_MapFile
    {
		public uint FileObject { get; private set; }
		public uint Flags { get; private set; }
		public ulong MiscInfo { get; private set; }
		public uint ProcessId { get; private set; }
		public uint ViewBase { get; private set; }
		public dynamic ViewSize { get; private set; }

        public static IEnumerable<FileIo_V2_MapFile> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<FileIo_V2_MapFile> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FileIo_V2_MapFile> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM FileIo_V2_MapFile");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FileIo_V2_MapFile
                {
                     FileObject = (uint) (managementObject.Properties["FileObject"]?.Value ?? default(uint)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 MiscInfo = (ulong) (managementObject.Properties["MiscInfo"]?.Value ?? default(ulong)),
		 ProcessId = (uint) (managementObject.Properties["ProcessId"]?.Value ?? default(uint)),
		 ViewBase = (uint) (managementObject.Properties["ViewBase"]?.Value ?? default(uint)),
		 ViewSize = (dynamic) (managementObject.Properties["ViewSize"]?.Value ?? default(dynamic))
                };
        }
    }
}