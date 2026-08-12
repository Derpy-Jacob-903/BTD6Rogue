using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Bloons;

namespace BTD6Rogue;

public class DiamondBloon : RogueBloon {
    public override string BaseBloonId => "BTD6Rogue-RubyBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 97;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 214;

	public override bool Camo => false;
    public override bool Regrow => false;
    public override bool Elite => false;
}

public class RubyBloon : ModBloon
{
    public override void ModifyBaseBloonModel(BloonModel bloonModel) { }
    public override string BaseBloon => "DiamondBloon";
}
