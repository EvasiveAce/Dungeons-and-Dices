using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDices.dices
{
    public abstract class Dice
    {
        public static double Price { get; set; }
        public static double PriceMultiplier { get; set; } = 1.15;
        public static int DiceSides { get; set; }
        
        
        public int Roll()
        {
            Random numberGen = new Random();
            return numberGen.Next(1, DiceSides);
        }

    }
}