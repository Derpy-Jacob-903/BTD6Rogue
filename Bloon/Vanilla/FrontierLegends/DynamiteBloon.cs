namespace BTD6Rogue;

public class DynamiteBloon : RogueBloon {
    public override string BaseBloonId => "DynamiteBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 61;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 55;

    public override bool Camo => false;
    public override bool Regrow => false;
    public override bool Elite => true;
}
