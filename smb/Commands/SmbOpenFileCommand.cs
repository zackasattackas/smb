using System.Linq;
using BananaHomie.Smb.Management;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show opened shared files")]
    internal class SmbOpenFileCommand : SmbCommandBase
    {
        [Option("-s|--session=<ID>", "Show files open in the specified session.", CommandOptionType.SingleValue)]
        public ulong? SessionId { get; set; }
        public override void OnExecute(CommandLineApplication app)
        {
            var files = SmbOpenFile.EnumerateInstances(ComputerName, GetNetworkCredential());
            if (SessionId.HasValue)
                files = files.Where(f => f.SessionId == SessionId.Value);

            if (PrintAsList)
                PrintCollection(files);
            else
                PrintTable(files);
        }
    }
}