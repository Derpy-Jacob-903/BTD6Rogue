using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using Il2CppNinjaKiwi.LiNK.Client.DotNetZip.Zlib;
using NAudio.Codecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using static Il2CppSystem.Runtime.Remoting.RemotingServices;
using static MelonLoader.MelonLogger;
using Random = System.Random;

namespace BTD6Rogue;

public class RoundManager(InGame game) {
	private InGame game = game;

	public List<string> bossBag = new List<string>();
	public string nextBoss = "";

	public bool activeBoss = false;

	public int randMincrease = 400;
	public int minIncrease = 600;

	private int previousSpawn = 0;

	public void BossSpawned() {
		activeBoss = true;
		previousSpawn = 5000; // MS until start spawning cashless bloons
		Thread t = new Thread(new ThreadStart(TrySpawnCashlessBloons));
		t.Start();
	}

	public void TrySpawnCashlessBloons() {
		int round = game.bridge.GetCurrentRound();
		while (activeBoss) {
			Thread.Sleep(previousSpawn);
			if (!activeBoss) { break; } // check if active boss got changed during Thread.Sleep
			if (game == null || game.bridge == null) { break; }
			if (round != game.bridge.GetCurrentRound()) { break; }
			if (BTD6Rogue.rogueGame == null) { break; }
			int groupRbe = GetRoundRbe(round) / 15;
			RogueDifficulty difficulty = BTD6Rogue.rogueGame.difficulty;
			List<Tuple<RogueBloon, List<string>>> sendableBloons = difficulty.GetSendableRogueBloons(round + 1, groupRbe);
			if (sendableBloons.Count < 1) { continue; }
			Tuple<RogueBloon, List<string>> bloonData = sendableBloons[new Random().Next(sendableBloons.Count)];

			bool isCamo = false;
			bool isRegrow = false;
			bool isFortified = false;
			if (bloonData.Item2.Contains("Camo")) { isCamo = new Random().Next(4) == 0; }
			if (bloonData.Item2.Contains("Regrow")) { isRegrow = new Random().Next(4) == 0; }
			if (bloonData.Item2.Contains("Fortified")) { isFortified = new Random().Next(4) == 0; }

			int nextIncrease = 0 + new Random().Next(600) + 200;
			BloonGroupModel bgm = bloonData.Item1.GenerateBloonGroup(round, groupRbe, 0, nextIncrease, isCamo, isRegrow, isFortified);
			game.bridge.SpawnBloons(bgm.GetEmissions(), round, 5000);
			previousSpawn = nextIncrease * 3; // Change previous spawn timer based off the bloon group spawned just now
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

		RogueDifficulty difficulty = new MediumDifficulty();

		int bloonGroups = new Random().Next(4) + 2;
		int mincrease = 0;

		//if ((round + 1) % 20 == 0) {
			//int bossTier = Math.Min((round + 1) / 20, 5);
			//roundModel.AddBloonGroup(nextBoss + bossTier.ToString());
		//}

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

			List<Tuple<RogueBloon, List<string>>> sendableBloons = difficulty.GetSendableRogueBloons(round * 4, groupRbe);
			if (sendableBloons.Count < 1) {
				continue;
			}
			Tuple<RogueBloon, List<string>> bloonData = sendableBloons[new Random().Next(sendableBloons.Count)];

			bool isCamo = false;
			bool isRegrow = false;
			bool isFortified = false;

            if (bloonData.Item2.Contains("Camo")) { isCamo = new Random().Next(4) == 0; }
            if (bloonData.Item1.BaseBloonId == "ClassicRounds-Olive") { isCamo = true; }
            if (bloonData.Item2.Contains("Regrow")) { isRegrow = new Random().Next(4) == 0; }
			if (bloonData.Item2.Contains("Fortified")) { isFortified = new Random().Next(4) == 0; }

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
        //bool procAcrobat = round == game.lastSetRound;
		var mult = FunnyNumber(round);

        var v = (round + mult[0]/4) * (4 + mult[1]/4);
        ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Info) " + "Jimbo" + ": " + 
            (round + mult[0]) + " Chips x " + (4 + mult[1] / 4) + " Mult");
        //if (procAcrobat) { v *= 3; }
        //if (round + game.GetStartRound() % 6 == 0) { v *= 4; }
        ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Info) " + "Jimbo" + ": " +
            Math.Floor((0.16 * Math.Pow(v, 3) - 0.75 * Math.Pow(v, 2) + 15 * v) / 3 + 20) + " Round RBE");
        return (int) Math.Floor((0.16 * Math.Pow(v, 3) - 0.75 * Math.Pow(v, 2) + 15 * v) / 3 + 20);
	}

    public void JimboJumpscare()
    {
        ModContent.GetAudioClip<BTD6Rogue>("negative").Play();
    }
    public void log(string s)
    {
        ModContent.GetAudioClip<BTD6Rogue>("voice" + new Random().Next(1, 11)).Play();
        ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Info) " + "Jimbo" + ": " + s);
    }

    public int[] FunnyNumber(int round)
	{
        var v = new int[] { 0, 0 };
        var rand = new Random();
        for (int i = 1; i < round/rand.Next(5,10); i++)
        {
            var k = 1;
            var strings = Array.Empty<string>();
            switch (rand.Next(0, 25))
            {
                case 0: log("Joker");  v[1] += 4; break; // Joker
                case 1:
                    log("Misprint Joker");
                    v[1] += rand.Next(0, 23); break; // Misprint Joker
                case 2: // Greedy Joker
                    log("Greedy Joker");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Support)
						{ v[1] += 3; JimboJumpscare();
                            log("Greedy Joker Proc");
                        }
                    }
                    break;
                case 3: // Lusty Joker
                    log("Lusty Joker");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Magic)
                        { v[1] += 3; JimboJumpscare();
                            log("Lusty Joker Proc");
                        }
                    }
                    break;
                case 4: // Wrathful Joker
                    log("Wrathful Joker");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Primary)
                        { v[1] += 3; JimboJumpscare();
                            log("Wrathful Joker Proc");
                        }
                    }
                    break;
                case 5: // Gluttonous Joker
                    log("Gluttonous Joker");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military)
                        { v[1] += 3; JimboJumpscare();
                            log("Gluttonous Joker Proc");
                        }
                    }
                    break;
                case 6: //Jolly Joker
                    log("Jolly Joker");
                    var rankGroups6 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                        if (rankGroups6.Any(group => group.Count() >= 2 && group.Count() <= 4)) { v[1] += 8; JimboJumpscare();
                        log("Jolly Joker Proc");
                    }
                    break;
                case 7: //Zany Joker
                    log("Zany Joker");
                    var rankGroups7 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                        if (rankGroups7.Any(group => group.Count() >= 3 && group.Count() <= 6)) { v[1] += 12; JimboJumpscare();
                        log("Zany Joker Proc");
                    }
                    break;
                case 8: //Mad Joker
                    log("Mad Joker Proc");
                    var rankGroups8 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                        var pairsCount8 = rankGroups8.Count(group => group.Count() >= 2 && group.Count() <= 4);
                        if (pairsCount8 >= 2) { v[1] += 10; JimboJumpscare();
                        log("Mad Joker Proc");
                    }
                    break;
                case 9: //Crazy Joker
                    log("Crazy Joker");
                    var rankGroups9 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                        if (rankGroups9.Count() >= 5) { v[1] += 12; JimboJumpscare();
                        log("Crazy Joker Proc");
                    }
                    break;
                case 10: //Droll Joker
                    log("Droll Joker");
                    var rankGroups10 = game.GetTowers().GroupBy(card => card.towerModel.towerSet);
                        if (rankGroups10.Any(group => group.Count() >= 5)) { v[1] += 10; JimboJumpscare();
                        log("Droll Joker Proc");
                    }
                    break;
                case 11: //Sly Joker
                    log("Sly Joker ");
                    var rankGroups11 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                    if (rankGroups11.Any(group => group.Count() >= 2 && group.Count() <= 4)) { v[0] += 5; JimboJumpscare();
                        log("Sly Joker Proc");
                    }
                    break;
                case 12: //Wily Joker
                    log("Wily Joker");
                    var rankGroups12 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                    if (rankGroups12.Any(group => group.Count() >= 3 && group.Count() <= 6)) { v[0] += 10; JimboJumpscare();
                        log("Wily Joker Proc");
                    }
                    break;
                case 13: //Clever Joker
                    log("Clever Joker");
                    var rankGroups13 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                    var pairsCount13 = rankGroups13.Count(group => group.Count() >= 2 && group.Count() <= 4);
                    if (pairsCount13 >= 2) { v[0] += 8; JimboJumpscare();
                        log("Clever Joker Proc");
                    }
                    break;
                case 14: //Devious Joker
                    log("Devious Joker");
                    var rankGroups14 = game.GetTowers().GroupBy(card => card.towerModel.baseId);
                    if (rankGroups14.Count() >= 5) { v[0] += 10; JimboJumpscare();
                        log("Devious Joker Proc");
                    }
                    break;
                case 15: //Crafty Joker
                    log("Crafty Joker");
                    var rankGroups15 = game.GetTowers().GroupBy(card => card.towerModel.towerSet);
                    if (rankGroups15.Any(group => group.Count() >= 5)) { v[0] += 8; JimboJumpscare();
                        log("Crafty Joker Proc");
                    }
                    break;
                case 16: //Half Joker
                    log("Half Joker");
                    var rankGroups16 = game.GetTowers();
                    if (rankGroups16.Count <= 6) { v[1] += 20; JimboJumpscare();
                        log("Half Joker Proc");
                    }
                    break;
                case 17: //Odd Todd
                    log("Odd Todd");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.tiers.Sum() % 2 == 1)
                        { v[0] += 3; JimboJumpscare();
                            log("Odd Todd Proc");
                        }
                    }
                    break;
                case 18: //Even Steven
                    log("Even Steven");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.tiers.Sum() % 2 == 0)
                        { v[1] += 4; JimboJumpscare();
                            log("Even Steven Proc");
                        }
                    }
                    break;
                case 19: //Scholar
                    log("Scholar");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.tier == 5)
                        { v[0] += 2; v[1] += 4; JimboJumpscare();
                            log("Scholar Proc");
                        }
                    }
                    break;
                case 20: //Gros Michel/Cavendish
                    var i19 = rand.Next(1, 6);
					if (i19 != 1) { v[1] += 15;
                        log("Gros Michel");
                    }
					else { v[1] *= 3; JimboJumpscare();
                        log("Cavendish");
                    }
                    break;
                case 21: //Photograph
                    log("Photograph");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)
                        { 
							v[1] *= 2; JimboJumpscare();
                            log("Photograph Proc");
                            break;
                        }
                    }
                    break;
                case 22: //Blackboard
                    log("Blackboard");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.towerSet == (TowerSet.Magic | TowerSet.Support))
                        {
                            log("Blackboard Skiped");
                            break; 
                        }
                    }
                    log("Blackboard Proc");
                    v[1] *= 3; JimboJumpscare();
                    break;
                case 23: //Walkie Talkie
                    log("Walkie Talkie");
                    foreach (var j in game.GetTowers())
                    {
                        if (j.towerModel.tier == 4)
                        { v[0] += 1; v[1] += 4; JimboJumpscare();
                            log("Walkie Talkie Proc");
                        }
                    }
                    break;
                case 24: //Green Joker
                    log("Green Joker");
                    v[1] += game.GetTowers().Count;
                    break;
                case 25: //Blue Joker
                    log("Blue Joker");
                    int tv = 0;
                    foreach (var j in game.GetTowers())
                    {
                        tv += (j.towerModel.tiers.Sum() - j.towerModel.tiers.Sum() % 10) / 10;
                    }
                    v[0] += (int)tv;
                    break;
            }
        }
        return v;
    }
}
