

namespace BTD6Rogue;

public class GameStartEncounter : RogueEncounter {
	public override bool CanStartEncounter() {
		return true;
	}

	public override void StartEncounter() {
		if (ModifierUtil.HasModifier<ODraftModifier>()) {
            /*if (ModifierUtil.HasModifier<OPrismaticShardModifier>())
            {
                if (!BTD6Rogue.rogueGame.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)) { BTD6Rogue.rogueGame.panelManager.AppendPanel("PrismaticChoicePanel", this); }
                BTD6Rogue.rogueGame.panelManager.AppendPanel("PrismaticChoicePanel", this);
                BTD6Rogue.rogueGame.panelManager.AppendPanel("PrismaticChoicePanel", this);
                BTD6Rogue.rogueGame.panelManager.AppendPanel("PrismaticChoicePanel", this);
                return;
            }
			else*/
            { 
                if (!BTD6Rogue.rogueGame.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)) { BTD6Rogue.rogueGame.panelManager.AppendPanel("HeroChoicePanel", this); }
                BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", this);
                BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", this);
                BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", this, true);
                return;
            }
        }
		else {
            if (!BTD6Rogue.rogueGame.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)) { BTD6Rogue.rogueGame.panelManager.AppendPanel("HeroSelectPanel", this); }
            BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerSelectPanel", this);
            if (!ModifierUtil.HasModifier<OScatterbrainModifier>()) { BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerSelectPanel", this); }
            BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerSelectPanel", this, true);
        }
	}

	public override void EncounterPanelCreated() {}

	public override void ProcessChoice(EncounterChoice choice) {
		if (!(choice is TowerChoice) && !(choice is HeroChoice)) {
			BTD6Rogue.LogMessage("EncounterChoice instance passed to ProcessChoice from EncounterPanel isn't an instance of TowerChoice or HeroChoice", this.Name, ErrorLevels.Error);
			return;
		}

		if (choice is HeroChoice) {
			HeroChoice heroChoice = (HeroChoice) choice;
			HeroData heroData = HeroUtil.CreateDataFromChoice(heroChoice);
			BTD6Rogue.rogueGame.towerManager.AddHeroToInventory(heroData);
		} else if (choice is TowerChoice) {
			TowerChoice towerChoice = (TowerChoice) choice;
			TowerData towerData = TowerUtil.CreateDataFromChoice(towerChoice);
			BTD6Rogue.rogueGame.towerManager.AddTowerToInventory(towerData);
		}

		if (BTD6Rogue.rogueGame.panelManager.panelQueue.Count < 1) { EndEncounter(); }
	}

	public override void EncounterPanelDestroyed() { }
}
