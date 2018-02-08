using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_FaxService_FaxService
    {
        public uint Bytesreceived { get; private set; }
        public uint Bytessent { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public uint Failedfaxestransmissions { get; private set; }
        public uint Failedoutgoingconnections { get; private set; }
        public uint Failedreceptions { get; private set; }
        public uint Faxessent { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public uint Minutesreceiving { get; private set; }
        public uint Minutessending { get; private set; }
        public string Name { get; private set; }
        public uint Pagessent { get; private set; }
        public uint Receivedfaxes { get; private set; }
        public uint Receivedpages { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint Totalbytes { get; private set; }
        public uint Totalfaxessentandreceived { get; private set; }
        public uint Totalminutessendingandreceiving { get; private set; }
        public uint Totalpages { get; private set; }

        public static PerfFormattedData_FaxService_FaxService[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_FaxService_FaxService[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_FaxService_FaxService[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_FaxService_FaxService");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_FaxService_FaxService>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_FaxService_FaxService
                {
                    Bytesreceived = (uint) managementObject.Properties["Bytesreceived"].Value,
                    Bytessent = (uint) managementObject.Properties["Bytessent"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    Failedfaxestransmissions = (uint) managementObject.Properties["Failedfaxestransmissions"].Value,
                    Failedoutgoingconnections = (uint) managementObject.Properties["Failedoutgoingconnections"].Value,
                    Failedreceptions = (uint) managementObject.Properties["Failedreceptions"].Value,
                    Faxessent = (uint) managementObject.Properties["Faxessent"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Minutesreceiving = (uint) managementObject.Properties["Minutesreceiving"].Value,
                    Minutessending = (uint) managementObject.Properties["Minutessending"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Pagessent = (uint) managementObject.Properties["Pagessent"].Value,
                    Receivedfaxes = (uint) managementObject.Properties["Receivedfaxes"].Value,
                    Receivedpages = (uint) managementObject.Properties["Receivedpages"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    Totalbytes = (uint) managementObject.Properties["Totalbytes"].Value,
                    Totalfaxessentandreceived = (uint) managementObject.Properties["Totalfaxessentandreceived"].Value,
                    Totalminutessendingandreceiving =
                        (uint) managementObject.Properties["Totalminutessendingandreceiving"].Value,
                    Totalpages = (uint) managementObject.Properties["Totalpages"].Value
                });

            return list.ToArray();
        }
    }
}