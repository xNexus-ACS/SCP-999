using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using SCP_999.Scp999PlayerScript;

namespace SCP_999
{
    public class EventHandlers
    {
        /// <summary>
        /// CCTOR
        /// </summary>
        public readonly MainClass plugin;
        public EventHandlers(MainClass plugin)
        {
            this.plugin = plugin;
        }

        /// <summary>
        /// Spawnea un Scp999 al iniciar la ronda con la chance de 75% / Spawns an Scp999 on RoundStart with the chance of 75%
        /// </summary>
        public void OnRoundStarted()
        {
            bool Is999 = false;
            bool Spawn999 = plugin.Rng.Next(100) <= 99;

            foreach (Player player in Player.List)
            {
                switch (player.Role.Type)
                {
                    case RoleType.Scientist:
                    case RoleType.ClassD:
                        {
                            if (Spawn999 && !Is999)
                            {
                                CustomRole.Get(typeof(Scp999Script))?.AddRole(player);
                                Is999 = true;
                            }
                            break;
                        }
                }
            }
        }
    }
}
