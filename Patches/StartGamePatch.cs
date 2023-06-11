﻿using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity;
using HarmonyLib;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
static class StartGamePatch {
    [HarmonyPostfix]
    private static void Postfix(InGame __instance) {
        if (__instance.bridge.IsSandboxMode()) { return; }
        BTD6Rogue.mod.StartRogueGame(__instance);
    }
}