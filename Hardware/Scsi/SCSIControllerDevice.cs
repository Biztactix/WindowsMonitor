using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class SCSIControllerDevice
    {
        public ushort AccessState { get; private set; }
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }
        public uint NegotiatedDataWidth { get; private set; }
        public ulong NegotiatedSpeed { get; private set; }
        public uint NumberOfHardResets { get; private set; }
        public uint NumberOfSoftResets { get; private set; }

        public static SCSIControllerDevice[] Retrieve(string remote, string username, string password)
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

        public static SCSIControllerDevice[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static SCSIControllerDevice[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SCSIControllerDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<SCSIControllerDevice>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new SCSIControllerDevice
                {
                    AccessState = (ushort) managementObject.Properties["AccessState"].Value,
                    Antecedent = (string) managementObject.Properties["Antecedent"].Value,
                    Dependent = (string) managementObject.Properties["Dependent"].Value,
                    NegotiatedDataWidth = (uint) managementObject.Properties["NegotiatedDataWidth"].Value,
                    NegotiatedSpeed = (ulong) managementObject.Properties["NegotiatedSpeed"].Value,
                    NumberOfHardResets = (uint) managementObject.Properties["NumberOfHardResets"].Value,
                    NumberOfSoftResets = (uint) managementObject.Properties["NumberOfSoftResets"].Value
                });

            return list.ToArray();
        }
    }
}