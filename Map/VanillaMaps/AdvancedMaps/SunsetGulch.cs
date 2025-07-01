using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class SunsetGulch : RogueMap {

	public override string InternalName => "SunsetGulch";
	public override string MapName => "Sunset Gulch";

	public override string MapImage => VanillaSprites.MapSelectSunsetGulchMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Advanced;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
