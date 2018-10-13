using BananaHomie.Smb.Commands;
using BananaHomie.Smb.Internal;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Reflection;

namespace BananaHomie.Smb
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                CommandLineApplication.Execute<SmbCommand>(args);
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException te)
                    e = te.InnerException;
                Utilities.Print(e.Message + " " +e.InnerException?.Message, color: ConsoleColor.Red);
            }
        }
    }
}
