using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    static class RandomNumberGenerator
    {
        static Random rand;
        public static void Start()
        {
            rand = new Random();
        }
        public static int Next(int maxValue)
        {
            return rand.Next(maxValue);
        }
        public static int Between(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }
    }
}
