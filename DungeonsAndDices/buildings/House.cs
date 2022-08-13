using DungeonsAndDices.os;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.buildings
{
    public class House
    {
        public static void HouseMenu()
        {
            Console.Title = "Dungeons and Dices - Home";
            Output.WriteLine("<-- Welcome Home -->");
            string[] houseOptions = {"Location -> Shop"};
            foreach (string houseOption in houseOptions)
            {
                Output.WriteLine(houseOption);
            }
            Output.WriteLine("Player's Coins: ¢" + PlayerStats.Coins);
            Output.WriteLine();
            Output.WriteLine("Where would you like to go?");
            string userSelection;
            userSelection = Input.ReadLine();
            switch (userSelection)
            {
                case ("Shop"):
                    Output.Clear();
                    Shop.ShopMenu();
                    break;
                case ("Roll"):
                    Output.Clear();
                    foreach (var item in DiceStats.D6DiceList)
                    {
                        Output.WriteLine(item.Roll().ToString());
                    }
                    break;
                default:
                    Output.Clear();
                    House.HouseMenu();
                    break;
            }
        }
    }
}
