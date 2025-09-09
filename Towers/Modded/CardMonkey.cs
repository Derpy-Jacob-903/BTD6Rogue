using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class CardMonkey : RogueTower {
	public override string BaseTowerId => "CardMonkey-CardMonkey";

	public override Dictionary<string, TowerTag[]> TowerTags => [];

    public override Vector2Int[] TowerAmountRanges => [new(1, 4), new(1, 4), new(1, 4)];
}