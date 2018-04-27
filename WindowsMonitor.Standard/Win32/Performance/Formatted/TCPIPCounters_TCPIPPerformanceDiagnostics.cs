using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class TCPIPCounters_TCPIPPerformanceDiagnostics
    {
		public string Caption { get; private set; }
		public uint Deniedconnectorsendrequestsinlowpowermode { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint IPv4NBLsindicatedwithlowresourceflag { get; private set; }
		public uint IPv4NBLsindicatedwithoutprevalidation { get; private set; }
		public uint IPv4NBLsPersecindicatedwithlowresourceflag { get; private set; }
		public uint IPv4NBLsPersecindicatedwithoutprevalidation { get; private set; }
		public uint IPv4NBLsPersectreatedasnonprevalidated { get; private set; }
		public uint IPv4NBLstreatedasnonprevalidated { get; private set; }
		public uint IPv4outboundNBLsnotprocessedviafastpath { get; private set; }
		public uint IPv4outboundNBLsPersecnotprocessedviafastpath { get; private set; }
		public uint IPv6NBLsindicatedwithlowresourceflag { get; private set; }
		public uint IPv6NBLsindicatedwithoutprevalidation { get; private set; }
		public uint IPv6NBLsPersecindicatedwithlowresourceflag { get; private set; }
		public uint IPv6NBLsPersecindicatedwithoutprevalidation { get; private set; }
		public uint IPv6NBLsPersectreatedasnonprevalidated { get; private set; }
		public uint IPv6NBLstreatedasnonprevalidated { get; private set; }
		public uint IPv6outboundNBLsnotprocessedviafastpath { get; private set; }
		public uint IPv6outboundNBLsPersecnotprocessedviafastpath { get; private set; }
		public string Name { get; private set; }
		public uint TCPconnectrequestsfallenoffloopbackfastpath { get; private set; }
		public uint TCPconnectrequestsPersecfallenoffloopbackfastpath { get; private set; }
		public uint TCPinboundsegmentsnotprocessedviafastpath { get; private set; }
		public uint TCPinboundsegmentsPersecnotprocessedviafastpath { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<TCPIPCounters_TCPIPPerformanceDiagnostics> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TCPIPCounters_TCPIPPerformanceDiagnostics> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TCPIPCounters_TCPIPPerformanceDiagnostics> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_TCPIPCounters_TCPIPPerformanceDiagnostics");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TCPIPCounters_TCPIPPerformanceDiagnostics
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Deniedconnectorsendrequestsinlowpowermode = (uint) (managementObject.Properties["Deniedconnectorsendrequestsinlowpowermode"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IPv4NBLsindicatedwithlowresourceflag = (uint) (managementObject.Properties["IPv4NBLsindicatedwithlowresourceflag"]?.Value ?? default(uint)),
		 IPv4NBLsindicatedwithoutprevalidation = (uint) (managementObject.Properties["IPv4NBLsindicatedwithoutprevalidation"]?.Value ?? default(uint)),
		 IPv4NBLsPersecindicatedwithlowresourceflag = (uint) (managementObject.Properties["IPv4NBLsPersecindicatedwithlowresourceflag"]?.Value ?? default(uint)),
		 IPv4NBLsPersecindicatedwithoutprevalidation = (uint) (managementObject.Properties["IPv4NBLsPersecindicatedwithoutprevalidation"]?.Value ?? default(uint)),
		 IPv4NBLsPersectreatedasnonprevalidated = (uint) (managementObject.Properties["IPv4NBLsPersectreatedasnonprevalidated"]?.Value ?? default(uint)),
		 IPv4NBLstreatedasnonprevalidated = (uint) (managementObject.Properties["IPv4NBLstreatedasnonprevalidated"]?.Value ?? default(uint)),
		 IPv4outboundNBLsnotprocessedviafastpath = (uint) (managementObject.Properties["IPv4outboundNBLsnotprocessedviafastpath"]?.Value ?? default(uint)),
		 IPv4outboundNBLsPersecnotprocessedviafastpath = (uint) (managementObject.Properties["IPv4outboundNBLsPersecnotprocessedviafastpath"]?.Value ?? default(uint)),
		 IPv6NBLsindicatedwithlowresourceflag = (uint) (managementObject.Properties["IPv6NBLsindicatedwithlowresourceflag"]?.Value ?? default(uint)),
		 IPv6NBLsindicatedwithoutprevalidation = (uint) (managementObject.Properties["IPv6NBLsindicatedwithoutprevalidation"]?.Value ?? default(uint)),
		 IPv6NBLsPersecindicatedwithlowresourceflag = (uint) (managementObject.Properties["IPv6NBLsPersecindicatedwithlowresourceflag"]?.Value ?? default(uint)),
		 IPv6NBLsPersecindicatedwithoutprevalidation = (uint) (managementObject.Properties["IPv6NBLsPersecindicatedwithoutprevalidation"]?.Value ?? default(uint)),
		 IPv6NBLsPersectreatedasnonprevalidated = (uint) (managementObject.Properties["IPv6NBLsPersectreatedasnonprevalidated"]?.Value ?? default(uint)),
		 IPv6NBLstreatedasnonprevalidated = (uint) (managementObject.Properties["IPv6NBLstreatedasnonprevalidated"]?.Value ?? default(uint)),
		 IPv6outboundNBLsnotprocessedviafastpath = (uint) (managementObject.Properties["IPv6outboundNBLsnotprocessedviafastpath"]?.Value ?? default(uint)),
		 IPv6outboundNBLsPersecnotprocessedviafastpath = (uint) (managementObject.Properties["IPv6outboundNBLsPersecnotprocessedviafastpath"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 TCPconnectrequestsfallenoffloopbackfastpath = (uint) (managementObject.Properties["TCPconnectrequestsfallenoffloopbackfastpath"]?.Value ?? default(uint)),
		 TCPconnectrequestsPersecfallenoffloopbackfastpath = (uint) (managementObject.Properties["TCPconnectrequestsPersecfallenoffloopbackfastpath"]?.Value ?? default(uint)),
		 TCPinboundsegmentsnotprocessedviafastpath = (uint) (managementObject.Properties["TCPinboundsegmentsnotprocessedviafastpath"]?.Value ?? default(uint)),
		 TCPinboundsegmentsPersecnotprocessedviafastpath = (uint) (managementObject.Properties["TCPinboundsegmentsPersecnotprocessedviafastpath"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}