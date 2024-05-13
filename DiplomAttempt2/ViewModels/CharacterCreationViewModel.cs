﻿using DiplomAttempt2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiplomAttempt2.ViewModels
{
    public class CharacterCreationViewModel : INotifyPropertyChanged
    {
        public int Strength { get; set; } = 8;
        public int Dexterity { get; set; } = 8;
        public int Constitution { get; set; } = 8;
        public int Wisdom { get; set; } = 8;
        public int Intelligence { get; set; } = 8;
        public int Charisma { get; set; } = 8;
        public int Points { get; set; } = 27;
        public int SkillsCount { get; set; }
        public Dictionary<Skill, bool> SkillsChecked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand PlusCommand { get; private set; }
        public ICommand MinusCommand { get; private set; }
        public ICommand CheckSkillCommand { get; private set; }
        public CharacterCreationViewModel() 
        {
            PlusCommand = new Command<string>
                (
                    execute: (string arg) =>
                    {
                        switch (arg)
                        {
                            case "str":
                                if(Strength < 15)
                                {
                                    Strength++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Strength"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "dex":
                                if (Dexterity < 15)
                                {
                                    Dexterity++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Dexterity"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "con":
                                if (Constitution < 15)
                                {
                                    Constitution++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Constitution"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "wis":
                                if (Wisdom < 15)
                                {
                                    Wisdom++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Wisdom"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "int":
                                if (Intelligence < 15)
                                {
                                    Intelligence++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Intelligence"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "cha":
                                if (Charisma < 15)
                                {
                                    Charisma++; Points--;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Charisma"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                        }
                        ((Command)PlusCommand).ChangeCanExecute();
                        ((Command)MinusCommand).ChangeCanExecute();

                    },
                    canExecute: (string arg) =>
                    {
                        return Points > 0;
                    }
                );

            MinusCommand = new Command<string>
                (
                    execute: (string arg) =>
                    {
                        switch (arg)
                        {
                            case "str":
                                if (Strength > 8)
                                {
                                    Strength--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Strength"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "dex":
                                if (Dexterity > 8)
                                {
                                    Dexterity--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Dexterity"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "con":
                                if (Constitution > 8)
                                {
                                    Constitution--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Constitution"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "wis":
                                if (Wisdom > 8)
                                {
                                    Wisdom--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Wisdom"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "int":
                                if (Intelligence > 8)
                                {
                                    Intelligence--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Intelligence"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                            case "cha":
                                if (Charisma > 8)
                                {
                                    Charisma--; Points++;
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Charisma"));
                                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                                };
                                break;
                        }
                        ((Command)PlusCommand).ChangeCanExecute();
                        ((Command)MinusCommand).ChangeCanExecute();

                    },
                    canExecute: (string arg) =>
                    {
                        return Points < 27;
                    }
                );
            CheckSkillCommand = new Command<Skill>
                (
                    execute: (Skill skill) => 
                    {
                        if (SkillsChecked[skill])
                        {
                            SkillsCount++;
                            SkillsChecked[skill] = false;
                        }
                        else
                        {
                            SkillsCount--;
                            SkillsChecked[skill] = true;
                        }
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SkillsCount"));
                        ((Command)CheckSkillCommand).ChangeCanExecute();
                    },
                    canExecute: (Skill skill) =>
                    {
                        return (SkillsCount > 0) || (SkillsCount == 0 && SkillsChecked[skill]);
                    }

                );
        }
    }
}
