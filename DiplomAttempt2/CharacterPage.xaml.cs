using DiplomAttempt2.Models;
using DiplomAttempt2.ViewModels;


namespace DiplomAttempt2;

public partial class CharacterPage : ContentPage
{
	CharacterViewModel _viewModel;
	public CharacterPage(Character character)
	{
		_viewModel = new CharacterViewModel(character);
		BindingContext = _viewModel;
        InitializeComponent();
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
            if ((StackLayout)sender == StrengthLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Strength] ? 2 : 0;
                int finalResult = result + _viewModel.StrBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.StrBonus.ToString() + 
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки силы", outp, "Окей");
            }
            if ((StackLayout)sender == DexterityLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Dexterity] ? 2 : 0;
                int finalResult = result + _viewModel.DexBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.DexBonus.ToString() +
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки ловкости", outp, "Окей");
            }
            if ((StackLayout)sender == ConstitutionLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Constitution] ? 2 : 0;
                int finalResult = result + _viewModel.ConBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.ConBonus.ToString() +
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки телосложения", outp, "Окей");
            }
            if ((StackLayout)sender == WisdomLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Wisdom] ? 2 : 0;
                int finalResult = result + _viewModel.WisBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.WisBonus.ToString() +
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки мудрости", outp, "Окей");
            }
            if ((StackLayout)sender == IntelligenceLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Intelligence] ? 2 : 0;
                int finalResult = result + _viewModel.IntBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.IntBonus.ToString() +
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки интеллекта", outp, "Окей");
            }
            if ((StackLayout)sender == CharismaLayout)
            {
                int masteryBonus = _viewModel.Character.AbilityProficiencies[Ability.Charisma] ? 2 : 0;
                int finalResult = result + _viewModel.ChaBonus + masteryBonus;
                string outp = result.ToString() + " + " + _viewModel.ChaBonus.ToString() +
                    " + " + masteryBonus.ToString() + " = " + finalResult.ToString();
                DisplayAlert("Бросок проверки харизмы", outp, "Окей");
            }
        }
        
    }
}