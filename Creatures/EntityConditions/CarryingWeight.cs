using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Creatures.EntityConditions
{
    internal class CarryingWeight
	{
		public int MaxCarryingWeight { get; set; }
		public int CurrentCarryingWeight { get; set; }
		public int CarryingWeightModifiers { get; set; }
	}
}