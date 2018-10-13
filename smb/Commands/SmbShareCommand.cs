using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show local shared folders")]
    internal class SmbShareCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            var shares = SmbShare.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (PrintAsList)
                PrintCollection(shares);
            else
                PrintTable(shares);
        }
    }
}