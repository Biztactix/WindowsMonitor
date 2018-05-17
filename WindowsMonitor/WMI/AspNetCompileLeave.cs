using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class AspNetCompileLeave
    {
		public ulong ConnID { get; private set; }
		public dynamic ContextId { get; private set; }
		public string Files { get; private set; }
		public uint Flags { get; private set; }
		public uint Level { get; private set; }
		public string Status { get; private set; }

        public static IEnumerable<AspNetCompileLeave> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<AspNetCompileLeave> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<AspNetCompileLeave> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM AspNetCompileLeave");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new AspNetCompileLeave
                {
                     ConnID = (ulong) (managementObject.Properties["ConnID"]?.Value ?? default(ulong)),
		 ContextId = (dynamic) (managementObject.Properties["ContextId"]?.Value ?? default(dynamic)),
		 Files = (string) (managementObject.Properties["Files"]?.Value ?? default(string)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 Level = (uint) (managementObject.Properties["Level"]?.Value ?? default(uint)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string))
                };
        }
    }
}