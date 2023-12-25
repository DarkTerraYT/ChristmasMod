using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ChristmasMod.Displays;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using System.Linq;
namespace ChristmasMod.Upgrades
{
    internal class CaltropyPresents : ModUpgrade<PresentLauncher>
    {
        public override int Path => BOTTOM;

        public override int Tier => 1;

        public override int Cost => 520;

        public override string Description => "Presents now contain caltrops (sometimes doesn't work idk why), presents also now do 2 damage ";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.pierce = 5;
            towerModel.GetWeapon().projectile.GetDamageModel().damage = 2;

            towerModel.GetWeapon().projectile.AddBehavior(new CreateProjectileOnExhaustPierceModel("CreateProjectileOnExhaustPierceModel_Caltrops", Game.instance.model.GetTower("NinjaMonkey", 0, 0, 2).GetWeapon(1).projectile.Duplicate(), new SingleEmissionModel("SingleEmissionModel_", null), 5, 1, 30, true, new(), 1, false));
        }
    }

    internal class SeekingPresents : ModUpgrade<PresentLauncher>
    {
        public override int Path => BOTTOM;

        public override int Tier => 2;

        public override int Cost => 835;

        public override string Description => "Presents now seek out the bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.AddBehavior(Game.instance.model.GetTower("WizardMonkey", 1).GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate());
        }
    }

    internal class PresentTurrets : ModUpgrade<PresentLauncher>
    {
        public override int Path => BOTTOM;

        public override int Tier => 3;

        public override int Cost => 1340;

        public override string Description => "Present Launcher now places down fast firing present turrets";

        public override string Icon => "PresentTurret-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].range = towerModel.range;
            Avatarspawner[0].weapons[0].rate = 20;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].name = "MiniFarmPlacer";
            Avatarspawner[0].weapons[0].projectile.ApplyDisplay<RegularPresent>();
            Avatarspawner[0].weapons[0].projectile.scale *= 1.25f;
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetWeapon(1).projectile.GetBehavior<CreateTowerModel>().tower.Duplicate(), 0, false, false, false, false, false));

            var tower = Avatarspawner[0].weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;

            tower.ApplyDisplay<PresentTurretDisplay>();
            tower.GetAttackModel().RemoveBehavior<DisplayModel>();
            tower.GetWeapon().rate = 0.1f;
            tower.GetWeapon().projectile.GetDamageModel().damage = 1;
            tower.GetWeapon().projectile.display = new(Game.instance.model.GetTower("DartMonkey").GetWeapon().projectile.display.GUID);
            tower.GetWeapon().projectile.id = "PTurret";
            tower.GetAttackModel().AddBehavior<RotateToTargetModel>(new("RotateToTargetModel_", false, false, true, 0, true, true));
            tower.icon = GetSpriteReference<ChristmasMod>("PresentTurret-Portrait");

            towerModel.GetAttackModel().AddWeapon(Avatarspawner[0].weapons[0]);
        }
    }
    internal class SpecialTurrets : ModUpgrade<PresentLauncher>
    {
        public override int Path => BOTTOM;

        public override int Tier => 4;

        public override int Cost => 4560;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var tower = towerModel.GetWeapon(1).projectile.GetBehavior<CreateTowerModel>().tower;
            var projectile = tower.GetWeapon().projectile;
            var weapon = tower.GetWeapon();

            weapon.rate *= 0.75f;

            projectile.ApplyDisplay<RegularPresent>();
            projectile.scale = 0.5f;
            projectile.id = "Bresent";

            projectile.AddBehavior(Game.instance.model.GetTowerFromId("DartMonkey-500").GetWeapon().projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>());
            var CPEFM = projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>();
            CPEFM.emission = new RandomArcEmissionModel("RandomArcEmissionModel_", 3, 0, 360, 25, 5, null);
        }
    }
    internal class MegaTurrets : ModUpgrade<PresentLauncher>
    {
        public override int Path => BOTTOM;

        public override int Tier => 5;

        public override int Cost => 35650;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon(1).projectile.scale *= 2;

            var tower = towerModel.GetWeapon(1).projectile.GetBehavior<CreateTowerModel>().tower;
            var projectile = tower.GetWeapon().projectile;
            var weapon = tower.GetWeapon();

            weapon.rate *= 0.75f;
            projectile.id = "Fresent";

            var CPEFM = projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>();
            CPEFM.emission = new RandomArcEmissionModel("RandomArcEmissionModel_", 4, 0, 360, 25, 5, null);
        }
    }
}
