using DungeonsAndDices.dices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.stats
{
    public static class DiceStats
    {
        public static List<Dice> DiceList = CreateDiceList<Dice>();
        //Later on implment getD6Count for shop shit
        public static List<T> CreateDiceList<T>() where T : Dice
        {
            var list = new List<T>();
            return list;
        }

    }
}