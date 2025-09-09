using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BTD6Rogue;

public class RoundManager(InGame game) {
	private InGame game = game;

	public List<string> bossBag = new List<string>();
	public string nextBoss = "";

	public bool activeBoss = false;
    public Thread? cashlessThread = null;
    public bool? isCashless = null;

    public int randMincrease = 400;
	public int minIncrease = 600;

	private int previousSpawn = 0;

	public void BossSpawned() {
		activeBoss = true;
		previousSpawn = 5000; // MS until start spawning cashless bloons
        cashlessThread = new Thread(new ThreadStart(TrySpawnCashlessBloons));
        cashlessThread.Start();
    }

	[Obsolete("This doesn't help/work.")]
    public void KillCashlessBloonsThread()
    {
		if (BTD6Rogue.rogueGame == null) { return; }
        if (BTD6Rogue.rogueGame.roundManager == null) { return; }
        Thread? thread = BTD6Rogue.rogueGame.roundManager.cashlessThread;
        if (thread != null && thread.IsAlive)
        {
            BTD6Rogue.rogueGame.roundManager.activeBoss = false;
			if (!thread.Join(5000)) { BTD6Rogue.LogMessage("cashlessThread did not shut down in time. It may cause a crash next time a boss spawns.", "RoundManager.KillCashlessBloonsThread", ErrorLevels.Critical); }
        }
        //BTD6Rogue.rogueGame.roundManager.cashlessThread = null;
    }

    public void TrySpawnCashlessBloons() {
		while (activeBoss)
        {
            //game = InGame.instance;
            Thread.Sleep(previousSpawn);
            ///I FUCKING HATE THIS BUG HHHH
            //if (!IsBridgeSafe()) { break; } //this just causes more proplums
            //if (!IsBridgeSafe()) { game = InGame.instance; } //this just causes more proplums
            /*if (!IsBridgeSafe()) //TODO: dispose of RoundManager when we restart the run 
            {
                BTD6Rogue.LogMessage("TrySpawnCashlessBloons Thread is using a stale InGame instance. It WILL cause a crash next time a boss spawns.", "RoundManager.TrySpawnCashlessBloons", ErrorLevels.Critical);
                throw new AccessViolationException("TrySpawnCashlessBloons Thread is using a stale InGame instance. It WILL cause a FATAL AccessViolationException next time a boss spawns.");
                //break;
            }*/
            if (!activeBoss) { break; } // check if active boss got changed during Thread.Sleep
            if (game == null || game.bridge == null) { break; }
            if (BTD6Rogue.rogueGame == null) { break; }
            int round = game.bridge.GetCurrentRound();
            int groupRbe = GetRoundRbe(round) / 15;
			RogueDifficulty difficulty = BTD6Rogue.rogueGame.difficulty;
			List<Tuple<RogueBloon, List<string>>> sendableBloons = difficulty.GetSendableRogueBloons(round + 1, groupRbe);
			if (sendableBloons.Count < 1) { continue; }
			Tuple<RogueBloon, List<string>> bloonData = sendableBloons[new Random().Next(sendableBloons.Count)];

			bool isCamo = false;
			bool isRegrow = false;
			bool isFortified = false;
			if (bloonData.Item2.Contains("Camo")) { isCamo = new Random().Next(4) == 0 || bloonData.Item1.ForceCamo || ModifierUtil.HasModifier<OForceCamoModifier>(); }
			if (bloonData.Item2.Contains("Regrow")) { isRegrow = new Random().Next(4) == 0 || bloonData.Item1.ForceRegrow || ModifierUtil.HasModifier<OForceRegrowModifier>(); }
			if (bloonData.Item2.Contains("Fortified")) { isFortified = new Random().Next(4) == 0 || bloonData.Item1.ForceFortified /*|| ModifierUtil.HasModifier<OForceFortifiedModifier>()*/; }

			int nextIncrease = 0 + new Random().Next(600) + 200;
			BloonGroupModel bgm = bloonData.Item1.GenerateBloonGroup(round, groupRbe, 0, nextIncrease, isCamo, isRegrow, isFortified);
			game.bridge.SpawnBloons(bgm.GetEmissions(), round, 5000);
			previousSpawn = nextIncrease * 3; // Change previous spawn timer based off the bloon group spawned just now
		}
    }

