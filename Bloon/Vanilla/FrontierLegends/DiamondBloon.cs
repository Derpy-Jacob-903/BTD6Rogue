namespace BTD6Rogue;

public class DiamondBloon : RogueBloon {
    public override string BaseBloonId => "DiamondBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 97;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 214;

	public override bool Camo => false;
    public override bool Regrow => false;
}
