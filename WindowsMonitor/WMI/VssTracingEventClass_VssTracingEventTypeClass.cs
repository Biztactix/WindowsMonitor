using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class VssTracingEventClass_VssTracingEventTypeClass
    {
		public string FunctionName { get; private set; }
		public uint Indent { get; private set; }
		public uint LineNumber { get; private set; }
		public string MessageDescription { get; private set; }
		public uint ModuleIndex { get; private set; }
		public string SourceFileAlias { get; private set; }
		public string SourceFileName { get; private set; }
		public string Text { get; private set; }

        public static IEnumerable<VssTracingEventClass_VssTracingEventTypeClass> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<VssTracingEventClass_VssTracingEventTypeClass> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<VssTracingEventClass_VssTracingEventTypeClass> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM VssTracingEventClass_VssTracingEventTypeClass");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new VssTracingEventClass_VssTracingEventTypeClass
                {
                     FunctionName = (string) (managementObject.Properties["FunctionName"]?.Value ?? default(string)),
		 Indent = (uint) (managementObject.Properties["Indent"]?.Value ?? default(uint)),
		 LineNumber = (uint) (managementObject.Properties["LineNumber"]?.Value ?? default(uint)),
		 MessageDescription = (string) (managementObject.Properties["MessageDescription"]?.Value ?? default(string)),
		 ModuleIndex = (uint) (managementObject.Properties["ModuleIndex"]?.Value ?? default(uint)),
		 SourceFileAlias = (string) (managementObject.Properties["SourceFileAlias"]?.Value ?? default(string)),
		 SourceFileName = (string) (managementObject.Properties["SourceFileName"]?.Value ?? default(string)),
		 Text = (string) (managementObject.Properties["Text"]?.Value ?? default(string))
                };
        }
    }
}