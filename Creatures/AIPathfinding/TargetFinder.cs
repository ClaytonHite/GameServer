using Game_Server.PlayerInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.AIPathfinding
{
    public class TargetFinder
    {
        static int playerRange = 6;
        public Player _target;
        public Monster _selectedUnit;
        public static List<Monster> activeMonsterList = new List<Monster>();
        public static void OnServerUpdate()
        {
            foreach (Monster monster in activeMonsterList)
            {
                if (monster.pathfinding.isNear() < 1.75) 
                {
                    if (Player.players[monster.currentTargetID] != null)
                    {
                        Combat.MonsterAttack(monster);
                        return;
                    }
                    else
                    {
                        monster.currentTarget = "";
                    }
                }
                monster.pathfinding.Update();
            }
        }
        public static void Update(Player _player)
        {
            foreach (int _monster in MonsterManager.monsters.Keys)
            {
                Monster monster = MonsterManager.monsters[_monster];
                float distX = _player.position.X - monster.monsterPosition.X;
                float distY = _player.position.Y - monster.monsterPosition.Y;
                if (distX <= playerRange && distX >= (-1) * playerRange &&
                    distY <= playerRange && distY >= (-1) * playerRange)
                {
                    if (monster.currentTarget == "")
                    {
                        monster.currentTarget = _player.username;
                        monster.currentTargetID = _player.id;
                        Console.WriteLine($"WE MADE THE CURRENT TARGET ID {_player.id}.");
                        monster.pathfinding.EnteredMonsterRange(_player, monster);
                        activeMonsterList.Add(monster);
                    }
                }
                else
                {
                    if (monster.currentTarget != "" && monster.currentTarget == _player.username)
                    {
                        if (Vector2.Distance(monster.monsterPosition, _player.position) > 7)
                        {
                            monster.currentTarget = "";
                            monster.currentTargetID = 0;
                            monster.pathfinding.ExitedMonsterRange();
                            activeMonsterList.Remove(monster);
                        }
                    }
                }
            }
        }
    }
}
