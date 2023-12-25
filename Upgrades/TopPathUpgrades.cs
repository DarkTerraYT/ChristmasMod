using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ChristmasMod.Displays;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasMod.Upgrades
{
    internal class BiggerPresents : ModUpgrade<PresentLauncher>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => 525;

        public override string Description => "Presents are 1.25x bigger, pops one more layer and can pop more bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetWeapon().projectile;

            projectileModel.scale *= 1.25f;
            projectileModel.radius *= 1.25f;

            projectileModel.pierce += 2;

            projectileModel.GetDamageModel().damage += 1;
        }
    }
    internal class EvenBiggerPresents : ModUpgrade<PresentLauncher>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => 725;

        public override string Description => "Presents are 1.5x bigger, pops another layer and can pop even more bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var projectileModel = towerModel.GetWeapon().projectile;

            projectileModel.scale *= 1.5f;
            projectileModel.radius *= 1.5f;

            projectileModel.pierce += 3;

            projectileModel.GetDamageModel().damage += 1;
        }
    }
    internal class ExplosivePresents : ModUpgrade<PresentLauncher>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1005;

        public override string Description => "Presents now explode. No explaining needed. (Can pop black bloons)";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.AddBehavior(Game.instance.model.GetTower("BombShooter").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
            towerModel.GetWeapon().projectile.AddBehavior(Game.instance.model.GetTower("BombShooter").GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
        }
    }
    internal class BiggerExplosions : ModUpgrade<PresentLauncher>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 5220;

        public override string Description => "Presents now have bigger and more damaging explosions.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 9;
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.scale *= 1.5f;
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.radius *= 1.5f;
            towerModel.GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale *= 1.5f;
        }
    }
    internal class BiggestExplosions : ModUpgrade<PresentLauncher>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 35220;

        public override string Description => "'I like bombs!' - Someone somewhere probably";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 21;
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.scale *= 5f;
            towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.radius *= 5;
            towerModel.GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale *= 5;

            towerModel.GetWeapon().rate *= 0.5f;
        }
    }
}
