using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISCSI_RedirectPortalInfo
    {
		public dynamic OriginalIPAddr { get; private set; }
		public uint OriginalPort { get; private set; }
		public byte Redirected { get; private set; }
		public dynamic RedirectedIPAddr { get; private set; }
		public uint RedirectedPort { get; private set; }
		public byte TemporaryRedirect { get; private set; }
		public ulong UniqueConnectionId { get; private set; }

        public static IEnumerable<ISCSI_RedirectPortalInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ISCSI_RedirectPortalInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISCSI_RedirectPortalInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISCSI_RedirectPortalInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISCSI_RedirectPortalInfo
                {
                     OriginalIPAddr = (dynamic) (managementObject.Properties["OriginalIPAddr"]?.Value ?? default(dynamic)),
		 OriginalPort = (uint) (managementObject.Properties["OriginalPort"]?.Value ?? default(uint)),
		 Redirected = (byte) (managementObject.Properties["Redirected"]?.Value ?? default(byte)),
		 RedirectedIPAddr = (dynamic) (managementObject.Properties["RedirectedIPAddr"]?.Value ?? default(dynamic)),
		 RedirectedPort = (uint) (managementObject.Properties["RedirectedPort"]?.Value ?? default(uint)),
		 TemporaryRedirect = (byte) (managementObject.Properties["TemporaryRedirect"]?.Value ?? default(byte)),
		 UniqueConnectionId = (ulong) (managementObject.Properties["UniqueConnectionId"]?.Value ?? default(ulong))
                };
        }
    }
}