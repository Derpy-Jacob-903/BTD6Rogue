﻿using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class Mermonkey : RogueTower {
	public override string BaseTowerId => TowerType.Mermonkey;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(1, 3), new(2, 3), new(2, 4)];
}