using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Hooks;
using BTD_Mod_Helper.Api.Hooks.BloonHooks;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

partial class BTD6Rogue 
{
    [HookTarget(typeof(BloonDegradeHook), HookTargetAttribute.EHookType.Postfix)]
    public static bool PostDegradeHook(Bloon __instance)
    {
        if (__instance.bloonModel.isBoss)
        {
            BTD6Rogue.rogueGame.roundManager.BossDefeated();
        }
        return true;
    }
}
