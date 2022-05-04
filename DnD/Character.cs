using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    internal class Character
    {
        public string Name { get; set; }
        //public string Race { get; set; }
        public string Classes { get; set; }
        public int Level { get; set; }
        public AbilityScore Score { get; set; }
        public int XP { get; set; }
        public Character(string name, string classes, int level, AbilityScore score, int xp)
        {
            Name = name;
            Classes = classes;
            Level = level;
            Score = score;
            XP = xp;
        }
    }
    internal class AbilityScore
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public AbilityScore(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
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
