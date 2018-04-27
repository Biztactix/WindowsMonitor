using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class WmiProvider_PutClassAsyncEvent_Post
    {
		public dynamic ClassObject { get; private set; }
		public uint Flags { get; private set; }
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public dynamic ObjectParameter { get; private set; }
		public string provider { get; private set; }
		public uint ResultCode { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public string StringParameter { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<WmiProvider_PutClassAsyncEvent_Post> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiProvider_PutClassAsyncEvent_Post> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiProvider_PutClassAsyncEvent_Post> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_PutClassAsyncEvent_Post");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiProvider_PutClassAsyncEvent_Post
                {
                     ClassObject = (dynamic) (managementObject.Properties["ClassObject"]?.Value ?? default(dynamic)),
		 Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value ?? default(string)),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value ?? default(string)),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value ?? default(string)),
		 ObjectParameter = (dynamic) (managementObject.Properties["ObjectParameter"]?.Value ?? default(dynamic)),
		 provider = (string) (managementObject.Properties["provider"]?.Value ?? default(string)),
		 ResultCode = (uint) (managementObject.Properties["ResultCode"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 StringParameter = (string) (managementObject.Properties["StringParameter"]?.Value ?? default(string)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value ?? default(string)),
		 User = (string) (managementObject.Properties["User"]?.Value ?? default(string))
                };
        }
    }
}