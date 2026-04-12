namespace BTD6Rogue;

public class AuraBloon : RogueBloon {
    public override string BaseBloonId => "AuraBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 61;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 85;

    public override bool Camo => false;
    public override bool Regrow => false;
}
