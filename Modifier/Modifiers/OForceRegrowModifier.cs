using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OForceRegrowModifier : RogueModifier {
	public override string DisplayName => "All Regrow";
	public override string Description => "";
    public override string Image => VanillaSprites.RegrowBloonIcon;

    public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
