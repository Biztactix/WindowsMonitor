using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation
    {
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
        public uint WorkflowsAbortedPersec { get; private set; }
        public uint WorkflowsCompleted { get; private set; }
        public uint WorkflowsCompletedPersec { get; private set; }
        public uint WorkflowsCreated { get; private set; }
        public uint WorkflowsCreatedPersec { get; private set; }
        public uint WorkflowsExecuting { get; private set; }
        public uint WorkflowsIdlePersec { get; private set; }
        public uint WorkflowsInMemory { get; private set; }
        public uint WorkflowsLoaded { get; private set; }
        public uint WorkflowsLoadedPersec { get; private set; }
        public uint WorkflowsPending { get; private set; }
        public uint WorkflowsPersisted { get; private set; }
        public uint WorkflowsPersistedPersec { get; private set; }
        public uint WorkflowsRunnable { get; private set; }
        public uint WorkflowsSuspended { get; private set; }
        public uint WorkflowsSuspendedPersec { get; private set; }
        public uint WorkflowsTerminated { get; private set; }
        public uint WorkflowsTerminatedPersec { get; private set; }
        public uint WorkflowsUnloaded { get; private set; }
        public uint WorkflowsUnloadedPersec { get; private set; }

        public static PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation[] Retrieve(
            string remote, string username, string password)
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

        public static PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation[] Retrieve(
            ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery(
                    "SELECT * FROM Win32_PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_WindowsWorkflowFoundation3000_WindowsWorkflowFoundation
                {
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
                    WorkflowsAbortedPersec = (uint) managementObject.Properties["WorkflowsAbortedPersec"].Value,
                    WorkflowsCompleted = (uint) managementObject.Properties["WorkflowsCompleted"].Value,
                    WorkflowsCompletedPersec = (uint) managementObject.Properties["WorkflowsCompletedPersec"].Value,
                    WorkflowsCreated = (uint) managementObject.Properties["WorkflowsCreated"].Value,
                    WorkflowsCreatedPersec = (uint) managementObject.Properties["WorkflowsCreatedPersec"].Value,
                    WorkflowsExecuting = (uint) managementObject.Properties["WorkflowsExecuting"].Value,
                    WorkflowsIdlePersec = (uint) managementObject.Properties["WorkflowsIdlePersec"].Value,
                    WorkflowsInMemory = (uint) managementObject.Properties["WorkflowsInMemory"].Value,
                    WorkflowsLoaded = (uint) managementObject.Properties["WorkflowsLoaded"].Value,
                    WorkflowsLoadedPersec = (uint) managementObject.Properties["WorkflowsLoadedPersec"].Value,
                    WorkflowsPending = (uint) managementObject.Properties["WorkflowsPending"].Value,
                    WorkflowsPersisted = (uint) managementObject.Properties["WorkflowsPersisted"].Value,
                    WorkflowsPersistedPersec = (uint) managementObject.Properties["WorkflowsPersistedPersec"].Value,
                    WorkflowsRunnable = (uint) managementObject.Properties["WorkflowsRunnable"].Value,
                    WorkflowsSuspended = (uint) managementObject.Properties["WorkflowsSuspended"].Value,
                    WorkflowsSuspendedPersec = (uint) managementObject.Properties["WorkflowsSuspendedPersec"].Value,
                    WorkflowsTerminated = (uint) managementObject.Properties["WorkflowsTerminated"].Value,
                    WorkflowsTerminatedPersec = (uint) managementObject.Properties["WorkflowsTerminatedPersec"].Value,
                    WorkflowsUnloaded = (uint) managementObject.Properties["WorkflowsUnloaded"].Value,
                    WorkflowsUnloadedPersec = (uint) managementObject.Properties["WorkflowsUnloadedPersec"].Value
                });

            return list.ToArray();
        }
    }
}