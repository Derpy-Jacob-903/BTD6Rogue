namespace BTD6Rogue;

public class RingleaderBloon : RogueBloon {
    public override string BaseBloonId => "RingleaderBloon";
    public override int MasteryMult => 6;
    public override int StartRound => 59;
    public override int EndRound => -1;
    public override bool CanSpawn => ModifierUtil.HasModifier<OAZFrontierModifier>();

    public override int BloonRbe => 171;

    public override bool Camo => false;
    public override bool Regrow => false;
    public override bool Elite => false;
}
