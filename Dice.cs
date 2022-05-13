using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public class Dice
    {
        static int numResult;
        static int numSides;
        public static int D20Die()
        {
            numSides = 20;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
        public static int D12Die()
        {
            numSides = 12;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
        public static int D10Die()
        {
            numSides = 10;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
        public static int D8Die()
        {
            numSides = 8;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
        public static int D6Die()
        {
            numSides = 6;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
        public static int D4Die()
        {
            numSides = 4;
            numResult = RandomNumberGenerator.Next(numSides) + 1 + Constants.WeightedDice;
            if (numResult > numSides) { numResult = numSides; }
            return numResult;
        }
    }
}
