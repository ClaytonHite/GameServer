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
        public Collider(Vector2 Position, bool Walkable)
        {
            colliderId++;
            this.Position = Position;
            this.Walkable = Walkable;
            Colliders.Add(colliderId, this);
        }
        public static bool CheckForCollider(Vector2 position)
        {
            try
            {
                foreach (Collider collider in Colliders.Values)
                {
                    if (collider.Position.X == position.X && collider.Position.Y == position.Y)
                    {
                        if (!collider.Walkable)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                Console.WriteLine("COLLIDERS WERE ACESSED DURING FOREACH LOOP");
            }
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
    }
}
