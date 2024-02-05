using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public class Character
    {
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int MaxHits { get; set; } = 10;
        public int Hits { get; set; } = 10;
        public int TempHits { get; set; } = 0;
    }
}
