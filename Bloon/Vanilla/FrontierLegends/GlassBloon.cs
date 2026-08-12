namespace BTD6Rogue;

public class GlassBloon : RogueBloon {
    public override string BaseBloonId => "GlassBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 63;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 89;

	public override bool Camo => false;
    public override bool Regrow => false;
    public override bool Elite => false;
}
