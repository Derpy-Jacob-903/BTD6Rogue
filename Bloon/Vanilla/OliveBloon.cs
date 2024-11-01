namespace BTD6Rogue;

public class CamoBloon : RogueBloon {
    public override string BaseBloonId => "ClassicRounds-Olive";
    public override int StartRound => 24;
    public override int EndRound => 75;

	public override int BloonRbe => 11;

	public override bool Camo => true;
    public override int CamoStartRound => 24;
    public override int CamoEndRound => 75;
    public override bool Regrow => false;
    public override int RegrowStartRound => 24;
    public override int RegrowEndRound => 75;
}
