namespace BTD6Rogue;

public class AmberBloon : RogueBloon {
    public override string BaseBloonId => "XStablesMod-Amber";
    public override int StartRound => 20;
    public override int EndRound => 47;

	public override int BloonRbe => 13;

	public override bool Camo => true;
    public override int CamoStartRound => 47;
    public override int CamoEndRound => 47;
    public override bool Regrow => true;
    public override int RegrowStartRound => 47;
    public override int RegrowEndRound => 47;
}
