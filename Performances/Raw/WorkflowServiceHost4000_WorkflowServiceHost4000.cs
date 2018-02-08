using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000
    {
        public uint AverageWorkflowLoadTime { get; private set; }
        public uint AverageWorkflowLoadTime_Base { get; private set; }
        public uint AverageWorkflowPersistTime { get; private set; }
        public uint AverageWorkflowPersistTime_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint WorkflowsAborted { get; private set; }
        public uint WorkflowsAbortedPerSecond { get; private set; }
        public uint WorkflowsCompleted { get; private set; }
        public uint WorkflowsCompletedPerSecond { get; private set; }
        public uint WorkflowsCreated { get; private set; }
        public uint WorkflowsCreatedPerSecond { get; private set; }
        public uint WorkflowsExecuting { get; private set; }
        public uint WorkflowsIdlePerSecond { get; private set; }
        public uint WorkflowsInMemory { get; private set; }
        public uint WorkflowsLoaded { get; private set; }
        public uint WorkflowsLoadedPerSecond { get; private set; }
        public uint WorkflowsPersisted { get; private set; }
        public uint WorkflowsPersistedPerSecond { get; private set; }
        public uint WorkflowsSuspended { get; private set; }
        public uint WorkflowsSuspendedPerSecond { get; private set; }
        public uint WorkflowsTerminated { get; private set; }
        public uint WorkflowsTerminatedPerSecond { get; private set; }
        public uint WorkflowsUnloaded { get; private set; }
        public uint WorkflowsUnloadedPerSecond { get; private set; }

        public static PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000[] Retrieve(string remote,
            string username, string password)
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

        public static PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_WorkflowServiceHost4000_WorkflowServiceHost4000
                {
                    AverageWorkflowLoadTime = (uint) managementObject.Properties["AverageWorkflowLoadTime"].Value,
                    AverageWorkflowLoadTime_Base = (uint) managementObject.Properties["AverageWorkflowLoadTime_Base"]
                        .Value,
                    AverageWorkflowPersistTime = (uint) managementObject.Properties["AverageWorkflowPersistTime"].Value,
                    AverageWorkflowPersistTime_Base =
                        (uint) managementObject.Properties["AverageWorkflowPersistTime_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    WorkflowsAborted = (uint) managementObject.Properties["WorkflowsAborted"].Value,
                    WorkflowsAbortedPerSecond = (uint) managementObject.Properties["WorkflowsAbortedPerSecond"].Value,
                    WorkflowsCompleted = (uint) managementObject.Properties["WorkflowsCompleted"].Value,
                    WorkflowsCompletedPerSecond = (uint) managementObject.Properties["WorkflowsCompletedPerSecond"]
                        .Value,
                    WorkflowsCreated = (uint) managementObject.Properties["WorkflowsCreated"].Value,
                    WorkflowsCreatedPerSecond = (uint) managementObject.Properties["WorkflowsCreatedPerSecond"].Value,
                    WorkflowsExecuting = (uint) managementObject.Properties["WorkflowsExecuting"].Value,
                    WorkflowsIdlePerSecond = (uint) managementObject.Properties["WorkflowsIdlePerSecond"].Value,
                    WorkflowsInMemory = (uint) managementObject.Properties["WorkflowsInMemory"].Value,
                    WorkflowsLoaded = (uint) managementObject.Properties["WorkflowsLoaded"].Value,
                    WorkflowsLoadedPerSecond = (uint) managementObject.Properties["WorkflowsLoadedPerSecond"].Value,
                    WorkflowsPersisted = (uint) managementObject.Properties["WorkflowsPersisted"].Value,
                    WorkflowsPersistedPerSecond = (uint) managementObject.Properties["WorkflowsPersistedPerSecond"]
                        .Value,
                    WorkflowsSuspended = (uint) managementObject.Properties["WorkflowsSuspended"].Value,
                    WorkflowsSuspendedPerSecond = (uint) managementObject.Properties["WorkflowsSuspendedPerSecond"]
                        .Value,
                    WorkflowsTerminated = (uint) managementObject.Properties["WorkflowsTerminated"].Value,
                    WorkflowsTerminatedPerSecond = (uint) managementObject.Properties["WorkflowsTerminatedPerSecond"]
                        .Value,
                    WorkflowsUnloaded = (uint) managementObject.Properties["WorkflowsUnloaded"].Value,
                    WorkflowsUnloadedPerSecond = (uint) managementObject.Properties["WorkflowsUnloadedPerSecond"].Value
                });

            return list.ToArray();
        }
    }
}