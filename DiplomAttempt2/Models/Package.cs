using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Package
    {
        public string Name { get; set; }
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Feat> Feats { get; set; }
        public ObservableCollection<Origin> Origins{ get; set; }
        public ObservableCollection<Enemy> Enemies { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Spell> Spells { get; set; }
    }
}
