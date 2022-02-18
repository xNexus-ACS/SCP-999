using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using System.Collections.Generic;
using Scp999Handler_Player = Exiled.Events.Handlers.Player;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace SCP_999.Scp999PlayerScript
{
    public class Scp999Script : CustomRole
    {
        /// <summary>
        /// Scp999PlayerScript
        /// </summary>
        public override uint Id { get; set; } = 37;
        public override string Name { get; set; } = "SCP 999";
        public override string Description { get; set; } = "The Cute SCP 999";
        public override RoleType Role { get; set; } = RoleType.Tutorial;
        public override int MaxHealth { get; set; } = 1000;
        protected override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1,
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Chance = 100,
                    Role = RoleType.Scp049,
                }
            }
        };
        /// <summary>
        /// Inventario que tendra el 999
        /// </summary>
        protected override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Coin}",
            $"{ItemType.Flashlight}",
            $"{ItemType.KeycardO5}",
        };
        /// <summary>
        /// BC que aparecera al ponerle al jugador el role
        /// </summary>
        /// <param name="player"></param>
        protected override void RoleAdded(Player player)
        {
            player.Broadcast(5, "<i>You are the <color=green>Scp999</color></i>");
            player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
            player.IsGodModeEnabled = true;
            player.RankName = "SCP 999";
            player.RankColor = "green";
            base.RoleAdded(player);
        }
        /// <summary>
        /// Activa los eventos
        /// </summary>
        protected override void SubscribeEvents()
        {
            Scp999Handler_Player.DroppingItem += this.OnDroppingItem;
            Scp999Handler_Player.PickingUpItem += this.OnPickingUpItem;
            base.SubscribeEvents();
        }
        /// <summary>
        /// Desactiva los eventos
        /// </summary>
        protected override void UnSubscribeEvents()
        {
            Scp999Handler_Player.DroppingItem -= this.OnDroppingItem;
            Scp999Handler_Player.PickingUpItem -= this.OnPickingUpItem;
            base.UnSubscribeEvents();
        }
        /// <summary>
        /// Hace que el 999 no pueda tirar juegos
        /// </summary>
        /// <param name="ev"></param>
        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if (Check(ev.Player))
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("<i>You cant drop items while you are <color=green>scp-999</color></i>");
            }
        }
        /// <summary>
        /// Hace que el 999 no pueda cojer objetos
        /// </summary>
        /// <param name="ev"></param>
        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Check(ev.Player))
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("<i>You cant pickup items while you are <color=green>scp-999</color></i>");
            }
        }
    }
}
