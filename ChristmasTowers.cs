using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasMod
{
    internal class ChristmasTowers : ModTowerSet
    {
        public override SpriteReference ContainerLargeReference => GetSpriteReference<ChristmasMod>("ChristmasContainerLarge");
        public override SpriteReference ContainerReference => GetSpriteReference<ChristmasMod>("ChristmasContainer");
        public override SpriteReference ButtonReference => GetSpriteReference<ChristmasMod>("ChristmasButton");
    }
}
