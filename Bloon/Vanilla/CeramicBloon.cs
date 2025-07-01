namespace BTD6Rogue;

public class CeramicBloon : RogueBloon {
    public override string BaseBloonId => "Ceramic";
    public override string MasteryBloonId => "Moab";
    public override int StartRound => 39;
    public override int EndRound => -1;

	public override int BloonRbe => 104;

	public override bool Camo => true;
    public override bool? CamoIfMastery => false;
    public override int CamoStartRound => 62;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override bool? RegrowIfMastery => false;
    public override int RegrowStartRound => 47;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 56;
    public override int FortifiedEndRound => -1;
}
