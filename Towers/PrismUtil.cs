using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTD6Rogue;

// Functions to handle common tower related code
// Code here should not change anything game data
// Handle all of that in TowerManager
public static class PrismUtil {
	public static List<EncounterChoice> CreateAllValidPrismChoices(RogueGame rogueGame) {
        List<EncounterChoice> towerChoices = [.. TowerUtil.CreateAllValidTowerChoices(rogueGame).Cast<EncounterChoice>()];
        List<EncounterChoice> heroChoices = [.. HeroUtil.CreateAllValidHeroChoices(rogueGame).Cast<EncounterChoice>()];
        towerChoices.AddRange(heroChoices);
        return towerChoices;
	}
}
