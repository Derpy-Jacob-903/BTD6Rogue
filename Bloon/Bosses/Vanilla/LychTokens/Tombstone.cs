using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;

namespace BTD6Rogue;

public class TombstoneBloon : RogueBoss {
	public override string BossName => "Tombstone";
	public override bool IsBoss => false;

	public static readonly float baseMaxHealth = 500;
	public static readonly float levelHealthModifier = 2;

	
	public static readonly List<string> firstSpawnBloons = new List<string>() {
		BloonType.Undead,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic,
		BloonType.Moab,
		BloonType.Bfb
	};
	public static readonly List<string> secondSpawnBloons = new List<string>() {
		BloonType.Yellow,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic,
		BloonType.Moab,
		BloonType.Bfb
	};
	public static readonly List<string> thirdSpawnBloons = new List<string>() {
		BloonType.Yellow,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic,
		BloonType.Moab,
		BloonType.Bfb
	};

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (TimeTrigger behavior in bloon.GetBloonBehaviors<TimeTrigger>()) {
			TimeTriggerModel model = behavior.timeTriggerModel;
			model.interval = (baseTimeInterval + levelTimeIntervalAddition * tier);
		}

		foreach (DrainLivesAction behavior in bloon.GetBloonBehaviors<DrainLivesAction>()) {
			DrainLivesActionModel model = behavior.drainLivesActionModel;
			model.livesDrained = Mathf.FloorToInt((baseDrainLives + levelDrainLives * tier));
		}
	}
}
