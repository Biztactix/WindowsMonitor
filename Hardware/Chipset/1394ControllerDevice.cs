using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class Controller1394Device
    {
        public ushort AccessState { get; private set; }
        public string Antecedent { get; private set; }
        public string Dependent { get; private set; }
        public uint NegotiatedDataWidth { get; private set; }
        public ulong NegotiatedSpeed { get; private set; }
        public uint NumberOfHardResets { get; private set; }
        public uint NumberOfSoftResets { get; private set; }

        public static Controller1394Device[] Retrieve(string remote, string username, string password)
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

        public static Controller1394Device[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static Controller1394Device[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_1394ControllerDevice");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<Controller1394Device>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new Controller1394Device
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