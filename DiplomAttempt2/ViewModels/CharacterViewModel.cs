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
        public int ConBonus { get => (Character.Abilities[Ability.Constitution] - 10) / 2 ; }
        public int WisBonus { get => (Character.Abilities[Ability.Wisdom] - 10) / 2; }
        public int IntBonus { get => (Character.Abilities[Ability.Intelligence] - 10) / 2; }
        public int ChaBonus { get => (Character.Abilities[Ability.Charisma] - 10) / 2; }
        public int Initiative { get => DexBonus; }
        public int PassivePerception { get => 10 + WisBonus + Character.SkillsProficiencies[Skill.Perception] * MasteryBonus; }
        public int MasteryBonus { get => 2 + (Character.Level - 1) / 4; }
        public int SpellAttack { get => MasteryBonus + WisBonus; }
        public int MeleeAttack { get => MasteryBonus + StrBonus; }
        public int RangeAttack { get => MasteryBonus + DexBonus; }
        public int ArmorClass { get => 10; }
        public int SpellSaveThrow { get => 10 + WisBonus; }
        public int AcrobaticsBonus { get => DexBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Acrobatics]; }
        public int AnimalHandlingBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.AnimalHandling]; }
        public int ArcanaBonus { get => IntBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Arcana]; }
        public int AthleticsBonus { get => StrBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Athletics]; }
        public int DeceptionBonus { get => ChaBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Deception]; }
        public int HistoryBonus { get => IntBonus + MasteryBonus * Character.SkillsProficiencies[Skill.History]; }
        public int InsightBonus { get => IntBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Insight]; }
        public int IntimidationBonus { get => ChaBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Intimidation]; }
        public int InvestigationBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Investigation]; }
        public int MedicineBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Medicine]; }
        public int NatureBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Nature]; }
        public int PerceptionBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Perception]; }
        public int PerformanceBonus { get => ChaBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Performance]; }
        public int PersuasionBonus { get => ChaBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Persuasion]; }
        public int ReligionBonus { get => IntBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Religion]; }
        public int SleightOfHandBonus { get => DexBonus + MasteryBonus * Character.SkillsProficiencies[Skill.SleightOfHand]; }
        public int StealthBonus { get => DexBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Stealth]; }
        public int SurvivalBonus { get => WisBonus + MasteryBonus * Character.SkillsProficiencies[Skill.Survival]; }
        public ICommand IncrementHitsCommand { get; private set; }
        public ICommand DecrementHitsCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public CharacterViewModel(Character character)
        {
            Character = character;
            IncrementHitsCommand = new Command
                (
                    execute: () => ExecuteIncrement(),
                    canExecute: () => CanExecuteIncrement()
                );
            DecrementHitsCommand = new Command
                (
                    execute: () => ExecuteDecrement(),
                    canExecute: () => CanExecuteDecrement()
                );
        }
        private void ExecuteIncrement()
        {
            Character.Hits++;
            OnPropertyChanged();
            ContentManager.SaveCharacters();
            ((Command)IncrementHitsCommand).ChangeCanExecute();
            ((Command)DecrementHitsCommand).ChangeCanExecute();
        }
        private void ExecuteDecrement()
        {
            Character.Hits--;
            OnPropertyChanged();
            ContentManager.SaveCharacters();
            ((Command)IncrementHitsCommand).ChangeCanExecute();
            ((Command)DecrementHitsCommand).ChangeCanExecute();
        }
        private bool CanExecuteDecrement()
        {
            return Character.Hits > 0;
        }
        private bool CanExecuteIncrement()
        {
            return Character.Hits < Character.MaxHits;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
