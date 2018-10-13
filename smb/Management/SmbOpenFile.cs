using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Reflection;
using BananaHomie.Smb.Internal;
using JetBrains.Annotations;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbOpenFile", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbOpenFile : IManagementObjectWrapper
    {
        [UsedImplicitly]
        public ManagementObject BaseObject { get; private set; }

        [UsedImplicitly]
        [TableColumn("Client", -25, Order = 1)]
        [ManagementObjectProperty]
        public string ClientComputerName { get; private set; }

        [UsedImplicitly]
        [TableColumn("User", -25, Order = 2)]
        [ManagementObjectProperty]
        public string ClientUserName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ClusterNodeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool ContinuouslyAvailable { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Encrypted { get; private set; }

        [UsedImplicitly]
        [TableColumn("Id", 12, Order = 0)]
        [ManagementObjectProperty]
        public ulong FileId { get; private set; }

        [UsedImplicitly]
        [TableColumn("Locks", 5, Order = 5)]
        [ManagementObjectProperty]
        public uint Locks { get; private set; }

        [UsedImplicitly]
        [TableColumn("Path", -30, Order = 4)]
        [ManagementObjectProperty]
        public string Path { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint Permissions { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ScopeName { get; private set; }

        [UsedImplicitly]
        [TableColumn("Session", 7)]
        [ManagementObjectProperty]
        public ulong SessionId { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ShareRelativePath { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public SmbInstance SmbInstance { get; private set; }

        public static IEnumerable<SmbOpenFile> EnumerateInstances(
            string computerName = ".",
            NetworkCredential credentials = default)
        {
            var classInfo = typeof(SmbOpenFile).GetCustomAttribute<ManagementObjectAttribute>();

            foreach (var o in WMI.Query(classInfo.GetQuery(), classInfo.GetScope(computerName, credentials)))
                yield return WMI.Bind<SmbOpenFile>((ManagementObject)o);
        }
    }
}