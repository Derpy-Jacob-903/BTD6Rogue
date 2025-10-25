using HarmonyLib;
using UnityEngine.SceneManagement;
using BTDMenuManager = Il2CppAssets.Scripts.Unity.Menu.MenuManager;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BTDMenuManager._UnloadSceneAsync_d__46), nameof(BTDMenuManager._UnloadSceneAsync_d__46.MoveNext))]
static class MenuManager_UnloadSceneAsync {
	[HarmonyPrefix]
	static void Prefix(BTDMenuManager._UnloadSceneAsync_d__46 __instance) {
		if (__instance.sceneName.Contains("ModdedMenu") && __instance.__1__state == 0) {
			__instance.__4__this.sceneInstanceDict.Remove(__instance.sceneName);
			Scene scene = SceneManager.GetSceneByName(__instance.sceneName);
			__instance.__2__current = SceneManager.UnloadSceneAsync(scene);
			__instance.__1__state = 1;
		}
	}
}