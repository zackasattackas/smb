using BananaHomie.Smb.Internal;
using BananaHomie.Smb.Management;
using JetBrains.Annotations;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BananaHomie.Smb.Commands
{
    internal abstract class SmbCommandBase : CommandBase
    {
        private string _password;

        [UsedImplicitly]
        public SmbCommand Parent { get; private set; }

        [Argument(0, "\\\\server", "The remote server to connect to. Default is '.' for localhost")]
        public string ComputerName { get; set; } = ".";

        [Option("-u", "The username to connect to the remote server", CommandOptionType.SingleValue)]
        public string UserName { get; set; }

        [Option("-p", "The password to connect to the remote server", CommandOptionType.SingleValue)]
        public string Password
        {
            get => _password ?? (_password = Prompt.GetPassword("Password: "));
            set => _password = value;
        }

        [Option("-l|--list", "Format and print records as a list", CommandOptionType.NoValue)]
        public bool PrintAsList { get; set; }


        public NetworkCredential GetNetworkCredential()
        {
            if (ComputerName == "." || ComputerName == "localhost" || ComputerName == Environment.MachineName)
                return default;
            return new NetworkCredential(UserName, Password);
        }

        protected void PrintObject(object o)
        {
            var properties = o.GetType().GetProperties();
            var maxWidth = properties.Max(p => p.Name.Length);
            foreach (var property in o.GetType().GetProperties())
            {
                if (!property.IsDefined<ManagementObjectPropertyAttribute>())
                    continue;

                Utilities.Print(string.Format($"{{0, -{maxWidth + 1}}}: {{1}}", property.Name, property.GetValue(o)));
            }
        }

        protected void PrintCollection(IEnumerable collection)
        {
            var index = 0;
            foreach (var item in collection)
            {
                Utilities.Print($"\r\n[{index++}]", color: ConsoleColor.Yellow);
                PrintObject(item);
            }
        }

        protected void PrintTable(IEnumerable o)
        {
            var headerPrinted = false;
            var count = 0;

            foreach (var item in o)
            {
                var columns = TableColumnAttribute.GetColumns(item);
                if (!headerPrinted)
                {
                    var header = TableColumnAttribute.GetHeaderString(columns);
                    Utilities.Print(header);
                    headerPrinted = true;
                }

                PrintRow(columns);

                count++;
            }
            
            Utilities.Print(count > 0 ? $"\r\n{count} item(s)" : "No items found");

            void PrintRow(IEnumerable<TableColumnAttribute> columns)
            {
                var row = TableColumnAttribute.ToString(columns);

                Utilities.Print(row);
            }
        }
    }
}