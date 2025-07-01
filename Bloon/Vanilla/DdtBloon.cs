namespace BTD6Rogue;

public class DdtBloon : RogueBloon {
    public override string BaseBloonId => "Ddt"; //wait were we using the decamoed DDT?
    public override int MasteryMult => 6;
    public override int StartRound => 90;
    public override int EndRound => -1;

	public override int BloonRbe => 816;
	public override bool MoabClass => true;


    public override bool Camo => true;
    public override bool ForceCamo => true;
    public override int CamoStartRound => 90;
    public override int CamoEndRound => -1;

    public override bool Fortified => true;
    public override int FortifiedStartRound => 110;
    public override int FortifiedEndRound => -1;
}
