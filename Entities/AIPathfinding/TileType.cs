using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.AIPathfinding
{
	public class TileType
	{
		public string name = "";
		//Add visual prefabs red for collider green for open space.
		//public GameObject tileVisualPrefab = new GameObject();
		public bool isWalkable = true;
		public float movementCost = 1;
	}
}
