using AdventuresOnlineGameServer.Creatures.Players;
using Game_Server.AIPathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.PlayerInteractions
{
    class Combat
    {
        public static Dictionary<int, Monster> monsters = MonsterManager.monsters;
        public static int D20Die = 0;
        public static void PlayerAttack(int _fromClient, int monsterID, Vector2 monsterLocation)
        {
            if (!Server.clients[_fromClient].player.playerAttacking)
            {
                Server.clients[_fromClient].player.playerAttacking = true;
                Task.Run(async delegate
                {
                    await Task.Delay((10000 / Server.clients[_fromClient].player.playerDexterity) * 3);
                    Server.clients[_fromClient].player.playerAttacking = false;
                });
                int damage = GetPlayerAttackDamage(_fromClient);
                if (monsters.ContainsKey(monsterID))
                {
                    monsters[monsterID].currentHitPoints = monsters[monsterID].currentHitPoints - damage;
                    if (monsters[monsterID].currentHitPoints > 0)
                    {
                        ServerSend.PlayerDamageDone(monsterID, damage, monsterLocation, _fromClient);
                    }
                    if (monsters[monsterID].currentHitPoints <= 0)
                    {
                        MonsterManager.Death(damage, monsterID, _fromClient);
                    }
                }
            }
        }
        public static int GetPlayerAttackDamage(int _fromClient)
        {
            //TODO
            //make AC stat for monsters
            //add skill for weapons on players
            //add current weapon on player
            int damRange = 0;
            int playerLevel = Server.clients[_fromClient].player.playerLevel;
            int playerWeapon = 1;
            int playerSkillDamage = 10;
            if (Server.clients[_fromClient].player.playerClass == "Barbarian" || Server.clients[_fromClient].player.playerClass == "Cleric" || Server.clients[_fromClient].player.playerClass == "Druid" || Server.clients[_fromClient].player.playerClass == "Fighter" || Server.clients[_fromClient].player.playerClass == "Paladin")
            {
                playerSkillDamage = Server.clients[_fromClient].player.playerStrength;
            }//"Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"
            if (Server.clients[_fromClient].player.playerClass == "Monk" || Server.clients[_fromClient].player.playerClass == "Ranger" || Server.clients[_fromClient].player.playerClass == "Rogue")
            {
                playerSkillDamage = Server.clients[_fromClient].player.playerDexterity + (Server.clients[_fromClient].player.playerStrength / 2);
            }
            D20Die = Dice.D20Die();
            int damage = (playerLevel / 5) + (((int)((3.25f * playerWeapon)) * (playerSkillDamage)) / 28);
            if (D20Die <= 5)
            {
                damage = damage * 0;
            }
            if (D20Die > 5 && D20Die <= 10)
            {
                damage = (damage / 2) + 1;
                damRange = RandomNumberGenerator.Between(-1 * (damage * D20Die) / 20, (damage * D20Die) / 20);
            }
            else if (D20Die > 10 && D20Die <= 18)
            {
                damRange = RandomNumberGenerator.Between(-1 * (damage * D20Die) / 20, (damage * D20Die) / 20);
            }
            if (D20Die > 18)
            {
                damage = damage * 2;
                Console.WriteLine($"{Server.clients[_fromClient].player.username} just did a critical hit for {damage}!");
            }
            int finalDamage = damage + damRange;
            return finalDamage;
        }
        public static void MonsterAttack(Monster _monster)
        {
            if (!_monster.isAttacking)
            {
                _monster.isAttacking = true;
                Task.Run(async delegate
                {
                    await Task.Delay((10000 / _monster.monsterDexterity) * 3);
                    _monster.isAttacking = false;
                });
                int damage = GetMonsterAttackDamage(_monster);
                if (Server.clients.ContainsKey(_monster.currentTargetID))
                {
                    Server.clients[_monster.currentTargetID].player.currentHitPoints = Server.clients[_monster.currentTargetID].player.currentHitPoints - damage;
                    if (Server.clients[_monster.currentTargetID].player.currentHitPoints > 0)
                    {
                        ServerSend.MonsterDamageDone(_monster.monsterID, damage, Server.clients[_monster.currentTargetID].player.position, _monster.currentTargetID);
                    }
                    if (Server.clients[_monster.currentTargetID].player.currentHitPoints <= 0)
                    {
                        PlayerManager.Death(damage, _monster.monsterID, _monster.currentTargetID);
                    }
                }
            }            
        }
        static int GetMonsterAttackDamage(Monster _monster)
        {
            int monsterDamage = 0;
            int monsterStrength = _monster.monsterStrength;
            int damRange = 0;
            int monsterLevel = _monster.monsterLevel;
            int damage = (monsterLevel / 5) + (((int)((3.25f)) * (monsterStrength)) / 28);
            D20Die = Dice.D20Die();
            if (D20Die <= 5)
            {
                monsterDamage = damage * 0;
            }
            if (D20Die > 5 && D20Die <= 10)
            {
                damage = (damage / 2) + 1;
                damRange = RandomNumberGenerator.Between(-1 * (damage * D20Die) / 20, (damage * D20Die) / 20 );
                monsterDamage = damage + damRange;
            }
            else if (D20Die > 10 && D20Die <= 18)
            {
                damRange = RandomNumberGenerator.Between(-1 * (damage * D20Die) / 20, (damage * D20Die) / 20);
                monsterDamage = damage + damRange;
            }
            if (D20Die > 18)
            {
                monsterDamage = damage * 2;
            }
            return monsterDamage;
        }
    }
}


            
        
    

