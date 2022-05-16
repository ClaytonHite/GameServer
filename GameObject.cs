using Game_Server.AIPathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
   class GameObject
    {
        public Vector2 Position = new Vector2(0, 0);
        public string Tag = "";
        private static List<GameObject> GameObjects;
        public int tileX;
        public int tileY;
        public TileMap map;
        public Monster monster;
        public List<Node> currentPath = null;
        public GameObject(Vector2 Position, string Tag)
        {
            this.Position = Position;
            this.Tag = Tag;

            RegisterGameObject(this);
        }
        public static void onLoad()
        {
            GameObjects = new List<GameObject>();
        }
        public void DestroySelf()
        {
            UnRegisterGameObject(this);
        }
        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
        public static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }
        public static List<GameObject> GetGameObjects()
        {
            return GameObjects;
        }
    }
}
