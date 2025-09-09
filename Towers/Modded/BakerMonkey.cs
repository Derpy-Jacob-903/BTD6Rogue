using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class BakerMonkeyV1 : RogueTower
{
    public override string BaseTowerId => "BakerMonkeyMod-BakerMonkey"; //Same ID for both TowerMakingGroup's and Stiefanek's Version

    public override Dictionary<string, TowerTag[]> TowerTags => [];

    public override Vector2Int[] TowerAmountRanges => [new(1, 3), new(1, 3), new(1, 3)];
}
public class BakerMonkeyV2 : RogueTower
{
    public override string BaseTowerId => "BakerMonkeyModV2-BakerMonkey";

    public override Dictionary<string, TowerTag[]> TowerTags => [];

    public override Vector2Int[] TowerAmountRanges => [new(1, 3), new(1, 3), new(1, 3)];
}