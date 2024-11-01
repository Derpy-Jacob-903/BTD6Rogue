namespace BTD6Rogue;

public class MagentaBloon : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Magenta";
    public override int StartRound => 9;
    public override int EndRound => 23;

    public override int BloonRbe => 6;

    public override bool Camo => true;
    public override int CamoStartRound => 24;
    public override int CamoEndRound => 30;
    public override bool Regrow => true;
    public override int RegrowStartRound => 14;
    public override int RegrowEndRound => 20;
}
