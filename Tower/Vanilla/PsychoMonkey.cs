using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class PsychoMonkey : RogueTower {
	public override string BaseTowerId => "psychomonkey-Psychomonkey";

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 3), new(2, 3), new(1, 2)];
}