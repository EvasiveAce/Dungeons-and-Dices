using DungeonsAndDices.buildings;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDices 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeons and Dices";
            PlayerStats.Coins = 10;
            House.HouseMenu();
        }
    }
}
