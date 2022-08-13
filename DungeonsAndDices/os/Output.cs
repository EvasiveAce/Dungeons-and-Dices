using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndDices.os
{
    public static class Output
    {
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}