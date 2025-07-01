using Il2CppAssets.Scripts.Unity;
using System;

namespace BTD6Rogue
{
    public static class BloonValidation
    {
        [Obsolete("Moved to BloonUtil.")]
        public static void ValidateRogueBloon(RogueBloon bloon)
        {
            BloonUtil.ValidateRogueBloon(bloon);
        }

        [Obsolete ("BloonUtil.GetAllBloons() now validates each RogueBloon.")]
        public static void ValidateAllRogueBloons()
        {
            BloonUtil.GetAllBloons();
            /*foreach (var rogueBloon in BloonUtil.GetAllBloons())
            {
                ValidateRogueBloon(rogueBloon);
            }*/
        }
    }
}
