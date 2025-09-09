
namespace BTD6Rogue;

public class GainPrismaticEncounter : RogueEncounter {
	public override bool CanStartEncounter() {
		return true;
	}

	public override void StartEncounter() {
		BTD6Rogue.rogueGame.panelManager.AppendPanel("PrismChoicePanel", this, true);
	}

	public override void EncounterPanelCreated() { }

	public override void ProcessChoice(EncounterChoice choice) {
		if (choice is TowerChoice) {
            TowerChoice towerChoice = (TowerChoice)choice;
            TowerData towerData = TowerUtil.CreateDataFromChoice(towerChoice);
            BTD6Rogue.rogueGame.towerManager.AddTowerToInventory(towerData);
            EndEncounter();
        }
        else if (choice is HeroChoice)
        {
            HeroChoice heroChoice = (HeroChoice)choice;
            HeroData heroData = HeroUtil.CreateDataFromChoice(heroChoice);
            BTD6Rogue.rogueGame.towerManager.AddHeroToInventory(heroData);
            EndEncounter();
        }
        else
        {
            BTD6Rogue.LogMessage("EncounterChoice instance passed to ProcessChoice from EncounterPanel isn't an instance of TowerChoice or HeroChoice.", this.Name, ErrorLevels.Error);
            return;
        }
	}

	public override void EncounterPanelDestroyed() { }
}
