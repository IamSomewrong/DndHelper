using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomAttempt2.Models
{
    public enum Dice
    {
        K4,
        K6,
        K8,
        K10,
        K12,
        K20
    }
    public enum WeaponType
    {
        MeleeSimple,
        MeleeMilitary,
        RangedSimple,
        RangedMilitary
    }
    public enum DamageType
    {
        Cutting,
        Chopping,
        Pricking
    }
    public enum WeaponProperty
    {
        Ammunition,         // Оружие требует патроны
        Finesse,            // Оружие использует либо Силу, либо Ловкость для бонуса к атаке
        Heavy,              // Оружие считается тяжелым, им можно использовать, если у вас нет силы
        Light,              // Оружие мало весит и удобно для дополнительной атаки
        Loading,            // Оружие требует одну руку, чтобы перезарядить
        Range,              // Оружие может атаковать на дальней дистанции
        Reach,              // Оружие имеет большую дистанцию атаки
        Special,            // Оружие имеет специальные свойства
        Thrown,             // Оружие можно метнуть в цель
        TwoHanded,          // Оружие требует обеих рук для использования
        Versatile           // Оружие можно использовать одной рукой или двумя
    }
    public class Weapon : Item
    {
        public WeaponType Type { get; set; }
        public Dice Damage { get; set; }
        public DamageType DamageType { get; set; }
        public ObservableCollection<WeaponProperty> Properties { get; set; }
        public Dice VersatileDamage { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }

}
