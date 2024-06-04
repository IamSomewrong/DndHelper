using DiplomAttempt2.Models;
using DiplomAttempt2.ViewModels;


namespace DiplomAttempt2;

public partial class CharacterPage : ContentPage, ICharacterPage
{
	CharacterViewModel _viewModel;

    public Character character { get; set; }

    public CharacterPage()
	{
        InitializeComponent();
    }

    public void Initialize()
    {
        _viewModel = new CharacterViewModel(character);
        BindingContext = _viewModel;
        Title = _viewModel.Character.Name;
    }
    

    private void DexterityAttackTapped(object sender, TappedEventArgs e)
    {
        int result = Random.Shared.Next(1, 21);
        if(result == 1)
        {
            DisplayAlert("Бросок атаки ловкостью", result.ToString() + " - критический провал!", "Окей");
        }
        else if(result == 20) 
        {
            DisplayAlert("Бросок атаки ловкостью", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        {
            result += _viewModel.RangeAttack;
		    DisplayAlert("Бросок атаки ловкостью", result.ToString(), "Окей");
        }
        
    }

    private void StrengthAttackTapped(object sender, TappedEventArgs e)
    {
        int result = Random.Shared.Next(1, 21);
        if (result == 1)
        {
            DisplayAlert("Бросок атаки силой", result.ToString() + " - критический провал!", "Окей");
        }
        else if (result == 20)
        {
            DisplayAlert("Бросок атаки силой", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        {
            result += _viewModel.MeleeAttack;
            DisplayAlert("Бросок атаки силой", result.ToString(), "Окей");
        }
    }

    private void SpellAttackTapped(object sender, TappedEventArgs e)
    {
        int result = Random.Shared.Next(1, 21);
        if (result == 1)
        {
            DisplayAlert("Бросок атаки заклинанием", result.ToString() + " - критический провал!", "Окей");
        }
        else if (result == 20)
        {
            DisplayAlert("Бросок атаки заклинанием", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        {
            result += _viewModel.SpellAttack;
            DisplayAlert("Бросок атаки заклинанием", result.ToString(), "Окей");
        }
    }

    private void AbilityCheck(object sender, TappedEventArgs e)
    {
        int result = Random.Shared.Next(1, 21);
        if (result == 1)
        {
            DisplayAlert("Бросок проверки характеристики", result.ToString() + " - критический провал!", "Окей");
        }
        else if (result == 20)
        {
            DisplayAlert("Бросок проверки характеристики", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        {
            StackLayout control = (StackLayout)sender;

            Dictionary<StackLayout, Ability> controlToAbility = new Dictionary<StackLayout, Ability>()
            {
                { StrengthLayout, Ability.Strength},
                { DexterityLayout, Ability.Dexterity},
                { ConstitutionLayout, Ability.Constitution},
                { WisdomLayout, Ability.Wisdom},
                { IntelligenceLayout, Ability.Intelligence},
                { CharismaLayout, Ability.Charisma}
            };
            Dictionary<StackLayout, int> controlToAbilityBonus = new Dictionary<StackLayout, int>()
            {
                { StrengthLayout, _viewModel.StrBonus},
                { DexterityLayout, _viewModel.DexBonus},
                { ConstitutionLayout, _viewModel.ConBonus},
                { WisdomLayout, _viewModel.WisBonus},
                { IntelligenceLayout, _viewModel.IntBonus},
                { CharismaLayout, _viewModel.ChaBonus}
            };

            int masteryBonus = _viewModel.Character.AbilityProficiencies[controlToAbility[control]] ? _viewModel.MasteryBonus : 0;
            int finalResult = result + controlToAbilityBonus[control] + masteryBonus;
            string outp = result.ToString() + " + " + controlToAbilityBonus[control].ToString() +
                " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
            DisplayAlert("Бросок проверки характеристики " + controlToAbility[control].ToString(), outp, "Окей");
        }
        
    }

    private void SkillCheck(object sender, TappedEventArgs e)
    {
        int result = Random.Shared.Next(1, 21);
        if (result == 1)
        {
            DisplayAlert("Бросок проверки способности", result.ToString() + " - критический провал!", "Окей");
        }
        else if (result == 20)
        {
            DisplayAlert("Бросок проверки способности", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        { 
            FlexLayout control = (FlexLayout) sender;

            Dictionary<FlexLayout, Skill> controlToSkill = new Dictionary<FlexLayout, Skill>()
            {
                { AcrobaticsLayout, Skill.Acrobatics},
                { AthleticsLayout, Skill.Athletics},
                { ArcanaLayout, Skill.Arcana},
                { AnimalHandlingLayout, Skill.AnimalHandling},
                { DeceptionLayout, Skill.Deception},
                { HistoryLayout, Skill.History},
                { InsightLayout, Skill.Insight},
                { IntimidationLayout, Skill.Intimidation},
                { InvestigationLayout, Skill.Investigation},
                { MedicineLayout, Skill.Medicine},
                { NatureLayout, Skill.Nature },
                { PerceptionLayout, Skill.Perception},
                { PerformanceLayout, Skill.Performance},
                { PersuasionLayout, Skill.Persuasion},
                { ReligionLayout, Skill.Religion},
                { SleightOfHandLayout, Skill.SleightOfHand },
                { StealthLayout, Skill.Stealth },
                { SurvivalLayout, Skill.Survival }
            };
            Dictionary<FlexLayout, int> controlToAbilityBonus = new Dictionary<FlexLayout, int>()
            {
                {AcrobaticsLayout, _viewModel.DexBonus },
                { AthleticsLayout, _viewModel.StrBonus},
                { ArcanaLayout, _viewModel.IntBonus},
                { AnimalHandlingLayout, _viewModel.WisBonus},
                { DeceptionLayout, _viewModel.ChaBonus},
                { HistoryLayout, _viewModel.IntBonus},
                { InsightLayout, _viewModel.IntBonus},
                { IntimidationLayout, _viewModel.ChaBonus},
                { InvestigationLayout, _viewModel.WisBonus},
                { MedicineLayout, _viewModel.WisBonus},
                { NatureLayout, _viewModel.IntBonus },
                { PerceptionLayout, _viewModel.WisBonus},
                { PerformanceLayout, _viewModel.ChaBonus},
                { PersuasionLayout, _viewModel.WisBonus},
                { ReligionLayout, _viewModel.IntBonus},
                { SleightOfHandLayout, _viewModel.DexBonus },
                { StealthLayout, _viewModel.DexBonus },
                { SurvivalLayout, _viewModel.WisBonus }
            };

            int masteryBonus = _viewModel.Character.SkillsProficiencies[controlToSkill[control]] * _viewModel.MasteryBonus;
            int finalResult = result + controlToAbilityBonus[control] + masteryBonus;
            string outp = result.ToString() + " + " + controlToAbilityBonus[control].ToString() +
                " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
            DisplayAlert("Бросок проверки способности " + controlToSkill[control].ToString(), outp, "Окей");
        }
    }
}