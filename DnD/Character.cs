using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    internal class Character//character object
    {
        public string Name { get; set; }
        //the name of the character
        //public string Race { get; set; } currently unused, possible expansion option
        public string Classes { get; set; }
        //the class of the character
        public int Level { get; set; }//the level of the character
        //class and level could be adapted to fit the DnD rules for multiclassing, possible expansion option
        public AbilityScore Score { get; set; }//the six ability scores of the character
        public int XP { get; set; }//the amount of xp the character has
        //xp could be set up with formula to level up character, possible expansion option
        public Character(string name, string classes, int level, AbilityScore score, int xp)//constructor
        {
            Name = name;
            Classes = classes;
            Level = level;
            Score = score;
            XP = xp;
        }
    }
    internal class AbilityScore//abilityscore object
    {
        //the character has six different ability scores, all of which are functionally equivalent in this part of the code
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public AbilityScore(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)//constructor
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }
    }
}
