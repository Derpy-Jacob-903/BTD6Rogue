using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OAZFrontierModifier : RogueModifier {
	public override string DisplayName => "Frontier Bloons";
	public override string Description => "Allows Frontier Legends exclusive Bloons to spawn.\nNote: Diamondback may spawn Diamond Bloons regardless of this option.";
    public override string Image => GetSpriteReference("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
