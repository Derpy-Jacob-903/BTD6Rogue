namespace BTD6Rogue;

public class MoabBloon : RogueBloon {
    public override string BaseBloonId => "Moab";
    public override int StartRound => 40;
    public override int EndRound => -1;

	public override int BloonRbe => 616;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 60;
    public override int FortifiedEndRound => -1;
}
public class CMoabBloon : RogueBloon {
    public override string BaseBloonId => "ClassicRounds-ClassicMoab";
    public override int StartRound => 37;
    public override int EndRound => -1;

	public override int BloonRbe => 522;
	public override bool MoabClass => true;
}
public class XMoabBloon : RogueBloon {
    public override string BaseBloonId => "XStablesMod-MoabX";
    public override int StartRound => 45;
    public override int EndRound => -1;

	public override int BloonRbe => 1252;
	public override bool MoabClass => true;
}
public class MiniMoabBloon : RogueBloon {
    public override string BaseBloonId => "XStablesMod-MiniMoab";
    public override int StartRound => 40;
    public override int EndRound => -1;

	public override int BloonRbe => 491;
	public override bool MoabClass => true;
}
public class BrickCasle : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-BrickCastle";
    public override int StartRound => 45;
    public override int EndRound => -1;

    public override int BloonRbe => 1440;
    public override bool MoabClass => true;
}
public class BRC : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Brc";
    public override int StartRound => 50;
    public override int EndRound => -1;

    public override int BloonRbe => 4428;
    public override bool MoabClass => true;
}
public class HTA : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Hta";
    public override int StartRound => 57;
    public override int EndRound => -1;

    public override int BloonRbe => 628;
    public override bool MoabClass => true;
}
public class LPZ : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Lpz";
    public override int StartRound => 70;
    public override int EndRound => -1;

    public override int BloonRbe => 1840;
    public override bool MoabClass => true;
}
public class Setup : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Setup";
    public override int StartRound => 24;
    public override int EndRound => 80;

    public override int BloonRbe => 1;
}
public class Haste : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Hastening";
    public override int StartRound => 80;
    public override int EndRound => -1;

    public override int BloonRbe => 150;
}

