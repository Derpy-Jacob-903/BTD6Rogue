namespace BTD6Rogue;

public class BrickBloon : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Brick";
    public override int StartRound => 37;
    public override int EndRound => -1;

    public override int BloonRbe => 238;

    public override bool Fortified => true;
    public override int FortifiedStartRound => 52;
    public override int FortifiedEndRound => -1;
}
