using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using RemoteAdmin;

namespace MpgServerPlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class HelloWorld : ICommand
    {
        public string Command { get; } = "hello";

        public string[] Aliases { get; } = { "helloworld" };

        public string Description { get; } = "A Command that says hello to the world.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(sender is PlayerCommandSender player)
            {
                response = $"Hello {player.Nickname}";
                return false;
            }
            else
            {
                response = "World";
                return true;
            }
        }
    }
}
