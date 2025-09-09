using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class LostCrevasse : RogueMap
{
    public override string InternalName => "LostCrevasse";
    public override string MapName => "Lost Crevasse";

    public override string MapImage => VanillaSprites.MapSelectLostCrevasseMapButton;

    public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
    public override int RogueDifficulty => 0;

    public override bool Water => true;

    public override float[] TrackLengths => [0f];
    public override int[] TrackTypes => [0];
}
