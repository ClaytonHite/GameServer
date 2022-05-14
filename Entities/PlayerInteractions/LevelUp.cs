using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.PlayerInteractions
{
    class LevelUp
    {
        public static int firstLevelExpRequirement = 100;
        public static void CheckLevelExperience()
        {
            for (int i = 1; i < 101; i++)
            {//FOR INFO ONLY VALUES LOAD AT SERVER START
                Console.WriteLine($"For Level {i} it takes {(long)ExperienceTableForLevel(i)} experience.");
            }
        }
        public static void AddExperienceToPlayer(int _fromClient, int Experience)
        {
            Dictionary<int, Player> players = Player.players;
            players[_fromClient].playerExperience += Experience;
            players[_fromClient].ExperienceRequired = (long)ExperienceTableForLevel(players[_fromClient].playerLevel);
            while (players[_fromClient].playerExperience > players[_fromClient].ExperienceRequired)
            {
                players[_fromClient].playerSkillPoints += 5;
                players[_fromClient].playerLevel += 1;
                Console.WriteLine(DateTime.Now + $" -- {players[_fromClient].username} is now level {players[_fromClient].playerLevel}!");
                players[_fromClient].ExperienceRequired = (long)ExperienceTableForLevel(players[_fromClient].playerLevel);
                players[_fromClient].PreviousExperienceRequired = (long)ExperienceTableForLevel((players[_fromClient].playerLevel - 1));
                ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
            }
            ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
        }
        public static double ExperienceTableForLevel(int playerLevel)
        {
            if (playerLevel <= 5)
            {
                return Constants.firstLevelExpRequirement * (playerLevel - 1);
            }
            if (playerLevel > 5 && playerLevel <= 19)
            {
                return Constants.firstLevelExpRequirement * Math.Pow(playerLevel - 1, Constants.PerLevelExperienceMultiplier);
            }
            if (playerLevel > 19 && playerLevel <= 39)
            {
                return Constants.firstLevelExpRequirement * Math.Pow(playerLevel - 1, Constants.PerLevelExperienceMultiplier * 1.1f);
            }
            if (playerLevel > 39 && playerLevel < 60)
            {
                return Constants.firstLevelExpRequirement * Math.Pow(playerLevel - 1, Constants.PerLevelExperienceMultiplier * 1.2f);
            }
            else
            {
                return Constants.firstLevelExpRequirement * Math.Pow(playerLevel - 1, Constants.PerLevelExperienceMultiplier * 1.2f);
            }
        }
    }
}
