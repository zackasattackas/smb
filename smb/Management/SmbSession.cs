using BananaHomie.Smb.Internal;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Reflection;
using JetBrains.Annotations;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbSession", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbSession
    {
        [UsedImplicitly]
        [TableColumn("Computer", -20, Order = 1)]
        [ManagementObjectProperty]
        public string ClientComputerName { get; private set; }

        [UsedImplicitly]
        [TableColumn("User", -20, Order = 2)]
        [ManagementObjectProperty]
        public string ClientUserName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ClusterNodeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string Dialect { get; private set; }

        [UsedImplicitly]
        [TableColumn("Opens", 5, Order =  3)]
        [ManagementObjectProperty]
        public ulong NumOpens { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ScopeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint SecondsExists { get; set; }

        [TableColumn("Alive", 10)]
        public string Alive => TimeSpan.FromSeconds(SecondsExists).ToString("dd\\dhh\\hmm\\m");

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint SecondsIdle { get; set; }

        [TableColumn("Idle", 10)]
        public string Idle => TimeSpan.FromSeconds(SecondsIdle).ToString("dd\\dhh\\hmm\\m");

        [UsedImplicitly]
        [TableColumn("Id", 12, Order = 0)]
        [ManagementObjectProperty]
        public ulong SessionId { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public SmbInstance SmbInstance { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string TransportName { get; private set; }

        public static IEnumerable<SmbSession> EnumerateInstances(
            string computerName = ".",
            NetworkCredential credentials = default)
        {
            var classInfo = typeof(SmbSession).GetCustomAttribute<ManagementObjectAttribute>();

            foreach (var o in WMI.Query(classInfo.GetQuery(), classInfo.GetScope(computerName, credentials)))
                yield return WMI.Bind<SmbSession>((ManagementObject) o);
        }
    }
}
