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
            string name = Naming();
            Character character = new(name, abilityScore, charclass);
            Console.WriteLine($"Name: {character.Name}\n" +
                $"Class: {character.Classes}\n" +
                $"Str: {character.Score.Strength}\n" +
                $"Dex: {character.Score.Dexterity}\n" +
                $"Con: {character.Score.Constitution}\n" +
                $"Int: {character.Score.Intelligence}\n" +
                $"Wis: {character.Score.Wisdom}\n" +
                $"Cha: {character.Score.Charisma}");
        }
        public AbilityScore Stats()
        {
            int[] stats;
            bool parser;
            Console.WriteLine("Please choose how to allocate stats:\n" +
                "'1' for rolling 4d6 - omit lowest\n" +
                "'2' for standart array");
            do
            {
                stats = Console.ReadKey().KeyChar switch
                {
                    '1' => StatRoller(),//program rolls stats
                    '2' => new int[] { 15, 14, 13, 12, 10, 8 },//program delivers base array
                    _ => new int[1]
                };
            } while (stats.Length != 6);
            //assign scores to each attribute
            int[] stats2 = new int[6];
            List<int> chosen = new();
            int choice;
            //fordeling af stats
            foreach (int i in stats)
            {
                Console.Clear();
                foreach (int j in stats)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine($"\nWhich stat do you want to assign the score {i}?\n" +
                    $"'1' => Str - {stats2[0]}\n" +
                    $"'2' => Dex - {stats2[1]}\n" +
                    $"'3' => Con - {stats2[2]}\n" +
                    $"'4' => Int - {stats2[3]}\n" +
                    $"'5' => Wis - {stats2[4]}\n" +
                    $"'6' => Cha - {stats2[5]}");
                do
                {
                    parser = int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice);
                    if (parser && !chosen.Contains(choice) && choice > 0 && choice < 7)
                    {
                        stats2[choice - 1] = i;
                    }
                    else
                    {
                        Console.WriteLine("fejl");
                    }
                } while (!parser || chosen.Contains(choice) || choice < 1 || choice > 6);
                chosen.Add(choice);
            }
            foreach (int i in stats2)
            {
                Console.Write($"{i} ");
            }
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
            Console.WriteLine("Please choose how to allocate stats:\n" +
                "'1' => Fighter\n" +
                "'2' => Rogue\n" +
                "'3' => Barbarian\n" +
                "'4' => Wizard\n" +
                "'5' => Cleric\n" +
                "'6' => Bard");
            while(true)
            {
                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        return "Fighter";
                    case '2':
                        return "Rogue";
                    case '3':
                        return "Barbarian";
                    case '4':
                        return "Wizard";
                    case '5':
                        return "Cleric";
                    case '6':
                        return "Bard";
                    default:
                        Console.WriteLine("fejl");
                        break;
                }
            }
        }
        public string Naming()
        {
            string name;
            Console.WriteLine("Write the name of your character:");
            while (true)
            {
                name = Console.ReadLine();
                if (name != null)
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("fejl");
                }
            }
        }
    }
}
