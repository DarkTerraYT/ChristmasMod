using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ChristmasMod.Displays;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using static ChristmasMod.ChristmasMod;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;

namespace ChristmasMod
{
    internal class PresentLauncher : ModTower<ChristmasTowers>
    {
        public override string BaseTower => TowerType.DartMonkey;

        public override int Cost => 895;

        public override string Icon => Portrait;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += 45;

            towerModel.GetAttackModel().range += 45;

            var projectileModel = towerModel.GetWeapon().projectile;

            projectileModel.RemoveBehavior<CreateProjectileOnContactModel>();

            projectileModel.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey-500").GetWeapon().projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate());

            projectileModel.id = "present";

            var CPEFM = projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>();
            CPEFM.emission = new RandomArcEmissionModel("RandomArcEmissionModel_", 3, 0, 360, 25, 5, null);

            towerModel.ApplyDisplay<PresentLauncher000>();

            towerModel.GetWeapon().projectile.ApplyDisplay<RegularPresent>();

            towerModel.GetWeapon().projectile.pierce = 1;

            towerModel.GetWeapon().projectile.GetDamageModel().damage = 0;

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}
