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
        public Origin Origin { get; set; }
        public int MaxHits { get; set; }
        public int Hits { get; set; }
        public int TempHits { get; set; } = 0;
        public Dictionary<Ability, int> Abilities { get; set;}
        public Dictionary<Ability, bool> AbilityProficiencies { get; set; }
        public Dictionary<Ability, bool> Weapons { get; set; }
        public Dictionary<Skill, int> SkillsProficiencies { get; set;}
        public int Initiative { get;} 
        public int ArmorClass { get;}
        public int Speed { get; set; }
        public bool Inspiration { get; set; } = false;
    }
}
