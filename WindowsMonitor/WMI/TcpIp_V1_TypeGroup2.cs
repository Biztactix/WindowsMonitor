using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TcpIp_V1_TypeGroup2
    {
		public uint connid { get; private set; }
		public dynamic daddr { get; private set; }
		public dynamic dport { get; private set; }
		public uint Flags { get; private set; }
		public ushort mss { get; private set; }
		public uint PID { get; private set; }
		public uint rcvwin { get; private set; }
		public short rcvwinscale { get; private set; }
		public ushort sackopt { get; private set; }
		public dynamic saddr { get; private set; }
		public uint seqnum { get; private set; }
		public uint size { get; private set; }
		public short sndwinscale { get; private set; }
		public dynamic sport { get; private set; }
		public ushort tsopt { get; private set; }
		public ushort wsopt { get; private set; }

        public static IEnumerable<TcpIp_V1_TypeGroup2> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TcpIp_V1_TypeGroup2> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TcpIp_V1_TypeGroup2> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TcpIp_V1_TypeGroup2");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TcpIp_V1_TypeGroup2
                {
                     connid = (uint) (managementObject.Properties["connid"]?.Value ?? default(uint)),
		 daddr = (dynamic) (managementObject.Properties["daddr"]?.Value ?? default(dynamic)),
		 dport = (dynamic) (managementObject.Properties["dport"]?.Value ?? default(dynamic)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 mss = (ushort) (managementObject.Properties["mss"]?.Value ?? default(ushort)),
		 PID = (uint) (managementObject.Properties["PID"]?.Value ?? default(uint)),
		 rcvwin = (uint) (managementObject.Properties["rcvwin"]?.Value ?? default(uint)),
		 rcvwinscale = (short) (managementObject.Properties["rcvwinscale"]?.Value ?? default(short)),
		 sackopt = (ushort) (managementObject.Properties["sackopt"]?.Value ?? default(ushort)),
		 saddr = (dynamic) (managementObject.Properties["saddr"]?.Value ?? default(dynamic)),
		 seqnum = (uint) (managementObject.Properties["seqnum"]?.Value ?? default(uint)),
		 size = (uint) (managementObject.Properties["size"]?.Value ?? default(uint)),
		 sndwinscale = (short) (managementObject.Properties["sndwinscale"]?.Value ?? default(short)),
		 sport = (dynamic) (managementObject.Properties["sport"]?.Value ?? default(dynamic)),
		 tsopt = (ushort) (managementObject.Properties["tsopt"]?.Value ?? default(ushort)),
		 wsopt = (ushort) (managementObject.Properties["wsopt"]?.Value ?? default(ushort))
                };
        }
    }
}