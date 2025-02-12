namespace BTD6Rogue;

public class CeramicBloon : RogueBloon {
    public override string BaseBloonId => "Ceramic";
    public override int StartRound => 39;
    public override int EndRound => -1;

	public override int BloonRbe => 104;

	public override bool Camo => true;
    public override int CamoStartRound => 62;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 47;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 56;
    public override int FortifiedEndRound => -1;
}

public class Brick : RogueBloon
{
    public override string BaseBloonId => "Ceramic";
    public override int StartRound => 44;
    public override int EndRound => -1;

    public override int BloonRbe => 104;

    public override bool Camo => true;
    public override int CamoStartRound => 67;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 52;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 61;
    public override int FortifiedEndRound => -1;
}
public class Magma : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Magma";
    public override int StartRound => 79;
    public override int EndRound => -1;

    public override int BloonRbe => 210;

    public override bool Camo => true;
    public override int CamoStartRound => 102;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 87;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 96;
    public override int FortifiedEndRound => -1;
}

public class ClassicRainbow : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-ClassicRainbow";
    public override int StartRound => 12;
    public override int EndRound => 85;

    public override int BloonRbe => 37;
}

public class ClassicCeramic : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-ClassicCeramic";
    public override int StartRound => 39;
    public override int EndRound => -1;

    public override int BloonRbe => 84;
}

public class Olive : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-Olive";
    public override int StartRound => 24;
    public override int EndRound => 62;
    public override int BloonRbe => 11;
}

public class Glass : RogueBloon
{
    public override string BaseBloonId => "ClassicRounds-Glass";
    public override int StartRound => 28;
    public override int EndRound => -1;

    public override int BloonRbe => 23;

    public override bool Camo => true;
    public override int CamoStartRound => 57;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 46;
    public override int RegrowEndRound => -1;
}