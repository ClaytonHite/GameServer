using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server.AIPathfinding
{
	public class Node
	{
		public List<Node> neighbours;
		public int x;
		public int y;

		public Node()
		{
			neighbours = new List<Node>();
		}

		public float DistanceTo(Node n)
		{
			if (n == null)
			{
				Console.WriteLine("Null value for n in Node.cs");
			}

			return Vector2.Distance(new Vector2(x, y),new Vector2(n.x, n.y));
		}
	}
}
