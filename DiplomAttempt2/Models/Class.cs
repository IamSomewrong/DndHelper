using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    
    public class Class
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Ability> SavingThrows { get; set; }
        public Dice HitDice { get; set; }
        public int SkillsCount { get; set; }
        public ObservableCollection<Skill> Skills { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Gear> Tools { get; set; }
        public ObservableCollection<ClassFeature> ClassFeatures { get; set; }
        public ObservableCollection<Subclass> Subclasses { get; set; }

    }
}