using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class WinSAT
    {
        public float CPUScore { get; private set; }
        public float D3DScore { get; private set; }
        public float DiskScore { get; private set; }
        public float GraphicsScore { get; private set; }
        public float MemoryScore { get; private set; }
        public string TimeTaken { get; private set; }
        public uint WinSATAssessmentState { get; private set; }
        public float WinSPRLevel { get; private set; }

        public static WinSAT[] Retrieve(string remote, string username, string password)
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

        public static WinSAT[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static WinSAT[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_WinSAT");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<WinSAT>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new WinSAT
                {
                    CPUScore = (float) managementObject.Properties["CPUScore"].Value,
                    D3DScore = (float) managementObject.Properties["D3DScore"].Value,
                    DiskScore = (float) managementObject.Properties["DiskScore"].Value,
                    GraphicsScore = (float) managementObject.Properties["GraphicsScore"].Value,
                    MemoryScore = (float) managementObject.Properties["MemoryScore"].Value,
                    TimeTaken = (string) managementObject.Properties["TimeTaken"].Value,
                    WinSATAssessmentState = (uint) managementObject.Properties["WinSATAssessmentState"].Value,
                    WinSPRLevel = (float) managementObject.Properties["WinSPRLevel"].Value
                });

            return list.ToArray();
        }
    }
}