using Game_Server.PlayerInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.AIPathfinding
{
    class TargetFinder
    {
        static int playerRange = 6;
        public Player _target;
        public Monster _selectedUnit;
        public static List<Monster> addToActiveMonsterList = new List<Monster>();
        public static List<Monster> activeMonsterList = new List<Monster>();
        public static List<Monster> removeFromActiveMonsterList = new List<Monster>();
        public static void OnServerUpdate()
        {
            foreach (Monster monster in addToActiveMonsterList)
            {
                activeMonsterList.Add(monster);
            }
            addToActiveMonsterList.Clear();
            foreach (Monster monster in activeMonsterList)
            {
                if (Server.clients.ContainsKey(monster.currentTargetID))
                {
                    float distanceCheck = monster.pathfinding.isNear();
                    if (distanceCheck < 1.75)
                    {
                        if (Server.clients[monster.currentTargetID] != null)
                        {
                            Combat.MonsterAttack(monster);
                        }
                        else
                        {
                            monster.currentTarget = "";
                            monster.currentTargetID = 0;
                            removeFromActiveMonsterList.Add(monster);
                        }
                    }
                    monster.pathfinding.Update();
                }
                else
                {
                    monster.currentTarget = "";
                    monster.currentTargetID = 0;
                    removeFromActiveMonsterList.Add(monster);
                }
            }
            foreach (Monster monster in removeFromActiveMonsterList)
            {
                activeMonsterList.Remove(monster);
            }
            removeFromActiveMonsterList.Clear();
        }
        public static void Update(Player _player)
        {
            foreach (int _key in MonsterManager.monsters.Keys)
            {
                Monster monster = MonsterManager.monsters[_key];
                float distX = _player.position.X - monster.monsterPosition.X;
                float distY = _player.position.Y - monster.monsterPosition.Y;
                if (distX <= playerRange && distX >= (-1) * playerRange &&
                    distY <= playerRange && distY >= (-1) * playerRange)
                {
                    if (monster.currentTarget == "")
                    {
                        monster.currentTarget = _player.username;
                        monster.currentTargetID = _player.id;
                        monster.pathfinding.EnteredMonsterRange(_player, monster);
                        addToActiveMonsterList.Add(monster);
                    }
                }
                else
                {
                    if (Server.clients.ContainsKey(monster.currentTargetID))
                    {
                        if (monster.currentTarget == Server.clients[monster.currentTargetID].player.username)
                        {
                            monster.currentTarget = "";
                            monster.currentTargetID = 0;
                            monster.pathfinding.ExitedMonsterRange();
                            addToActiveMonsterList.Remove(monster);
                        }
                        if (monster.currentTarget != "" && monster.currentTarget == _player.username)
                        {
                            if (Vector2.Distance(monster.monsterPosition, _player.position) > 7)
                            {
                                monster.currentTarget = "";
                                monster.currentTargetID = 0;
                                monster.pathfinding.ExitedMonsterRange();
                                addToActiveMonsterList.Remove(monster);
                            }
                        }
                    }
                }
            }
        }
        public static void RefreshAfterMonsterDeath(Monster monster)
        {
            monster.currentTarget = "";
            monster.currentTargetID = 0;
        }
    }
}
