using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show open sessions")]
    internal class SmbSessionCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            var sessions = SmbSession.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (PrintAsList)
                PrintCollection(sessions);
            else
                PrintTable(sessions);
        }
    }
}