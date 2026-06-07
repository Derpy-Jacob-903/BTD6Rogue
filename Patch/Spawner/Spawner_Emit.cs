using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Data.Quests;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Track;
using System;
using System.Linq;

namespace BTD6Rogue;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.Emit))]
internal static class Spawner_Emit {
    [HarmonyPrefix]
    private static void Prefix(Spawner __instance, ref BloonModel bloonModel, int roundNumber, int emissionIndex) {
        if (BTD6Rogue.rogueGame is null) { return; }
        if (bloonModel.isBoss || bloonModel.baseId.Contains("Lych") || bloonModel.IsRock) {
            BossUtil.GetBossFromBloonId(bloonModel.baseId).AdjustBloonModel(bloonModel, roundNumber / 20, false);
        }
    }

    public static bool isLychToken(BloonModel bloonModel)
    {
        return bloonModel.baseId.Contains("Lych") || bloonModel.baseId.Contains("Tombstone"); // || bloonModel.baseId.Contains("Undead");
    }

    [HarmonyPostfix]
    private static void Postfix(Spawner __instance, BloonModel bloonModel, int roundNumber, int emissionIndex, ref Bloon __result)
    {
        if (BTD6Rogue.rogueGame is null) { return; }
        if (bloonModel.isBoss || isLychToken(bloonModel) || bloonModel.IsRock) //note: should this include Undead Moabs and Diamond Bloons?
        {
            RogueBoss boss = BossUtil.GetBossFromBloonId(bloonModel.baseId);
            boss.AdjustBloon(__result, roundNumber / 20, false);
            if (boss.IsBoss)
            {
                BTD6Rogue.rogueGame.roundManager.BossSpawned();
            }
        }
        if (emissionIndex >= 5000)
        {
            IncreaseBloonWorthModel.BloonWorthMutator bme = new IncreaseBloonWorthModel.BloonWorthMutator(
                "CashlessBloon", 0, 0, "", Il2Cpp.BloonProperties.None);
            __result.AddMutator(bme, -1, false);
        }
        if (bloonModel.isBoss)
        {
            __instance.bossBloonManager.currentBoss = __result;
            __instance.bossBloonManager.currentBossTier = Math.Min(((roundNumber + 1) / 20), 5);
        }
        //custom properties here
        /*var rand = new Random();
        bool isTattered = false;
        //if (roundNumber >= 8 && !bloonModel.isMoab) { isTattered = rand.Next(4) == 0; }
        if (roundNumber >= 8 && BTD6Rogue.rogueGame.modifiers.Any(m => m is ZNewPropertiesModifier) && !bloonModel.isMoab) { isTattered = rand.Next(4) == 0; }
        if (isTattered)
        {
            __result.AddMutatorForNumLayers(new BuffBloonSpeedModel.BloonBuffMutator(2, "Bleed"), layerCount: 1);
        }*/

        /*bool isSplitting = false;
        if (roundNumber >= 6 && !bloonModel.isMoab && BTD6Rogue.rogueGame.modifiers.Any(m => m is ZNewPropertiesModifier) && bloonModel.bloonProperties == BloonProperties.None) { isSplitting = rand.Next(4) == 0; }
        if (BTD6Rogue.rogueGame.modifiers.Any(m => m is OForceSplittingModifier) && !bloonModel.isMoab) { isSplitting = true }
        if (isSplitting)
        {
            __result.bloonModel.RemoveAllChildren();
            __result.bloonModel.AddToChildren(__result.bloonModel.id, 3);
        }*/

        bool isLead = false;
        //if (roundNumber >= 28 && !bloonModel.isMoab && BTD6Rogue.rogueGame.modifiers.Any(m => m is ZNewPropertiesModifier)) { isLead = rand.Next(4) == 0; }
        //if (ModifierUtil.HasModifier<OForceLeadModifier>() && !bloonModel.isMoab) { isLead = true; }
        if (isLead)
        {
            __result.bloonModel.bloonProperties |= Il2Cpp.BloonProperties.Lead;
        }
    }
}
