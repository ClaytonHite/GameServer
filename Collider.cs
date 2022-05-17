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
        public string Tag;
        public static Collider[,] colliderArray = new Collider[TileMap.mapSize, TileMap.mapSize];
        public Collider(Vector2 Position, bool walkable, string tag)
        {
            colliderId++;
            this.Position = Position;
            this.Walkable = walkable;
            this.Tag = tag;
            RegisterColliderArray(this);
        }
        public static bool CheckForCollider(Vector2 position)
        {

            if (colliderArray[(int)position.X, (int)position.Y] == null)
            {
                return true;
            }
            //if (colliderArray[(int)position.X, (int)position.Y].Walkable && colliderArray[(int)position.X, (int)position.Y].Tag == "Player")
            //{
            //    return false;
            //}
            //REWORK PATHFINDER TO FIND CLOSEST TILE NEXT TO PLAYER SO IT DOESNT THROW THE TARGET OUT OF THE GRAPH ARRAY BECAUSE IT THINKS IT CANT MOVE ON TOP OF PLAYER.
            if (!colliderArray[(int)position.X, (int)position.Y].Walkable)
            {
                return false;
            }
            return true;
        }
        public static Collider GetColliders(Vector2 position)
        {
            return colliderArray[(int)position.X, (int)position.Y];
        }
        public void DestorySelf()
        {
            UnregisterColliderArray(this);
        }
        public void RegisterColliderArray(Collider collider)
        {
            colliderArray[(int)collider.Position.X, (int)collider.Position.Y] = collider;
        }
        public void UnregisterColliderArray(Collider collider)
        {
            colliderArray[(int)collider.Position.X, (int)collider.Position.Y] = null;
        }
    }
}
