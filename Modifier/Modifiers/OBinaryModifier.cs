using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OBinaryModifier : RogueModifier {
	public override string DisplayName => "Binary";
	public override string Description => "Choices only have 2 options. Start with only 2 Monkeys."; //"Choices only have 2 options. Start with only 2 Monkeys"
    public override string Image => GetSpriteReference("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
