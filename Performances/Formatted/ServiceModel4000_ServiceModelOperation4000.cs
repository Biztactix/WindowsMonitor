using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_ServiceModel4000_ServiceModelOperation4000
    {
        public uint CallFailedPerSecond { get; private set; }
        public uint Calls { get; private set; }
        public uint CallsDuration { get; private set; }
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

        public static PerfFormattedData_ServiceModel4000_ServiceModelOperation4000[] Retrieve(string remote,
            string username, string password)
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

        public static PerfFormattedData_ServiceModel4000_ServiceModelOperation4000[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_ServiceModel4000_ServiceModelOperation4000[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ServiceModel4000_ServiceModelOperation4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_ServiceModel4000_ServiceModelOperation4000>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_ServiceModel4000_ServiceModelOperation4000
                {
                    CallFailedPerSecond = (uint) managementObject.Properties["CallFailedPerSecond"].Value,
                    Calls = (uint) managementObject.Properties["Calls"].Value,
                    CallsDuration = (uint) managementObject.Properties["CallsDuration"].Value,
                    CallsFailed = (uint) managementObject.Properties["CallsFailed"].Value,
                    CallsFaulted = (uint) managementObject.Properties["CallsFaulted"].Value,
                    CallsFaultedPerSecond = (uint) managementObject.Properties["CallsFaultedPerSecond"].Value,
                    CallsOutstanding = (uint) managementObject.Properties["CallsOutstanding"].Value,
                    CallsPerSecond = (uint) managementObject.Properties["CallsPerSecond"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SecurityCallsNotAuthorized = (uint) managementObject.Properties["SecurityCallsNotAuthorized"].Value,
                    SecurityCallsNotAuthorizedPerSecond =
                        (uint) managementObject.Properties["SecurityCallsNotAuthorizedPerSecond"].Value,
                    SecurityValidationandAuthenticationFailures = (uint) managementObject
                        .Properties["SecurityValidationandAuthenticationFailures"].Value,
                    SecurityValidationandAuthenticationFailuresPerSecond = (uint) managementObject
                        .Properties["SecurityValidationandAuthenticationFailuresPerSecond"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    TransactionsFlowed = (uint) managementObject.Properties["TransactionsFlowed"].Value,
                    TransactionsFlowedPerSecond = (uint) managementObject.Properties["TransactionsFlowedPerSecond"]
                        .Value
                });

            return list.ToArray();
        }
    }
}