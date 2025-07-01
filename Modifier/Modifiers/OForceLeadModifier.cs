using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OForceLeadModifier : RogueModifier {
	public override string DisplayName => "All Lead";
	public override string Description => ""; //
    public override string Image => VanillaSprites.LeadBloonIcon;

    public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
