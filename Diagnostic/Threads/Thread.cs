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
	public sealed class Thread
	{
		public String Caption { get; private set; }
public String CreationClassName { get; private set; }
public String CSCreationClassName { get; private set; }
public String CSName { get; private set; }
public String Description { get; private set; }
public UInt64 ElapsedTime { get; private set; }
public UInt16 ExecutionState { get; private set; }
public String Handle { get; private set; }
public DateTime InstallDate { get; private set; }
public UInt64 KernelModeTime { get; private set; }
public String Name { get; private set; }
public String OSCreationClassName { get; private set; }
public String OSName { get; private set; }
public UInt32 Priority { get; private set; }
public UInt32 PriorityBase { get; private set; }
public String ProcessCreationClassName { get; private set; }
public String ProcessHandle { get; private set; }
public UInt32 StartAddress { get; private set; }
public String Status { get; private set; }
public UInt32 ThreadState { get; private set; }
public UInt32 ThreadWaitReason { get; private set; }
public UInt64 UserModeTime { get; private set; }
		
		public static Thread[] Retrieve(string remote, string username, string password)
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

		public static Thread[] Retrieve()
		{
			var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
			return Retrieve(managementScope);
		}

		public static Thread[] Retrieve(ManagementScope managementScope)
		{
		    var objectQuery = new ObjectQuery("SELECT * FROM Win32_Thread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

			var list = new List<Thread>();

            foreach (ManagementObject managementObject in objectCollection)
            {
				list.Add(new Thread
				{
					Caption = (String) managementObject.Properties["Caption"].Value,
CreationClassName = (String) managementObject.Properties["CreationClassName"].Value,
CSCreationClassName = (String) managementObject.Properties["CSCreationClassName"].Value,
CSName = (String) managementObject.Properties["CSName"].Value,
Description = (String) managementObject.Properties["Description"].Value,
ElapsedTime = (UInt64) managementObject.Properties["ElapsedTime"].Value,
ExecutionState = (UInt16) managementObject.Properties["ExecutionState"].Value,
Handle = (String) managementObject.Properties["Handle"].Value,
InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
KernelModeTime = (UInt64) managementObject.Properties["KernelModeTime"].Value,
Name = (String) managementObject.Properties["Name"].Value,
OSCreationClassName = (String) managementObject.Properties["OSCreationClassName"].Value,
OSName = (String) managementObject.Properties["OSName"].Value,
Priority = (UInt32) managementObject.Properties["Priority"].Value,
PriorityBase = (UInt32) managementObject.Properties["PriorityBase"].Value,
ProcessCreationClassName = (String) managementObject.Properties["ProcessCreationClassName"].Value,
ProcessHandle = (String) managementObject.Properties["ProcessHandle"].Value,
StartAddress = (UInt32) managementObject.Properties["StartAddress"].Value,
Status = (String) managementObject.Properties["Status"].Value,
ThreadState = (UInt32) managementObject.Properties["ThreadState"].Value,
ThreadWaitReason = (UInt32) managementObject.Properties["ThreadWaitReason"].Value,
UserModeTime = (UInt64) managementObject.Properties["UserModeTime"].Value,
				});
            }

			return list.ToArray();
		}
	}
}