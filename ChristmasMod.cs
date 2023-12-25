using MelonLoader;
using BTD_Mod_Helper;
using ChristmasMod;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api;

[assembly: MelonInfo(typeof(ChristmasMod.ChristmasMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ChristmasMod;

public class ChristmasMod : BloonsTD6Mod
{
    internal const string assetBundleName = "present";
    internal const string basePrefabName = "present";

    public static int middlePathUpgradesBought = 0;

    /// <summary>
    /// Simple method to get a projectile.
    /// </summary>
    /// <param name="TowerID">ID of the tower </param>
    /// <returns>The Duplicated Projectile</returns>
    public static ProjectileModel GetProjectile(string TowerID, int index = 0)
    {
        return Game.instance.model.GetTowerFromId(TowerID).GetWeapon(index).projectile.Duplicate();
    }

    public override void OnApplicationStart()
    {
        middlePathUpgradesBought = 0;
    }

    public override void OnGameModelLoaded(GameModel model)
    {
        middlePathUpgradesBought = 0;
    }

    public override void OnMainMenu()
    {
        middlePathUpgradesBought = 0;
    }

    public override void OnTowerUpgraded(Tower tower, string upgradeName, TowerModel newBaseTowerModel)
    {
        if (upgradeName.Contains("BetterSurprises"))
        {
            if(middlePathUpgradesBought == 0)
            middlePathUpgradesBought++;
        }
        if (upgradeName.Contains("EvenBetterSurprises"))
        {
            if (middlePathUpgradesBought == 1)
                middlePathUpgradesBought++;
        }
        if (upgradeName.Contains("GreatSurprises"))
        {
            if(middlePathUpgradesBought == 2)
            {
                middlePathUpgradesBought++;
            }
        }
        if (upgradeName.Contains("AwesomeSurprises"))
        {
            if(middlePathUpgradesBought == 3)
            {
                middlePathUpgradesBought++;
            }
        }
        if (upgradeName.Contains("BestSurprises"))
        {
            if (middlePathUpgradesBought == 4)
                middlePathUpgradesBought++;
        }
    }

    public override void OnProjectileCreated(Projectile projectile, Entity entity, Model modelToUse)
    {
        var projectileModel = projectile.projectileModel;

        if (projectileModel.id.Contains("present"))
        {
            if (middlePathUpgradesBought == 0)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("DartMonkey"), GetProjectile("TackShooter"), GetProjectile("GlueGunner"), GetProjectile("BoomerangMonkey"), GetProjectile("BombShooter")]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            if (middlePathUpgradesBought == 1)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("DartMonkey"), GetProjectile("TackShooter"), GetProjectile("GlueGunner"), GetProjectile("BoomerangMonkey"), GetProjectile("BombShooter"), GetProjectile("DartMonkey-300"), GetProjectile("DartMonkey-003"), GetProjectile("TackShooter-300"), GetProjectile("TackShooter-030"), GetProjectile("GlueGunner-300"), GetProjectile("GlueGunner-003"), GetProjectile("BoomerangMonkey-200"), GetProjectile("BombShooter-003"), GetProjectile("BombShooter-030")]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            if (middlePathUpgradesBought == 2)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("DartMonkey"), GetProjectile("TackShooter"), GetProjectile("GlueGunner"), GetProjectile("BoomerangMonkey"), GetProjectile("BombShooter"), GetProjectile("DartMonkey-400"), GetProjectile("DartMonkey-004"), GetProjectile("TackShooter-300"), GetProjectile("TackShooter-030"), GetProjectile("GlueGunner-400"), GetProjectile("GlueGunner-004"), GetProjectile("BoomerangMonkey-200"), GetProjectile("BombShooter-004"), GetProjectile("BombShooter-030"), GetProjectile("WizardMonkey-400"), GetProjectile("WizardMonkey-030", 2), GetProjectile("SuperMonkey-200"), GetProjectile("SuperMonkey-003"), GetProjectile("SuperMonkey-203"), GetProjectile("Druid-200", 1), GetProjectile("Druid-300", 2)]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            if (middlePathUpgradesBought == 3)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("DartMonkey"), GetProjectile("TackShooter"), GetProjectile("GlueGunner"), GetProjectile("BoomerangMonkey"), GetProjectile("BombShooter"), GetProjectile("DartMonkey-400"), GetProjectile("DartMonkey-004"), GetProjectile("TackShooter-300"), GetProjectile("TackShooter-030"), GetProjectile("GlueGunner-400"), GetProjectile("GlueGunner-004"), GetProjectile("BoomerangMonkey-200"), GetProjectile("BombShooter-004"), GetProjectile("BombShooter-030"), GetProjectile("WizardMonkey-400"), GetProjectile("WizardMonkey-030", 2), GetProjectile("SuperMonkey-200"), GetProjectile("SuperMonkey-003"), GetProjectile("SuperMonkey-203"), GetProjectile("Druid-200", 1), GetProjectile("Druid-300", 2), GetProjectile("DartMonkey-005"), GetProjectile("DartMonkey-500"), GetProjectile("BombShooter-040"), GetProjectile("BombShooter-400"), GetProjectile("BoomerangMonkey-004"), GetProjectile("GlueGunner-004"), GetProjectile("GlueGunner-500"), GetProjectile("DartMonkey-004"), GetProjectile("DartlingGunner-040"), GetProjectile("DartlingGunner-300"), GetProjectile("SuperMonkey-004"), GetProjectile("SuperMonkey-204"), GetProjectile("SuperMonkey-040"), GetProjectile("Druid-400", 3)]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            if (middlePathUpgradesBought == 4)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("DartMonkey"), GetProjectile("TackShooter"), GetProjectile("GlueGunner"), GetProjectile("BoomerangMonkey"), GetProjectile("BombShooter"), GetProjectile("DartMonkey-400"), GetProjectile("DartMonkey-004"), GetProjectile("TackShooter-300"), GetProjectile("TackShooter-030"), GetProjectile("GlueGunner-400"), GetProjectile("GlueGunner-004"), GetProjectile("BoomerangMonkey-200"), GetProjectile("BombShooter-004"), GetProjectile("BombShooter-030"), GetProjectile("WizardMonkey-400"), GetProjectile("WizardMonkey-030", 2), GetProjectile("SuperMonkey-200"), GetProjectile("SuperMonkey-003"), GetProjectile("SuperMonkey-203"), GetProjectile("Druid-200", 1), GetProjectile("Druid-300", 2), GetProjectile("DartMonkey-005"), GetProjectile("DartMonkey-500"), GetProjectile("BombShooter-040"), GetProjectile("BombShooter-400"), GetProjectile("BoomerangMonkey-004"), GetProjectile("GlueGunner-004"), GetProjectile("GlueGunner-500"), GetProjectile("DartMonkey-004"), GetProjectile("DartlingGunner-040"), GetProjectile("DartlingGunner-300"), GetProjectile("SuperMonkey-004"), GetProjectile("SuperMonkey-204"), GetProjectile("SuperMonkey-040"), GetProjectile("Druid-400", 3), GetProjectile("SuperMonkey-300"), GetProjectile("BananaFarm-400"), GetProjectile("BananaFarm-240"), GetProjectile("GlueGunner-005"), GetProjectile("SuperMonkey-050")]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            if (middlePathUpgradesBought == 5)
            {
                Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("SuperMonkey-250"), GetProjectile("SuperMonkey-205"), GetProjectile("SuperMonkey-500"), GetProjectile("DartMonkey-500"), GetProjectile("DartMonkey-005"), GetProjectile("GlueGunner-500"), GetProjectile("GlueGunner-005"), GetProjectile("BoomerangMonkey-500"), GetProjectile("BoomerangMonkey-005"), GetProjectile("BombShooter-050"), GetProjectile("BombShooter-005"), GetProjectile("BombShooter-500"), GetProjectile("IceMonkey-005"), GetProjectile("DartlingGunner-050"), GetProjectile("WizardMonkey-050"), GetProjectile("WizardMonkey-500"), GetProjectile("WizardMonkey-005"), GetProjectile("SuperMonkey-050"), GetProjectile("NinjaMonkey-005", 2), GetProjectile("Druid-500", 4), GetProjectile("BananaFarm-520"), GetProjectile("MonkeyVillage-500"), GetProjectile("EngineerMonkey-500")]);
                projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
            }

            projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.SetHitCamo(true);
        }

        if (projectileModel.id.Contains("Bresent"))
        {
            Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("SuperMonkey-200"), GetProjectile("BombShooter-004"), GetProjectile("GlueGunner-400"), GetProjectile("WizardMonkey-400"), GetProjectile("Alchemist-004")]);
            projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
        }

        if (projectileModel.id.Contains("Fresent"))
        {
            Il2CppReferenceArray<ProjectileModel> projectiles = new([GetProjectile("SuperMonkey-400"), GetProjectile("BombShooter-004"), GetProjectile("GlueGunner-500"), GetProjectile("WizardMonkey-500"), GetProjectile("Alchemist-005"), GetProjectile("BoomerangMonkey-005"), GetProjectile("DartMonkey-005")]);
            projectileModel.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile = projectiles[new Random().Next(0, projectiles.Count - 1)];
        }
    }
}