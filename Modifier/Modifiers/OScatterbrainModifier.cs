using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OScatterbrainModifier : RogueModifier {
	public override string DisplayName => "Scatterbrain";
	public override string Description => "Gain one less Monkey from Tower and Paragon Choices"; //"Gain one less Monkey from Tower and Paragon Choices"
    public override string Image => GetSpriteReference("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
