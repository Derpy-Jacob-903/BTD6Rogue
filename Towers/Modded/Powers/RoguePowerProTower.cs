using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD6Rogue
{
    public abstract class RoguePowerProTower : RogueTower
    {
        public override bool ChoiceBlacklisted => ModifierUtil.HasModifier<NoPowersModifier>() && !RogueModSettings.AllowProPowersAsMonkeys;
        public override bool SelectBlacklisted => ModifierUtil.HasModifier<NoPowersModifier>() && !RogueModSettings.AllowProPowersAsMonkeys;
        public static bool StaticBlacklisted => ModifierUtil.HasModifier<NoPowersModifier>() && !RogueModSettings.AllowProPowersAsMonkeys;

        // Get the RogueTower's TowerModel at a path and tier of that path
        // TODO: make it so it can get crosspaths, additionally combine functionality with getbasetower
        public override TowerModel GetTower(int[] tiers)
        {
            return Game.instance.model.GetTowerModel(BaseTowerId, Math.Max(tiers[0] - 2, 0), Math.Max(tiers[1] - 2, 0), Math.Max(tiers[2] - 2, 0));
        }
        public override void Register() { }
    }
}
