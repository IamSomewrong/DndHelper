using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Character
    {
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public string Name { get; set; }
        public Race Race { get; set; }
        public Class Class { get; set; }
        public int MaxHits { get; set; } = 10;
        public int Hits { get; set; } = 10;
        public int TempHits { get; set; } = 0;
        public Dictionary<Ability, int> AbilitiesProficiencies { get; set;}
        public Dictionary<Ability, bool> Weapons { get; set; }
        public Dictionary<Skill, int> SkillsProficiencies { get; set;}
        public int Initiative { get; set; }
        public int ArmorClass { get; set; }
        public int Speed { get; set; }
        public bool Inspiration { get; set; }
    }
}
