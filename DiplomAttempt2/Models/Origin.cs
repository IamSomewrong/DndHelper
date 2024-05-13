using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public enum Skill
    {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    
    }
    public class Origin
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Skill> Skills { get; set; }
        public ObservableCollection<Gear> GearsForInventory { get; set; }
        public ObservableCollection<Gear> Gears {  get; set; }
        public ObservableCollection<string> Traits { get; set; }

    }
}
