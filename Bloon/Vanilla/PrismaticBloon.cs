namespace BTD6Rogue;

public class PrismaticBloon : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Prismatic";
    public override int StartRound => 40;
    public override int EndRound => -1;

    public override int BloonRbe => 142;

    public override bool Camo => true;
    public override int CamoStartRound => 62;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 47;
    public override int RegrowEndRound => -1;
    public override bool Fortified => false;
    public override int FortifiedStartRound => 56;
    public override int FortifiedEndRound => -1;
}
