using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class OPrismaticShardModifier : RogueModifier {
	public override string DisplayName => "Prismatic\nShard";
	public override string Description => "Tower and Hero Choices are replaced by Prismatic Choices, which include both Monkeys and Heroes"; //"Gain one less Monkey from Tower and Paragon Choices"
    public override string Image => GetSpriteReference("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {}

	public override void RemoveRogueModifier(ModModel model) {}
}
