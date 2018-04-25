using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ServerSession
    {
		public uint ActiveTime { get; private set; }
		public string Caption { get; private set; }
		public string ClientType { get; private set; }
		public string ComputerName { get; private set; }
		public string Description { get; private set; }
		public uint IdleTime { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public uint ResourcesOpened { get; private set; }
		public uint SessionType { get; private set; }
		public string Status { get; private set; }
		public string TransportName { get; private set; }
		public string UserName { get; private set; }

        public static IEnumerable<ServerSession> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServerSession> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServerSession> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServerSession");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServerSession
                {
                     ActiveTime = (uint) (managementObject.Properties["ActiveTime"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ClientType = (string) (managementObject.Properties["ClientType"]?.Value ?? default(string)),
		 ComputerName = (string) (managementObject.Properties["ComputerName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 IdleTime = (uint) (managementObject.Properties["IdleTime"]?.Value ?? default(uint)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ResourcesOpened = (uint) (managementObject.Properties["ResourcesOpened"]?.Value ?? default(uint)),
		 SessionType = (uint) (managementObject.Properties["SessionType"]?.Value ?? default(uint)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 TransportName = (string) (managementObject.Properties["TransportName"]?.Value ?? default(string)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value ?? default(string))
                };
        }
    }
}