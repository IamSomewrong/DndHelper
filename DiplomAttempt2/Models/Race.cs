using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public enum Ability
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    public class Race
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Speed { get; set; }
        public ObservableCollection<int> AbilityBonuses { get; set; }
        public ObservableCollection<Subrace> Subraces { get; set; }
        public ObservableCollection<Spell> Spells { get; set; }
        public ObservableCollection<Trait> Traits { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }
        public ObservableCollection<Gear> Gears { get; set; }
    }
}
