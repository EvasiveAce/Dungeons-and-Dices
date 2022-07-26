﻿using DungeonsAndDices.dices;
using DungeonsAndDices.os;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.buildings
{
    public class Shop
    {
        public static void ShopMenu()
        {
            Console.Title = "Dungeons and Dices - Shop";
            Output.WriteLine("<-- Welcome to the Shop -->");
            string[] shopOptions = { "D6: ¢" + D6.Price + " -> " + "Own: " + DiceStats.DiceList.Count, "D4", "D20", "Exit"};
            foreach (string shopOption in shopOptions)
            {
                Output.WriteLine(shopOption);
            }
            Output.WriteLine();
            Output.WriteLine("Player's Coins: ¢" + PlayerStats.Coins);
            Output.WriteLine();
            Output.WriteLine("What would you like?");
            string userSelection;
            userSelection = Input.ReadLine();
            switch (userSelection)
            {
                case ("D6"):
                    purchaseDice("D6", DiceStats.DiceList);
                    Input.ReadLine();
                    Output.Clear();
                    ShopMenu();
                    break;
                case ("Exit"): case("Home"):
                    Output.Clear();
                    House.HouseMenu();
                    break;
            }
        }

        public static void purchaseDice(string diceType, List<Dice> diceList)
        {
            if (diceType == "D6")
            {
                if (PlayerStats.Coins >= D6.Price)
                {
                    PlayerStats.Coins = PlayerStats.Coins - D6.Price;
                    diceList.Add(new D6());
                    //Price = rounded to nearst int, price base * price mult^amount of already own die
                    Output.WriteLine("You purchased a D6");
                    D6.Price = Math.Ceiling(D6.Price * Math.Pow(D6.PriceMultiplier, diceList.Count));
                }
                else
                {
                    Output.WriteLine("Not enough coins, bitch");
                }
            }

        }
    }
}
