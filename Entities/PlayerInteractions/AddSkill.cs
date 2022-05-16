using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.PlayerInteractions
{
    class AddSkills
    {
        public static Dictionary<int, Client> clients = Server.clients;
        public static Dictionary<string, int[]> RaceStatMod = PlayerStatModifiers.RaceStatMod;
        public static Dictionary<string, int[]> ClassStatMod = PlayerStatModifiers.ClassStatMod;
        public static void StatRoll(int _fromClient, int skill)
        {
            //Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            if (clients[_fromClient].player.playerSkillPoints > 0)
            {
                string playerClass = clients[_fromClient].player.playerClass;
                int classNumber = 0;
                for (int i = 0; i < Constants.Classes.Length; i++)
                {
                    if (playerClass == Constants.Classes[i])
                    {
                        classNumber = i;
                    }
                }
                if (skill == 0)//Strength
                {
                    if (classNumber == 0)//Barbarian
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D12Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D12Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D12Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        clients[_fromClient].player.playerStrength += 1;
                        clients[_fromClient].player.playerCarryingWeight += addCarryingWeight;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
                if (skill == 1)//Dexterity
                {
                    if (classNumber == 0)//Barbarian
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        clients[_fromClient].player.playerDexterity += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
                if (skill == 2)//Constitution
                {
                    if (classNumber == 0)//Barbarian
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        clients[_fromClient].player.playerConstitution += 1;
                        clients[_fromClient].player.maxHitPoints += addHealth;
                        clients[_fromClient].player.currentHitPoints += addHealth;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
                if (skill == 3)//Intellect
                {
                    if (classNumber == 0)//Barbarian
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D10Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D10Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D8Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D8Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        clients[_fromClient].player.playerIntellect += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
                if (skill == 4)//Wisdom
                {
                    if (classNumber == 0)//Barbarian
                    {
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D10Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D10Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D4Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D12Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D8Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D8Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D12Die();
                        clients[_fromClient].player.playerWisdom += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
                if (skill == 5)//Charisma
                {
                    if (classNumber == 0)//Barbarian
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D10Die();
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 3)//Druid
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 5)//Monk
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D8Die();
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.maxManaPoints += addMana;
                        clients[_fromClient].player.currentManaPoints += addMana;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        clients[_fromClient].player.playerCharisma += 1;
                        clients[_fromClient].player.playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, clients[_fromClient].player);
                    }
                }
            }
        }
    }
}
