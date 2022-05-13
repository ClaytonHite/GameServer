using Game_Server.AIPathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    internal class GameLogic
    {
        public static void Update()
        {
            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null)
                {
                    _client.player.Update();
                }
            }
            ThreadManager.UpdateMain();
            TargetFinder.OnServerUpdate();
        }
    }
}
