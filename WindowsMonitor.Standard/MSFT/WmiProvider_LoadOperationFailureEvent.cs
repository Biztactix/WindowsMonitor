using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class WmiProvider_LoadOperationFailureEvent
    {
		public string Clsid { get; private set; }
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public bool InProcServer { get; private set; }
		public string InProcServerPath { get; private set; }
		public string Locale { get; private set; }
		public bool LocalServer { get; private set; }
		public string LocalServerPath { get; private set; }
		public string Namespace { get; private set; }
		public string provider { get; private set; }
		public uint ResultCode { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public string ServerName { get; private set; }
		public uint Synchronisation { get; private set; }
		public uint ThreadingModel { get; private set; }
		public ulong TIME_CREATED { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<WmiProvider_LoadOperationFailureEvent> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiProvider_LoadOperationFailureEvent> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiProvider_LoadOperationFailureEvent> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_LoadOperationFailureEvent");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiProvider_LoadOperationFailureEvent
                {
                     Clsid = (string) (managementObject.Properties["Clsid"]?.Value ?? default(string)),
		 HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value ?? default(string)),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 InProcServer = (bool) (managementObject.Properties["InProcServer"]?.Value ?? default(bool)),
		 InProcServerPath = (string) (managementObject.Properties["InProcServerPath"]?.Value ?? default(string)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value ?? default(string)),
		 LocalServer = (bool) (managementObject.Properties["LocalServer"]?.Value ?? default(bool)),
		 LocalServerPath = (string) (managementObject.Properties["LocalServerPath"]?.Value ?? default(string)),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value ?? default(string)),
		 provider = (string) (managementObject.Properties["provider"]?.Value ?? default(string)),
		 ResultCode = (uint) (managementObject.Properties["ResultCode"]?.Value ?? default(uint)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 ServerName = (string) (managementObject.Properties["ServerName"]?.Value ?? default(string)),
		 Synchronisation = (uint) (managementObject.Properties["Synchronisation"]?.Value ?? default(uint)),
		 ThreadingModel = (uint) (managementObject.Properties["ThreadingModel"]?.Value ?? default(uint)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value ?? default(string)),
		 User = (string) (managementObject.Properties["User"]?.Value ?? default(string))
                };
        }
    }
}