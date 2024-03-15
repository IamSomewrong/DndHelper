using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public enum ArmorType
    {
        Light,
        Medium,
        Heavy,
        Shield
    }
    public class Armor : Item
    {
        public int ArmorClass { get; set; }
        public int MinStrenght {  get; set; }
        public bool Interference { get; set; }
        
    }
}
