using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class ODraftModifier : RogueModifier {
	public override string DisplayName => "Draft";
	public override string Description => "Starting Hero and Tower Selects are replaced with Choices"; //"Starting Hero and Tower Selects are replaced with Choices"
    public override string Image => GetSpriteReference("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
