using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class NomadPackages
    {
		public string AlreadyCached { get; private set; }
		public string BackOffSeconds { get; private set; }
		public string BytesFromDp { get; private set; }
		public string BytesFromPeer { get; private set; }
		public string CachePriority { get; private set; }
		public string CacheToFolder { get; private set; }
		public string CachingSeconds { get; private set; }
		public string DisconnectedSeconds { get; private set; }
		public string DiskUsageKb { get; private set; }
		public string ElapsedSeconds { get; private set; }
		public string FinishTimeUtc { get; private set; }
		public string LastElectedUtc { get; private set; }
		public string LastElectionUtc { get; private set; }
		public string LstFileTimeUtc { get; private set; }
		public string OptInfo { get; private set; }
		public string PackageId { get; private set; }
		public string Percent { get; private set; }
		public string ReconnectCount { get; private set; }
		public string ReturnCode { get; private set; }
		public string ReturnStatus { get; private set; }
		public string StartTimeUtc { get; private set; }
		public string VerifiedUtc { get; private set; }
		public string Version { get; private set; }
		public string WorkRate { get; private set; }

        public static IEnumerable<NomadPackages> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NomadPackages> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NomadPackages> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM NomadPackages");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NomadPackages
                {
                     AlreadyCached = (string) (managementObject.Properties["AlreadyCached"]?.Value ?? default(string)),
		 BackOffSeconds = (string) (managementObject.Properties["BackOffSeconds"]?.Value ?? default(string)),
		 BytesFromDp = (string) (managementObject.Properties["BytesFromDP"]?.Value ?? default(string)),
		 BytesFromPeer = (string) (managementObject.Properties["BytesFromPeer"]?.Value ?? default(string)),
		 CachePriority = (string) (managementObject.Properties["CachePriority"]?.Value ?? default(string)),
		 CacheToFolder = (string) (managementObject.Properties["CacheToFolder"]?.Value ?? default(string)),
		 CachingSeconds = (string) (managementObject.Properties["CachingSeconds"]?.Value ?? default(string)),
		 DisconnectedSeconds = (string) (managementObject.Properties["DisconnectedSeconds"]?.Value ?? default(string)),
		 DiskUsageKb = (string) (managementObject.Properties["DiskUsageKB"]?.Value ?? default(string)),
		 ElapsedSeconds = (string) (managementObject.Properties["ElapsedSeconds"]?.Value ?? default(string)),
		 FinishTimeUtc = (string) (managementObject.Properties["FinishTimeUTC"]?.Value ?? default(string)),
		 LastElectedUtc = (string) (managementObject.Properties["LastElectedUTC"]?.Value ?? default(string)),
		 LastElectionUtc = (string) (managementObject.Properties["LastElectionUTC"]?.Value ?? default(string)),
		 LstFileTimeUtc = (string) (managementObject.Properties["LstFileTimeUTC"]?.Value ?? default(string)),
		 OptInfo = (string) (managementObject.Properties["OptInfo"]?.Value ?? default(string)),
		 PackageId = (string) (managementObject.Properties["PackageID"]?.Value ?? default(string)),
		 Percent = (string) (managementObject.Properties["Percent"]?.Value ?? default(string)),
		 ReconnectCount = (string) (managementObject.Properties["ReconnectCount"]?.Value ?? default(string)),
		 ReturnCode = (string) (managementObject.Properties["ReturnCode"]?.Value ?? default(string)),
		 ReturnStatus = (string) (managementObject.Properties["ReturnStatus"]?.Value ?? default(string)),
		 StartTimeUtc = (string) (managementObject.Properties["StartTimeUTC"]?.Value ?? default(string)),
		 VerifiedUtc = (string) (managementObject.Properties["VerifiedUTC"]?.Value ?? default(string)),
		 Version = (string) (managementObject.Properties["Version"]?.Value ?? default(string)),
		 WorkRate = (string) (managementObject.Properties["WorkRate"]?.Value ?? default(string))
                };
        }
    }
}