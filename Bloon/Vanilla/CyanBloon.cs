namespace BTD6Rogue;

public class CyanBloon : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Cyan";
    public override int StartRound => 10;
    public override int EndRound => 24;

    public override int BloonRbe => 7;

    public override bool Camo => true;
    public override int CamoStartRound => 22;
    public override int CamoEndRound => 28;
    public override bool Regrow => true;
    public override int RegrowStartRound => 12;
    public override int RegrowEndRound => 18;
}