    public bool IsBridgeSafe()
    {
        try
        {
            var bridge = game?.bridge;
            if (bridge == null) return false;
            int round = bridge.GetCurrentRound();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public void BossDefeated() {
		activeBoss = false;
	}

	public void GenerateBossBag() {
		foreach (RogueBoss boss in ModContent.GetContent<RogueBoss>()) {
			if (!boss.IsBoss) { continue; }
			bossBag.Add(boss.BossName);
		}
	}

	public string GenerateNextBoss() {
		string bossName = bossBag[new Random().Next(bossBag.Count)];
		bossBag.Remove(bossName);
		nextBoss = bossName;
		if (bossBag.Count < 1) { GenerateBossBag(); }
		return bossName;
	}

	public RoundModel GenerateRound(int round, bool updateRoundSet = false) {
		if (round <= 139) {
			RoundModel baseRoundModel = game.GetGameModel().roundSet.rounds[round];
			RoundModel generatedRoundModel = GenerateRoundModel(baseRoundModel, round);

			if (updateRoundSet) {
				game.GetGameModel().roundSet.rounds[round] = generatedRoundModel;
			}

			return generatedRoundModel;
		}


		RoundModel randomRoundModel = GenerateRoundModel(new RoundModel("", new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<BloonGroupModel>(1)), round);
		RoundModel newRoundModel = GenerateRoundModel(randomRoundModel, round);

		RoundSetModel rsm = game.GetGameModel().roundSet;
		rsm.rounds.AddTo(newRoundModel);
		game.GetGameModel().SetRoundSet(rsm);

		return newRoundModel;
	}

	private RoundModel GenerateRoundModel(RoundModel baseRoundModel, int round) {
		RoundModel roundModel = baseRoundModel;
		roundModel.ClearBloonGroups();

		RogueDifficulty difficulty = BTD6Rogue.rogueGame.difficulty;

		int bloonGroups = new Random().Next(4) + 2;
		int mincrease = 0;

		if ((round + 1) % 20 == 0) {
			int bossTier = Math.Min((round + 1) / 20, 5);
			roundModel.AddBloonGroup(nextBoss + bossTier.ToString());
		}

		List<BloonGroupModel> bloonGroupModels = roundModel.groups.ToList();

		int roundRbe = GetRoundRbe(round);
		int remainingRbe = roundRbe;
		int remainingGroups = bloonGroups;
		int averageGroupRbe = roundRbe / bloonGroups;

		for (int i = 0; i < bloonGroups; i++) {
			if (averageGroupRbe > remainingRbe) {
				averageGroupRbe = remainingRbe / remainingGroups;
			}

			int minRbe = (int) Math.Floor(averageGroupRbe * 0.85d);
			int maxRbe = (int) Math.Ceiling(averageGroupRbe * 1.15d);
			if (minRbe > maxRbe) {
				minRbe = maxRbe - 1;
			}
			int groupRbe = new Random().Next(minRbe, maxRbe);
			int nextIncrease = mincrease + new Random().Next(randMincrease) + 200;

			List<Tuple<RogueBloon, List<string>>> sendableBloons = difficulty.GetSendableRogueBloons(round, groupRbe);
			if (sendableBloons.Count < 1) {
				continue;
			}
			Tuple<RogueBloon, List<string>> bloonData = sendableBloons[new Random().Next(sendableBloons.Count)];

			bool isCamo = false;
			bool isRegrow = false;
			bool isFortified = false;

            if (bloonData.Item2.Contains("Camo")) { isCamo = new Random().Next(4) == 0 || bloonData.Item1.ForceCamo || ModifierUtil.HasModifier<OForceCamoModifier>(); }
            if (bloonData.Item2.Contains("Regrow")) { isRegrow = new Random().Next(4) == 0 || bloonData.Item1.ForceRegrow || ModifierUtil.HasModifier<OForceRegrowModifier>(); }
            if (bloonData.Item2.Contains("Fortified")) { isFortified = new Random().Next(4) == 0 || bloonData.Item1.ForceFortified /*|| ModifierUtil.HasModifier<OForceFortifiedModifier>()*/; }

            bloonGroupModels.Add(bloonData.Item1.GenerateBloonGroup(round, groupRbe, mincrease, nextIncrease, isCamo, isRegrow, isFortified));
			int generatedGroupAmount = bloonData.Item1.GetBloonAmount(round, groupRbe, isFortified);
			int generatedGroupRbe = bloonData.Item1.GetGroupRbe(round, generatedGroupAmount, isFortified);
			remainingRbe -= generatedGroupRbe;
			remainingGroups--;

			mincrease = nextIncrease;
		}

		roundModel.groups = bloonGroupModels.ToIl2CppReferenceArray();
		return roundModel;
	}

	public int GetRoundRbe(int round) {
		return (int) Math.Floor((0.16 * Math.Pow(round, 3) - 0.75 * Math.Pow(round, 2) + 15 * round) / 3 + 20);
	}
}
