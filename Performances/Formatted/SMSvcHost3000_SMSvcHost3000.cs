using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfFormattedData_SMSvcHost3000_SMSvcHost3000
    {
        public string Caption { get; private set; }
        public uint ConnectionsAcceptedovernetpipe { get; private set; }
        public uint ConnectionsAcceptedovernettcp { get; private set; }
        public uint ConnectionsDispatchedovernetpipe { get; private set; }
        public uint ConnectionsDispatchedovernettcp { get; private set; }
        public string Description { get; private set; }
        public uint DispatchFailuresovernetpipe { get; private set; }
        public uint DispatchFailuresovernettcp { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public uint ProtocolFailuresovernetpipe { get; private set; }
        public uint ProtocolFailuresovernettcp { get; private set; }
        public uint RegistrationsActivefornetpipe { get; private set; }
        public uint RegistrationsActivefornettcp { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }
        public uint UrisRegisteredfornetpipe { get; private set; }
        public uint UrisRegisteredfornettcp { get; private set; }
        public uint UrisUnregisteredfornetpipe { get; private set; }
        public uint UrisUnregisteredfornettcp { get; private set; }

        public static PerfFormattedData_SMSvcHost3000_SMSvcHost3000[] Retrieve(string remote, string username,
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

        public static PerfFormattedData_SMSvcHost3000_SMSvcHost3000[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfFormattedData_SMSvcHost3000_SMSvcHost3000[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_SMSvcHost3000_SMSvcHost3000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfFormattedData_SMSvcHost3000_SMSvcHost3000>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfFormattedData_SMSvcHost3000_SMSvcHost3000
                {
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    ConnectionsAcceptedovernetpipe =
                        (uint) managementObject.Properties["ConnectionsAcceptedovernetpipe"].Value,
                    ConnectionsAcceptedovernettcp = (uint) managementObject.Properties["ConnectionsAcceptedovernettcp"]
                        .Value,
                    ConnectionsDispatchedovernetpipe =
                        (uint) managementObject.Properties["ConnectionsDispatchedovernetpipe"].Value,
                    ConnectionsDispatchedovernettcp =
                        (uint) managementObject.Properties["ConnectionsDispatchedovernettcp"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    DispatchFailuresovernetpipe = (uint) managementObject.Properties["DispatchFailuresovernetpipe"]
                        .Value,
                    DispatchFailuresovernettcp = (uint) managementObject.Properties["DispatchFailuresovernettcp"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    ProtocolFailuresovernetpipe = (uint) managementObject.Properties["ProtocolFailuresovernetpipe"]
                        .Value,
                    ProtocolFailuresovernettcp = (uint) managementObject.Properties["ProtocolFailuresovernettcp"].Value,
                    RegistrationsActivefornetpipe = (uint) managementObject.Properties["RegistrationsActivefornetpipe"]
                        .Value,
                    RegistrationsActivefornettcp = (uint) managementObject.Properties["RegistrationsActivefornettcp"]
                        .Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value,
                    UrisRegisteredfornetpipe = (uint) managementObject.Properties["UrisRegisteredfornetpipe"].Value,
                    UrisRegisteredfornettcp = (uint) managementObject.Properties["UrisRegisteredfornettcp"].Value,
                    UrisUnregisteredfornetpipe = (uint) managementObject.Properties["UrisUnregisteredfornetpipe"].Value,
                    UrisUnregisteredfornettcp = (uint) managementObject.Properties["UrisUnregisteredfornettcp"].Value
                });

            return list.ToArray();
        }
    }
}