using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    internal class Creation
    {
        public void Start()
        {
            Stats();
            Class();
        }
        public void Stats()
        {
            int[] stats;
            Console.WriteLine("Please choose how to allocate stats:\n" +
                "'1' for rolling 4d6 - omit lowest\n" +
                "'2' for standart array");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    stats = StatRoller();
                    break;
                case '2':
                    stats = new int[] { 15, 14, 13, 12, 10, 8 };
                    break;
                default:
                    stats = new int[] { 15, 14, 13, 12, 10, 8 };
                    break;
            }
            foreach (int i in stats)
            {
                Console.Write($"{i} ");
            }
        }
        public int[] StatRoller()
        {
            Random dice = new();
            int[] stats = new int[6], 
                rolls = new int[4];
            for (int i = 0; i < stats.Length; i++)
            {
                for (int j = 0; j < rolls.Length; j++)
                {
                    rolls[j] = dice.Next(1, 7);
                }
                Array.Sort(rolls);
                Array.Reverse(rolls);
                stats[i] = rolls[0] + rolls[1] + rolls[2];
            }
            Array.Sort(stats);
            Array.Reverse(stats);
            return stats;
        }
        public void Class()
        {

        }
    }
}
