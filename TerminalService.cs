using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class TerminalService
    {
        public bool AcceptPause { get; private set; }
        public bool AcceptStop { get; private set; }
        public string Caption { get; private set; }
        public uint CheckPoint { get; private set; }
        public string CreationClassName { get; private set; }
        public bool DelayedAutoStart { get; private set; }
        public string Description { get; private set; }
        public bool DesktopInteract { get; private set; }
        public uint DisconnectedSessions { get; private set; }
        public string DisplayName { get; private set; }
        public string ErrorControl { get; private set; }
        public uint ExitCode { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Name { get; private set; }
        public string PathName { get; private set; }
        public uint ProcessId { get; private set; }
        public uint ServiceSpecificExitCode { get; private set; }
        public string ServiceType { get; private set; }
        public bool Started { get; private set; }
        public string StartMode { get; private set; }
        public string StartName { get; private set; }
        public string State { get; private set; }
        public string Status { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public uint TagId { get; private set; }
        public uint TotalSessions { get; private set; }
        public uint WaitHint { get; private set; }

        public static TerminalService[] Retrieve(string remote, string username, string password)
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

        public static TerminalService[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static TerminalService[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_TerminalService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<TerminalService>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new TerminalService
                {
                    AcceptPause = (bool) managementObject.Properties["AcceptPause"].Value,
                    AcceptStop = (bool) managementObject.Properties["AcceptStop"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    CheckPoint = (uint) managementObject.Properties["CheckPoint"].Value,
                    CreationClassName = (string) managementObject.Properties["CreationClassName"].Value,
                    DelayedAutoStart = (bool) managementObject.Properties["DelayedAutoStart"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DesktopInteract = (bool) managementObject.Properties["DesktopInteract"].Value,
                    DisconnectedSessions = (uint) managementObject.Properties["DisconnectedSessions"].Value,
                    DisplayName = (string) managementObject.Properties["DisplayName"].Value,
                    ErrorControl = (string) managementObject.Properties["ErrorControl"].Value,
                    ExitCode = (uint) managementObject.Properties["ExitCode"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    PathName = (string) managementObject.Properties["PathName"].Value,
                    ProcessId = (uint) managementObject.Properties["ProcessId"].Value,
                    ServiceSpecificExitCode = (uint) managementObject.Properties["ServiceSpecificExitCode"].Value,
                    ServiceType = (string) managementObject.Properties["ServiceType"].Value,
                    Started = (bool) managementObject.Properties["Started"].Value,
                    StartMode = (string) managementObject.Properties["StartMode"].Value,
                    StartName = (string) managementObject.Properties["StartName"].Value,
                    State = (string) managementObject.Properties["State"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    SystemCreationClassName = (string) managementObject.Properties["SystemCreationClassName"].Value,
                    SystemName = (string) managementObject.Properties["SystemName"].Value,
                    TagId = (uint) managementObject.Properties["TagId"].Value,
                    TotalSessions = (uint) managementObject.Properties["TotalSessions"].Value,
                    WaitHint = (uint) managementObject.Properties["WaitHint"].Value
                });

            return list.ToArray();
        }
    }
}