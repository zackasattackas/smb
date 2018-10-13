using McMaster.Extensions.CommandLineUtils;
using System.Reflection;

namespace BananaHomie.Smb.Commands
{
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    [Command("smb", Description = "View and monitor SMB activity")]
    [Subcommand("connections", typeof(SmbConnectionCommand))]
    [Subcommand("files", typeof(SmbOpenFileCommand))]
    [Subcommand("help", typeof(HelpCommand))]
    [Subcommand("sessions", typeof(SmbSessionCommand))]
    [Subcommand("shares", typeof(SmbShareCommand))]   
    internal class SmbCommand : CommandBase
    {
        public override void OnExecute(CommandLineApplication app)
        {
            app.ShowHint();
        }

        private static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
