using AdventuresOnlineGameServer.Entities.Items;
using Game_Server.AIPathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    class Monster
    {
        public static int monsterCount;
        public static Dictionary<int, Monster> monsters = MonsterManager.monsters;
        public static List<string> monsterList = new List<string>();
        public Pathfinding pathfinding = new Pathfinding();
        public static string monsterString = "";
        public int monsterID;
        public string monsterName = "";
        public Vector2 monsterPosition;
        public Vector2 spawnPosition;
        public int monsterLevel;
        public int monsterAvatar;
        public int currentHitPoints;
        public int maxHitPoints;
        public int currentManaPoints;
        public int maxManaPoints;
        public string monsterRace = "";
        public string monsterClass = "";
        public int monsterStrength;
        public int monsterDexterity;
        public int monsterConstitution;
        public int monsterIntellect;
        public int monsterWisdom;
        public int monsterCharisma;
        public int monsterExperienceGiven;
        public string currentTarget = "";
        public int currentTargetID;
        public bool isMoving;
        public bool isAttacking;
        public Collider collider = new Collider(new Vector2(0,0), false);
        public List<Item> LootTable = new List<Item>();
        public static void AddMonster(Monster monster)
        {
            monsterCount++;
            monsters.Add(monsterCount, monster);
            monsters[monsterCount].monsterID = monsterCount;
        }
        public static string MonsterDataString()
        {
            monsterList.Clear();
            foreach (KeyValuePair<int, Monster> item in monsters)
            {
                monsterList.Add(item.Value.monsterName + "," +
                    Convert.ToString(item.Key) + "," +
                    Convert.ToString(item.Value.monsterAvatar) + "," +
                    Convert.ToString(item.Value.currentHitPoints) + "," +
                    Convert.ToString(item.Value.maxHitPoints) + "," +
                    Convert.ToString(item.Value.monsterPosition.X) + "," +
                    Convert.ToString(item.Value.monsterPosition.Y)
                    );
            }
            return monsterString = string.Join(":", monsterList);
        }
    }
}
