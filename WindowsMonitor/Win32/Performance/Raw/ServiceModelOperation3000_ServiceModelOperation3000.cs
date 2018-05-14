using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class ServiceModelOperation3000_ServiceModelOperation3000
    {
		public uint CallFailedPerSecond { get; private set; }
		public uint Calls { get; private set; }
		public uint CallsDuration { get; private set; }
		public uint CallsDuration_Base { get; private set; }
		public uint CallsFailed { get; private set; }
		public uint CallsFaulted { get; private set; }
		public uint CallsFaultedPerSecond { get; private set; }
		public uint CallsOutstanding { get; private set; }
		public uint CallsPerSecond { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint SecurityCallsNotAuthorized { get; private set; }
		public uint SecurityCallsNotAuthorizedPerSecond { get; private set; }
		public uint SecurityValidationandAuthenticationFailures { get; private set; }
		public uint SecurityValidationandAuthenticationFailuresPerSecond { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TransactionsFlowed { get; private set; }
		public uint TransactionsFlowedPerSecond { get; private set; }

        public static IEnumerable<ServiceModelOperation3000_ServiceModelOperation3000> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServiceModelOperation3000_ServiceModelOperation3000> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServiceModelOperation3000_ServiceModelOperation3000> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ServiceModelOperation3000_ServiceModelOperation3000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServiceModelOperation3000_ServiceModelOperation3000
                {
                     CallFailedPerSecond = (uint) (managementObject.Properties["CallFailedPerSecond"]?.Value ?? default(uint)),
		 Calls = (uint) (managementObject.Properties["Calls"]?.Value ?? default(uint)),
		 CallsDuration = (uint) (managementObject.Properties["CallsDuration"]?.Value ?? default(uint)),
		 CallsDuration_Base = (uint) (managementObject.Properties["CallsDuration_Base"]?.Value ?? default(uint)),
		 CallsFailed = (uint) (managementObject.Properties["CallsFailed"]?.Value ?? default(uint)),
		 CallsFaulted = (uint) (managementObject.Properties["CallsFaulted"]?.Value ?? default(uint)),
		 CallsFaultedPerSecond = (uint) (managementObject.Properties["CallsFaultedPerSecond"]?.Value ?? default(uint)),
		 CallsOutstanding = (uint) (managementObject.Properties["CallsOutstanding"]?.Value ?? default(uint)),
		 CallsPerSecond = (uint) (managementObject.Properties["CallsPerSecond"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SecurityCallsNotAuthorized = (uint) (managementObject.Properties["SecurityCallsNotAuthorized"]?.Value ?? default(uint)),
		 SecurityCallsNotAuthorizedPerSecond = (uint) (managementObject.Properties["SecurityCallsNotAuthorizedPerSecond"]?.Value ?? default(uint)),
		 SecurityValidationandAuthenticationFailures = (uint) (managementObject.Properties["SecurityValidationandAuthenticationFailures"]?.Value ?? default(uint)),
		 SecurityValidationandAuthenticationFailuresPerSecond = (uint) (managementObject.Properties["SecurityValidationandAuthenticationFailuresPerSecond"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionsFlowed = (uint) (managementObject.Properties["TransactionsFlowed"]?.Value ?? default(uint)),
		 TransactionsFlowedPerSecond = (uint) (managementObject.Properties["TransactionsFlowedPerSecond"]?.Value ?? default(uint))
                };
        }
    }
}