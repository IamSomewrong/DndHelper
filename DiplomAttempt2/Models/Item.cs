using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CostInCopper { get; set; }
        public float Weight { get; set; }
        public ObservableCollection<Spell> Spells { get; set; }
    }
}
