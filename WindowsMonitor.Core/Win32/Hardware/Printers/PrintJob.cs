using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Printers
{
    /// <summary>
    /// </summary>
    public sealed class PrintJob
    {
		public string Caption { get; private set; }
		public string Color { get; private set; }
		public string DataType { get; private set; }
		public string Description { get; private set; }
		public string Document { get; private set; }
		public string DriverName { get; private set; }
		public DateTime ElapsedTime { get; private set; }
		public string HostPrintQueue { get; private set; }
		public DateTime InstallDate { get; private set; }
		public uint JobId { get; private set; }
		public string JobStatus { get; private set; }
		public string Name { get; private set; }
		public string Notify { get; private set; }
		public string Owner { get; private set; }
		public uint PagesPrinted { get; private set; }
		public uint PaperLength { get; private set; }
		public string PaperSize { get; private set; }
		public uint PaperWidth { get; private set; }
		public string Parameters { get; private set; }
		public string PrintProcessor { get; private set; }
		public uint Priority { get; private set; }
		public uint Size { get; private set; }
		public uint SizeHigh { get; private set; }
		public DateTime StartTime { get; private set; }
		public string Status { get; private set; }
		public uint StatusMask { get; private set; }
		public DateTime TimeSubmitted { get; private set; }
		public uint TotalPages { get; private set; }
		public DateTime UntilTime { get; private set; }

        public static IEnumerable<PrintJob> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PrintJob> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PrintJob> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrintJob");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PrintJob
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Color = (string) (managementObject.Properties["Color"]?.Value ?? default(string)),
		 DataType = (string) (managementObject.Properties["DataType"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Document = (string) (managementObject.Properties["Document"]?.Value ?? default(string)),
		 DriverName = (string) (managementObject.Properties["DriverName"]?.Value ?? default(string)),
		 ElapsedTime = (DateTime) (managementObject.Properties["ElapsedTime"]?.Value ?? default(DateTime)),
		 HostPrintQueue = (string) (managementObject.Properties["HostPrintQueue"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 JobId = (uint) (managementObject.Properties["JobId"]?.Value ?? default(uint)),
		 JobStatus = (string) (managementObject.Properties["JobStatus"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Notify = (string) (managementObject.Properties["Notify"]?.Value ?? default(string)),
		 Owner = (string) (managementObject.Properties["Owner"]?.Value ?? default(string)),
		 PagesPrinted = (uint) (managementObject.Properties["PagesPrinted"]?.Value ?? default(uint)),
		 PaperLength = (uint) (managementObject.Properties["PaperLength"]?.Value ?? default(uint)),
		 PaperSize = (string) (managementObject.Properties["PaperSize"]?.Value ?? default(string)),
		 PaperWidth = (uint) (managementObject.Properties["PaperWidth"]?.Value ?? default(uint)),
		 Parameters = (string) (managementObject.Properties["Parameters"]?.Value ?? default(string)),
		 PrintProcessor = (string) (managementObject.Properties["PrintProcessor"]?.Value ?? default(string)),
		 Priority = (uint) (managementObject.Properties["Priority"]?.Value ?? default(uint)),
		 Size = (uint) (managementObject.Properties["Size"]?.Value ?? default(uint)),
		 SizeHigh = (uint) (managementObject.Properties["SizeHigh"]?.Value ?? default(uint)),
		 StartTime = (DateTime) (managementObject.Properties["StartTime"]?.Value ?? default(DateTime)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusMask = (uint) (managementObject.Properties["StatusMask"]?.Value ?? default(uint)),
		 TimeSubmitted = (DateTime) (managementObject.Properties["TimeSubmitted"]?.Value ?? default(DateTime)),
		 TotalPages = (uint) (managementObject.Properties["TotalPages"]?.Value ?? default(uint)),
		 UntilTime = (DateTime) (managementObject.Properties["UntilTime"]?.Value ?? default(DateTime))
                };
        }
    }
}