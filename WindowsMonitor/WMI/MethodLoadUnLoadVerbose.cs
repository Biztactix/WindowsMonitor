using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MethodLoadUnLoadVerbose
    {
		public uint MethodFlags { get; private set; }
		public ulong MethodIdentifier { get; private set; }
		public string Methodname { get; private set; }
		public string MethodNameSpace { get; private set; }
		public string MethodSig { get; private set; }
		public uint MethodSize { get; private set; }
		public ulong MethodStartAddress { get; private set; }
		public uint MethodToken { get; private set; }
		public ulong ModuleID { get; private set; }

        public static IEnumerable<MethodLoadUnLoadVerbose> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MethodLoadUnLoadVerbose> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MethodLoadUnLoadVerbose> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MethodLoadUnLoadVerbose");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MethodLoadUnLoadVerbose
                {
                     MethodFlags = (uint) (managementObject.Properties["MethodFlags"]?.Value ?? default(uint)),
		 MethodIdentifier = (ulong) (managementObject.Properties["MethodIdentifier"]?.Value ?? default(ulong)),
		 Methodname = (string) (managementObject.Properties["Methodname"]?.Value ?? default(string)),
		 MethodNameSpace = (string) (managementObject.Properties["MethodNameSpace"]?.Value ?? default(string)),
		 MethodSig = (string) (managementObject.Properties["MethodSig"]?.Value ?? default(string)),
		 MethodSize = (uint) (managementObject.Properties["MethodSize"]?.Value ?? default(uint)),
		 MethodStartAddress = (ulong) (managementObject.Properties["MethodStartAddress"]?.Value ?? default(ulong)),
		 MethodToken = (uint) (managementObject.Properties["MethodToken"]?.Value ?? default(uint)),
		 ModuleID = (ulong) (managementObject.Properties["ModuleID"]?.Value ?? default(ulong))
                };
        }
    }
}