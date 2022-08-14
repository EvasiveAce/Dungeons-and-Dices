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
            PlayerStats.HP = 10;
            //Shop.purchaseDice("D6", DiceStats.DiceList);
            //House.HouseMenu();
            FC.FCMenu();
        }
    }
}
