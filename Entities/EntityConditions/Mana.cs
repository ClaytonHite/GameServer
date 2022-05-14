using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Creatures.EntityConditions
{
    internal class Mana
	{
		public int MaxMana { get; set; }
		public int CurrentMana { get; set; }
		public int ManaModifiers { get; set; }
	}
}
