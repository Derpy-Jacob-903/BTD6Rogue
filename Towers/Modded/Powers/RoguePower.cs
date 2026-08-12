using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD6Rogue
{
    public abstract class RoguePowerTower : RogueTower
    {
        public override bool ChoiceBlacklisted => StaticChoiceBlacklisted;
        public static bool StaticChoiceBlacklisted => ModifierUtil.HasModifier<NoPowersModifier>() || RogueModSettings.AllowPowersInShop == RogueModSettings.AllowPowersEnum.Unlimited /*|| !ModifierUtil.HasModifier<OPrismaticShardModifier>()*/;
        public override bool SelectBlacklisted => StaticSelectBlacklisted;
        public static bool StaticSelectBlacklisted => ModifierUtil.HasModifier<NoPowersModifier>() || RogueModSettings.AllowPowersInShop == RogueModSettings.AllowPowersEnum.None;

        // Get the RogueTower's TowerModel at a path and tier of that path
        public override TowerModel GetTower(int[] tiers)
        {
            return Game.instance.model.GetTowerModel(BaseTowerId, 0, 0, 0);
        }
        public override void Register() { }
    }
}
