using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class Eevee : RogueTower {
	public override string BaseTowerId => "Eevee-Eevee";

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 4), new(1, 2), new(2, 3)];
}