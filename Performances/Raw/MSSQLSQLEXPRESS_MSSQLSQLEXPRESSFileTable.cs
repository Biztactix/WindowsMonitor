using System.Collections.Generic;
using System.Management;

namespace ComputerManagment
{
    /// <summary>
    /// </summary>
    public sealed class PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable
    {
        public ulong AvgtimedeleteFileTableitem { get; private set; }
        public uint AvgtimedeleteFileTableitem_Base { get; private set; }
        public ulong AvgtimeFileTableenumeration { get; private set; }
        public uint AvgtimeFileTableenumeration_Base { get; private set; }
        public ulong AvgtimeFileTablehandlekill { get; private set; }
        public uint AvgtimeFileTablehandlekill_Base { get; private set; }
        public ulong AvgtimemoveFileTableitem { get; private set; }
        public uint AvgtimemoveFileTableitem_Base { get; private set; }
        public ulong AvgtimeperfileIOrequest { get; private set; }
        public uint AvgtimeperfileIOrequest_Base { get; private set; }
        public ulong AvgtimeperfileIOresponse { get; private set; }
        public uint AvgtimeperfileIOresponse_Base { get; private set; }
        public ulong AvgtimerenameFileTableitem { get; private set; }
        public uint AvgtimerenameFileTableitem_Base { get; private set; }
        public ulong AvgtimetogetFileTableitem { get; private set; }
        public uint AvgtimetogetFileTableitem_Base { get; private set; }
        public ulong AvgtimeupdateFileTableitem { get; private set; }
        public uint AvgtimeupdateFileTableitem_Base { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public ulong FileTabledboperationsPersec { get; private set; }
        public ulong FileTableenumerationreqsPersec { get; private set; }
        public ulong FileTablefileIOrequestsPersec { get; private set; }
        public ulong FileTablefileIOresponsePersec { get; private set; }
        public ulong FileTableitemdeletereqsPersec { get; private set; }
        public ulong FileTableitemgetrequestsPersec { get; private set; }
        public ulong FileTableitemmovereqsPersec { get; private set; }
        public ulong FileTableitemrenamereqsPersec { get; private set; }
        public ulong FileTableitemupdatereqsPersec { get; private set; }
        public ulong FileTablekillhandleopsPersec { get; private set; }
        public ulong FileTabletableoperationsPersec { get; private set; }
        public ulong Frequency_Object { get; private set; }
        public ulong Frequency_PerfTime { get; private set; }
        public ulong Frequency_Sys100NS { get; private set; }
        public string Name { get; private set; }
        public ulong Timestamp_Object { get; private set; }
        public ulong Timestamp_PerfTime { get; private set; }
        public ulong Timestamp_Sys100NS { get; private set; }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable[] Retrieve(string remote, string username,
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

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable[] Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable[] Retrieve(ManagementScope managementScope)
        {
            var objectQuery =
                new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            var list = new List<PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable>();

            foreach (ManagementObject managementObject in objectCollection)
                list.Add(new PerfRawData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable
                {
                    AvgtimedeleteFileTableitem =
                        (ulong) managementObject.Properties["AvgtimedeleteFileTableitem"].Value,
                    AvgtimedeleteFileTableitem_Base =
                        (uint) managementObject.Properties["AvgtimedeleteFileTableitem_Base"].Value,
                    AvgtimeFileTableenumeration = (ulong) managementObject.Properties["AvgtimeFileTableenumeration"]
                        .Value,
                    AvgtimeFileTableenumeration_Base =
                        (uint) managementObject.Properties["AvgtimeFileTableenumeration_Base"].Value,
                    AvgtimeFileTablehandlekill =
                        (ulong) managementObject.Properties["AvgtimeFileTablehandlekill"].Value,
                    AvgtimeFileTablehandlekill_Base =
                        (uint) managementObject.Properties["AvgtimeFileTablehandlekill_Base"].Value,
                    AvgtimemoveFileTableitem = (ulong) managementObject.Properties["AvgtimemoveFileTableitem"].Value,
                    AvgtimemoveFileTableitem_Base = (uint) managementObject.Properties["AvgtimemoveFileTableitem_Base"]
                        .Value,
                    AvgtimeperfileIOrequest = (ulong) managementObject.Properties["AvgtimeperfileIOrequest"].Value,
                    AvgtimeperfileIOrequest_Base = (uint) managementObject.Properties["AvgtimeperfileIOrequest_Base"]
                        .Value,
                    AvgtimeperfileIOresponse = (ulong) managementObject.Properties["AvgtimeperfileIOresponse"].Value,
                    AvgtimeperfileIOresponse_Base = (uint) managementObject.Properties["AvgtimeperfileIOresponse_Base"]
                        .Value,
                    AvgtimerenameFileTableitem =
                        (ulong) managementObject.Properties["AvgtimerenameFileTableitem"].Value,
                    AvgtimerenameFileTableitem_Base =
                        (uint) managementObject.Properties["AvgtimerenameFileTableitem_Base"].Value,
                    AvgtimetogetFileTableitem = (ulong) managementObject.Properties["AvgtimetogetFileTableitem"].Value,
                    AvgtimetogetFileTableitem_Base =
                        (uint) managementObject.Properties["AvgtimetogetFileTableitem_Base"].Value,
                    AvgtimeupdateFileTableitem =
                        (ulong) managementObject.Properties["AvgtimeupdateFileTableitem"].Value,
                    AvgtimeupdateFileTableitem_Base =
                        (uint) managementObject.Properties["AvgtimeupdateFileTableitem_Base"].Value,
                    Caption = (string) managementObject.Properties["Caption"].Value,
                    Description = (string) managementObject.Properties["Description"].Value,
                    FileTabledboperationsPersec = (ulong) managementObject.Properties["FileTabledboperationsPersec"]
                        .Value,
                    FileTableenumerationreqsPersec =
                        (ulong) managementObject.Properties["FileTableenumerationreqsPersec"].Value,
                    FileTablefileIOrequestsPersec =
                        (ulong) managementObject.Properties["FileTablefileIOrequestsPersec"].Value,
                    FileTablefileIOresponsePersec =
                        (ulong) managementObject.Properties["FileTablefileIOresponsePersec"].Value,
                    FileTableitemdeletereqsPersec =
                        (ulong) managementObject.Properties["FileTableitemdeletereqsPersec"].Value,
                    FileTableitemgetrequestsPersec =
                        (ulong) managementObject.Properties["FileTableitemgetrequestsPersec"].Value,
                    FileTableitemmovereqsPersec = (ulong) managementObject.Properties["FileTableitemmovereqsPersec"]
                        .Value,
                    FileTableitemrenamereqsPersec =
                        (ulong) managementObject.Properties["FileTableitemrenamereqsPersec"].Value,
                    FileTableitemupdatereqsPersec =
                        (ulong) managementObject.Properties["FileTableitemupdatereqsPersec"].Value,
                    FileTablekillhandleopsPersec = (ulong) managementObject.Properties["FileTablekillhandleopsPersec"]
                        .Value,
                    FileTabletableoperationsPersec =
                        (ulong) managementObject.Properties["FileTabletableoperationsPersec"].Value,
                    Frequency_Object = (ulong) managementObject.Properties["Frequency_Object"].Value,
                    Frequency_PerfTime = (ulong) managementObject.Properties["Frequency_PerfTime"].Value,
                    Frequency_Sys100NS = (ulong) managementObject.Properties["Frequency_Sys100NS"].Value,
                    Name = (string) managementObject.Properties["Name"].Value,
                    Timestamp_Object = (ulong) managementObject.Properties["Timestamp_Object"].Value,
                    Timestamp_PerfTime = (ulong) managementObject.Properties["Timestamp_PerfTime"].Value,
                    Timestamp_Sys100NS = (ulong) managementObject.Properties["Timestamp_Sys100NS"].Value
                });

            return list.ToArray();
        }
    }
}