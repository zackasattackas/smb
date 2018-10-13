using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BananaHomie.Smb.Management;
using JetBrains.Annotations;
using McMaster.Extensions.CommandLineUtils;

namespace BananaHomie.Smb.Commands
{
    [Command(Description = "Force close a session. Any unsaved data will be lost")]
    internal class CloseSessionCommand : CommandBase
    {
        [UsedImplicitly]
        public SmbSessionCommand Parent { get; private set; }

        [Required]
        [Argument(1, "session", "The unique session identifier")]
        public ulong SessionId { get; set; }

        public override void OnExecute(CommandLineApplication app)
        {
            var session = SmbSession.EnumerateInstances(Parent.ComputerName, Parent.GetNetworkCredential())
                .Single(s => s.SessionId == SessionId);

            session.ForceClose();

            throw new NotImplementedException();
        }
    }
}