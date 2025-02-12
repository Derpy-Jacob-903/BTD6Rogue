namespace BTD6Rogue;

public class RainbowBloon : RogueBloon {
    public override string BaseBloonId => "Rainbow";
    public override int StartRound => 36;
    public override int EndRound => -1;

	public override int BloonRbe => 47;

	public override bool Camo => true;
    public override int CamoStartRound => 55;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 48;
    public override int RegrowEndRound => -1;
}
public class Prism : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Prismatic";
    public override int StartRound => 46;
    public override int EndRound => -1;

    public override int BloonRbe => 142;

    public override bool Camo => true;
    public override int CamoStartRound => 65;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 58;
    public override int RegrowEndRound => -1;
}
public class Lavender : RogueBloon {
    public override string BaseBloonId => "XStablesMod-Lavender";
    public override int StartRound => 29;
    public override int EndRound => 55;

	public override int BloonRbe => 5;

	public override bool Camo => true;
    public override int CamoStartRound => 41;
    public override int CamoEndRound => 57;
    public override bool Regrow => true;
    public override int RegrowStartRound => 31;
    public override int RegrowEndRound => 47;
}
