using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpgServerPlugin.Commands
{
    class Allow : ICommand
    {
        public string Command { get; } = "allow";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command that is allowed";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "The command was a success!";
            return false;
        }
    }
}
