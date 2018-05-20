using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Storage.MSStorageDriver
{
    /// <summary>
    /// </summary>
    public sealed class SenseData
    {
		public byte additionalSenseCode { get; private set; }
		public byte additionalSenseCodeQualifier { get; private set; }
		public byte additionalSenseLength { get; private set; }
		public byte[] commandSpecificInformation { get; private set; }
		public bool endOfMedia { get; private set; }
		public byte errorCode { get; private set; }
		public byte fieldReplaceableUnitCode { get; private set; }
		public bool fileMark { get; private set; }
		public bool incorrectLength { get; private set; }
		public byte[] information { get; private set; }
		public bool reserved { get; private set; }
		public byte segmentNumber { get; private set; }
		public byte senseKey { get; private set; }
		public byte[] senseKeySpecific { get; private set; }
		public bool valid { get; private set; }

        public static IEnumerable<SenseData> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SenseData> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SenseData> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSStorageDriver_SenseData");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SenseData
                {
                     additionalSenseCode = (byte) (managementObject.Properties["additionalSenseCode"]?.Value ?? default(byte)),
		 additionalSenseCodeQualifier = (byte) (managementObject.Properties["additionalSenseCodeQualifier"]?.Value ?? default(byte)),
		 additionalSenseLength = (byte) (managementObject.Properties["additionalSenseLength"]?.Value ?? default(byte)),
		 commandSpecificInformation = (byte[]) (managementObject.Properties["commandSpecificInformation"]?.Value ?? new byte[0]),
		 endOfMedia = (bool) (managementObject.Properties["endOfMedia"]?.Value ?? default(bool)),
		 errorCode = (byte) (managementObject.Properties["errorCode"]?.Value ?? default(byte)),
		 fieldReplaceableUnitCode = (byte) (managementObject.Properties["fieldReplaceableUnitCode"]?.Value ?? default(byte)),
		 fileMark = (bool) (managementObject.Properties["fileMark"]?.Value ?? default(bool)),
		 incorrectLength = (bool) (managementObject.Properties["incorrectLength"]?.Value ?? default(bool)),
		 information = (byte[]) (managementObject.Properties["information"]?.Value ?? new byte[0]),
		 reserved = (bool) (managementObject.Properties["reserved"]?.Value ?? default(bool)),
		 segmentNumber = (byte) (managementObject.Properties["segmentNumber"]?.Value ?? default(byte)),
		 senseKey = (byte) (managementObject.Properties["senseKey"]?.Value ?? default(byte)),
		 senseKeySpecific = (byte[]) (managementObject.Properties["senseKeySpecific"]?.Value ?? new byte[0]),
		 valid = (bool) (managementObject.Properties["valid"]?.Value ?? default(bool))
                };
        }
    }
}