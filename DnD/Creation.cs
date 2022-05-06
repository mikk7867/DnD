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
            //character created based on the previous variables/methods
            Character character = new(name, charclass, 1, abilityScore, 0);
            //character is printed in console
            Console.WriteLine($"Name: {character.Name}\n" +
                $"Class: {character.Classes}\n" +
                $"Str: {character.Score.Strength}\n" +
                $"Dex: {character.Score.Dexterity}\n" +
                $"Con: {character.Score.Constitution}\n" +
                $"Int: {character.Score.Intelligence}\n" +
                $"Wis: {character.Score.Wisdom}\n" +
                $"Cha: {character.Score.Charisma}");
            //append method
            Append(character);
        }
        public AbilityScore Stats()//method to gain the ability scores of the character
        {
            //variables
            int choice;
            bool parser;
            int[] stats, 
                stats2 = new int[6];
            List<int> chosen = new();
            //menu
            Console.WriteLine("Please choose how to allocate stats:\n" +
                "'1' for rolling 4d6 - omit lowest\n" +
                "'2' for standart array");
            //choose-one-of-the-right-options-loop
            do
            {
                stats = Console.ReadKey().KeyChar switch
                {
                    '1' => StatRoller(),//program rolls stats (method)
                    '2' => new int[] { 15, 14, 13, 12, 10, 8 },//program delivers base array
                    _ => new int[1]//for functionallity
                };
            } while (stats.Length != 6);//if incorrect input, try again
            //distribution of stats
            foreach (int i in stats)//for each value
            {
                Console.Clear();
                //prints the stats
                foreach (int j in stats)
                {
                    Console.Write($"{j} ");
                }
                //menu
                Console.WriteLine($"\nWhich stat do you want to assign the score {i}?\n" +
                    $"'1' => Str - {stats2[0]}\n" +
                    $"'2' => Dex - {stats2[1]}\n" +
                    $"'3' => Con - {stats2[2]}\n" +
                    $"'4' => Int - {stats2[3]}\n" +
                    $"'5' => Wis - {stats2[4]}\n" +
                    $"'6' => Cha - {stats2[5]}");
                //loop to avoid breaking the character/program
                do
                {
                    parser = int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice);
                    //if key is digit, stat is unused and index is in correct range
                    if (parser && !chosen.Contains(choice) && choice > 0 && choice < 7)
                    {
                        //adds the score to the chosen stat
                        stats2[choice - 1] = i;
                    }
                    else
                    {
                        //error message
                        Console.WriteLine("Incorrect input, try again");
                    }
                } while (!parser || chosen.Contains(choice) || choice < 1 || choice > 6);//if statement is not fulfilled => try again
                //chosen stat is added to the list, to prevent choosing the same stat more than once
                chosen.Add(choice);
            }
            //prints the stats in the chosen order
            foreach (int i in stats2)
            {
                Console.Write($"{i} ");
            }
            //returns stats, with chosen distribution
            return new(stats2[0], stats2[1], stats2[2], stats2[3], stats2[4], stats2[5]);
        }
        public int[] StatRoller()//simulates the DnD rules for rolling stats
        {
            //variables
            Random dice = new();
            int[] stats = new int[6],
                rolls = new int[4];
            //once for each stat (six times, not specified to each stat)
            for (int i = 0; i < stats.Length; i++)
            {
                //rolls 4d6
                for (int j = 0; j < rolls.Length; j++)
                {
                    //d6 roll added to array of rolls
                    rolls[j] = dice.Next(1, 7);
                }
                //array of rolls sorted decending
                Array.Sort(rolls);
                Array.Reverse(rolls);
                //score = sum of three highest rolls (4d6, omit lowest)
                stats[i] = rolls[0] + rolls[1] + rolls[2];
            }
            //array of scores sorted decending
            Array.Sort(stats);
            Array.Reverse(stats);
            //array of scores returned
            return stats;
        }
        public string Class()//detirmines the class of the character
        {
            //menu
            Console.WriteLine("Choose a class:\n" +
                "'1' => Barbarian\n" +
                "'2' => Bard\n" +
                "'3' => Cleric\n" +
                "'4' => Fighter\n" +
                "'5' => Paladin\n" +
                "'6' => Rogue\n" +
                "'7' => Wizard");
            //loops until a value is returned (returning ends the method)
            while (true)
            {
                //switch based on key press
                switch (Console.ReadKey().KeyChar)
                {
                    //returns class as string based on input, as told in menu
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
                        //error message
                        Console.WriteLine("Incorrect input, try again");
                        break;
                }
            }
            //more classes exist in DnD, possible expansion option
        }
        public string Naming()//the name of the character
        {
            //variable(s?)
            string? name;
            //menu (short)
            Console.WriteLine("Write the name of your character:");
            //loops until a value is returned (returning ends the method)
            while (true)
            {
                //string name = input, nullable to prevent crashing is input is empty
                name = Console.ReadLine();
                //if string name is not null, and is only letters
                if (name != null && name.All(Char.IsLetter))
                {
                    //chosen name is returned as written
                    return name;
                }
                else
                {
                    //error message
                    Console.WriteLine("Error, try again");
                }
            }
        }
        public void Append(Character c)//method to add character to file.txt
        {
            //variable => layout designed to be easily deciphered, see reader method
            string s = $"{c.Name},{c.Classes},{c.Level}," +
                $"{c.Score.Strength},{c.Score.Dexterity},{c.Score.Constitution}," +
                $"{c.Score.Intelligence},{c.Score.Wisdom},{c.Score.Charisma},{c.XP},";
            //string appended to the end of text file
            File.AppendAllText("characters.txt", s);
        }
        public void View(List<Character> list)//prints out a list of characters
        {
            //for each character...
            foreach (Character c in list)
            {
                //...prints the information on that character
                Console.WriteLine($"Name: {c.Name}\n" +
                    $"Class: {c.Classes} lv {c.Level}\n" +
                    $"Str: {c.Score.Strength}\n" +
                    $"Dex: {c.Score.Dexterity}\n" +
                    $"Con: {c.Score.Constitution}\n" +
                    $"Int: {c.Score.Intelligence}\n" +
                    $"Wis: {c.Score.Wisdom}\n" +
                    $"Cha: {c.Score.Charisma}\n" +
                    $"XP: {c.XP}\n");
            }
        }
        public List<Character> Partytime()//sets up and return a character list aka party
        {
            //variables
            int page = 0;
            string input;
            Character c;
            List<Character> list = Reader(), party = new();
            //if list contains 4 or fewer characters...
            if (list.Count < 5)
            {
                //...all are added to party and returned
                return list;
            }
            //loops until a value is returned (returning ends the method)
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Page {page + 1}\n");
                for (int i = 0; i < 3; i++)
                {
                    if ((page * 3) + i < list.Count)
                    {
                        //character is set based on page number and number on page...
                        c = list[(page * 3) + i];
                        //...and the information is then printed
                        Console.WriteLine($"Character nr. {i + 1}\n" +
                            $"Name: {c.Name}\n" +
                            $"Class: {c.Classes} lv {c.Level}\n" +
                            $"Str: {c.Score.Strength}\n" +
                            $"Dex: {c.Score.Dexterity}\n" +
                            $"Con: {c.Score.Constitution}\n" +
                            $"Int: {c.Score.Intelligence}\n" +
                            $"Wis: {c.Score.Wisdom}\n" +
                            $"Cha: {c.Score.Charisma}\n" +
                            $"XP: {c.XP}");
                        //if the character is already in the party...
                        if (party.Contains(c))
                        {
                            //...it is displayed here
                            Console.WriteLine(" - In party -");
                        }
                        Console.WriteLine();
                    }
                }
                //menu
                Console.WriteLine("Press character number to add them to party\n" +
                    "Press '0' to confirm current party (min 4 members)\n" +
                    "Press 'd' to go to next page\n" +
                    "Press 'a' to go to previous page");
                //input char => string => tolower
                input = Console.ReadKey().KeyChar.ToString().ToLower();
                Console.WriteLine();
                //if the input is '0' and the party is big enough
                if (input == "0" && party.Count > 3)
                {
                    //list of characters is returned
                    return party;
                }
                //if the user chose next page and it is possible to create a next page (number of characters)
                else if (input == "d" && (page + 1) * 3 < list.Count)
                {
                    page++;
                }
                //if the user chose the previous page and the current page number is more than 1
                else if (input == "a" && page > 0)
                {
                    page--;
                }
                //if the user chose a character to add to their party (fulfilling the conditions)
                else if (int.TryParse(input, out int i) && i < (list.Count + 1) && input != "0")
                {
                    //the chosen character is added to the party/list
                    party.Add(list[(page * 3) + i - 1]);
                }
                else
                {
                    //error message
                    Console.WriteLine("Error, try again");
                    Console.ReadKey();
                }
            }
        }
        public List<Character> Reader()//returns list of characters read from text file
        {
            //string = text from file
            string s = File.ReadAllText("characters.txt");
            //text split by commas
            List<string> lines = s.Split(',').ToList();
            //other variables
            List<int> stats = new();
            List<Character> characters = new();
            Character temp;
            AbilityScore numbers;
            //for each character (10 values per character, 10 * nr-of-values)
            for (int i = 0; i < (lines.Count / 10); i++)
            {
                //for the ability scores, because they need to be added to the character as an abilityscore object
                for (int j = 0; j < 6; j++)
                {
                    //converts each stat to int and adds it to an int array
                    stats.Add(int.Parse(lines[(i * 10) + j + 3]));
                }
                //assigns abilityscore object with values from int array
                numbers = new(stats[0], stats[1], stats[2], stats[3], stats[4], stats[5]);
                //assigns character object with values from string + abilityscore object
                temp = new(lines[(i * 10)], lines[(i * 10) + 1], int.Parse(lines[(i * 10) + 2]), numbers, int.Parse(lines[(i * 10) + 9]));
                //adds character to list of characters
                characters.Add(temp);
            }
            //returns list of characters
            return characters;
        }
    }
}
