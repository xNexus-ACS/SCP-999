using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace SCP_999
{
    public class MainClass : Plugin<Config>
    {
        public Random Rng = new Random();
        public override string Name { get; } = "Scp999PlayerScript";
        public override string Prefix { get; } = "scp_999";
        public override string Author { get; } = "xNexus-ACS";
        public override Version Version { get; } = new Version(0, 4, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        public EventHandlers _scp999Handlers;

        public override void OnEnabled()
        {
            _scp999Handlers = new EventHandlers(this);

            Server.RoundStarted += _scp999Handlers.OnRoundStarted;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Server.RoundStarted -= _scp999Handlers.OnRoundStarted;

            _scp999Handlers = null;
            base.OnDisabled();
        }
    }
}
