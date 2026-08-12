using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using System;

namespace BTD6Rogue;

public class RogueModSettings : ModSettings {

    public static readonly ModSettingCategory LoggingSettings = new("Logging Settings");

    public static readonly ModSettingBool LogInfoMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogWarningMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogErrorMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogCriticalMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogDebugMessages = new(false) { category = LoggingSettings };


    private static readonly ModSettingButton BloonValidationButton = new()
    {
        displayName = "Validate All RogueBloons",
        description =
            "Validates each RogueBloon to ensure it references existing Bloons in the GameModel. Logs warnings if invalid references are found. This is unnecessary if no new RogueBloons are being added by external mods.",
        action = () =>
        {
            BloonUtil.GetAllBloons();
            PopupScreen.instance.SafelyQueue(screen =>
            screen.ShowOkPopup($"Finished validating RogueBloons. Check the logs for details."));
        },
        buttonText = "Validate",
        category = "Modding"
    };

    public static readonly ModSettingCategory PowerSettings = new("Powers") { collapsed = !ModHelper.HasMod("Powers-In-Shop") };
    public enum AllowPowersEnum { None, Standard, Unlimited }

    public static readonly ModSettingEnum<AllowPowersEnum> AllowPowersInShop = new(AllowPowersEnum.None)
    {
        category = PowerSettings,
        description =
            "Requires Powers In Shop\nSets if Powers are removed from the shop in BTD Rogue modes.\nNone: No Powers appear in the shop.\nStandard: Start with Unlimited Banana Farmers and Tech Bots.\nUnlimited: Start with Unlimited copies of every Power.\nThe \"No Powers\" modifier takes precedent over this option."
    }; //" If the AllowProPowersAsMonkeys setting is on, it prevents this oppton from applying to Powers Pro." };
    //public static readonly ModSettingBool AllowBattleCatInMonkeyChoices = new(false) { category = "Powers" };
    //public static readonly ModSettingBool AllowProPowersAsMonkeys = new(false) { category = "Powers", description = "Requires Powers In Shop\nPowers Pro can appear as Monkeys in Tower Choices/Selections.\nPowers Pro start with all upgrades locked, with their tier 1/2/3 upgrades being available alongside Monkeys' tier 3/4/5 upgrades. \n**You have to unlock Powers Pro and their upgrades normally to be able to buy them from the shop!**\nThe \"No Powers\" modifier takes precedent over this option." }; 
}
