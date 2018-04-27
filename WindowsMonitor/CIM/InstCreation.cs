using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class InstCreation
    {
		public string[] CorrelatedIndications { get; private set; }
		public string IndicationFilterName { get; private set; }
		public string IndicationIdentifier { get; private set; }
		public DateTime IndicationTime { get; private set; }
		public string OtherSeverity { get; private set; }
		public ushort PerceivedSeverity { get; private set; }
		public string SequenceContext { get; private set; }
		public long SequenceNumber { get; private set; }
		public dynamic SourceInstance { get; private set; }
		public string SourceInstanceHost { get; private set; }
		public string SourceInstanceModelPath { get; private set; }

        public static IEnumerable<InstCreation> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<InstCreation> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<InstCreation> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_InstCreation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new InstCreation
                {
                     CorrelatedIndications = (string[]) (managementObject.Properties["CorrelatedIndications"]?.Value ?? new string[0]),
		 IndicationFilterName = (string) (managementObject.Properties["IndicationFilterName"]?.Value ?? default(string)),
		 IndicationIdentifier = (string) (managementObject.Properties["IndicationIdentifier"]?.Value ?? default(string)),
		 IndicationTime = (DateTime) (managementObject.Properties["IndicationTime"]?.Value ?? default(DateTime)),
		 OtherSeverity = (string) (managementObject.Properties["OtherSeverity"]?.Value ?? default(string)),
		 PerceivedSeverity = (ushort) (managementObject.Properties["PerceivedSeverity"]?.Value ?? default(ushort)),
		 SequenceContext = (string) (managementObject.Properties["SequenceContext"]?.Value ?? default(string)),
		 SequenceNumber = (long) (managementObject.Properties["SequenceNumber"]?.Value ?? default(long)),
		 SourceInstance = (dynamic) (managementObject.Properties["SourceInstance"]?.Value ?? default(dynamic)),
		 SourceInstanceHost = (string) (managementObject.Properties["SourceInstanceHost"]?.Value ?? default(string)),
		 SourceInstanceModelPath = (string) (managementObject.Properties["SourceInstanceModelPath"]?.Value ?? default(string))
                };
        }
    }
}