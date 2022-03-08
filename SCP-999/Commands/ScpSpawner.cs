using CommandSystem;
using Exiled.API.Features;
using System;
using Exiled.Permissions.Extensions;
using Exiled.CustomRoles.API.Features;

namespace SCP_999.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpSpawner : ICommand
    {
        public string Command { get; } = "scp999";
        public string[] Aliases { get; } = { "s999" };
        public string Description { get; } = "Command for spawn the SCP999";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player p = Player.Get(sender);

            if (!p.CheckPermission("scp999.command"))
            {
                response = "You dont have perms";
                return false;
            }
            string[] args = arguments.Array;
            if (args == null)
            {
                response = "Usage: scp999 <playerid> 999";
                return false;
            }
            Player target = Player.Get(args[1]);

            if (target == null)
            {
                response = "Usage: scp999 <playerid> 999";
                return false;
            }
            switch (args[2])
            {
                case "default":
                    {
                        response = "";
                        return false;
                    }
                case "999":
                    {
                        CustomRole.Get(typeof(Scp999Script)).AddRole(target);
                        break;
                    }
            }
            response = "Done";
            return true;
        }
    }
}
