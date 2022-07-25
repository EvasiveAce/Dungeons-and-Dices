using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDices.dices
{
    public class D6 : Dice
    {
        //StartPrice
        public static double Price = 1;
        public D6()
        {
            D6.DiceSides = 6;
        }
    }
}
