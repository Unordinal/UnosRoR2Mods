﻿using BepInEx;
using BepInEx.Logging;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Unordinal.ItemCountDisplay
{

    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class ItemCountDisplay : BaseUnityPlugin
    {
        public const string PluginGUID = "Unordinal.ItemCountDisplay";
        public const string PluginName = "Item Count Display";
        public const string PluginVersion = "1.0.2";

        public static new ManualLogSource Logger { get; private set; }

        public void Awake()
        {
            Logger = base.Logger;
        }

        public void OnEnable()
        {
            AddHooks();
        }

        public void OnDisable()
        {
            RemoveHooks();
        }

        public void AddHooks()
        {
            On.RoR2.UI.ScoreboardStrip.SetMaster += ScoreboardStrip_SetMaster;
            On.RoR2.UI.ScoreboardStrip.UpdateMoneyText += ScoreboardStrip_UpdateMoneyText;
        }

        public void RemoveHooks()
        {
            On.RoR2.UI.ScoreboardStrip.SetMaster -= ScoreboardStrip_SetMaster;
            On.RoR2.UI.ScoreboardStrip.UpdateMoneyText -= ScoreboardStrip_UpdateMoneyText;
        }

        private void ScoreboardStrip_SetMaster(On.RoR2.UI.ScoreboardStrip.orig_SetMaster orig, ScoreboardStrip self, CharacterMaster newMaster)
        {
            orig(self, newMaster);
            self.moneyText.GetComponent<LayoutElement>().preferredWidth = 200f;
        }

        private void ScoreboardStrip_UpdateMoneyText(On.RoR2.UI.ScoreboardStrip.orig_UpdateMoneyText orig, ScoreboardStrip self)
        {
            var master = self.GetFieldValue<CharacterMaster>("master");
            if (master?.inventory is null) return;

            var tierCountMap = Utils.GetTierCounts(master.inventory);
            var tierCountMapFiltered = tierCountMap.Where(kv => kv.Value > 0);
            var itemCount = tierCountMap.Sum(kv => kv.Value);

            StringBuilder sb = new StringBuilder();
            if (itemCount > 0)
            {
                sb.Append($"<nobr><color=#FFF>{itemCount} ");
                sb.Append("[");
                foreach (var pair in tierCountMapFiltered)
                {
                    string tierCount = pair.Value.ToString().Colorize(Utils.TierToHexString(pair.Key));
                    sb.Append($"{tierCount}");
                    sb.Append(" ");
                }
                if (sb[sb.Length - 1] == ' ')
                    sb[sb.Length - 1] = ']';

                sb.Append("</color></nobr>\n<nobr>");
            }
            sb.Append($"${master.money}</nobr>");
            self.moneyText.text = sb.ToString();
            self.moneyText.overflowMode = TMPro.TextOverflowModes.Overflow;
        }
    }
}
