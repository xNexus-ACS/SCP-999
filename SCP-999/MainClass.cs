using Exiled.API.Features;
using System;

namespace SCP_999
{
    public class MainClass : Plugin<Config>
    {
        public static MainClass Instance;
        public override string Name { get; } = "Scp999PlayerScript";
        public override string Prefix { get; } = "scp_999";
        public override string Author { get; } = "xNexus-ACS";
        public override Version Version { get; } = new Version(0, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 3);

        public Scp999Script Scp999;

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();

            SCP999();
        }
        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
        public void SCP999()
        {
            Scp999 = new Scp999Script { Role = RoleType.Tutorial };
            Scp999.TryRegister();
        }
    }
}
