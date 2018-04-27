using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class Thread
    {
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public ushort ExecutionState { get; private set; }
		public string Handle { get; private set; }
		public DateTime InstallDate { get; private set; }
		public ulong KernelModeTime { get; private set; }
		public string Name { get; private set; }
		public string OSCreationClassName { get; private set; }
		public string OSName { get; private set; }
		public uint Priority { get; private set; }
		public string ProcessCreationClassName { get; private set; }
		public string ProcessHandle { get; private set; }
		public string Status { get; private set; }
		public ulong UserModeTime { get; private set; }

        public static IEnumerable<Thread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Thread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Thread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_Thread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Thread
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ExecutionState = (ushort) (managementObject.Properties["ExecutionState"]?.Value ?? default(ushort)),
		 Handle = (string) (managementObject.Properties["Handle"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 KernelModeTime = (ulong) (managementObject.Properties["KernelModeTime"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OSCreationClassName = (string) (managementObject.Properties["OSCreationClassName"]?.Value ?? default(string)),
		 OSName = (string) (managementObject.Properties["OSName"]?.Value ?? default(string)),
		 Priority = (uint) (managementObject.Properties["Priority"]?.Value ?? default(uint)),
		 ProcessCreationClassName = (string) (managementObject.Properties["ProcessCreationClassName"]?.Value ?? default(string)),
		 ProcessHandle = (string) (managementObject.Properties["ProcessHandle"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 UserModeTime = (ulong) (managementObject.Properties["UserModeTime"]?.Value ?? default(ulong))
                };
        }
    }
}