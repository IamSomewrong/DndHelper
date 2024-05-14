using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiplomAttempt2.Models;


namespace DiplomAttempt2.ViewModels
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        public Character Character { get; set; }
        public int Strength { get => Character.Abilities[Ability.Strength]; }
        public int Dexterity { get => Character.Abilities[Ability.Dexterity]; }
        public int Constitution { get => Character.Abilities[Ability.Constitution]; }
        public int Wisdom { get => Character.Abilities[Ability.Wisdom]; }
        public int Intelligence { get => Character.Abilities[Ability.Intelligence]; }
        public int Charisma { get => Character.Abilities[Ability.Charisma]; }
        public int StrBonus { get => (Character.Abilities[Ability.Strength] - 10) / 2; }
        public int DexBonus { get => (Character.Abilities[Ability.Dexterity] - 10) / 2; }
        public int ConBonus { get => (Character.Abilities[Ability.Constitution] - 10) / 2; }
        public int WisBonus { get => (Character.Abilities[Ability.Wisdom] - 10) / 2; }
        public int IntBonus { get => (Character.Abilities[Ability.Intelligence] - 10) / 2; }
        public int ChaBonus { get => (Character.Abilities[Ability.Charisma] - 10) / 2; }
        public int Initiative { get => DexBonus; }
        public int PassivePerception
        {
            get => 10 + WisBonus + Character.SkillsProficiencies[Skill.Perception] * 2;
        }
        public int MasteryBonus { get => 2 + (Character.Level - 1) / 4; }
        public int SpellAttack { get => MasteryBonus + WisBonus; }
        public int MeleeAttack { get => MasteryBonus + StrBonus; }
        public int RangeAttack { get => MasteryBonus + DexBonus; }
        public int ArmorClass { get => 10; }
        public int SpellSaveThrow { get => 10 + WisBonus; }
        public ICommand IncrementHitsCommand { get; private set; }
        public ICommand DecrementHitsCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public CharacterViewModel(Character character)
        {
            Character = character;
            IncrementHitsCommand = new Command
                (
                    execute: () =>
                    {
                        Character.Hits++;
                        OnPropertyChanged();
                        App.SaveCharacters();
                        ((Command)IncrementHitsCommand).ChangeCanExecute();
                        ((Command)DecrementHitsCommand).ChangeCanExecute();
                    },
                    canExecute: () =>
                    {
                        return Character.Hits < Character.MaxHits;
                    }
                );
            DecrementHitsCommand = new Command
                (
                    execute: () =>
                    {
                        Character.Hits--;
                        OnPropertyChanged();
                        App.SaveCharacters();
                        ((Command)IncrementHitsCommand).ChangeCanExecute();
                        ((Command)DecrementHitsCommand).ChangeCanExecute();
                    },
                    canExecute: () =>
                    {
                        return Character.Hits > 0;
                    }
                );
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
