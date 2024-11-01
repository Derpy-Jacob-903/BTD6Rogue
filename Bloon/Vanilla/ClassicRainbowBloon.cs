namespace BTD6Rogue;

public class ClassicRainbowBloon : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-ClassicRainbow";
    public override int StartRound => 18;
    public override int EndRound => 149;

    public override int BloonRbe => 37;
}

public class EarlyClassicRainbowBloon : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-ClassicRainbow";
    public override int StartRound => 12;
    public override int EndRound => 12;

    public override int BloonRbe => 37;
}
