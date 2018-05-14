using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class Error
    {
		public uint CIMStatusCode { get; private set; }
		public string CIMStatusCodeDescription { get; private set; }
		public string ErrorSource { get; private set; }
		public ushort ErrorSourceFormat { get; private set; }
		public ushort ErrorType { get; private set; }
		public string Message { get; private set; }
		public string[] MessageArguments { get; private set; }
		public string MessageID { get; private set; }
		public string OtherErrorSourceFormat { get; private set; }
		public string OtherErrorType { get; private set; }
		public string OWningEntity { get; private set; }
		public ushort PerceivedSeverity { get; private set; }
		public ushort ProbableCause { get; private set; }
		public string ProbableCauseDescription { get; private set; }
		public string[] RecommendedActions { get; private set; }

        public static IEnumerable<Error> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Error> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Error> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_Error");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Error
                {
                     CIMStatusCode = (uint) (managementObject.Properties["CIMStatusCode"]?.Value ?? default(uint)),
		 CIMStatusCodeDescription = (string) (managementObject.Properties["CIMStatusCodeDescription"]?.Value),
		 ErrorSource = (string) (managementObject.Properties["ErrorSource"]?.Value),
		 ErrorSourceFormat = (ushort) (managementObject.Properties["ErrorSourceFormat"]?.Value ?? default(ushort)),
		 ErrorType = (ushort) (managementObject.Properties["ErrorType"]?.Value ?? default(ushort)),
		 Message = (string) (managementObject.Properties["Message"]?.Value),
		 MessageArguments = (string[]) (managementObject.Properties["MessageArguments"]?.Value ?? new string[0]),
		 MessageID = (string) (managementObject.Properties["MessageID"]?.Value),
		 OtherErrorSourceFormat = (string) (managementObject.Properties["OtherErrorSourceFormat"]?.Value),
		 OtherErrorType = (string) (managementObject.Properties["OtherErrorType"]?.Value),
		 OWningEntity = (string) (managementObject.Properties["OWningEntity"]?.Value),
		 PerceivedSeverity = (ushort) (managementObject.Properties["PerceivedSeverity"]?.Value ?? default(ushort)),
		 ProbableCause = (ushort) (managementObject.Properties["ProbableCause"]?.Value ?? default(ushort)),
		 ProbableCauseDescription = (string) (managementObject.Properties["ProbableCauseDescription"]?.Value),
		 RecommendedActions = (string[]) (managementObject.Properties["RecommendedActions"]?.Value ?? new string[0])
                };
        }
    }
}