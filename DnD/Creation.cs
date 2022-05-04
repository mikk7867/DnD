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
            Character character = new(name, charclass, 1, abilityScore, 0);
            Console.WriteLine($"Name: {character.Name}\n" +
                $"Class: {character.Classes}\n" +
                $"Str: {character.Score.Strength}\n" +
                $"Dex: {character.Score.Dexterity}\n" +
                $"Con: {character.Score.Constitution}\n" +
                $"Int: {character.Score.Intelligence}\n" +
                $"Wis: {character.Score.Wisdom}\n" +
                $"Cha: {character.Score.Charisma}");
            Append(character);
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
                "'1' => Barbarian\n" +
                "'2' => Bard\n" +
                "'3' => Cleric\n" +
                "'4' => Fighter\n" +
                "'5' => Paladin\n" +
                "'6' => Rogue\n" +
                "'7' => Wizard");
            while (true)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return "Barbarian";
                    case '2':
                        return "Bard";
                    case '3':
                        return "Cleric";
                    case '4':
                        return "Fighter";
                    case '5':
                        return "Paladin";
                    case '6':
                        return "Rogue";
                    case '7':
                        return "Wizard";
                    default:
                        Console.WriteLine("fejl");
                        break;
                }
            }
        }
        public string Naming()
        {
            string? name;
            Console.WriteLine("Write the name of your character:");
            while (true)
            {
                name = Console.ReadLine();
                if (name != null && name.All(Char.IsLetter))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("fejl");
                }
            }
        }
        public void Append(Character c)
        {
            string s = $"{c.Name},{c.Classes},{c.Level}," +
                $"{c.Score.Strength},{c.Score.Dexterity},{c.Score.Constitution}," +
                $"{c.Score.Intelligence},{c.Score.Wisdom},{c.Score.Charisma},{c.XP},";
            //Console.WriteLine(s); //test
            File.AppendAllText("characters.txt", s);
        }
        public void View(List<Character> list)
        {
            foreach (Character c in list)
            {
                Console.WriteLine($"Name: {c.Name}\n" +
                    $"Class: {c.Classes} lv {c.Level}\n" +
                    $"Str: {c.Score.Strength}\n" +
                    $"Dex: {c.Score.Dexterity}\n" +
                    $"Con: {c.Score.Constitution}\n" +
                    $"Int: {c.Score.Intelligence}\n" +
                    $"Wis: {c.Score.Wisdom}\n" +
                    $"Cha: {c.Score.Charisma}\n" +
                    $"XP: {c.XP}\n\n");
            }
        }
        public List<Character> Partytime()
        {
            List<Character> list = Reader(), party = new();
            if (list.Count < 4)
            {
                return list;
            }
            int number;
            char input;
            while (true)
            {
                Console.Clear();
                number = 1;
                foreach (Character c in list)
                {
                    Console.WriteLine($"Character nr. {number}\n" +
                        $"Name: {c.Name}\n" +
                        $"Class: {c.Classes} lv {c.Level}\n" +
                        $"Str: {c.Score.Strength}\n" +
                        $"Dex: {c.Score.Dexterity}\n" +
                        $"Con: {c.Score.Constitution}\n" +
                        $"Int: {c.Score.Intelligence}\n" +
                        $"Wis: {c.Score.Wisdom}\n" +
                        $"Cha: {c.Score.Charisma}\n" +
                        $"XP: {c.XP}");
                    number++;
                    if (party.Contains(c))
                    {
                        Console.WriteLine(" - In party -");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Press character number to add them to party\n" +
                    "Press '0' to confirm current party");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input == '0' && party.Count > 3)
                {
                    return party;
                }
                else if (char.IsDigit(input) && int.Parse(input.ToString()) < (list.Count + 1))
                {
                    party.Add(list[int.Parse(input.ToString()) - 1]);
                }
                else
                {
                    Console.WriteLine("fejl");
                }
            }
        }
        public List<Character> Reader()
        {
            string s = File.ReadAllText("characters.txt");
            List<string> lines = s.Split(',').ToList();
            List<int> stats = new();
            List<Character> characters = new();
            Character temp;
            AbilityScore numbers;
            for (int i = 0; i < (lines.Count / 10); i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    stats.Add(int.Parse(lines[(i * 10) + j + 3]));
                }
                numbers = new(stats[0], stats[1], stats[2], stats[3], stats[4], stats[5]);
                temp = new(lines[(i * 10)], lines[(i * 10)+1], int.Parse(lines[(i * 10)+2]), numbers, int.Parse(lines[(i * 10) + 9]));
                characters.Add(temp);
            }
            return characters;
        }
    }
}
