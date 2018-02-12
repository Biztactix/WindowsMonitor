using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class PerfProc_Image_Costly
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong ExecReadOnly { get; private set; }
		public ulong ExecReadPerWrite { get; private set; }
		public ulong Executable { get; private set; }
		public ulong ExecWriteCopy { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong NoAccess { get; private set; }
		public ulong ReadOnly { get; private set; }
		public ulong ReadPerWrite { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong WriteCopy { get; private set; }

        public static IEnumerable<PerfProc_Image_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PerfProc_Image_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PerfProc_Image_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Image_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PerfProc_Image_Costly
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ExecReadOnly = (ulong) (managementObject.Properties["ExecReadOnly"]?.Value ?? default(ulong)),
		 ExecReadPerWrite = (ulong) (managementObject.Properties["ExecReadPerWrite"]?.Value ?? default(ulong)),
		 Executable = (ulong) (managementObject.Properties["Executable"]?.Value ?? default(ulong)),
		 ExecWriteCopy = (ulong) (managementObject.Properties["ExecWriteCopy"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NoAccess = (ulong) (managementObject.Properties["NoAccess"]?.Value ?? default(ulong)),
		 ReadOnly = (ulong) (managementObject.Properties["ReadOnly"]?.Value ?? default(ulong)),
		 ReadPerWrite = (ulong) (managementObject.Properties["ReadPerWrite"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 WriteCopy = (ulong) (managementObject.Properties["WriteCopy"]?.Value ?? default(ulong))
                };
        }
    }
}