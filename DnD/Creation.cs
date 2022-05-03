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
            //user rolls stats
            AbilityScore abilityScore = Stats();
            //user picks class
            string charclass = Class();
            //user picks a name
            string name = "Placeholder";
            Character character = new(name, abilityScore, charclass);
        }
        public AbilityScore Stats()
        {
            int[] stats;
            Console.WriteLine("Please choose how to allocate stats:\n" +
                "'1' for rolling 4d6 - omit lowest\n" +
                "'2' for standart array");
            do
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        //program rolls stats
                        stats = StatRoller();
                        break;
                    case '2':
                        //program delivers base array
                        stats = new int[] { 15, 14, 13, 12, 10, 8 };
                        break;
                    default://midlertidig
                        break;
                }
            } while (stats[0] == null);
            
            foreach (int i in stats)
            {
                Console.Write($"{i} ");
            }
            //assign scores to each attribute
            int[] stats2 = new int[6];
            //fordeling af stats

            //returnering af stats, nu fordelt
            return new(stats2[0], stats2[1], stats2[2], stats2[3], stats2[4], stats2[5]);
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
        public string Class()
        {
            Console.WriteLine("Choose a class");

            return "";
        }
    }
}
