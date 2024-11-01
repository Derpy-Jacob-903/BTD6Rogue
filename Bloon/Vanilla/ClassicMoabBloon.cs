namespace BTD6Rogue;

public class CMoabBloon : RogueBloon {
    public override string BaseBloonId => "Moab";
    public override int StartRound => 40;
    public override int EndRound => 149;

	public override int BloonRbe => 536;
	public override bool MoabClass => true;
}
