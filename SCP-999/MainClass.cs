using Exiled.API.Features;
using System;
using Exiled.CustomRoles.API;

namespace SCP_999
{
    public class MainClass : Plugin<Config>
    {
        public override string Name { get; } = "Scp999PlayerScript";
        public override string Prefix { get; } = "scp_999";
        public override string Author { get; } = "xNexus-ACS";
        public override Version Version { get; } = new Version(0, 5, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        public Scp999Script scp999;
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            Scp999();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }

        public void Scp999()
        {
            scp999 = new Scp999Script {Role = RoleType.Tutorial};
            scp999.Register();
        }
    }
}
