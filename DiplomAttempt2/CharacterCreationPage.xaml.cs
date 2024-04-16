using DiplomAttempt2.Models;
using System.Collections.ObjectModel;


namespace DiplomAttempt2;

public partial class CharacterCreationPage : ContentPage
{
	ObservableCollection<Character> _characters;
	List<Race> _races = new List<Race>();
	public CharacterCreationPage(IEnumerable<Character> characters)
    {
		InitializeComponent();
		_characters = (ObservableCollection<Character>)characters;
		foreach(Package package in App.Packages)
		{
			_races = _races.Concat(package.Races).ToList();
		}
		List<string> raceNames = (from r in _races select r.Name).ToList<string>();
		RacePicker.ItemsSource = raceNames;
	}

	public async void EndCreation(object sender, EventArgs e)
	{
		_characters.Add(new Character() {Name = NameEntry.Text, Race = _races[RacePicker.SelectedIndex] });
		App.SaveCharacters();
        await Navigation.PopAsync();
	}
}