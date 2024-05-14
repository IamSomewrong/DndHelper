using DiplomAttempt2.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DiplomAttempt2;

public partial class RacesPage : ContentPage
{
    ObservableCollection<Race> _races;

    public RacesPage(ObservableCollection<Race> races)
    {
        InitializeComponent();
        _races = races;
        FeatsView.ItemsSource = races;
    }

    private async void CreateClicked(object sender, EventArgs e)
    {
        string name = await DisplayPromptAsync("Создание расы", "Введите название:");
        if (!String.IsNullOrWhiteSpace(name))
        {
            Race race = new Race()
            {
                Name = name,
                AbilityBonuses = new ObservableCollection<int>() { 0, 0, 0, 0, 0, 0 },
                Subraces = new ObservableCollection<Subrace>(),
                Spells = new ObservableCollection<Spell>(),
                Traits = new ObservableCollection<Trait>(),
                Weapons = new ObservableCollection<Weapon>(),
                Armors = new ObservableCollection<Armor>(),
                Gears = new ObservableCollection<Gear>(),
            };
            _races.Add(race);
            ContentManager.SavePackages();
        }
    }

    private async void ToRace(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new RacePage(_races[e.ItemIndex]));
    }
}
