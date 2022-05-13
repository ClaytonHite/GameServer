using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.PlayerInteractions
{
    public class PlayerStatModifiers
    {
        static string[] Races = Constants.Races; //{ "Dragonborn", "Dwarf", "Elf", "Gnome", "Goblin", "Half-Elf", "Halfling", "Half-Orc", "Human", "Tiefling" };
        static string[] Classes = Constants.Classes; //{ "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
        static string[] Stats = Constants.Stats; //{ "Strength", "Dexterity", "Constitution", "Intellect", "Wisdom", "Charisma" };
        public static Dictionary<string, int[]> RaceStatMod = new Dictionary<string, int[]>();
        public static Dictionary<string, int[]> ClassStatMod = new Dictionary<string, int[]>();

        public static void LoadStatMods()
        {
            for (int i = 0; i < Races.Length; i++)
            {
                if (i == 0)//DragonBorn
                {
                    int[] statArray = { 2, 0, 0, 0, 0, 1 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 1)//Dwarf
                {
                    int[] statArray = { 0, 0, 2, 0, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 2)//Elf
                {
                    int[] statArray = { 0, 2, 0, 0, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 3)//Gnome
                {
                    int[] statArray = { 0, 0, 0, 2, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 4)//Goblin
                {
                    int[] statArray = { 0, 2, 1, 0, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 5)//Half-Elf
                {// DO WORK
                    int[] statArray = { 1, 1, 0, 1, 0, 2 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 6)//Halfling
                {
                    int[] statArray = { 0, 2, 0, 0, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 7)//Half-Orc
                {
                    int[] statArray = { 2, 0, 1, 0, 0, 0 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 8)//Human
                {
                    int[] statArray = { 1, 1, 1, 1, 1, 1 };
                    RaceStatMod.Add(Races[i], statArray);
                }
                if (i == 9)//Tiefling
                {
                    int[] statArray = { 0, 0, 0, 1, 0, 2 };
                    RaceStatMod.Add(Races[i], statArray);
                }
            }
            for (int i = 0; i < Classes.Length; i++)
            {
                if (i == 0)//Barbarian
                {
                    int[] statArray = { 12, 0, 12, 4, 0, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 1)//Bard
                {
                    int[] statArray = { 4, 0, 8, 4, 0, 12 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 2)//Cleric
                {
                    int[] statArray = { 4, 0, 8, 10, 10, 10 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 3)//Druid
                {
                    int[] statArray = { 4, 0, 8, 10, 10, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 4)//Fighter
                {
                    int[] statArray = { 12, 0, 12, 4, 0, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 5)//Monk
                {
                    int[] statArray = { 4, 0, 8, 4, 4, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 6)//Paladin
                {
                    int[] statArray = { 10, 0, 12, 8, 8, 8 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 7)//Ranger
                {
                    int[] statArray = { 4, 0, 10, 8, 8, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 8)//Rogue
                {
                    int[] statArray = { 4, 8, 8, 4, 0, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 9)//Sorcerer
                {
                    int[] statArray = { 2, 0, 6, 12, 0, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 10)//Warlock
                {
                    int[] statArray = { 2, 0, 8, 8, 8, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
                if (i == 11)//Wizard
                {
                    int[] statArray = { 2, 0, 6, 12, 12, 0 };
                    ClassStatMod.Add(Classes[i], statArray);
                }
            }
        }
    }
}
