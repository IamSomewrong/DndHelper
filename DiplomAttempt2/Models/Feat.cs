using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Feat
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Trait> Traits { get; set; }
    }
}
