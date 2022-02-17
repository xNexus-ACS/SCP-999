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
        public string Description { get; } = "Spawn de SCP 999";

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
                response = "You need arguments";
                return false;
            }
            Player target = Player.Get(args[1]);

            if (target == null)
            {
                response = "Must define a target";
                return false;
            }
            switch (args[2])
            {
                case "usage":
                    {
                        response = "Usage: scp999 <playerid> <999>";
                        return true;
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
