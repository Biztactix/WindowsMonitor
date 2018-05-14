using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ClassModification
    {
		public dynamic ClassDefinition { get; private set; }
		public string[] CorrelatedIndications { get; private set; }
		public string IndicationFilterName { get; private set; }
		public string IndicationIdentifier { get; private set; }
		public DateTime IndicationTime { get; private set; }
		public string OtherSeverity { get; private set; }
		public ushort PerceivedSeverity { get; private set; }
		public dynamic PreviousClassDefinition { get; private set; }
		public string SequenceContext { get; private set; }
		public long SequenceNumber { get; private set; }

        public static IEnumerable<ClassModification> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ClassModification> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ClassModification> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ClassModification");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ClassModification
                {
                     ClassDefinition = (dynamic) (managementObject.Properties["ClassDefinition"]?.Value ?? default(dynamic)),
		 CorrelatedIndications = (string[]) (managementObject.Properties["CorrelatedIndications"]?.Value ?? new string[0]),
		 IndicationFilterName = (string) (managementObject.Properties["IndicationFilterName"]?.Value),
		 IndicationIdentifier = (string) (managementObject.Properties["IndicationIdentifier"]?.Value),
		 IndicationTime = (DateTime) (managementObject.Properties["IndicationTime"]?.Value ?? default(DateTime)),
		 OtherSeverity = (string) (managementObject.Properties["OtherSeverity"]?.Value),
		 PerceivedSeverity = (ushort) (managementObject.Properties["PerceivedSeverity"]?.Value ?? default(ushort)),
		 PreviousClassDefinition = (dynamic) (managementObject.Properties["PreviousClassDefinition"]?.Value ?? default(dynamic)),
		 SequenceContext = (string) (managementObject.Properties["SequenceContext"]?.Value),
		 SequenceNumber = (long) (managementObject.Properties["SequenceNumber"]?.Value ?? default(long))
                };
        }
    }
}