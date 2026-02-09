using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Collections;
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Initialise))]
internal static class InGame_Initialise
{

    [HarmonyPostfix]
    private static void Postfix(InGame __instance)
    {
        //Instantiating the Boss UI used to be done here, now that's done in the `InGame_StartMatch` patch.
    }
}