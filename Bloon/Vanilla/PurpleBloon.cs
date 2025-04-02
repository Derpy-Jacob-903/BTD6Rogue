namespace BTD6Rogue;

public class PurpleBloon : RogueBloon {
    public override string BaseBloonId => "Purple";
    public override int StartRound => 32;
    public override int EndRound => -1;

	public override int BloonRbe => 11;

	public override bool Camo => true;
    public override int CamoStartRound => 52;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 44;
    public override int RegrowEndRound => -1;
}

public class Arcane : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Arcane";
    public override int StartRound => 52;
    public override int EndRound => -1;

    public override int BloonRbe => 45;

    public override bool Camo => true;
    public override int CamoStartRound => 72;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 64;
    public override int RegrowEndRound => -1;
}
public class MagicCastle : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-MagicCastle";
    public override int StartRound => 72;
    public override int EndRound => -1;

    public override int BloonRbe => 520;
}