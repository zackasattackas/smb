using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BananaHomie.Smb.Internal;
using JetBrains.Annotations;

namespace BananaHomie.Smb.Management
{
    [ManagementObject("MSFT_SmbWitnessClient", Namespace = "Root\\Microsoft\\Windows\\SmbWitness")]
    internal class SmbWitnessClient : IManagementObjectWrapper
    {
        [UsedImplicitly]
        public ManagementObject BaseObject { get; private set; }

        [UsedImplicitly]
        [TableColumn("Name", -15, Order = 0)]
        [ManagementObjectProperty]
        public string ClientName { get; private set; }

        [UsedImplicitly]
        [TableColumn("Node", -15, Order = 2)]
        [ManagementObjectProperty]
        public string WitnessNodeName { get; private set; }

        [UsedImplicitly]
        [TableColumn("File Server", -15)]
        [ManagementObjectProperty]
        public string FileServerNodeName { get; private set; }

        [UsedImplicitly]
        [TableColumn("Network", -10)]
        [ManagementObjectProperty]
        public string NetworkName { get; private set; }

        [UsedImplicitly]
        [TableColumn("Share", -10)]
        [ManagementObjectProperty]
        public string ShareName { get; private set; }

        [UsedImplicitly]
        [TableColumn("IP", -15, Order = 1)]
        [ManagementObjectProperty("IpAddress")]
        public string IPAddress { get; private set; }

        [UsedImplicitly]
        [TableColumn("State", -10)]
        [ManagementObjectProperty]
        public string State { get; private set; }

        [UsedImplicitly]
        [TableColumn(nameof(Flags), 5)]
        [ManagementObjectProperty]
        public uint Flags { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint ResourcesMonitored { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint NotificationsSent { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint NotificationsCancelled { get; private set; }

        [UsedImplicitly]
        [ManagementObjectProperty]
        public uint QueuedNotifications { get; private set; }

        public static IEnumerable<SmbWitnessClient> EnumerateInstances(
            string computerName = ".",
            NetworkCredential credentials = default)
        {
            var classInfo = typeof(SmbWitnessClient).GetCustomAttribute<ManagementObjectAttribute>();

            foreach (var o in WMI.Query(classInfo.GetQuery(), classInfo.GetScope(computerName, credentials)))
                yield return WMI.Bind<SmbWitnessClient>((ManagementObject) o);
        }

        public static void Move(string clientName, string destinationNode, string networkName)
        {
            throw new NotImplementedException();
        }
    }
}
