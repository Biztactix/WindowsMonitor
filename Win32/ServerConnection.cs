using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ServerConnection
    {
		public uint ActiveTime { get; private set; }
		public string Caption { get; private set; }
		public string ComputerName { get; private set; }
		public uint ConnectionID { get; private set; }
		public string Description { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string Name { get; private set; }
		public uint NumberOfFiles { get; private set; }
		public uint NumberOfUsers { get; private set; }
		public string ShareName { get; private set; }
		public string Status { get; private set; }
		public string UserName { get; private set; }

        public static IEnumerable<ServerConnection> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServerConnection> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServerConnection> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServerConnection");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServerConnection
                {
                     ActiveTime = (uint) (managementObject.Properties["ActiveTime"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ComputerName = (string) (managementObject.Properties["ComputerName"]?.Value ?? default(string)),
		 ConnectionID = (uint) (managementObject.Properties["ConnectionID"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberOfFiles = (uint) (managementObject.Properties["NumberOfFiles"]?.Value ?? default(uint)),
		 NumberOfUsers = (uint) (managementObject.Properties["NumberOfUsers"]?.Value ?? default(uint)),
		 ShareName = (string) (managementObject.Properties["ShareName"]?.Value ?? default(string)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value ?? default(string))
                };
        }
    }
}