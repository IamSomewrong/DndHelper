using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    internal class Feat
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<(string, string)> Traits { get; set; }
    }
}
