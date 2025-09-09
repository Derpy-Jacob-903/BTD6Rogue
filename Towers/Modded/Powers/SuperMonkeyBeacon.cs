using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class SuperMonkeyBeacon : RoguePowerProTower {
    public override string BaseTowerId => "PowersInShop-SuperMonkeyBeacon";
    public override Dictionary<string, TowerTag[]> TowerTags => [];
	public override Vector2Int[] TowerAmountRanges => [new(1, 1), new(1, 1), new(1, 1)];
}