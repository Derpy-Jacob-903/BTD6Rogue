using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using MelonLoader;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class PrismChoicePanel : RoguePanel {
	public void ChooseTower(TowerChoice towerChoice) {
		if (!active) { return; }
		active = false;
		encounter.ProcessChoice(towerChoice);
		DestroyPanel();
    }
    public void ChooseHero(HeroChoice heroChoice)
    {
        if (!active) { return; }
        active = false;
        encounter.ProcessChoice(heroChoice);
        DestroyPanel();
    }
    public void ChooseNull()
    {
        if (!active) { return; }
        active = false;
        DestroyPanel();
    }

    public void RerollTowers(EncounterChoice[] prismChoices, bool useReroll = true) {
		if (!active) { return; }
		active = false;

		foreach (EncounterChoice towerChoice in prismChoices) {
            if (towerChoice is TowerChoice)
            {
                TowerChoice tc = (TowerChoice)towerChoice;
                BTD6Rogue.rogueGame.towerManager.UnlockTowerPath(tc.towerId, Array.IndexOf(tc.towerPaths, tc.towerPaths.Max()));
            }
            else if (towerChoice is HeroChoice)
            {
                TowerChoice hc = (TowerChoice)towerChoice;
                BTD6Rogue.rogueGame.towerManager.UnlockHero(hc.towerId);
            }
		}
		if (useReroll) { BTD6Rogue.rogueGame.rerolls--; }
	    BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", encounter);
		DestroyPanel();
	}

	public override void CreatePanel() {
		ModHelperPanel borderPanel = parent.AddPanel(new Info("Border Panel") { AnchorMin = new(0.225f, 0.25f), AnchorMax = new Vector2(0.775f, 0.75f) }, VanillaSprites.BrownInsertPanelDark);
		ModHelperPanel towerSelectPanel = borderPanel.AddPanel(new Info("Tower Select Panel", InfoPreset.FillParent), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 40);

		ModHelperText chooseText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "Choose a Path", 86);
		ModHelperText infoText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "None of these paths will show up again, choose wisely", 52);
		ModHelperPanel towerRow = towerSelectPanel.AddPanel(new Info("MapRow", InfoPreset.Flex) { FlexHeight = 4 }, null, RectTransform.Axis.Horizontal, 50);

        EncounterChoice[] towerChoices = TowerUtil.CreateValidTowerChoices(BTD6Rogue.rogueGame);
        EncounterChoice[] heroChoices = HeroUtil.CreateValidHeroChoices(BTD6Rogue.rogueGame);
        if (heroChoices == null) { BTD6Rogue.rogueGame.towerManager.UnlockAllHeroes(); heroChoices = HeroUtil.CreateValidHeroChoices(BTD6Rogue.rogueGame); }
        if (towerChoices == null) { BTD6Rogue.rogueGame.towerManager.UnlockAllTowers(); towerChoices = TowerUtil.CreateValidTowerChoices(BTD6Rogue.rogueGame); }
        EncounterChoice[] prismChoices = towerChoices;
        prismChoices.AddRangeToArray(heroChoices);
        if (ModifierUtil.HasModifier<OBinaryModifier>()) { var binaryChoices = towerChoices.ToList(); binaryChoices.Remove(binaryChoices.Last()); towerChoices = binaryChoices.ToArray(); }

        for (int i = 0; i < prismChoices.Length; i++) {
			if (prismChoices[i] is TowerChoice)
            {
                TowerChoice towerChoice = (TowerChoice)prismChoices[i];
                if (towerChoice.towerModel is null)
                { BTD6Rogue.rogueGame.towerManager.LockTowerPath(towerChoice.towerId, 0); BTD6Rogue.rogueGame.towerManager.LockTowerPath(towerChoice.towerId, 1); BTD6Rogue.rogueGame.towerManager.LockTowerPath(towerChoice.towerId, 2); i--; continue; }
                BTD6Rogue.rogueGame.towerManager.LockTowerPath(towerChoice.towerId, Array.IndexOf(towerChoice.towerPaths, towerChoice.towerPaths.Max()));

                string buttonSprite = ModContent.GetTextureGUID<BTD6Rogue>("TowerContainerNeutral");
                string towerSet = towerChoice.towerModel.GetTowerSet();
                if (towerSet == "Hero")
                {
                    buttonSprite = VanillaSprites.TowerContainerHero;
                }
                /*else if (towerSet == "Items" || towerSet == "PowersInShop-Powers" || towerSet == "SpecialAgents-SpecialAgentSet") {
                    buttonSprite = ModContent.GetTextureGUID<BTD6Rogue>("TowerContainerPower");
                }*/
                else if (towerSet == "Primary")
                {
                    buttonSprite = VanillaSprites.TowerContainerPrimary;
                }
                else if (towerSet == "Military")
                {
                    buttonSprite = VanillaSprites.TowerContainerMilitary;
                }
                else if (towerSet == "Magic")
                {
                    buttonSprite = VanillaSprites.TowerContainerMagic;
                }
                else if (towerSet == "Support")
                {
                    buttonSprite = VanillaSprites.TowerContainerSupport;
                }

                ModHelperButton button = towerRow.AddButton(new Info("Tower Button", InfoPreset.Flex), buttonSprite, new Action(() => ChooseTower(towerChoice)));

                AspectRatioFitter arf = button.gameObject.AddComponent<AspectRatioFitter>();
                arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

                ModHelperImage towerImage = button.AddImage(new Info("Image", InfoPreset.FillParent), towerChoice.towerImage.GetGUID());

                ModHelperText towerBaseName = towerImage.AddText(new Info("Tower Base Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerId, 72, Il2CppTMPro.TextAlignmentOptions.Bottom);
                ModHelperText towerUpgradeName = towerImage.AddText(new Info("Tower Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerName, 72, Il2CppTMPro.TextAlignmentOptions.Top);
                ModHelperText towerAmount = towerImage.AddText(new Info("Tower Amount", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerAmount.ToString(), 96, Il2CppTMPro.TextAlignmentOptions.TopRight);
            }
            else if (prismChoices[i] is HeroChoice)
            {
                HeroChoice heroChoice = (HeroChoice)heroChoices[i];
                BTD6Rogue.rogueGame.towerManager.LockHero(heroChoice.towerId);

                ModHelperButton button = towerRow.AddButton(new Info("Tower Button", InfoPreset.Flex), heroChoice.towerModel.towerSet == TowerSet.Hero ? VanillaSprites.TowerContainerHero : ModContent.GetTextureGUID<BTD6Rogue>("TowerContainerNeutral"), new Action(() => ChooseHero(heroChoice)));

                AspectRatioFitter arf = button.gameObject.AddComponent<AspectRatioFitter>();
                arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;


                ModHelperImage towerImage = button.AddImage(new Info("Image", InfoPreset.FillParent), heroChoice.towerImage.GetGUID());
                //GUID may not correspond to a image, if so it will display a white square


                ModHelperText towerUpgradeName = towerImage.AddText(new Info("Tower Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, heroChoice.towerId, 72, Il2CppTMPro.TextAlignmentOptions.Bottom);
            }
            else
            {
                string buttonSprite = ModContent.GetTextureGUID<BTD6Rogue>("TowerContainerNeutral");
                ModHelperButton button = towerRow.AddButton(new Info("Tower Button", InfoPreset.Flex), buttonSprite, new Action(() => ChooseNull()));
            }
		}

		if (BTD6Rogue.rogueGame.rerolls > 0) {
			ModHelperButton rerollButton = towerSelectPanel.AddButton(new Info("Reroll Button", InfoPreset.Flex) {}, VanillaSprites.BlueBtnLong, new Action(() => RerollTowers(towerChoices)));
			AspectRatioFitter arf = rerollButton.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
			arf.aspectRatio = 3;
			ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", InfoPreset.FillParent), "Reroll: " + BTD6Rogue.rogueGame.rerolls, 64);
		}

		active = true;
	}
    public static string GetFallbackPortrait(TowerModel tower)
    {
        if (tower.IsHero()) {
            return ModContent.GetTextureGUID<BTD6Rogue>("UnknownHeroPortrait");
        }
        if (tower.isParagon) {
            return ModContent.GetTextureGUID<BTD6Rogue>("UnknownParagonPortrait");
        }
        if (tower.isSubTower || tower.isGeraldoItem) {
            return ModContent.GetTextureGUID<BTD6Rogue>("UnknownSubTowerPortrait");
        } 
		if (tower.GetTowerSet() == "Items" || tower.GetTowerSet() == "PowersInShop-Powers" || tower.GetTowerSet() == "SpecialAgents-SpecialAgentSet") {
            return ModContent.GetTextureGUID<BTD6Rogue>("UnknownPowerPortrait");
        }
        return ModContent.GetTextureGUID<BTD6Rogue>("UnknownTowerPortrait");
    }
}
