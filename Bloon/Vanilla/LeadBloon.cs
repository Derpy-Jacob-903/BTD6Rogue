namespace BTD6Rogue;

public class LeadBloon : RogueBloon {
    public override string BaseBloonId => "Lead";
    public override int StartRound => 28;
    public override int EndRound => -1;

	public override int BloonRbe => 23;

	public override bool Camo => true;
    public override int CamoStartRound => 57;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 46;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 51;
    public override int FortifiedEndRound => -1;
}
public class XStablesModMetal : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Metal";
    public override int StartRound => 48;
    public override int EndRound => -1;

    public override int BloonRbe => 51;

    public override bool Camo => true;
    public override int CamoStartRound => 77;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 66;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 71;
    public override int FortifiedEndRound => -1;
}
public class Robo : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Robo";
    public override int StartRound => 68;
    public override int EndRound => -1;

    public override int BloonRbe => 168;

    public override bool Fortified => true;
    public override int FortifiedStartRound => 91;
    public override int FortifiedEndRound => -1;
    public override bool MoabClass => true;
}
public class TechnoCastle : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-TechnoCastle";
    public override int StartRound => 88;
    public override int EndRound => -1;

    public override int BloonRbe => 1508;
    public override bool MoabClass => true;
}