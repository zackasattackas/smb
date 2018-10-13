using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show/move witness clients in a failover cluster")]
    internal class SmbWitnessCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            var witnessClients = SmbWitnessClient.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (PrintAsList)
                PrintCollection(witnessClients);
            else
                PrintTable(witnessClients);            
        }
    }
}
