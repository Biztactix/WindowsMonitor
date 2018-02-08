using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_Counters_PowerShellWorkflow
    {
        public uint ActivityHostManagerhostprocessespoolsize { get; private set; }
        public uint ActivityHostManagerNumberofbusyhostprocesses { get; private set; }
        public uint ActivityHostManagerNumberofcreatedhostprocesses { get; private set; }
        public uint ActivityHostManagerNumberofdisposedhostprocesses { get; private set; }
        public uint ActivityHostManagerNumberoffailedrequestsinqueue { get; private set; }
        public uint ActivityHostManagerNumberoffailedrequestsPersec { get; private set; }
        public uint ActivityHostManagerNumberofincomingrequestsPersec { get; private set; }
        public uint ActivityHostManagerNumberofpendingrequestsinqueue { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint Numberoffailedworkflowjobs { get; private set; }
        public uint NumberoffailedworkflowjobsPersec { get; private set; }
        public uint Numberofresumedworkflowjobs { get; private set; }
        public uint NumberofresumedworkflowjobsPersec { get; private set; }
        public uint Numberofrunningworkflowjobs { get; private set; }
        public uint NumberofrunningworkflowjobsPersec { get; private set; }
        public uint Numberofstoppedworkflowjobs { get; private set; }
        public uint NumberofstoppedworkflowjobsPersec { get; private set; }
        public uint Numberofsucceededworkflowjobs { get; private set; }
        public uint NumberofsucceededworkflowjobsPersec { get; private set; }
        public uint Numberofsuspendedworkflowjobs { get; private set; }
        public uint NumberofsuspendedworkflowjobsPersec { get; private set; }
        public uint Numberofterminatedworkflowjobs { get; private set; }
        public uint NumberofterminatedworkflowjobsPersec { get; private set; }
        public uint Numberofwaitingworkflowjobs { get; private set; }
        public uint PowerShellRemotingNumberofconnectionsclosedreopened { get; private set; }
        public uint PowerShellRemotingNumberofcreatedconnections { get; private set; }
        public uint PowerShellRemotingNumberofdisposedconnections { get; private set; }
        public uint PowerShellRemotingNumberofforcedtowaitrequestsinqueue { get; private set; }
        public uint PowerShellRemotingNumberofpendingrequestsinqueue { get; private set; }
        public uint PowerShellRemotingNumberofrequestsbeingserviced { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_Counters_PowerShellWorkflow[] Retrieve(string remote, string username,
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

        public static PerfRawData_Counters_PowerShellWorkflow[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_Counters_PowerShellWorkflow[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_PowerShellWorkflow");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_Counters_PowerShellWorkflow>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_Counters_PowerShellWorkflow
                {
                    ActivityHostManagerhostprocessespoolsize = (uint) managementObject
                        .Properties["ActivityHostManagerhostprocessespoolsize"].Value,
                    ActivityHostManagerNumberofbusyhostprocesses = (uint) managementObject
                        .Properties["ActivityHostManagerNumberofbusyhostprocesses"].Value,
                    ActivityHostManagerNumberofcreatedhostprocesses = (uint) managementObject
                        .Properties["ActivityHostManagerNumberofcreatedhostprocesses"].Value,
                    ActivityHostManagerNumberofdisposedhostprocesses = (uint) managementObject
                        .Properties["ActivityHostManagerNumberofdisposedhostprocesses"].Value,
                    ActivityHostManagerNumberoffailedrequestsinqueue = (uint) managementObject
                        .Properties["ActivityHostManagerNumberoffailedrequestsinqueue"].Value,
                    ActivityHostManagerNumberoffailedrequestsPersec = (uint) managementObject
                        .Properties["ActivityHostManagerNumberoffailedrequestsPersec"].Value,
                    ActivityHostManagerNumberofincomingrequestsPersec = (uint) managementObject
                        .Properties["ActivityHostManagerNumberofincomingrequestsPersec"].Value,
                    ActivityHostManagerNumberofpendingrequestsinqueue = (uint) managementObject
                        .Properties["ActivityHostManagerNumberofpendingrequestsinqueue"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Numberoffailedworkflowjobs = (uint) managementObject.Properties["Numberoffailedworkflowjobs"].Value,
                    NumberoffailedworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberoffailedworkflowjobsPersec"].Value,
                    Numberofresumedworkflowjobs = (uint) managementObject.Properties["Numberofresumedworkflowjobs"]
                        .Value,
                    NumberofresumedworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberofresumedworkflowjobsPersec"].Value,
                    Numberofrunningworkflowjobs = (uint) managementObject.Properties["Numberofrunningworkflowjobs"]
                        .Value,
                    NumberofrunningworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberofrunningworkflowjobsPersec"].Value,
                    Numberofstoppedworkflowjobs = (uint) managementObject.Properties["Numberofstoppedworkflowjobs"]
                        .Value,
                    NumberofstoppedworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberofstoppedworkflowjobsPersec"].Value,
                    Numberofsucceededworkflowjobs = (uint) managementObject.Properties["Numberofsucceededworkflowjobs"]
                        .Value,
                    NumberofsucceededworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberofsucceededworkflowjobsPersec"].Value,
                    Numberofsuspendedworkflowjobs = (uint) managementObject.Properties["Numberofsuspendedworkflowjobs"]
                        .Value,
                    NumberofsuspendedworkflowjobsPersec =
                        (uint) managementObject.Properties["NumberofsuspendedworkflowjobsPersec"].Value,
                    Numberofterminatedworkflowjobs =
                        (uint) managementObject.Properties["Numberofterminatedworkflowjobs"].Value,
                    NumberofterminatedworkflowjobsPersec = (uint) managementObject
                        .Properties["NumberofterminatedworkflowjobsPersec"].Value,
                    Numberofwaitingworkflowjobs = (uint) managementObject.Properties["Numberofwaitingworkflowjobs"]
                        .Value,
                    PowerShellRemotingNumberofconnectionsclosedreopened = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofconnectionsclosedreopened"].Value,
                    PowerShellRemotingNumberofcreatedconnections = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofcreatedconnections"].Value,
                    PowerShellRemotingNumberofdisposedconnections = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofdisposedconnections"].Value,
                    PowerShellRemotingNumberofforcedtowaitrequestsinqueue = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofforcedtowaitrequestsinqueue"].Value,
                    PowerShellRemotingNumberofpendingrequestsinqueue = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofpendingrequestsinqueue"].Value,
                    PowerShellRemotingNumberofrequestsbeingserviced = (uint) managementObject
                        .Properties["PowerShellRemotingNumberofrequestsbeingserviced"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}