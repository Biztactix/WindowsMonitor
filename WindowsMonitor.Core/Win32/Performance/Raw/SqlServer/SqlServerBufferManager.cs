using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerBufferManager
    {
		public ulong BackgroundwriterpagesPersec { get; private set; }
		public ulong Buffercachehitratio { get; private set; }
		public ulong Buffercachehitratio_Base { get; private set; }
		public string Caption { get; private set; }
		public ulong CheckpointpagesPersec { get; private set; }
		public ulong Databasepages { get; private set; }
		public string Description { get; private set; }
		public ulong Extensionallocatedpages { get; private set; }
		public ulong Extensionfreepages { get; private set; }
		public ulong Extensioninuseaspercentage { get; private set; }
		public ulong ExtensionoutstandingIOcounter { get; private set; }
		public ulong ExtensionpageevictionsPersec { get; private set; }
		public ulong ExtensionpagereadsPersec { get; private set; }
		public ulong Extensionpageunreferencedtime { get; private set; }
		public ulong ExtensionpagewritesPersec { get; private set; }
		public ulong FreeliststallsPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong IntegralControllerSlope { get; private set; }
		public ulong LazywritesPersec { get; private set; }
		public string Name { get; private set; }
		public ulong Pagelifeexpectancy { get; private set; }
		public ulong PagelookupsPersec { get; private set; }
		public ulong PagereadsPersec { get; private set; }
		public ulong PagewritesPersec { get; private set; }
		public ulong ReadaheadpagesPersec { get; private set; }
		public ulong ReadaheadtimePersec { get; private set; }
		public ulong Targetpages { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<SqlServerBufferManager> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerBufferManager> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerBufferManager> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerBufferManager
                {
                     BackgroundwriterpagesPersec = (ulong) (managementObject.Properties["BackgroundwriterpagesPersec"]?.Value ?? default(ulong)),
		 Buffercachehitratio = (ulong) (managementObject.Properties["Buffercachehitratio"]?.Value ?? default(ulong)),
		 Buffercachehitratio_Base = (ulong) (managementObject.Properties["Buffercachehitratio_Base"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CheckpointpagesPersec = (ulong) (managementObject.Properties["CheckpointpagesPersec"]?.Value ?? default(ulong)),
		 Databasepages = (ulong) (managementObject.Properties["Databasepages"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Extensionallocatedpages = (ulong) (managementObject.Properties["Extensionallocatedpages"]?.Value ?? default(ulong)),
		 Extensionfreepages = (ulong) (managementObject.Properties["Extensionfreepages"]?.Value ?? default(ulong)),
		 Extensioninuseaspercentage = (ulong) (managementObject.Properties["Extensioninuseaspercentage"]?.Value ?? default(ulong)),
		 ExtensionoutstandingIOcounter = (ulong) (managementObject.Properties["ExtensionoutstandingIOcounter"]?.Value ?? default(ulong)),
		 ExtensionpageevictionsPersec = (ulong) (managementObject.Properties["ExtensionpageevictionsPersec"]?.Value ?? default(ulong)),
		 ExtensionpagereadsPersec = (ulong) (managementObject.Properties["ExtensionpagereadsPersec"]?.Value ?? default(ulong)),
		 Extensionpageunreferencedtime = (ulong) (managementObject.Properties["Extensionpageunreferencedtime"]?.Value ?? default(ulong)),
		 ExtensionpagewritesPersec = (ulong) (managementObject.Properties["ExtensionpagewritesPersec"]?.Value ?? default(ulong)),
		 FreeliststallsPersec = (ulong) (managementObject.Properties["FreeliststallsPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IntegralControllerSlope = (ulong) (managementObject.Properties["IntegralControllerSlope"]?.Value ?? default(ulong)),
		 LazywritesPersec = (ulong) (managementObject.Properties["LazywritesPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Pagelifeexpectancy = (ulong) (managementObject.Properties["Pagelifeexpectancy"]?.Value ?? default(ulong)),
		 PagelookupsPersec = (ulong) (managementObject.Properties["PagelookupsPersec"]?.Value ?? default(ulong)),
		 PagereadsPersec = (ulong) (managementObject.Properties["PagereadsPersec"]?.Value ?? default(ulong)),
		 PagewritesPersec = (ulong) (managementObject.Properties["PagewritesPersec"]?.Value ?? default(ulong)),
		 ReadaheadpagesPersec = (ulong) (managementObject.Properties["ReadaheadpagesPersec"]?.Value ?? default(ulong)),
		 ReadaheadtimePersec = (ulong) (managementObject.Properties["ReadaheadtimePersec"]?.Value ?? default(ulong)),
		 Targetpages = (ulong) (managementObject.Properties["Targetpages"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}