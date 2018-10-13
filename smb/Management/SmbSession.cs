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
        [ManagementObjectProperty]
        public string ClientComputerName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ClientUserName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ClusterNodeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string Dialect { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public int NumOpens { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string ScopeName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public int SecondsExist { get; set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public int SecondsIdle { get; set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public int SessionId { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public SmbInstance? SmbInstance { get; private set; }

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
