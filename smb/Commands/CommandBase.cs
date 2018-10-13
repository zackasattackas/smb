using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    internal abstract class CommandBase
    {
        public abstract void OnExecute(CommandLineApplication app);
    }
}