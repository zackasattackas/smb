using JetBrains.Annotations;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Show help information")]
    internal class HelpCommand : CommandBase
    {        
        [UsedImplicitly]
        public SmbCommand Parent { get; private set; }

        public override void OnExecute(CommandLineApplication app)
        {
            if (app.IsShowingInformation)
                app.ShowHelp();
            else
                CommandLineApplication.Execute<SmbCommand>("--help");
        }
    }
}
