using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show local shared folders")]
    internal class SmbShareCommand : SmbCommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            throw new System.NotImplementedException();
        }
    }
}