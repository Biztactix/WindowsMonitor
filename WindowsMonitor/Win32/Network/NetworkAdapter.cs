using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class NetworkAdapter
    {
		public string AdapterType { get; private set; }
		public ushort AdapterTypeId { get; private set; }
		public bool AutoSense { get; private set; }
		public ushort Availability { get; private set; }
		public string Caption { get; private set; }
		public uint ConfigManagerErrorCode { get; private set; }
		public bool ConfigManagerUserConfig { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public string DeviceID { get; private set; }
		public bool ErrorCleared { get; private set; }
		public string ErrorDescription { get; private set; }
		public string GUID { get; private set; }
		public uint Index { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool Installed { get; private set; }
		public uint InterfaceIndex { get; private set; }
		public uint LastErrorCode { get; private set; }
		public string MACAddress { get; private set; }
		public string Manufacturer { get; private set; }
		public uint MaxNumberControlled { get; private set; }
		public ulong MaxSpeed { get; private set; }
		public string Name { get; private set; }
		public string NetConnectionID { get; private set; }
		public ushort NetConnectionStatus { get; private set; }
		public bool NetEnabled { get; private set; }
		public string[] NetworkAddresses { get; private set; }
		public string PermanentAddress { get; private set; }
		public bool PhysicalAdapter { get; private set; }
		public string PNPDeviceID { get; private set; }
		public ushort[] PowerManagementCapabilities { get; private set; }
		public bool PowerManagementSupported { get; private set; }
		public string ProductName { get; private set; }
		public string ServiceName { get; private set; }
		public ulong Speed { get; private set; }
		public string Status { get; private set; }
		public ushort StatusInfo { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public DateTime TimeOfLastReset { get; private set; }

        public static IEnumerable<NetworkAdapter> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NetworkAdapter> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NetworkAdapter> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NetworkAdapter
                {
                     AdapterType = (string) (managementObject.Properties["AdapterType"]?.Value ?? default(string)),
		 AdapterTypeId = (ushort) (managementObject.Properties["AdapterTypeId"]?.Value ?? default(ushort)),
		 AutoSense = (bool) (managementObject.Properties["AutoSense"]?.Value ?? default(bool)),
		 Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 GUID = (string) (managementObject.Properties["GUID"]?.Value ?? default(string)),
		 Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 Installed = (bool) (managementObject.Properties["Installed"]?.Value ?? default(bool)),
		 InterfaceIndex = (uint) (managementObject.Properties["InterfaceIndex"]?.Value ?? default(uint)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 MACAddress = (string) (managementObject.Properties["MACAddress"]?.Value ?? default(string)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MaxNumberControlled = (uint) (managementObject.Properties["MaxNumberControlled"]?.Value ?? default(uint)),
		 MaxSpeed = (ulong) (managementObject.Properties["MaxSpeed"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NetConnectionID = (string) (managementObject.Properties["NetConnectionID"]?.Value ?? default(string)),
		 NetConnectionStatus = (ushort) (managementObject.Properties["NetConnectionStatus"]?.Value ?? default(ushort)),
		 NetEnabled = (bool) (managementObject.Properties["NetEnabled"]?.Value ?? default(bool)),
		 NetworkAddresses = (string[]) (managementObject.Properties["NetworkAddresses"]?.Value ?? new string[0]),
		 PermanentAddress = (string) (managementObject.Properties["PermanentAddress"]?.Value ?? default(string)),
		 PhysicalAdapter = (bool) (managementObject.Properties["PhysicalAdapter"]?.Value ?? default(bool)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 ProductName = (string) (managementObject.Properties["ProductName"]?.Value ?? default(string)),
		 ServiceName = (string) (managementObject.Properties["ServiceName"]?.Value ?? default(string)),
		 Speed = (ulong) (managementObject.Properties["Speed"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 TimeOfLastReset = (DateTime) (managementObject.Properties["TimeOfLastReset"]?.Value ?? default(DateTime))
                };
        }
    }
}