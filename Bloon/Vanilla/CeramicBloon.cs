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
    public override string BaseBloonId => "XStablesMod-Brick";
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
    public override int StartRound => 80;
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
public class Frost : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Frost";
    public override int StartRound => 80;
    public override int EndRound => -1;

    public override int BloonRbe => 210;

    public override bool Camo => true;
    public override int CamoStartRound => 100;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 90;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 100;
    public override int FortifiedEndRound => -1;
}

public class Glade : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Glade";
    public override int StartRound => 60;
    public override int EndRound => -1;

    public override int BloonRbe => 70;

    public override bool Camo => true;
    public override int CamoStartRound => 85;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 78;
    public override int RegrowEndRound => -1;
}
public class Elemental : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Elemental";
    public override int StartRound => 100;
    public override int EndRound => -1;

    public override int BloonRbe => 520;
	
    public override bool Fortified => true;
    public override int FortifiedStartRound => 120;
    public override int FortifiedEndRound => -1;
    public override bool MoabClass => true;
}

public class Space : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-Space";
    public override int StartRound => 120;
    public override int EndRound => -1;

    public override int BloonRbe => 1290;
	
    public override bool Fortified => true;
    public override int FortifiedStartRound => 140;
    public override int FortifiedEndRound => -1;
    public override bool MoabClass => true;
}
public class GigaCastle : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-GigaCastle";
    public override int StartRound => 120;
    public override int EndRound => -1;

    public override int BloonRbe => 3970;
    public override bool MoabClass => true;
}
public class SpaceCastle : RogueBloon
{
    public override string BaseBloonId => "XStablesMod-SpaceCastle";
    public override int StartRound => 140;
    public override int EndRound => -1;

    public override int BloonRbe => 8450;
    public override bool MoabClass => true;
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