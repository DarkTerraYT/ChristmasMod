using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static ChristmasMod.ChristmasMod;

namespace ChristmasMod.Displays
{
    internal class PresentLauncher000 : ModDisplay
    {
        public override string BaseDisplay => GetDisplay(TowerType.BombShooter, 3);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }

    internal class SleighMonkey : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    internal class PresentTurretDisplay : ModCustomDisplay
    {
        public override string AssetBundleName => assetBundleName;

        public override string PrefabName => "PresentTurret";

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            foreach(var renderer in node.GetMeshRenderers())
            {
                renderer.ApplyOutlineShader();
                renderer.SetOutlineColor(Color.red);
            }
        }
    }

    internal class RegularPresent : ModCustomDisplay
    {
        public override string AssetBundleName => assetBundleName;

        public override string PrefabName => basePrefabName;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            GameObject gameObject = node.gameObject;

            gameObject.AddComponent<RotateXYZ>();
        }
    }
    internal class PresentSpike : ModCustomDisplay
    {
        public override string AssetBundleName => assetBundleName;

        public override string PrefabName => "PresentSpike";
    }
}
