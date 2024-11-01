namespace BTD6Rogue;

public class LimeBloon : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Lime";
    public override int StartRound => 13;
    public override int EndRound => 31;

    public override int BloonRbe => 10;

    public override bool Camo => true;
    public override int CamoStartRound => 24;
    public override int CamoEndRound => 30;
    public override bool Regrow => true;
    public override int RegrowStartRound => 14;
    public override int RegrowEndRound => 20;
}
