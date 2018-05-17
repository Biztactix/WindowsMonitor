using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TcpIp_TypeGroup1
    {
		public uint connid { get; private set; }
		public dynamic daddr { get; private set; }
		public dynamic dport { get; private set; }
		public uint Flags { get; private set; }
		public uint PID { get; private set; }
		public dynamic saddr { get; private set; }
		public uint seqnum { get; private set; }
		public uint size { get; private set; }
		public dynamic sport { get; private set; }

        public static IEnumerable<TcpIp_TypeGroup1> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TcpIp_TypeGroup1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TcpIp_TypeGroup1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TcpIp_TypeGroup1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TcpIp_TypeGroup1
                {
                     connid = (uint) (managementObject.Properties["connid"]?.Value ?? default(uint)),
		 daddr = (dynamic) (managementObject.Properties["daddr"]?.Value ?? default(dynamic)),
		 dport = (dynamic) (managementObject.Properties["dport"]?.Value ?? default(dynamic)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 PID = (uint) (managementObject.Properties["PID"]?.Value ?? default(uint)),
		 saddr = (dynamic) (managementObject.Properties["saddr"]?.Value ?? default(dynamic)),
		 seqnum = (uint) (managementObject.Properties["seqnum"]?.Value ?? default(uint)),
		 size = (uint) (managementObject.Properties["size"]?.Value ?? default(uint)),
		 sport = (dynamic) (managementObject.Properties["sport"]?.Value ?? default(dynamic))
                };
        }
    }
}