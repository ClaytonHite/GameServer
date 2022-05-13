using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Creatures.EntityConditions
{
	internal class Health
	{
		public int MaxHealth { get; set; }
		public int CurrentHealth { get; set; }
		public int HealthModifiers { get; set; }
	}
}
