using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show opened shared files")]
    internal class SmbOpenFileCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            throw new System.NotImplementedException();
        }
    }
}