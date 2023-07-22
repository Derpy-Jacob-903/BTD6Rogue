﻿using System;
using System.Collections.Generic;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.Powers;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class TowerChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public static TowerChoicePanel uiPanel = null!;

    public string[] towerChoices = new string[3];
    public string[] towerPaths = new string[3];
    public int[] towerAmounts = new int[3];

    public TowerChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string towerName) {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        int tower = Array.IndexOf(towerChoices, towerName);
        string towerStr = Game.instance.model.GetTowerWithName(towerName).baseId;
        towerInventory.towerMaxes[towerStr] += towerAmounts[tower];

        if (towerPaths[tower] == "top") {
            BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[0] = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].top = true;
        } else if (towerPaths[tower] == "mid") {
            BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[1] = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].mid = true;
        } else if (towerPaths[tower] == "bot") {
            BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[2] = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].bot = true;
        }

        __instance.bridge.OnTowerInventoryChangedSim(true);
        __instance.bridge.SetAutoPlay(true);
        BTD6Rogue.mod.uiOpen = false;
        uiPanel = null!;
        Destroy(gameObject);
    }

    public static TowerChoicePanel Create(RectTransform menu, InGame __instance) {
        BTD6Rogue.mod.uiOpen = true;
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2400, 1000), VanillaSprites.BrownInsertPanel);
        TowerChoicePanel towerChoicePanel = panel.AddComponent<TowerChoicePanel>();
        towerChoicePanel.__instance = __instance;
        uiPanel = towerChoicePanel!;

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        TowerModel[] towerModels = TowerUtil.GetThreeTowers(TowerUtil.GetMaxPath(__instance.currentRoundId + 1), TowerUtil.waterMaps.Contains(__instance.GetMap().mapModel.mapName));

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < towerModels.Length; i++) {
            TowerModel tower = towerModels[i];
            towerChoicePanel.towerChoices[i] = tower.GetTowerId();
            if (tower.GetUpgradeLevel(0) >= 1) { towerChoicePanel.towerPaths[i] = "top"; BTD6Rogue.mod.rogueTowers[tower.baseId].lockedPaths[0] = true; }
            if (tower.GetUpgradeLevel(1) >= 1) { towerChoicePanel.towerPaths[i] = "mid"; BTD6Rogue.mod.rogueTowers[tower.baseId].lockedPaths[1] = true; }
            if (tower.GetUpgradeLevel(2) >= 1) { towerChoicePanel.towerPaths[i] = "bot"; BTD6Rogue.mod.rogueTowers[tower.baseId].lockedPaths[2] = true; }
            towerChoicePanel.towerAmounts[i] = TowerUtil.GetTowerCount(tower);

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -100, 650), VanillaSprites.GreenBtn, new Action(() => towerChoicePanel.ChooseTower(tower.GetTowerId())));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
            ModHelperText towerName = towerButton.AddText(new Info("Tower Name", 0, -225, 650, 76), tower.name, 64);
            ModHelperText amountText = towerButton.AddText(new Info("Tower Amount", 225, 225, 500, 500), towerChoicePanel.towerAmounts[i].ToString(), 110);
            towerName.Text.enableAutoSizing = true;
        }
        ModHelperText chooseText = inset.AddText(new Info("Tower Amount", 0, 400, 2000, 100), "Choose a Path", 86);
        ModHelperText infoText = inset.AddText(new Info("Tower Amount", 0, 300, 2000, 100), "None of these paths will show up again, choose wisely", 56);

        return towerChoicePanel;
    }
}