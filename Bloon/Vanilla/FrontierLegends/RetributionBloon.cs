namespace BTD6Rogue;

public class RetributionBloon : RogueBloon {
    public override string BaseBloonId => "RetributionBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 101;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 138;

    public override bool Camo => false;
    public override bool Regrow => false;
    public override bool Elite => true;
}
