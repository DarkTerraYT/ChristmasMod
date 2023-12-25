using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasMod.Upgrades
{
    internal class BetterSurprises : ModUpgrade<PresentLauncher>
    {
        public override int Path => 1;

        public override int Tier => 1;

        public override int Cost => 1215;

        public override string Description => "Makes more projectiles that can come out from the presents. Only works once. Now shoots every .7 seconds instead on .95 seconds.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate = .7f;
        }
    }
    internal class EvenBetterSurprises : ModUpgrade<PresentLauncher>
    {
        public override int Path => 1;

        public override int Tier => 2;

        public override int Cost => 4675;

        public override string Description => "Makes even more projectiles that can come out from the presents. Only works once. Now shoots every .45 seconds instead on .7 seconds.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate = 0.45f;
        }
    }
    internal class GreatSurprises : ModUpgrade<PresentLauncher>
    {
        public override int Path => 1;

        public override int Tier => 3;

        public override int Cost => 15675;

        public override string Description => "Makes even more projectiles that can come out from the presents. Only works once.Now shoots every .2 seconds instead on .45 seconds.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate = towerModel.GetWeapon().rate = 0.2f;
        }
    }
    internal class AwesomeSurprises : ModUpgrade<PresentLauncher>
    {
        public override int Path => 1;

        public override int Tier => 4;

        public override int Cost => 65320;

        public override string Description => "Makes even more projectiles that can come out from the presents. Only works once. Now shoots every .1 seconds instead on .2 seconds.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate = 0.1f;
        }
    }
    internal class BestSurprises : ModUpgrade<PresentLauncher>
    {
        public override int Path => 1;

        public override int Tier => 5;

        public override int Cost => 250650;

        public override string Description => "Less projectiles can come out from the presents, but now all t5s. Only works once.Now shoots every .05 seconds instead on .1 seconds.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate = 0.05f;
        }
    }
}
