using DungeonsAndDices.dices;
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
            Console.WriteLine("Welcome to the Shop");
            string[] shopOptions = { "D6: ¢" + D6.Price + " -> " + "Own: " + DiceStats.D6DiceList.Count, "D4", "D20" };
            foreach (string shopOption in shopOptions)
            {
                Console.WriteLine(shopOption);
            }
            Console.WriteLine("Player's Coins: ¢" + PlayerStats.Coins);
            Console.WriteLine();
            Console.WriteLine("What would you like?");
            string userSelection;
            userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case ("D6"):
                    purchaseDice("D6", DiceStats.D6DiceList);
                    Console.ReadLine();
                    Console.Clear();
                    ShopMenu();
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
                    Console.WriteLine("You purchased a D6");
                    D6.Price = Math.Ceiling(D6.Price * Math.Pow(D6.PriceMultiplier, diceList.Count));
                }
                else
                {
                    Console.WriteLine("Not enough coins, bitch");
                }
            }

        }
    }
}
