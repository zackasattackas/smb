using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show open connections")]
    internal class SmbConnectionCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            var connections = SmbConnection.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (PrintAsList)
                PrintCollection(connections);            
            else
                PrintTable(connections);
        }
    }
}