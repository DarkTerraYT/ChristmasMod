using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ChristmasMod.Displays;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasMod
{
    internal class SleighMonkeyDrone : ModTower<ChristmasTowers>
    {
        public override string BaseTower => TowerType.EtienneDrone;

        public override int Cost => 0;

        public override bool DontAddToShop => true;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<SleighMonkey>();

            towerModel.GetWeapon().projectile.GetDamageModel().damage = 1;
            towerModel.GetWeapon().emission = new SingleEmissionModel("SingleEmissionModel", null);
            towerModel.GetWeapon().rate = 0.85f;
            towerModel.GetWeapon().projectile.id = "present";
            towerModel.GetWeapon().projectile.ApplyDisplay<RegularPresent>();
        }
    }
}
