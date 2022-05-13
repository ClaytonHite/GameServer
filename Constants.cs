using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public class Constants
    {
        public const int ExperienceBonus = 1;
        public const int WeightedDice = 10;
        public const float PerLevelExperienceMultiplier = 2f; //1.5f would lower experience needed to next level
        public const float firstLevelExpRequirement = 100;
        public const int TICKS_PER_SEC = 30;
        public const int MS_PER_TICK = 1000 / TICKS_PER_SEC;
        public static string[] Races = { "Dragonborn", "Dwarf", "Elf", "Gnome", "Goblin", "Half-Elf", "Halfling", "Half-Orc", "Human", "Tiefling" };
        public static string[] Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
        public static string[] Stats = { "Strength", "Dexterity", "Constitution", "Intellect", "Wisdom", "Charisma" };
    }
}
