using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public class Collider
    {
        public static int colliderId = 0;
        public bool Walkable { get; set; }
        public Vector2 Position;
        public static Dictionary<int, Collider> Colliders = new Dictionary<int, Collider>();
        public static Collider[,] colliderArray = new Collider[TileMap.mapSize, TileMap.mapSize];
        public Collider(Vector2 Position, bool Walkable)
        {
            colliderId++;
            this.Position = Position;
            this.Walkable = Walkable;
            Colliders.Add(colliderId, this);
            RegisterColliderArray(this);
        }
        public static bool CheckForCollider(Vector2 position)
        {
            if (colliderArray[(int)position.X, (int)position.Y] == null)
            {
                return true;
            }
            if (!colliderArray[(int)position.X, (int)position.Y].Walkable)
            {
                return false;
            }
            return true;
        }
        public static void DestorySelf(Vector2 position)
        {
            int keyToDelete = -1;
            foreach (KeyValuePair<int, Collider> collider in Colliders)
            {
                if (collider.Value.Position.X == position.X && collider.Value.Position.Y == position.Y)
                {
                    keyToDelete = collider.Key;
                }
            }
            if (keyToDelete >= 0)
            {
                Colliders.Remove(keyToDelete);
            }
        }
        public void RegisterColliderArray(Collider collider)
        {
            colliderArray[(int)collider.Position.X, (int)collider.Position.Y] = collider;
        }
    }
}
