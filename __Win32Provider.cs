using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __Win32Provider
    {
		public string ClientLoadableCLSID { get; private set; }
		public string CLSID { get; private set; }
		public int Concurrency { get; private set; }
		public string DefaultMachineName { get; private set; }
		public bool Enabled { get; private set; }
		public string HostingModel { get; private set; }
		public int ImpersonationLevel { get; private set; }
		public int InitializationReentrancy { get; private set; }
		public DateTime InitializationTimeoutInterval { get; private set; }
		public bool InitializeAsAdminFirst { get; private set; }
		public string Name { get; private set; }
		public DateTime OperationTimeoutInterval { get; private set; }
		public bool PerLocaleInitialization { get; private set; }
		public bool PerUserInitialization { get; private set; }
		public bool Pure { get; private set; }
		public string SecurityDescriptor { get; private set; }
		public bool SupportsExplicitShutdown { get; private set; }
		public bool SupportsExtendedStatus { get; private set; }
		public bool SupportsQuotas { get; private set; }
		public bool SupportsSendStatus { get; private set; }
		public bool SupportsShutdown { get; private set; }
		public bool SupportsThrottling { get; private set; }
		public DateTime UnloadTimeout { get; private set; }
		public uint Version { get; private set; }

        public static IEnumerable<__Win32Provider> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = System.Management.ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<__Win32Provider> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__Win32Provider> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __Win32Provider");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __Win32Provider
                {
                     ClientLoadableCLSID = (string) (managementObject.Properties["ClientLoadableCLSID"]?.Value ?? default(string)),
		 CLSID = (string) (managementObject.Properties["CLSID"]?.Value ?? default(string)),
		 Concurrency = (int) (managementObject.Properties["Concurrency"]?.Value ?? default(int)),
		 DefaultMachineName = (string) (managementObject.Properties["DefaultMachineName"]?.Value ?? default(string)),
		 Enabled = (bool) (managementObject.Properties["Enabled"]?.Value ?? default(bool)),
		 HostingModel = (string) (managementObject.Properties["HostingModel"]?.Value ?? default(string)),
		 ImpersonationLevel = (int) (managementObject.Properties["ImpersonationLevel"]?.Value ?? default(int)),
		 InitializationReentrancy = (int) (managementObject.Properties["InitializationReentrancy"]?.Value ?? default(int)),
		 InitializationTimeoutInterval = (DateTime) (managementObject.Properties["InitializationTimeoutInterval"]?.Value ?? default(DateTime)),
		 InitializeAsAdminFirst = (bool) (managementObject.Properties["InitializeAsAdminFirst"]?.Value ?? default(bool)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OperationTimeoutInterval = (DateTime) (managementObject.Properties["OperationTimeoutInterval"]?.Value ?? default(DateTime)),
		 PerLocaleInitialization = (bool) (managementObject.Properties["PerLocaleInitialization"]?.Value ?? default(bool)),
		 PerUserInitialization = (bool) (managementObject.Properties["PerUserInitialization"]?.Value ?? default(bool)),
		 Pure = (bool) (managementObject.Properties["Pure"]?.Value ?? default(bool)),
		 SecurityDescriptor = (string) (managementObject.Properties["SecurityDescriptor"]?.Value ?? default(string)),
		 SupportsExplicitShutdown = (bool) (managementObject.Properties["SupportsExplicitShutdown"]?.Value ?? default(bool)),
		 SupportsExtendedStatus = (bool) (managementObject.Properties["SupportsExtendedStatus"]?.Value ?? default(bool)),
		 SupportsQuotas = (bool) (managementObject.Properties["SupportsQuotas"]?.Value ?? default(bool)),
		 SupportsSendStatus = (bool) (managementObject.Properties["SupportsSendStatus"]?.Value ?? default(bool)),
		 SupportsShutdown = (bool) (managementObject.Properties["SupportsShutdown"]?.Value ?? default(bool)),
		 SupportsThrottling = (bool) (managementObject.Properties["SupportsThrottling"]?.Value ?? default(bool)),
		 UnloadTimeout = (DateTime) (managementObject.Properties["UnloadTimeout"]?.Value ?? default(DateTime)),
		 Version = (uint) (managementObject.Properties["Version"]?.Value ?? default(uint))
                };
        }
    }
}