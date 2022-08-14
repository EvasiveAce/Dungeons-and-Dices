using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.dices
{
    public class D4 : Dice
    {
        //StartPrice
        public static double Price = 1;
        public D4()
        {
            D4.DiceSides = 4;
        }
    }
}
