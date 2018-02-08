using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
        /// <summary>
        /// 
        /// </summary>
	public sealed class Process
	{
		public String Caption { get; private set; }
public String CommandLine { get; private set; }
public String CreationClassName { get; private set; }
public DateTime CreationDate { get; private set; }
public String CSCreationClassName { get; private set; }
public String CSName { get; private set; }
public String Description { get; private set; }
public String ExecutablePath { get; private set; }
public UInt16 ExecutionState { get; private set; }
public String Handle { get; private set; }
public UInt32 HandleCount { get; private set; }
public DateTime InstallDate { get; private set; }
public UInt64 KernelModeTime { get; private set; }
public UInt32 MaximumWorkingSetSize { get; private set; }
public UInt32 MinimumWorkingSetSize { get; private set; }
public String Name { get; private set; }
public String OSCreationClassName { get; private set; }
public String OSName { get; private set; }
public UInt64 OtherOperationCount { get; private set; }
public UInt64 OtherTransferCount { get; private set; }
public UInt32 PageFaults { get; private set; }
public UInt32 PageFileUsage { get; private set; }
public UInt32 ParentProcessId { get; private set; }
public UInt32 PeakPageFileUsage { get; private set; }
public UInt64 PeakVirtualSize { get; private set; }
public UInt32 PeakWorkingSetSize { get; private set; }
public UInt32 Priority { get; private set; }
public UInt64 PrivatePageCount { get; private set; }
public UInt32 ProcessId { get; private set; }
public UInt32 QuotaNonPagedPoolUsage { get; private set; }
public UInt32 QuotaPagedPoolUsage { get; private set; }
public UInt32 QuotaPeakNonPagedPoolUsage { get; private set; }
public UInt32 QuotaPeakPagedPoolUsage { get; private set; }
public UInt64 ReadOperationCount { get; private set; }
public UInt64 ReadTransferCount { get; private set; }
public UInt32 SessionId { get; private set; }
public String Status { get; private set; }
public DateTime TerminationDate { get; private set; }
public UInt32 ThreadCount { get; private set; }
public UInt64 UserModeTime { get; private set; }
public UInt64 VirtualSize { get; private set; }
public String WindowsVersion { get; private set; }
public UInt64 WorkingSetSize { get; private set; }
public UInt64 WriteOperationCount { get; private set; }
public UInt64 WriteTransferCount { get; private set; }
		
		public static Process[] Retrieve(string remote, string username, string password)
		{
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"),options);
            managementScope.Connect();

			return Retrieve(managementScope);
		}

		public static Process[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Process[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Process");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Process>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Process
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CommandLine = (String) managementObject.Properties["CommandLine"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
CreationDate = (DateTime) managementObject.Properties["CreationDate"].Value,
CSCreationClassName = (String) managementObject.Properties["CSCreationClassName"].Value,
CSName = (String) managementObject.Properties["CSName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
ExecutablePath = (String) managementObject.Properties["ExecutablePath"].Value,
ExecutionState = (UInt16) managementObject.Properties["ExecutionState"].Value,
Handle = (String) managementObject.Properties["Handle"].Value,
HandleCount = (UInt32) managementObject.Properties["HandleCount"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
KernelModeTime = (UInt64) managementObject.Properties["KernelModeTime"].Value,
MaximumWorkingSetSize = (UInt32) managementObject.Properties["MaximumWorkingSetSize"].Value,
MinimumWorkingSetSize = (UInt32) managementObject.Properties["MinimumWorkingSetSize"].Value,
Name = (String) managementObject.Properties["Name"].Value,
OSCreationClassName = (String) managementObject.Properties["OSCreationClassName"].Value,
OSName = (String) managementObject.Properties["OSName"].Value,
OtherOperationCount = (UInt64) managementObject.Properties["OtherOperationCount"].Value,
OtherTransferCount = (UInt64) managementObject.Properties["OtherTransferCount"].Value,
PageFaults = (UInt32) managementObject.Properties["PageFaults"].Value,
PageFileUsage = (UInt32) managementObject.Properties["PageFileUsage"].Value,
ParentProcessId = (UInt32) managementObject.Properties["ParentProcessId"].Value,
PeakPageFileUsage = (UInt32) managementObject.Properties["PeakPageFileUsage"].Value,
PeakVirtualSize = (UInt64) managementObject.Properties["PeakVirtualSize"].Value,
PeakWorkingSetSize = (UInt32) managementObject.Properties["PeakWorkingSetSize"].Value,
Priority = (UInt32) managementObject.Properties["Priority"].Value,
PrivatePageCount = (UInt64) managementObject.Properties["PrivatePageCount"].Value,
ProcessId = (UInt32) managementObject.Properties["ProcessId"].Value,
QuotaNonPagedPoolUsage = (UInt32) managementObject.Properties["QuotaNonPagedPoolUsage"].Value,
QuotaPagedPoolUsage = (UInt32) managementObject.Properties["QuotaPagedPoolUsage"].Value,
QuotaPeakNonPagedPoolUsage = (UInt32) managementObject.Properties["QuotaPeakNonPagedPoolUsage"].Value,
QuotaPeakPagedPoolUsage = (UInt32) managementObject.Properties["QuotaPeakPagedPoolUsage"].Value,
ReadOperationCount = (UInt64) managementObject.Properties["ReadOperationCount"].Value,
ReadTransferCount = (UInt64) managementObject.Properties["ReadTransferCount"].Value,
SessionId = (UInt32) managementObject.Properties["SessionId"].Value,
Status = (String) managementObject.Properties["Status"].Value,
TerminationDate = (DateTime) managementObject.Properties["TerminationDate"].Value,
ThreadCount = (UInt32) managementObject.Properties["ThreadCount"].Value,
UserModeTime = (UInt64) managementObject.Properties["UserModeTime"].Value,
VirtualSize = (UInt64) managementObject.Properties["VirtualSize"].Value,
WindowsVersion = (String) managementObject.Properties["WindowsVersion"].Value,
WorkingSetSize = (UInt64) managementObject.Properties["WorkingSetSize"].Value,
WriteOperationCount = (UInt64) managementObject.Properties["WriteOperationCount"].Value,
WriteTransferCount = (UInt64) managementObject.Properties["WriteTransferCount"].Value,
				});
            }

			return list.ToArray();
		}
	}
}