using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.PlayerInteractions
{
    public class AddSkills
    {
        public static Dictionary<int, Player> players = Player.players;
        public static Dictionary<string, int[]> RaceStatMod = PlayerStatModifiers.RaceStatMod;
        public static Dictionary<string, int[]> ClassStatMod = PlayerStatModifiers.ClassStatMod;
        public static void StatRoll(int _fromClient, int skill)
        {
            //Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            if (players[_fromClient].playerSkillPoints > 0)
            {
                string playerClass = players[_fromClient].playerClass;
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
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D12Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D12Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addCarryingWeight = statArray[0] + Dice.D4Die();
                        players[_fromClient].playerStrength += 1;
                        players[_fromClient].playerCarryingWeight += addCarryingWeight;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
                if (skill == 1)//Dexterity
                {
                    if (classNumber == 0)//Barbarian
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        players[_fromClient].playerDexterity += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
                if (skill == 2)//Constitution
                {
                    if (classNumber == 0)//Barbarian
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D12Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D6Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addHealth = statArray[2] + Dice.D4Die();
                        players[_fromClient].playerConstitution += 1;
                        players[_fromClient].maxHitPoints += addHealth;
                        players[_fromClient].currentHitPoints += addHealth;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
                if (skill == 3)//Intellect
                {
                    if (classNumber == 0)//Barbarian
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D10Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D10Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D8Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D4Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D8Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[3] + Dice.D12Die();
                        players[_fromClient].playerIntellect += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
                if (skill == 4)//Wisdom
                {
                    if (classNumber == 0)//Barbarian
                    {
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D10Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D10Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D4Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D12Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D8Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D8Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Wizard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[4] + Dice.D12Die();
                        players[_fromClient].playerWisdom += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
                if (skill == 5)//Charisma
                {
                    if (classNumber == 0)//Barbarian
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 1)//Bard
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 2)//Cleric
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D10Die();
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 3)//Druid
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 4)//Fighter
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 5)//Monk
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 6)//Paladin
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 7)//Ranger
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 8)//Rogue
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 9)//Sorcerer
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D12Die();
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 10)//Warlock
                    {
                        int[] statArray = ClassStatMod[playerClass];
                        int addMana = statArray[5] + Dice.D8Die();
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].maxManaPoints += addMana;
                        players[_fromClient].currentManaPoints += addMana;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                    if (classNumber == 11)//Wizard
                    {
                        players[_fromClient].playerCharisma += 1;
                        players[_fromClient].playerSkillPoints -= 1;
                        ServerSend.UpdatePlayer(_fromClient, players[_fromClient]);
                    }
                }
            }
        }
    }
}
