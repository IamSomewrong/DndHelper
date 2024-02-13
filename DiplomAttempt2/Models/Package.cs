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
    }
}
