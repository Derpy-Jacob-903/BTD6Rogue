using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OForceCamoModifier : RogueModifier {
	public override string DisplayName => "All Camo";
	public override string Description => ""; //
    public override string Image => VanillaSprites.CamoBloonIcon;

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
