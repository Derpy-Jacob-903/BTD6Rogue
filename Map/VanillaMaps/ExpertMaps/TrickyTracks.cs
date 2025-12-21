using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class TrickyTracks : RogueMap {

	public override string InternalName => "TrickyTracks";
	public override string MapName => "Tricky Tracks";

	public override string MapImage => VanillaSprites.MapSelectTrickyTracksButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
