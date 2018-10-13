using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show open sessions")]
    internal class SmbSessionCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            throw new System.NotImplementedException();
        }
    }
}