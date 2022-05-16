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
            Dictionary<int, Client> clients = Server.clients;
            clients[_fromClient].player.playerExperience += Experience;
            clients[_fromClient].player.ExperienceRequired = (long)ExperienceTableForLevel(clients[_fromClient].player.playerLevel);
            while (clients[_fromClient].player.playerExperience > clients[_fromClient].player.ExperienceRequired)
            {
                clients[_fromClient].player.playerSkillPoints += 5;
                clients[_fromClient].player.playerLevel += 1;
                Console.WriteLine(DateTime.Now + $" -- {clients[_fromClient].player.username} is now level {clients[_fromClient].player.playerLevel}!");
                clients[_fromClient].player.ExperienceRequired = (long)ExperienceTableForLevel(clients[_fromClient].player.playerLevel);
                clients[_fromClient].player.PreviousExperienceRequired = (long)ExperienceTableForLevel((clients[_fromClient].player.playerLevel - 1));
                ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
            }
            ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
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
