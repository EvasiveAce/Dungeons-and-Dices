using DungeonsAndDices.buildings;
using DungeonsAndDices.entities;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.os
{
    public class Fight
    {
        Enemy enemy = new Enemy();

        bool playerFirst = false;
        bool enemyAlive = true;

        int playerRoll = 0;
        int enemyRoll = 0;

        public void FightStart()
        {
            EnemySpawn();
            Output.WriteLine();
            Input.ReadLine();
            Output.Clear();
            RollForSpeed();
            Output.Clear();
            while(enemyAlive)
            {
                if(playerFirst)
                {
                    PlayerTurn();
                    DeathCheck();
                    EnemyTurn();
                    DeathCheck();
                }
                else
                {
                    EnemyTurn();
                    DeathCheck();
                    PlayerTurn();
                    DeathCheck();
                }
            }
        }

        public void RollForSpeed()
        {
            Output.WriteLine("Roll for Speed");
            Input.ReadLine();
            Output.WriteLine("Select the dice number");
            foreach (var item in DiceStats.DiceList)
            {
                Output.WriteLine($"{DiceStats.DiceList.IndexOf(item) + 1}. {item.GetName()}");
            }
            var userSelection = Input.ReadLine();
            if (userSelection == null || !int.TryParse(userSelection, out int value))
            {
                Output.WriteLine("Select an appropriate number");
                Input.ReadLine();
                Output.Clear();
                FC.FCMenu();
            }
            else
            {
                playerRoll = DiceStats.DiceList.ElementAt(Convert.ToInt32(userSelection) - 1).Roll();
                Output.Clear();
                Output.WriteLine($"You chose the {DiceStats.DiceList.ElementAt(Convert.ToInt32(userSelection) - 1).GetName()}");
                Output.WriteLine();
                Output.WriteLine($"You rolled a {playerRoll}!");
                Input.ReadLine();
                enemyRoll = enemy.enemyDice.Roll();
                Output.WriteLine($"The opposing {enemy.GetName()} rolled a {enemyRoll}!");
                Input.ReadLine();
                if (playerRoll > enemyRoll)
                {
                    Output.WriteLine($"{playerRoll} > {enemyRoll}");
                    Output.WriteLine("You attack first.");
                    Input.ReadLine();
                    playerFirst = true;
                }
                else if (playerRoll < enemyRoll)
                {
                    Output.WriteLine($"{playerRoll} < {enemyRoll}");
                    Output.WriteLine("You attack second.");
                    Input.ReadLine();
                    playerFirst = false;
                }
                else if (playerRoll == enemyRoll)
                {
                    Output.WriteLine($"{playerRoll} = {enemyRoll}");
                    Output.WriteLine("REROLL!!");
                    Input.ReadLine();
                    Output.Clear();
                    RollForSpeed();
                }
            }
        }

        public void EnemySpawn()
        {
            Output.WriteLine($"A {enemy.GetName()} appeared with {enemy.HP} HP");
        }

        public void PlayerTurn()
        {
            playerRoll = 0;
            Output.WriteLine("<-- YOUR TURN -->");
            Output.WriteLine();
            Output.WriteLine("Press enter to Roll");
            Input.ReadLine();
            int[] tempArray = new int[DiceStats.DiceList.Count];
            int t = 0;
            foreach (var item in DiceStats.DiceList)
            {
                var tempRoll = item.Roll();
                tempArray[t] = tempRoll;
                Output.WriteLine($"{item.GetName()}: {tempArray[t]}");
                playerRoll += tempRoll;
                t++;
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int k = i + 1; k < tempArray.Length; k++)
                {
                    if (tempArray[i] == tempArray[k])
                    {
                        Output.WriteLine("Critical!!");
                        playerRoll += tempArray[i];
                        playerRoll += tempArray[k];
                    }
                }
            }
            Output.WriteLine();
            Output.WriteLine($"The opposing {enemy.GetName()} took {playerRoll}");
            enemy.HP = enemy.HP - playerRoll;
            Output.WriteLine($"Remaining {enemy.GetName()} HP: {enemy.HP}");
            Input.ReadLine();
        }

        public void EnemyTurn()
        {
            enemyRoll = 0;
            Output.WriteLine("<-- ENEMY TURN -->");
            Input.ReadLine();
            enemyRoll = enemy.enemyDice.Roll();
            Output.WriteLine($"The opposing {enemy.GetName()} rolled {enemyRoll}");
            PlayerStats.HP = PlayerStats.HP - enemyRoll;
            Output.WriteLine($"Remaining Player HP: {PlayerStats.HP}");
            Input.ReadLine();
            
        }
        public void DeathCheck()
        {
            if(enemy.HP <= 0)
            {
                enemyAlive = false;
                Output.WriteLine($"You defeated the {enemy.GetName()}.");
                Output.WriteLine($"It dropped ¢{enemy.moneyDrop} while trying to flee from you.");
                Output.WriteLine();
                PlayerStats.Coins += enemy.moneyDrop;
                Output.WriteLine("Player's Coins: ¢" + PlayerStats.Coins);
                Input.ReadLine();
                Output.Clear();
                FC.FCMenu();
            } else if (PlayerStats.HP <= 0)
            {
                Output.WriteLine("You only live once");
                Output.WriteLine();
                Input.ReadLine();
                //add something here
            }
        }
    }
}
