using DungeonsAndDices.dices;
using DungeonsAndDices.os;
using DungeonsAndDices.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.entities
{ 
    public class Enemy
    {
        public int HP { get; set; }

        public static string[] Race = new string[] {"Ghoul", "Bear", "Mouse", "Wrinkler"};

        public static string[] Attributes = new string[] { "Nimble", "Cold", "Flaming", "Steadfast", "Necromancer" };

        public string EnemyRace { get; set; }

        public string EnemyAttribute { get; set; }

        public Dice enemyDice { get; set; }
        public int moneyDrop { get; set; }

        public Enemy()
        {
            enemyDice = new D4();
            Random random = new Random();
            EnemyRace = Race[random.Next(Race.Length)];
            EnemyAttribute = Attributes[random.Next(Attributes.Length)];
            HP = random.Next(10, 20);
            moneyDrop = enemyDice.Roll();
        }

        public string GetHP()
        {
            return HP.ToString();
        }

        public string GetName()
        {
            string name = $"{EnemyAttribute} {EnemyRace}";
            return name;
        }

    }
}