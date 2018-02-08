using System;
using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class ScheduledJob
    {
        public string Caption { get; private set; }
        public string Command { get; private set; }
        public uint DaysOfMonth { get; private set; }
        public uint DaysOfWeek { get; private set; }
        public string Description { get; private set; }
        public DateTime ElapsedTime { get; private set; }
        public DateTime InstallDate { get; private set; }
        public bool InteractWithDesktop { get; private set; }
        public uint JobId { get; private set; }
        public string JobStatus { get; private set; }
        public string Name { get; private set; }
        public string Notify { get; private set; }
        public string Owner { get; private set; }
        public uint Priority { get; private set; }
        public bool RunRepeatedly { get; private set; }
        public DateTime StartTime { get; private set; }
        public string Status { get; private set; }
        public DateTime TimeSubmitted { get; private set; }
        public DateTime UntilTime { get; private set; }

        public static ScheduledJob[] Retrieve(string remote, string username, string password)
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

        public static ScheduledJob[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static ScheduledJob[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ScheduledJob");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<ScheduledJob>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new ScheduledJob
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Command = (string) managementObject.Properties["Command"].Value,
                    DaysOfMonth = (uint) managementObject.Properties["DaysOfMonth"].Value,
                    DaysOfWeek = (uint) managementObject.Properties["DaysOfWeek"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    ElapsedTime = (DateTime) managementObject.Properties["ElapsedTime"].Value,
                    InstallDate = (DateTime) managementObject.Properties["InstallDate"].Value,
                    InteractWithDesktop = (bool) managementObject.Properties["InteractWithDesktop"].Value,
                    JobId = (uint) managementObject.Properties["JobId"].Value,
                    JobStatus = (string) managementObject.Properties["JobStatus"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Notify = (string) managementObject.Properties["Notify"].Value,
                    Owner = (string) managementObject.Properties["Owner"].Value,
                    Priority = (uint) managementObject.Properties["Priority"].Value,
                    RunRepeatedly = (bool) managementObject.Properties["RunRepeatedly"].Value,
                    StartTime = (DateTime) managementObject.Properties["StartTime"].Value,
                    Status = (string) managementObject.Properties["Status"].Value,
                    TimeSubmitted = (DateTime) managementObject.Properties["TimeSubmitted"].Value,
                    UntilTime = (DateTime) managementObject.Properties["UntilTime"].Value
                });

            return list.ToArray();
        }
    }
}