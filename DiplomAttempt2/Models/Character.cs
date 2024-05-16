using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Character : INotifyPropertyChanged
    {
        private int hits;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public string Name { get; set; }
        public Race Race { get; set; }
        public Class Class { get; set; }
        public Origin Origin { get; set; }
        public int MaxHits { get; set; }
        public int Hits { get => hits; set { hits = value; OnPropertyChanged(); } }
        public int TempHits { get; set; } = 0;
        public Dictionary<Ability, int> Abilities { get; set;}
        public Dictionary<Ability, bool> AbilityProficiencies { get; set; }
        public Dictionary<Skill, int> SkillsProficiencies { get; set;}
        
        public int Speed { get; set; }
        public bool Inspiration { get; set; } = false;
        public ObservableCollection<Item> Inventory { get; set; }
        public Armor Armor { get; set; }
        public Weapon Hand1 { get; set; }
        public Weapon Hand2 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
