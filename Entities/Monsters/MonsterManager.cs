using Game_Server.AIPathfinding;
using Game_Server.PlayerInteractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    class MonsterManager
    {
        public static Dictionary<int, Monster> monsters = new Dictionary<int, Monster>();
        static int MapSize = TileMap.mapSize;
        public static string monsterMapFilePath = "C:/Users/Clayt/Desktop/MonsterMap.txt";
        public static int secondsBetweenSpawn = 1;
        public float elapsedTime = 0.0f;
        public static void LoadMonsters()
        {
            string ReadFile = File.ReadAllText(monsterMapFilePath);
            string[] LoadFile = ReadFile.Split(':');
            for (int i = 0; i < LoadFile.Length; i++)
            {
                if (LoadFile[i] != ".")
                {
                    int posY = i / MapSize;
                    int posX = i % MapSize;
                    Vector2 pos = new Vector2(posX, posY);
                    int findMonster = Convert.ToInt32(LoadFile[i]);
                    Monster spawnMob = MonsterData.GetMonster(findMonster, posX, posY);
                    Monster.AddMonster(spawnMob);
                }
            }
        }
        public static void Spawn(int monsterID, int findMonster, int posX, int posY)
        {
            monsters.Add(monsterID, MonsterData.GetMonster(findMonster, posX, posY));
            Console.WriteLine(DateTime.Now + $" -- {monsters[monsterID].monsterName} has respawned!");
            monsters[monsterID].monsterID = monsterID;
            string respawnMonster = (monsters[monsterID].monsterName + "," +
                        Convert.ToString(monsterID) + "," +
                        Convert.ToString(monsters[monsterID].monsterAvatar) + "," +
                        Convert.ToString(monsters[monsterID].currentHitPoints) + "," +
                        Convert.ToString(monsters[monsterID].maxHitPoints) + "," +
                        Convert.ToString(monsters[monsterID].monsterPosition.X) + "," +
                        Convert.ToString(monsters[monsterID].monsterPosition.Y)
                        );
            ServerSend.MonsterUpdate(true, respawnMonster, -1, -1);
            foreach (Player player in Player.players.Values)
            {
                TargetFinder.Update(player);
            }
        }
        public static void Death(int damage, int monsterID, int _fromClient)
        {
            Console.WriteLine(DateTime.Now + $" -- {monsters[monsterID].monsterName} has been killed by {Player.players[_fromClient].username}!");
            Reset(monsterID, monsters[monsterID].monsterAvatar, (int)monsters[monsterID].spawnPosition.X, (int)monsters[monsterID].spawnPosition.Y);
            int addExperienceToPlayer = monsters[monsterID].monsterExperienceGiven;
            TargetFinder.RefreshAfterMonsterDeath(monsters[monsterID]);
            Collider.DestorySelf(monsters[monsterID].monsterPosition);
            monsters.Remove(monsterID);
            LevelUp.AddExperienceToPlayer(_fromClient, addExperienceToPlayer);
            ServerSend.MonsterUpdate(false, Convert.ToString(monsterID), damage, _fromClient);
        }
        public static void Reset(int monsterID, int findMonster, int posX, int posY)
        {
            Task.Run(async delegate
            {
                await Task.Delay(secondsBetweenSpawn * 5000);
                Spawn(monsterID, findMonster, posX, posY);
            });
        }
    }
}
