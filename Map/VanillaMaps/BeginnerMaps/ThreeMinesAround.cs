using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class ThreeMinesAround : RogueMap {

	public override string InternalName => "ThreeMinesAround";
	public override string MapName => "Three Mines 'Round";

	public override string MapImage => VanillaSprites.MapSelectThreeMinesAroundMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
