using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class FolderRedirection
    {
		public bool ContentsMoved { get; private set; }
		public bool ContentsMovedOnPolicyRemoval { get; private set; }
		public bool ContentsRenamedInLocalCache { get; private set; }
		public bool ExclusiveRightsGranted { get; private set; }
		public string FolderId { get; private set; }
		public bool MakeFolderAvailableOfflineDisabled { get; private set; }
		public string RedirectionPath { get; private set; }
		public byte RedirectionType { get; private set; }

        public static IEnumerable<FolderRedirection> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<FolderRedirection> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<FolderRedirection> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_FolderRedirection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new FolderRedirection
                {
                     ContentsMoved = (bool) (managementObject.Properties["ContentsMoved"]?.Value ?? default(bool)),
		 ContentsMovedOnPolicyRemoval = (bool) (managementObject.Properties["ContentsMovedOnPolicyRemoval"]?.Value ?? default(bool)),
		 ContentsRenamedInLocalCache = (bool) (managementObject.Properties["ContentsRenamedInLocalCache"]?.Value ?? default(bool)),
		 ExclusiveRightsGranted = (bool) (managementObject.Properties["ExclusiveRightsGranted"]?.Value ?? default(bool)),
		 FolderId = (string) (managementObject.Properties["FolderId"]?.Value ?? default(string)),
		 MakeFolderAvailableOfflineDisabled = (bool) (managementObject.Properties["MakeFolderAvailableOfflineDisabled"]?.Value ?? default(bool)),
		 RedirectionPath = (string) (managementObject.Properties["RedirectionPath"]?.Value ?? default(string)),
		 RedirectionType = (byte) (managementObject.Properties["RedirectionType"]?.Value ?? default(byte))
                };
        }
    }
}