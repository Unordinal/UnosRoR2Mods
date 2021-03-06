﻿using System.Collections.Generic;
using RoR2;
using UnosMods.TabItemStats.Formatters;
using static UnosMods.TabItemStats.ContextProvider;
using static UnosMods.TabItemStats.TabItemStats;

namespace UnosMods.TabItemStats
{
    public static partial class PickupStatProvider
    {
        public static Dictionary<EquipmentIndex, List<EquipmentStat>> equipmentDefs;

        public static void UpdateEquipmentDefs()
        {
            Logger.LogDebug("Updating equipment defs...");
            equipmentDefs = new Dictionary<EquipmentIndex, List<EquipmentStat>>
            {
                [EquipmentIndex.CommandMissile] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 12,
                        statText: "Missles",
                        formatter: new IntFormatter()
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? (PlayerDamage() * 3f) * 12f : 3f,
                        statText: "Missle (12x)",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() * 3f : 3f,
                        statText: "\tMissle (1x)",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Fruit] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerMaxHealth() * 0.5f : 0.5f,
                        statText: "Heal Amount",
                        formatter: PlayerIsValid() ? new FloatFormatter(suffix: " HP") : new PercentageFormatter(suffix: " HP")
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Blackhole] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 30f,
                        statText: "Radius",
                        formatter: new FloatFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: 10,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 60,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.CritOnUse] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 1f,
                        statText: "Critical Chance"
                        ),
                    new EquipmentStat(
                        value: 8,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 60,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.DroneBackup] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 4,
                        statText: "Drones",
                        formatter: new IntFormatter()
                        ),
                    new EquipmentStat(
                        value: 25,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 225 + ScaleByLevel(67.5f),
                        statText: "Drone Health",
                        formatter: new IntFormatter(suffix: $" HP (lv. {TeamLevel()})")
                        ),
                    new EquipmentStat(
                        value: 5f + ScaleByLevel(1f),
                        statText: "Drone Regeneration",
                        formatter: new FloatFormatter(suffix: $" HP/s (lv. {TeamLevel()})")
                        ),
                    new EquipmentStat(
                        value: 7f + ScaleByLevel(1.4f),
                        statText: "Drone Damage",
                        formatter: new FloatFormatter(suffix: $" (lv. {TeamLevel()})")
                        ),
                    new EquipmentStat(
                        value: 100,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.BFG] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 35,
                        statText: "Zap Radius",
                        formatter: new IntFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid()? PlayerDamage() * 6f: 6f,
                        statText: "Zap Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(suffix: "/s", color: NeutralColor) : new PercentageFormatter(suffix: "/s", color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 20,
                        statText: "Detonation Radius",
                        formatter: new IntFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid()? PlayerDamage() * 40f : 40f,
                        statText: "Detonation Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 140,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Jetpack] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 15,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 0.2f,
                        statText: "Move Speed"
                        ),
                    new EquipmentStat(
                        value: 60,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Lightning] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() * 30f : 30f,
                        statText: "Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 20,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.GoldGat] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() : 1f,
                        statText: "Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 1,
                        statText: "Gold per Bullet",
                        formatter: new IntFormatter(color: NegativeColor, prefix: "$")
                        )
                },
                [EquipmentIndex.PassiveHealing] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerMaxHealth() * 0.015f : 0.015f,
                        statText: "Healing",
                        formatter: PlayerIsValid() ? new FloatFormatter(suffix: " HP/s") : new PercentageFormatter(suffix: " HP/s")
                        ),
                    new EquipmentStat(
                        value: 0.1f,
                        statText: "Ally Healing"
                        ),
                    new EquipmentStat(
                        value: 15,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Scanner] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 500f,
                        statText: "Radius",
                        formatter: new FloatFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: 10,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Gateway] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 1000f,
                        statText: "Length",
                        formatter: new FloatFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: 30,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Cleanse] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 20,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.FireBallDash] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() * 5f : 5f,
                        statText: "Impact Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() * 8f : 8f,
                        statText: "Detonation Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 5,
                        statText: "Duration",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 30,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.GainArmor] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 500,
                        statText: "Armor Gain",
                        formatter: new IntFormatter()
                        ),
                    new EquipmentStat(
                        value: 5,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.QuestVolatileBattery] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 0.5f,
                        statText: "Explosion Health Threshold",
                        formatter: new PercentageFormatter(color: NegativeColor)
                        )
                },

                [EquipmentIndex.Meteor] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() * 6f : 6f,
                        statText: "Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: 20,
                        statText: "Duration",
                        formatter: new IntFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: 140,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.BurnNearby] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 9f,
                        statText: "Radius",
                        formatter: new IntFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: 8f,
                        statText: "Duration",
                        formatter: new FloatFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid()? PlayerMaxHealth() * 0.05f : 0.05f,
                        statText: "Damage Taken",
                        formatter: PlayerIsValid() ? new IntFormatter(suffix: " HP/s", color: NeutralColor) : new PercentageFormatter(suffix: " of max health", color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid()? PlayerMaxHealth() * 0.025f : 0.025f,
                        statText: "Damage to Allies",
                        formatter: PlayerIsValid() ? new IntFormatter(suffix: " HP/s", color: NegativeColor) : new PercentageFormatter(color: NegativeColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid()? PlayerMaxHealth() * 1.2f : 1.2f,
                        statText: "Damage to Enemies",
                        formatter: PlayerIsValid() ? new IntFormatter(suffix: " HP/s", color: PositiveColor) : new PercentageFormatter(color: PositiveColor)
                        ),
                    new EquipmentStat(
                        value: 45,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.CrippleWard] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 16f,
                        statText: "Radius",
                        formatter: new IntFormatter(suffix: "m")
                        ),
                    new EquipmentStat(
                        value: 0.5f,
                        statText: "Slowing"
                        ),
                    new EquipmentStat(
                        value: 20,
                        statText: "Armor Reduction",
                        formatter: new IntFormatter()
                        ),
                    new EquipmentStat(
                        value: 15,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },
                [EquipmentIndex.Tonic] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 15f,
                        statText: "Duration",
                        formatter: new FloatFormatter(suffix: "s")
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerDamage() : 1f,
                        statText: "Addit. Damage",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: NeutralColor) : new PercentageFormatter(color: NeutralColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerAttackSpeed() * 0.7f : 0.7f,
                        statText: "Addit. Attack Speed",
                        formatter: PlayerIsValid() ? new FloatFormatter(color: UtilityColor) : new PercentageFormatter(color: UtilityColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerMaxHealth() * 0.5f : 0.5f,
                        statText: "Addit. Max Health",
                        formatter: PlayerIsValid() ? new FloatFormatter() : new PercentageFormatter()
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerArmor() + 20 : 20,
                        statText: "Addit. Armor",
                        formatter: new IntFormatter(color: UtilityColor)
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerRegen() * 3f : 3f,
                        statText: "Addit. Passive Regeneration",
                        formatter: PlayerIsValid() ? new FloatFormatter(suffix: " HP/s") : new PercentageFormatter(suffix: " HP/s")
                        ),
                    new EquipmentStat(
                        value: PlayerIsValid() ? PlayerSpeed() * 0.3f : 0.3f,
                        statText: "Addit. Move Speed",
                        formatter: PlayerIsValid() ? new FloatFormatter(suffix: "m/s", color: UtilityColor) : new PercentageFormatter(suffix: "m/s", color: UtilityColor)
                        ),
                    new EquipmentStat(
                        value: 0.2f,
                        statText: "Affliction Chance",
                        formatter: new PercentageFormatter(suffix: " (modified by luck)", color: NegativeColor, maxValue: 1f)
                        ),
                    new EquipmentStat(
                        value: 60,
                        statText: "Cooldown",
                        formatter: new IntFormatter(color: CooldownColor, suffix: "s")
                        )
                },

                [EquipmentIndex.AffixRed] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 4f,
                        statText: "Burn Duration",
                        formatter: new FloatFormatter(suffix: "s")
                        )
                },
                [EquipmentIndex.AffixBlue] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 0.5f,
                        statText: "Shield Percentage",
                        formatter: new PercentageFormatter(maxValue: 1f)
                        ),
                    new EquipmentStat(
                        value: 0.5f,
                        statText: "Lightning Bomb Damage",
                        formatter: new PercentageFormatter(suffix: " of skill's damage")
                        )
                },
                [EquipmentIndex.AffixWhite] = new List<EquipmentStat>
                {
                    new EquipmentStat(
                        value: 1.5f,
                        statText: "Slow Duration",
                        formatter: new FloatFormatter()
                        )
                },
                [EquipmentIndex.AffixPoison] = new List<EquipmentStat>
                {
                },
            };
	    }
    }
}
