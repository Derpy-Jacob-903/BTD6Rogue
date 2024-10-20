﻿using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class WaterPark : RogueMap {

	public override string InternalName => "Waterpark";
	public override string MapName => "Water Park";

	public override string MapImage => VanillaSprites.MapSelectWaterparkMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
