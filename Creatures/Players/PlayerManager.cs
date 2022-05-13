using Game_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Creatures.Players
{
    class PlayerManager
    {
        public static Dictionary<int, Player> players = Player.players;
        public static Dictionary<int, Monster> monsters = MonsterManager.monsters;
        public static void Death(int damage, int monsterID, int _toClient)
        {
            Console.WriteLine(DateTime.Now + $" -- {players[_toClient].username} has been killed by {monsters[monsterID].monsterName} with a hit of {damage}!");
        }
    }
}
