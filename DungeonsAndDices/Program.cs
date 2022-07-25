using DungeonsAndDices.buildings;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDices 
{
    class Program
    {
        public static int coinAmount = 50;
        public static int rollValue = 1;
        public static int rollValuePrice = 50;
        static void Main(string[] args)
        {
            Console.Title = "Dungeons and Dices";
            PlayerStats.Coins = 0;
            Shop.ShopMenu();
        }
    }
}
