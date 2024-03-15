using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public enum GearClass
    {
        Other,
        Projectiles,
        ArcaneFocus,
        HolySymbol,
        DruidicFocus,
        Container,
        GameSet,
        Tools,
        Musical,
        Transport
    }
    public class Gear : Item
    {
        public GearClass GearClass { get; set; }
        public float RigidCapacity { get; set; }
        public float FluidCapacity { get; set; }
        public float TransportSpeed { get; set; }   

    }
}
