using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show opened shared files")]
    internal class SmbOpenFileCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            var files = SmbOpenFile.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (PrintAsList)
                PrintCollection(files);
            else
                PrintTable(files);
        }
    }
}