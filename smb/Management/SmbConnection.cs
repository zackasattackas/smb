using BananaHomie.Smb.Internal;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Reflection;
using JetBrains.Annotations;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbConnection", Namespace = "Root\\Microsoft\\Windows\\Smb")]
    public class SmbConnection : IManagementObjectWrapper
    {
        [UsedImplicitly]
        public ManagementObject BaseObject { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool ContinuouslyAvailable { get; private set; }

        [UsedImplicitly]
        [TableColumn("User", -25, Order = 3)]
        [ManagementObjectProperty]
        public string Credential { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string Dialect { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Encrypted { get; private set; }

        [UsedImplicitly]
        [TableColumn("Opens", 5, Order = 2)]
        [ManagementObjectProperty]
        public ulong NumOpens { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public bool Redirected { get; private set; }

        [UsedImplicitly]
        [TableColumn("Server", -25, Order = 0)]
        [ManagementObjectProperty]
        public string ServerName { get; private set; }

        [UsedImplicitly]
        [TableColumn("Share", -15, Order = 1)]
        [ManagementObjectProperty]
        public string ShareName { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public SmbInstance SmbInstance { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public string UserName { get; set; }

        public static IEnumerable<SmbConnection> EnumerateInstances(
            string computerName = ".",
            NetworkCredential credentials = default)
        {
            var classInfo = typeof(SmbConnection).GetCustomAttribute<ManagementObjectAttribute>();

            foreach (var o in WMI.Query(classInfo.GetQuery(), classInfo.GetScope(computerName, credentials)))
                yield return WMI.Bind<SmbConnection>((ManagementObject) o);
        }
    }
}