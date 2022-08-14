using DungeonsAndDices.entities;
using DungeonsAndDices.os;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.buildings
{
    public class FC
    {
        public static void FCMenu()
        {
            Console.Title = "Dungeons and Dices - Fight Club";
            Output.WriteLine("<-- Fight Club -->");


            string[] fightOptions = { "Location -> House", "Location -> Shop", "Action -> Wager", "Action -> FIGHT"};
            foreach (string fightOption in fightOptions)
            {
                Output.WriteLine(fightOption);
            }
            Output.WriteLine();
            Output.WriteLine("Player's HP: " + PlayerStats.HP);
            Output.WriteLine();
            Output.WriteLine("Fight or get out");
            string userSelection;
            userSelection = Input.ReadLine();

            switch(userSelection)
            {
                case ("House"):
                    Output.Clear();
                    House.HouseMenu();
                    break;
                case ("Shop"):
                    Output.Clear();
                    Shop.ShopMenu();
                    break;
                case ("Wager"):
                    break;
                case ("Fight"):
                    Output.Clear();
                    Fight fight = new Fight();
                    fight.FightStart();
                    break;
            }
        }
    }
}
