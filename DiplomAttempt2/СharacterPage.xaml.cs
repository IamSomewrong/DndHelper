using DiplomAttempt2.Models;
using DiplomAttempt2.ViewModels;


namespace DiplomAttempt2;

public partial class СharacterPage : ContentPage
{
	CharacterViewModel _viewModel;
	public СharacterPage(Character character)
	{
		_viewModel = new CharacterViewModel(character);
		BindingContext = _viewModel;
        InitializeComponent();
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
            DisplayAlert("Бросок атаки заклинанием", result.ToString() + " - критический провал!", "Окей");
        }
        else if (result == 20)
        {
            DisplayAlert("Бросок атаки заклинанием", result.ToString() + " - критическая удача!", "Окей");
        }
        else
        {
            if ((StackLayout)sender == StrengthLayout)
            {
                result += _viewModel.StrBonus + (_viewModel.Character.AbilityProficiencies[Ability.Strength]?2:0);
                DisplayAlert("Бросок проверки силы", result.ToString(), "Окей");
            }
            if ((StackLayout)sender == DexterityLayout)
            {
                result += _viewModel.DexBonus + (_viewModel.Character.AbilityProficiencies[Ability.Dexterity] ? 2 : 0);
                DisplayAlert("Бросок проверки ловкости", result.ToString(), "Окей");
            }
            if ((StackLayout)sender == ConstitutionLayout)
            {
                result += _viewModel.ConBonus + (_viewModel.Character.AbilityProficiencies[Ability.Constitution] ? 2 : 0);
                DisplayAlert("Бросок проверки телосложения", result.ToString(), "Окей");
            }
            if ((StackLayout)sender == WisdomLayout)
            {
                result += _viewModel.WisBonus + (_viewModel.Character.AbilityProficiencies[Ability.Wisdom] ? 2 : 0);
                DisplayAlert("Бросок проверки мудрости", result.ToString(), "Окей");
            }
            if ((StackLayout)sender == IntelligenceLayout)
            {
                result += _viewModel.IntBonus + (_viewModel.Character.AbilityProficiencies[Ability.Intelligence] ? 2 : 0);
                DisplayAlert("Бросок проверки интеллекта", result.ToString(), "Окей");
            }
            if ((StackLayout)sender == CharismaLayout)
            {
                result += _viewModel.ChaBonus + (_viewModel.Character.AbilityProficiencies[Ability.Charisma] ? 2 : 0);
                DisplayAlert("Бросок проверки харизмы", result.ToString(), "Окей");
            }
        }
        
    }
}