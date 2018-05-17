using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class NlServerAuth_Start
    {
		public string Account { get; private set; }
		public uint ChannelType { get; private set; }
		public string Client { get; private set; }
		public uint NegotiatedFlags { get; private set; }

        public static IEnumerable<NlServerAuth_Start> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NlServerAuth_Start> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NlServerAuth_Start> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM NlServerAuth_Start");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NlServerAuth_Start
                {
                     Account = (string) (managementObject.Properties["Account"]?.Value ?? default(string)),
		 ChannelType = (uint) (managementObject.Properties["ChannelType"]?.Value ?? default(uint)),
		 Client = (string) (managementObject.Properties["Client"]?.Value ?? default(string)),
		 NegotiatedFlags = (uint) (managementObject.Properties["NegotiatedFlags"]?.Value ?? default(uint))
                };
        }
    }
}