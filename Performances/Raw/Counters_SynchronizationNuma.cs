using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_SynchronizationNuma
    {
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint ExecResourceAcquiresAcqExclLitePersec { get; private set; }
        public uint ExecResourceAcquiresAcqShrdLitePersec { get; private set; }
        public uint ExecResourceAcquiresAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourceAcquiresAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourceAttemptsAcqExclLitePersec { get; private set; }
        public uint ExecResourceAttemptsAcqShrdLitePersec { get; private set; }
        public uint ExecResourceAttemptsAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourceAttemptsAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourceBoostExclOwnerPersec { get; private set; }
        public uint ExecResourceBoostSharedOwnersPersec { get; private set; }
        public uint ExecResourceContentionAcqExclLitePersec { get; private set; }
        public uint ExecResourceContentionAcqShrdLitePersec { get; private set; }
        public uint ExecResourceContentionAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourceContentionAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourcenoWaitsAcqExclLitePersec { get; private set; }
        public uint ExecResourcenoWaitsAcqShrdLitePersec { get; private set; }
        public uint ExecResourcenoWaitsAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourcenoWaitsAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourceRecursiveExclAcquiresAcqExclLitePersec { get; private set; }
        public uint ExecResourceRecursiveExclAcquiresAcqShrdLitePersec { get; private set; }
        public uint ExecResourceRecursiveExclAcquiresAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourceRecursiveExclAcquiresAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourceRecursiveShAcquiresAcqShrdLitePersec { get; private set; }
        public uint ExecResourceRecursiveShAcquiresAcqShrdStarveExclPersec { get; private set; }
        public uint ExecResourceRecursiveShAcquiresAcqShrdWaitForExclPersec { get; private set; }
        public uint ExecResourceSetOwnerPointerExclusivePersec { get; private set; }
        public uint ExecResourceSetOwnerPointerSharedExistingOwnerPersec { get; private set; }
        public uint ExecResourceSetOwnerPointerSharedNewOwnerPersec { get; private set; }
        public uint ExecResourceTotalAcquiresPersec { get; private set; }
        public uint ExecResourceTotalContentionsPersec { get; private set; }
        public uint ExecResourceTotalConvExclusiveToSharedPersec { get; private set; }
        public uint ExecResourceTotalDeletePersec { get; private set; }
        public uint ExecResourceTotalExclusiveReleasesPersec { get; private set; }
        public uint ExecResourceTotalInitializePersec { get; private set; }
        public uint ExecResourceTotalReInitializePersec { get; private set; }
        public uint ExecResourceTotalSharedReleasesPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint IPISendBroadcastRequestsPersec { get; private set; }
        public uint IPISendRoutineRequestsPersec { get; private set; }
        public uint IPISendSoftwareInterruptsPersec { get; private set; }
        public string Name { get; private set; }
        public uint SpinlockAcquiresPersec { get; private set; }
        public uint SpinlockContentionsPersec { get; private set; }
        public uint SpinlockSpinsPersec { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_SynchronizationNuma[] Retrieve(string remote, string username,
            string password)
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

        public static PerfRawData_Counters_SynchronizationNuma[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_SynchronizationNuma[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_SynchronizationNuma");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_SynchronizationNuma>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_SynchronizationNuma
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ExecResourceAcquiresAcqExclLitePersec = (uint) managementObject
                        .Properties["ExecResourceAcquiresAcqExclLitePersec"].Value,
                    ExecResourceAcquiresAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourceAcquiresAcqShrdLitePersec"].Value,
                    ExecResourceAcquiresAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourceAcquiresAcqShrdStarveExclPersec"].Value,
                    ExecResourceAcquiresAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourceAcquiresAcqShrdWaitForExclPersec"].Value,
                    ExecResourceAttemptsAcqExclLitePersec = (uint) managementObject
                        .Properties["ExecResourceAttemptsAcqExclLitePersec"].Value,
                    ExecResourceAttemptsAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourceAttemptsAcqShrdLitePersec"].Value,
                    ExecResourceAttemptsAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourceAttemptsAcqShrdStarveExclPersec"].Value,
                    ExecResourceAttemptsAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourceAttemptsAcqShrdWaitForExclPersec"].Value,
                    ExecResourceBoostExclOwnerPersec =
                        (uint) managementObject.Properties["ExecResourceBoostExclOwnerPersec"].Value,
                    ExecResourceBoostSharedOwnersPersec =
                        (uint) managementObject.Properties["ExecResourceBoostSharedOwnersPersec"].Value,
                    ExecResourceContentionAcqExclLitePersec = (uint) managementObject
                        .Properties["ExecResourceContentionAcqExclLitePersec"].Value,
                    ExecResourceContentionAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourceContentionAcqShrdLitePersec"].Value,
                    ExecResourceContentionAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourceContentionAcqShrdStarveExclPersec"].Value,
                    ExecResourceContentionAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourceContentionAcqShrdWaitForExclPersec"].Value,
                    ExecResourcenoWaitsAcqExclLitePersec = (uint) managementObject
                        .Properties["ExecResourcenoWaitsAcqExclLitePersec"].Value,
                    ExecResourcenoWaitsAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourcenoWaitsAcqShrdLitePersec"].Value,
                    ExecResourcenoWaitsAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourcenoWaitsAcqShrdStarveExclPersec"].Value,
                    ExecResourcenoWaitsAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourcenoWaitsAcqShrdWaitForExclPersec"].Value,
                    ExecResourceRecursiveExclAcquiresAcqExclLitePersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveExclAcquiresAcqExclLitePersec"].Value,
                    ExecResourceRecursiveExclAcquiresAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveExclAcquiresAcqShrdLitePersec"].Value,
                    ExecResourceRecursiveExclAcquiresAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveExclAcquiresAcqShrdStarveExclPersec"].Value,
                    ExecResourceRecursiveExclAcquiresAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveExclAcquiresAcqShrdWaitForExclPersec"].Value,
                    ExecResourceRecursiveShAcquiresAcqShrdLitePersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveShAcquiresAcqShrdLitePersec"].Value,
                    ExecResourceRecursiveShAcquiresAcqShrdStarveExclPersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveShAcquiresAcqShrdStarveExclPersec"].Value,
                    ExecResourceRecursiveShAcquiresAcqShrdWaitForExclPersec = (uint) managementObject
                        .Properties["ExecResourceRecursiveShAcquiresAcqShrdWaitForExclPersec"].Value,
                    ExecResourceSetOwnerPointerExclusivePersec = (uint) managementObject
                        .Properties["ExecResourceSetOwnerPointerExclusivePersec"].Value,
                    ExecResourceSetOwnerPointerSharedExistingOwnerPersec = (uint) managementObject
                        .Properties["ExecResourceSetOwnerPointerSharedExistingOwnerPersec"].Value,
                    ExecResourceSetOwnerPointerSharedNewOwnerPersec = (uint) managementObject
                        .Properties["ExecResourceSetOwnerPointerSharedNewOwnerPersec"].Value,
                    ExecResourceTotalAcquiresPersec =
                        (uint) managementObject.Properties["ExecResourceTotalAcquiresPersec"].Value,
                    ExecResourceTotalContentionsPersec =
                        (uint) managementObject.Properties["ExecResourceTotalContentionsPersec"].Value,
                    ExecResourceTotalConvExclusiveToSharedPersec = (uint) managementObject
                        .Properties["ExecResourceTotalConvExclusiveToSharedPersec"].Value,
                    ExecResourceTotalDeletePersec = (uint) managementObject.Properties["ExecResourceTotalDeletePersec"]
                        .Value,
                    ExecResourceTotalExclusiveReleasesPersec = (uint) managementObject
                        .Properties["ExecResourceTotalExclusiveReleasesPersec"].Value,
                    ExecResourceTotalInitializePersec =
                        (uint) managementObject.Properties["ExecResourceTotalInitializePersec"].Value,
                    ExecResourceTotalReInitializePersec =
                        (uint) managementObject.Properties["ExecResourceTotalReInitializePersec"].Value,
                    ExecResourceTotalSharedReleasesPersec = (uint) managementObject
                        .Properties["ExecResourceTotalSharedReleasesPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    IPISendBroadcastRequestsPersec =
                        (uint) managementObject.Properties["IPISendBroadcastRequestsPersec"].Value,
                    IPISendRoutineRequestsPersec = (uint) managementObject.Properties["IPISendRoutineRequestsPersec"]
                        .Value,
                    IPISendSoftwareInterruptsPersec =
                        (uint) managementObject.Properties["IPISendSoftwareInterruptsPersec"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    SpinlockAcquiresPersec = (uint) managementObject.Properties["SpinlockAcquiresPersec"].Value,
                    SpinlockContentionsPersec = (uint) managementObject.Properties["SpinlockContentionsPersec"].Value,
                    SpinlockSpinsPersec = (uint) managementObject.Properties["SpinlockSpinsPersec"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}